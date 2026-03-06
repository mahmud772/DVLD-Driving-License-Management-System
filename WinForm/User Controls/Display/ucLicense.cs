using Common;
using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm.Forms;
using DVLDWinForm.UIHelper;
using DVLDWinForm.UIHelper_Manger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDWinForm.User_Controls
{
    public partial class ucLicense : UserControl , IUserControl
    {

        private clsLicenseCardInfo_DTO _LicenseInfo { get; set; }
        public clsLicenseCardInfo_DTO LicenseInfo
        {
            get => _LicenseInfo;
            set
            {
                _LicenseInfo = value;
                LoadLicenseInfo(value);
            }
        }
        public IDTO Info { get => _LicenseInfo; set => LicenseInfo = value as clsLicenseCardInfo_DTO; }
        clsCRUDController _CRUDController;
        ContextMenuStrip _sharedContextMenu;
        private const int _step = 10; // مقدار التغيير في كل خطوة (سرعة الحركة)

        private const int _collapsedHeight = 220;
        private const int _expandedHeight = 410;

        clsControlAnimateHeight Animate;
        
        public ucLicense()
        {
            InitializeComponent();
            Animate = new clsControlAnimateHeight(this, _expandedHeight, _collapsedHeight, _step);
            CollapseInstantly();
        }
        public ucLicense(clsCRUDController CRUDController , ContextMenuStrip SharedContextMenu)
        {
            InitializeComponent();
            Animate = new clsControlAnimateHeight(this, _expandedHeight, _collapsedHeight, _step);
            CollapseInstantly();
            _CRUDController = CRUDController;
            _sharedContextMenu = SharedContextMenu;
        }
        private void LoadLicenseInfo(clsLicenseCardInfo_DTO LicenseInfo)
        {
            
            if (LicenseInfo == null)
            {
                MessageBox.Show("This is License Is Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            lbName.Text = LicenseInfo.FullName;
            lbNationalNo.Text = LicenseInfo.NationalNo;
            lbLicenseID.Text = Convert.ToString(LicenseInfo.LicenseID);
            lbIssueReason.Text = clsUtil.TextSepatation(LicenseInfo.IssueReason.ToString());
            lbDateOfBirth.Text = LicenseInfo.DateOfBirth.ToString("yyyy/MM/dd");
            lbIssueDate.Text = LicenseInfo.IssueDate.ToString("yyyy/MM/dd");
            lbExpiration.Text = LicenseInfo.ExpirationDate.ToString("yyyy/MM/dd");
            lbLicenseClass.Text = clsUtil.TextSepatation(LicenseInfo.LicenseClass.ToString());
            lbNotes.Text = LicenseInfo.Notes;
            clsUIHelper.LoadImage(LicenseInfo.ImagePath, LicenseInfo.Gendor , pbImage);
            pbIsActive.Image = (LicenseInfo.IsActive) ?
                             Properties.Resources.Active : Properties.Resources.NotActive;
            clsUIHelper.FitText(lbName , 8.0f);
        }

        private void _LoadDesign()
        {
            clsUIHelper.MakePictureBoxCircular(pbImage);
            clsUIHelper.CornerRadius(this, 25);
            clsUIHelper.CornerRadius(pnlMoreInfo, 25);
            clsUIHelper.CornerRadius(pnlNotes, 5);
            clsUIHelper.CornerRadius(pbIsActive, 5);
            if (_sharedContextMenu == null || _CRUDController == null)
                btnUpdate_Delete.Visible = false;
        }

        public void CollapseInstantly()
        {
            Animate.OnCollapse -= _Collapse;
            Animate.OnCollapse += _Collapse;
            Animate.OnExpand -= _Expand;
            Animate.QuickCollapse();
            clsUIHelper.CornerRadius(this, 15);
        }

        private void btnShowMore_Less_Click(object sender, EventArgs e)
        {
            Animate.OnCollapse -= _Collapse;
            Animate.OnExpand -= _Expand;
            if (Animate.Status == clsControlAnimateHeight.enStatus.Closed)
            {
                Animate.OnExpand += _Expand;
                Animate.Expand();
            }
            else
            {
                Animate.OnCollapse += _Collapse;
                Animate.Collapse();
            }

        }
        private void _Expand()
        {
            pnlMoreInfo.Visible = true;
            btnShowMore_Less.Text = "<<";

        }
        private void _Collapse()
        {
            pnlMoreInfo.Visible = false;
            btnShowMore_Less.Text = ">>";
        }
        

        private void pbImage_Paint(object sender, PaintEventArgs e)
        {
            clsUIHelper.MakeFramePictureBox(sender, e);
        }

        private void ucLicense_Load(object sender, EventArgs e)
        {
            _LoadDesign();
        }

        private void btnUpdate_Delete_Click(object sender, EventArgs e)
        {
            _CRUDController?.DTO = this.LicenseInfo;
            _sharedContextMenu?.Show(btnUpdate_Delete, new Point(0, btnUpdate_Delete.Height));
        }
    }
}
    
