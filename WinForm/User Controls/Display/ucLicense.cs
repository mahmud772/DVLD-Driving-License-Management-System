using Common;
using DVLD_BLL;
using DVLD_DTO;
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
        
        public clsLicenseCardInfo_DTO LicenseInfo { get; set =>  _LoadLicenseInfo(value);  }

        public IDTO Info { get => LicenseInfo; set => LicenseInfo = value as clsLicenseCardInfo_DTO; }

        private int _targetHeight; // الارتفاع الذي نريد الوصول إليه
        private const int _step = 10; // مقدار التغيير في كل خطوة (سرعة الحركة)

        // "We need to define the heights for both states."
        // (نحتاج إلى تحديد الارتفاعات لكلتا الحالتين).
        private int _collapsedHeight = 261;
        private int _expandedHeight = 450;

        clsControlAnimateHeight Animate;
        
        public ucLicense()
        {
            InitializeComponent();
            
        }
        private void _LoadLicenseInfo(clsLicenseCardInfo_DTO LicenseInfo)
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

        
        private void LoadImageDesign()
        {
            clsUIHelper.MakePictureBoxCircular(pbImage);
            pbImage.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private void LoadUserControlDesign()
        {
            clsUIHelper.CornerRadius(this, 25);
        }
        private void LoadPanelsDesign()
        {
            clsUIHelper.CornerRadius(pnlMoreInfo, 25);
            clsUIHelper.CornerRadius(pnlNotes, 25);

        }
        private void _LoadDesign()
        {
            LoadImageDesign();
            LoadUserControlDesign();
            LoadImageIsActivelDesign();
            LoadPanelsDesign();
        }
        private void LoadImageIsActivelDesign()
        {
            clsUIHelper.CornerRadius(pbIsActive, 5);
        }
       


        private void btnShowMore_Less_Click(object sender, EventArgs e)
        {
            Animate.OnExpand -=_Expand;
            Animate.OnExpand +=_Expand;
            Animate.OnCollapse -=_Collapse;
            Animate.OnCollapse +=_Collapse;
            if(Animate.Status == clsControlAnimateHeight.enStatus.Closed) 
            {
                Animate.OnExpand -= _Collapse;
                Animate.Expand();
            }
            else
            {  
                Animate.OnExpand -= _Expand;
                Animate.Collapse();
            }

            //    this.Tag = "IsAnimating"; // لمنع تداخل العمليات (To prevent operation overlap)
            //this.Region = null;
            //if (this.Height == _collapsedHeight)
            //{
            //    _targetHeight = _expandedHeight; // الهدف هو التوسيع
            //    pnlMoreInfo.Visible = true;
            //}
            //else
            //{
            //    _targetHeight = _collapsedHeight; // الهدف هو التقليص
            //}

            //tmrAnimationSize.Start();

            
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
        private void tmrAnimationSize_Tick(object sender, EventArgs e)
        {

            // استدعاء دالة الحركة (Call the animation function)
            bool isFinished = clsUIHelper.AnimateHeight(this, _targetHeight, _step);

            if (isFinished)
            {
                tmrAnimationSize.Stop();
                this.Tag = null; // إنهاء حالة التحريك (End animation state)
                clsUIHelper.CornerRadius(this, 15);
                // تحديث الحالة النهائية (Update final state)
                if (this.Height == _collapsedHeight)
                {
                    pnlMoreInfo.Visible = false;
                    btnShowMore_Less.Text = ">>";
                }
                else
                {
                    btnShowMore_Less.Text = "<<";
                }
            }
        }

        private void pbImage_Paint(object sender, PaintEventArgs e)
        {
            clsUIHelper.MakeFramePictureBox(sender, e);
        }

        private void ucLicense_Load(object sender, EventArgs e)
        {
            _LoadDesign();
            clsUIHelper.CornerRadius(this, 15);
            Animate = new clsControlAnimateHeight(this, _expandedHeight, _collapsedHeight, _step);
            Animate.OnCollapse += _Collapse;
            Animate.Collapse();
        }
    }
}
    
