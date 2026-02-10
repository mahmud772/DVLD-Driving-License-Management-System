using Common;
using DVLD_BLL;
using DVLD_DTO;
using DVLD_Models;
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
        
        private int _targetHeight; // الارتفاع الذي نريد الوصول إليه
        private const int _step = 20;
        // "We need to define the heights for both states."
        // (نحتاج إلى تحديد الارتفاعات لكلتا الحالتين).
        public int _collapsedHeight { get; } = 161;
        public int _expandedHeight { get; } = 300;

       
        public ucPerson()
        {
            InitializeComponent();
            Animate = new clsControlAnimateHeight(this, _expandedHeight, _collapsedHeight, _step);
            //clsStaticData_BLL.LoadAllStaticData();


            //tmrAnimationSize.Interval = 15; // سرعة التحديث (بالملي ثانية)
            //tmrAnimationSize.Tick += tmrAnimationSize_Tick;
            //this.Height = _collapsedHeight; // تعيين الارتفاع الأصغر (e.g., 230)
            //pnlMoreInfo.Visible = false;    // إخفاء لوحة المعلومات الإضافية
            //pnlIDs.Visible = false;
            //btnShowMore_Less.Text = ">>";   // تعيين النص المناسب للزر

            ////clsUIHelper.CornerRadius(this, 15);

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
            MainForm.CRUDController.PrepareUpdate = Person => new frmAddNew_UpdatePerson(Person as clsPerson_DTO);
            MainForm.CRUDController.TryDelete = clsPerson_BLL.DeletePerson;
            return true;
        }
        


        private void LoadImageDesign()
        {
            clsUIHelper.MakePictureBoxCircular(pbImage);
            
        }
        private void LoadUserControlDesign()
        {
            clsUIHelper.CornerRadius(this, 25);
        }

        private void LoadPanelsDesign()
        {
            clsUIHelper.CornerRadius(pnlContacts, 25);
            clsUIHelper.CornerRadius(pnlMoreInfo, 25);
            clsUIHelper.CornerRadius(pnlIDs, 25);

        }
        private void _LoadDesign()
        {
            LoadImageDesign();
            LoadUserControlDesign();
            LoadPanelsDesign();
        }

        public void CollapseInstantly()
        {
            Animate.OnCollapse -= _Collapse;
            Animate.OnCollapse += _Collapse;
            Animate.OnExpand -= _Expand;
            Animate.Collapse();
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
            
            Animate.OnCollapse += _Collapse;
            Animate.Collapse();
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
            Animate.OnExpand -= _Expand;
            Animate.OnExpand += _Expand;
            Animate.OnCollapse -= _Collapse;
            Animate.OnCollapse += _Collapse;
            if (Animate.Status == clsControlAnimateHeight.enStatus.Closed)
            {
                Animate.OnExpand -= _Collapse;
                Animate.Expand();
            }
            else
            {
                Animate.OnExpand -= _Expand;
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
            pnlMoreInfo.Visible = false;
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
