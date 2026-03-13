using Common;
using Common.Helpers;
using DVLD_BLL;
using DVLD_DTOs;
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
        private Func<bool> _SaveAction;

        private List<clsApplicationType_DTO> _ApplicationTypesList;
        private List<clsLicenseClass_DTO> _LicenseClassesList;

        private enum enApp { App = 1, LocalApp = 2 }
        private enApp Mode;


        public frmUpdateApplication(clsApplication_DTO applicationInfo)
        {
            InitializeComponent();
            _ApplicationInfo = applicationInfo;
            Mode = enApp.App;
        }

        public frmUpdateApplication(clsLocalDrivingLicenseApplication_DTO localApplicationInfo)
        {
            InitializeComponent();
            _LocalApplicationInfo = localApplicationInfo;
            Mode = enApp.LocalApp;
        }

        private void frmUpdateApplication_Load(object sender, EventArgs e)
        {
            _LoadLists();
            _BindControls();
            _LoadCurrentValues();
            _LoadDesign();
            SetSaveAction(); 
        }

        private void _LoadLists()
        {
            _ApplicationTypesList = clsStaticData_BLL.ApplicationTypes;
            _LicenseClassesList = clsStaticData_BLL.LicenseClasses;
        }

        private void _BindControls()
        {
            cbApplicationTypes.DataSource = _ApplicationTypesList;
            cbApplicationTypes.DisplayMember = "ApplicationTypeTitle";
            cbApplicationTypes.ValueMember = "ApplicationTypeID";

            cbLicenseClass.DataSource = _LicenseClassesList;
            cbLicenseClass.DisplayMember = "ClassName";
            cbLicenseClass.ValueMember = "LicenseClassID";
        }

        private void _LoadCurrentValues()
        {
            if (_ApplicationInfo != null)
            {
                cbApplicationTypes.SelectedValue = _ApplicationInfo.ApplicationTypeID;

                if (_ApplicationInfo.ApplicationStatus == clsApplicationEnums.enApplicationStatus.Cancelled)
                {
                    chbCancel.Checked = true;
                    chbCancel.Enabled = false;
                }
            }

            if (Mode == enApp.LocalApp && _LocalApplicationInfo != null)
            {
                cbLicenseClass.SelectedValue = _LocalApplicationInfo.LicenseClassID;
            }
        }

        private void _LoadDesign()
        {
            clsUIHelper.CornerRadius(pnlApplication, 5);
        }


        private void cbApplicationTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUIByApplicationType();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CollectDataFromUI())
            {
                MessageBox.Show("The Data Is Not Valid.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(_SaveAction == null) return;
            if(_SaveAction.Invoke()) DialogResult = DialogResult.OK;
            this.Close();
        }


        private void UpdateUIByApplicationType()
        {
            if (cbApplicationTypes.SelectedItem is not clsApplicationType_DTO selectedType)
                return;

            lbPaidFeesValue.Text = selectedType.ApplicationFees.ToString();

            bool isLocal = selectedType.ApplicationTypeID ==
                           (int)clsApplicationEnums.enApplicationType.NewLocalDrivingLicense;

            lbLicenseClass.Visible = isLocal;
            cbLicenseClass.Visible = isLocal;
            if(_ApplicationInfo?.ApplicationStatus == clsApplicationEnums.enApplicationStatus.Completed)
                chbCancel.Enabled = false;
            if(_ApplicationInfo?.ApplicationStatus == clsApplicationEnums.enApplicationStatus.Cancelled)
            {
                chbCancel.Checked = true;
                chbCancel.Enabled = false;
            }
            _SaveAction = isLocal ? SaveLocalApplication : SaveApplication;
        }

        private void SetSaveAction()
        {
            UpdateUIByApplicationType();
        }



        private bool CollectDataFromUI()
        {
            if (_ApplicationInfo == null)
                return false;

            if (cbApplicationTypes.SelectedValue == null)
                return false;

            _ApplicationInfo.ApplicationTypeID = (int)cbApplicationTypes.SelectedValue;

            if (chbCancel.Checked)
            {
                _ApplicationInfo.ApplicationStatus =
                    clsApplicationEnums.enApplicationStatus.Cancelled;
            }

            if (Mode == enApp.LocalApp)
            {
                if (cbLicenseClass.SelectedValue == null)
                    return false;

                _LocalApplicationInfo.LicenseClassID =
                    (int)cbLicenseClass.SelectedValue;
            }

            return true;
        }


        private bool SaveApplication()
        {
            clsApplication_BLL app = clsApplication_BLL.FindByApplicationID(_ApplicationInfo.ApplicationID);
            app.Application = _ApplicationInfo;
            return app.Save();
        }

        private bool SaveLocalApplication()
        {
            clsLocalDrivingLicenseApplication_BLL app = clsLocalDrivingLicenseApplication_BLL
                .FindByLocaLicenseApplicationlID(_LocalApplicationInfo.LocalDrivingLicenseApplicationID);

            app.Application = _ApplicationInfo;
            app.LocalApplication = _LocalApplicationInfo;
            return app.Save();
        }

    }
}
