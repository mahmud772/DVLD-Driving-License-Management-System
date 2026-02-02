using Common;
using Common.Helpers;
using DVLD_BLL;
using DVLD_DTO;
using DVLD_Models;
using DVLDWinForm.UIHelper;
using DVLDWinForm.UIHelper_Manger;
using DVLDWinForm.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDWinForm.Forms
{
    public partial class frmCreateApplication : Form
    {
        clsApplication_DTO _ApplicationInfo;
        clsLocalDrivingLicenseApplication_DTO _LocalApplicationInfo;
        List<clsApplicationType_DTO> _ApplicationTypesList;
        List<clsLicenseClass_DTO> _LicenseClassesList;
        Action CreateApp;
        Func<frmFind> OpenForm;
        public frmCreateApplication()
        {
            InitializeComponent();
            _LoadDesign();
        }
        

        private void _LoadDesign()
        {
            clsUIHelper.CornerRadius(pnlApplication, 15);
            lbLicenseClass.Visible = false;
            cbLicenseClass.Visible = false;
        }
        private void _SetApplicationInfo()
        {
            // جلب القائمة أولاً (Fetch the list first)
            _ApplicationTypesList = clsStaticData_BLL.ApplicationTypes;

            // ربط القائمة بالـ ComboBox (Bind the list to the ComboBox)
            cbApplicationTypes?.DataSource = _ApplicationTypesList;

            // تحديد ما يظهر للمستخدم وما يتم تخزينه برمجياً
            // Define what is displayed to the user and what is stored programmatically
            cbApplicationTypes.DisplayMember = "ApplicationTypeTitle"; // النص الذي يظهر (The displayed text)
            cbApplicationTypes.ValueMember = "ApplicationTypeID";     // القيمة المخفية (The hidden value)
            
            _LicenseClassesList = clsStaticData_BLL.LicenseClasses;
            cbLicenseClass?.DataSource = _LicenseClassesList;
            cbLicenseClass.DisplayMember = "ClassName";
            cbLicenseClass.ValueMember = "LicenseClassID";
            
        }

        private bool _GetApplicationInfo()
        {
            clsUIHelper.ErrorProvider.Clear();
            if (clsValidation.IsEmpty(clsUIHelper.ErrorProvider, tbID , "Select a valid ID")) return false;
            _ApplicationInfo = new clsApplication_DTO();
            _LocalApplicationInfo = new clsLocalDrivingLicenseApplication_DTO();
            if (cbApplicationTypes?.SelectedValue != null)
                _ApplicationInfo.ApplicationTypeID = cbApplicationTypes.SelectedIndex + 1;
            _ApplicationInfo.ApplicantPersonID = Convert.ToInt32(tbID.Text?.Trim());
            _LocalApplicationInfo.LicenseClass = clsLicenseEnumConverter.ToClass(cbLicenseClass.SelectedIndex + 1);
            return true;
        }
        

        private void frmCreateApplication_Load(object sender, EventArgs e)
        {
            _SetApplicationInfo();
            clsUIHelper.ErrorProvider.ContainerControl = this;
        }

        

        private void btnSave_Click_1(object sender, EventArgs e)
        {

            if (_GetApplicationInfo())
            {
                CreateApp?.Invoke();
                this.Close();
            }
            else
            {
                MessageBox.Show("The Data Is Not Valid .", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pbSelectedID_Click(object sender, EventArgs e)
        {
            frmFind frm = OpenForm?.Invoke();
            frm?.ShowDialog();
            tbID.Text = frm?.SelectedID;
        }



        private void _CreateApplication()
        {
            clsApplication_BLL Application = new clsApplication_BLL();
            Application.Application = _ApplicationInfo;
            Application.Save();
        }
        private void _CreateLoaclApplication()
        {
            clsLocalDrivingLicenseApplication_BLL Application = new clsLocalDrivingLicenseApplication_BLL();
            Application.Application = _ApplicationInfo;
            Application.LocalApplication = _LocalApplicationInfo;
            Application.Save();
        }
        private void _UpdateForm_NewLocalApplication()
        {
            lbLicenseClass.Visible = true;
            cbLicenseClass.Visible = true;
            lbID.Text = "Person ID           :";
        }
        private void _UpdateForm_RetakeTest()
        {
            lbLicenseClass.Visible = true;
            cbLicenseClass.Visible = true;
            lbID.Text = "Local Application ID:";
        }
        private void _UpdateForm_License()
        {
            lbLicenseClass.Visible = false;
            cbLicenseClass.Visible = false;
            lbID.Text = "License ID          :";
        }
        private void cbApplicationTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbApplicationTypes.SelectedIndex == 0) // New Local Driving License Service
            {
                CreateApp = _CreateLoaclApplication;
                OpenForm = () => new frmFind(new ctrlPerson() , clsPerson_BLL.Find);
                _UpdateForm_NewLocalApplication();
            }
            else if(cbApplicationTypes.SelectedIndex == 6) // RetakeTest
            {
                CreateApp = _CreateApplication;
                OpenForm = () => new frmFind(new ctrlApplication() , clsLocalDrivingLicenseApplication_BLL.FindByLocaLicenseApplicationlID);
                _UpdateForm_RetakeTest();
            }
            else
            {
                CreateApp = _CreateApplication;
                OpenForm = () => new frmFind(new ctrlLicense() , clsLicense_BLL.GetLicenseCardInfo);
                _UpdateForm_License();
            }
        }
    }
}
