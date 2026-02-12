using Common;
using Common.Helpers;
using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm.UIHelper;
using DVLDWinForm.User_Controls.Display.ucApplication;
using System;
using System.Windows.Forms;

namespace DVLDWinForm.Forms
{
    public partial class frmCreateApplication : Form
    {
        private clsApplication_DTO _applicationInfo;
        private clsLocalDrivingLicenseApplication_DTO _localInfo;

        private ApplicationFactory _factory;
        private FormStateManager _stateManager;

        public frmCreateApplication()
        {
            InitializeComponent();

            _factory = new ApplicationFactory();
            _stateManager = new FormStateManager(lbLicenseClass,cbLicenseClass,lbID,ckbOperationLicense);
             
        }
        private void _InitializeStaticDataToForm()
        {
            cbApplicationTypes?.DataSource = clsStaticData_BLL.ApplicationTypes;
            cbApplicationTypes.DisplayMember = "ApplicationTypeTitle";
            cbApplicationTypes.ValueMember = "ApplicationTypeID";
            cbLicenseClass?.DataSource = clsStaticData_BLL.LicenseClasses; ;
            cbLicenseClass.DisplayMember = "ClassName";
            cbLicenseClass.ValueMember = "LicenseClassID";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CollectData())
            {
                MessageBox.Show("Invalid Data");
                return;
            }

            clsApplicationEnums.enApplicationType type = clsApplicationEnumConverter.ToType(
                    Convert.ToInt32(cbApplicationTypes.SelectedValue));

            _factory.CreateApplication(_applicationInfo,_localInfo,type,ckbOperationLicense.Checked);

            this.Close();
        }

        private bool CollectData()
        {
            int ID;

            if (!int.TryParse(tbID.Text, out ID))
                return false;

            _applicationInfo = new clsApplication_DTO();
            //if(cbApplicationTypes.SelectedValue == )
            _applicationInfo.ApplicantPersonID = ID;
            _applicationInfo.ApplicationTypeID = Convert.ToByte(cbApplicationTypes.SelectedValue);

            if (cbLicenseClass.SelectedValue != null)
            {
                _localInfo = new clsLocalDrivingLicenseApplication_DTO();
                _localInfo.LicenseClass =clsLicenseEnumConverter.ToClass(Convert.ToInt32(cbLicenseClass.SelectedValue));
            }

            return true;
        }

        private void cbApplicationTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbApplicationTypes.SelectedValue == null)
                return;

            clsApplicationEnums.enApplicationType type =
                clsApplicationEnumConverter.ToType(
                    Convert.ToInt32(cbApplicationTypes.SelectedValue));

            _stateManager.UpdateState(type);
        }

        private void frmCreateApplication_Load(object sender, EventArgs e)
        {

        }
    }
}
