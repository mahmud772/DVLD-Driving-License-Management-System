using Common;
using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm;
using DVLDWinForm.Forms;
using DVLDWinForm.UIHelper;
using DVLDWinForm.UIHelper_Manger;
using DVLDWinForm.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.Expando;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DVLDWinForm
{
    public partial class ucPerson : UserControl , IUserControl
    {
        bool IsPersonSelectd ;
        public event Action OnVisibleChanged;
        public event Action OnUnvisibleChanged;
        private clsPerson_DTO _PersonInfo;

        clsControlAnimateHeight Animate;
        public clsPerson_DTO PersonInfo
        {
            get => _PersonInfo;
            set
            {
                _PersonInfo = value;      
                _SetPersonInfo(value);  
            }
        }
        public IDTO Info { get => PersonInfo; set => PersonInfo = value as clsPerson_DTO; }


        public Func<IDTO> SelectdDTO;
        
        private const int _step = 20;
        // "We need to define the heights for both states."
        // (نحتاج إلى تحديد الارتفاعات لكلتا الحالتين).
        public int _collapsedHeight { get; } = 161;
        public int _expandedHeight { get; } = 300;

       
        public ucPerson()
        {
            InitializeComponent();
            Animate = new clsControlAnimateHeight(this, _expandedHeight, _collapsedHeight, _step);
            CollapseInstantly();
        }
        

        private bool _SetPersonInfo(clsPerson_DTO PersonInfo)
        {

            if (PersonInfo == null)
            {
                //MessageBox.Show("This is Person Is Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IsPersonSelectd = true;
                return false;

            }
            
            lbPersonID.Text = Convert.ToString(PersonInfo.PersonID);
            lbNationalNo.Text = PersonInfo.NationalNo;
            lbPhone.Text = PersonInfo.Phone;
            lbEmail.Text = PersonInfo.Email;
            lbDateOfBirth.Text = PersonInfo.DateOfBirth.ToString("yyyy/MM/dd");
            lbGendor.Text = Convert.ToString(PersonInfo.Gendor);
            lbAddress.Text = PersonInfo.Address;
            lbName.Text = PersonInfo.FullName;
            lbCountry.Text = clsCountry_BLL.GetCountryName(PersonInfo.NationalityCountryID);
            clsUIHelper.LoadImage(PersonInfo.ImagePath, PersonInfo.Gendor, pbImage);
            clsUIHelper.FitText(lbName, 7.0f);
            clsUIHelper.FitText(lbAddress, 8.0f);
            clsUIHelper.FitText(lbEmail, 8.0f);
            return true;
        }
        
        private void _LoadDesign()
        {
            clsUIHelper.MakePictureBoxCircular(pbImage);
            clsUIHelper.CornerRadius(this, 25);
            clsUIHelper.CornerRadius(pnlContacts, 25);
            clsUIHelper.CornerRadius(pnlMoreInfo, 25);
            clsUIHelper.CornerRadius(pnlIDs, 25);
        }

        public void CollapseInstantly()
        {
            Animate.OnCollapse -= _Collapse;
            Animate.OnCollapse += _Collapse;
            Animate.OnExpand -= _Expand;
            Animate.QuickCollapse();
            clsUIHelper.CornerRadius(this, 15);
        }


        private void pbImage_Paint(object sender, PaintEventArgs e)
        {
            clsUIHelper.MakeFramePictureBox(sender, e);

        }

        private void ctrlPerson_Load(object sender, EventArgs e)
        {
            _LoadDesign();
            clsUIHelper.CornerRadius(this, 15);
            
        }

        

        
        private void _VisibleComponents()
        {
            OnVisibleChanged?.Invoke();
            pnlMoreInfo.Visible = true;
            pnlIDs.Visible = true;
        }
        private void _UnvisibleComponents()
        {
            OnUnvisibleChanged?.Invoke();
            pnlMoreInfo.Visible = false;
            pnlIDs.Visible = false;

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
            btnShowMore_Less.Text = "<<";
            _VisibleComponents();
        }
        private void _Collapse()
        {
            btnShowMore_Less.Text = ">>";
            _UnvisibleComponents();
        }
        private void btnUpdate_Delete_Click(object sender, EventArgs e)
        {
            if (PersonInfo != null && SelectdDTO == null)
            { 
                MainForm.CRUDController?.DTO = this.PersonInfo; 
            }
            else
            {
                MainForm.CRUDController?.DTO = SelectdDTO?.Invoke();
            }
            MainForm.SharedContextMenu.Show(btnUpdate_Delete , new Point(0,btnUpdate_Delete.Height));
        }
    }
}
