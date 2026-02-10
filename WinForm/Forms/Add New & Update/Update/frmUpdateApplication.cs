using Common;
using Common.Helpers;
using DVLD_BLL;
using DVLD_DTO;
using DVLD_Models;
using DVLDWinForm.UIHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDWinForm.Forms.Add_New___Update.Update
{
    public partial class frmUpdateApplication : Form
    {
        private clsApplication_DTO _ApplicationInfo;
        private clsLocalDrivingLicenseApplication_DTO _LocalApplicationInfo;
        Action CreateApp;
        List<clsApplicationType_DTO> _ApplicationTypesList;
        List<clsLicenseClass_DTO> _LicenseClassesList;
        enum enApp { App = 1, LocalApp = 2 }
        enApp Mode = enApp.App;
        public frmUpdateApplication(clsApplication_DTO ApplicationInfo)
        {
            InitializeComponent();
            _ApplicationInfo = ApplicationInfo;
            Mode = enApp.App;
        }
        public frmUpdateApplication(clsLocalDrivingLicenseApplication_DTO ApplicationInfo)
        {
            InitializeComponent();
            _LocalApplicationInfo = ApplicationInfo;
            Mode = enApp.LocalApp;
        }
        private void _LoadDesign()
        {
            clsUIHelper.CornerRadius(pnlApplication, 5);

            if (_ApplicationInfo?.ApplicationStatus == clsApplicationEnums.enApplicationStatus.Cancelled ||
               _LocalApplicationInfo?.ApplicationStatus == clsApplicationEnums.enApplicationStatus.Cancelled)
            {
                chbCancel.Checked = true;
                chbCancel.Enabled = false;
            }
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
            if (cbApplicationTypes?.SelectedValue != null)
                _ApplicationInfo.ApplicationTypeID = cbApplicationTypes.SelectedIndex + 1;
            _LocalApplicationInfo?.LicenseClass = clsLicenseEnumConverter.ToClass(cbLicenseClass.SelectedIndex + 1);
            if (chbCancel.Checked)
                _ApplicationInfo.ApplicationStatus = clsApplicationEnums.enApplicationStatus.Cancelled;
            return true;
        }
        private void _CreateApplication()
        {
            clsApplication_BLL Application = clsApplication_BLL.FindByApplicationID(_ApplicationInfo.ApplicationID);
            Application.Application = _ApplicationInfo;
            Application.Save();
        }
        private void _CreateLoaclApplication()
        {
            clsLocalDrivingLicenseApplication_BLL Application = clsLocalDrivingLicenseApplication_BLL.FindByLocaLicenseApplicationlID(_LocalApplicationInfo.LocalDrivingLicenseApplicationID);
            Application.Application = _ApplicationInfo;
            Application.LocalApplication = _LocalApplicationInfo;
            Application.Save();
        }
        private void btnSave_Click(object sender, EventArgs e)
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
        private void cbApplicationTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbApplicationTypes.SelectedIndex == 0) // New Local Driving License Service
            {
                CreateApp = _CreateLoaclApplication;
                lbLicenseClass.Visible = true;
                cbLicenseClass.Visible = true;
                lbPaidFeesValue.Text = _ApplicationTypesList?[cbApplicationTypes.SelectedIndex + 1].ApplicationFees.ToString();
            }
            else
            {
                CreateApp = _CreateApplication;
                lbLicenseClass.Visible = false;
                cbLicenseClass.Visible = false;
            }
        }
        private void frmUpdateApplication_Load(object sender, EventArgs e)
        {
            _SetApplicationInfo();
            _LoadDesign();
        }
    }
}
