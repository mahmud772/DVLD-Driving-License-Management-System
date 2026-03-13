using Common;
using Common.Helpers;
using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm.Forms.Add_New___Update.Add_New;
using DVLDWinForm.UIHelper;
using DVLDWinForm.UIHelper_Manger;
using DVLDWinForm.User_Controls;
using DVLDWinForm.User_Controls.Display;
using DVLDWinForm.User_Controls.Display.ucApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DVLDWinForm.Forms
{
    public partial class frmCreateApplication : Form
    {
        private clsApplication_DTO _applicationInfo;
        private clsLocalDrivingLicenseApplication_DTO _localInfo;
        clsApplicationType_DTO _CurrentApplicationType;
        clsLicenseClass_DTO _CurrentLicenseClass;
        Func<frmFind> OpenForm;
        Func<int, int> GetLicenseClass;
        private ApplicationFactory _factory;
        clsApplicationEnums.enApplicationType _type;
        public frmCreateApplication()
        {
            InitializeComponent();

            _factory = new ApplicationFactory(cbApplicationTypes , cbLicenseClass);
            
        }
        private void _LoadDesign()
        {
            clsUIHelper.CornerRadius(pnlApplication, 15);
            ckbOperationLicense.Visible = false;
            ckbOperationLicense.Checked = false;
            ckbOperationLicense.Location = lbLicenseClass.Location;
            lbPaidFeesLicenseClass.Visible = true;
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
            int LicenseID;
            int.TryParse(tbID.Text, out LicenseID);
            if(_factory.CreateApplication(_applicationInfo,_localInfo,LicenseID,type,ckbOperationLicense.Checked))
                DialogResult = DialogResult.OK;
            this.Close();
        }
        
        private bool CollectData()
        {
            int ID;
           
            if (!int.TryParse(tbID.Text, out ID))
                return false;

            _applicationInfo = new clsApplication_DTO();
            _applicationInfo.ApplicantPersonID = _factory.GetPersonIDByApplicationType(ID , _type);
            _applicationInfo.ApplicationTypeID = Convert.ToByte(cbApplicationTypes.SelectedValue);

            if (cbLicenseClass.SelectedValue != null && cbLicenseClass.Visible)
            {
                _localInfo = new clsLocalDrivingLicenseApplication_DTO();
                _localInfo.LicenseClass =clsLicenseEnumConverter.ToClass(Convert.ToInt32(cbLicenseClass.SelectedValue));
            }

            return true;
        }

        private void cbApplicationTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbApplicationTypes.SelectedItem == null)
                return;
            _CurrentApplicationType = cbApplicationTypes.SelectedItem as clsApplicationType_DTO;
            _type = clsApplicationEnumConverter.ToType(
                    Convert.ToInt32(_CurrentApplicationType?.ApplicationTypeID));
            UpdateState(_type);
        }
        private void pbSelectedID_Click(object sender, EventArgs e)
        {
            using (frmFind frm = OpenForm?.Invoke())
            {
                frm?.ShowDialog();
                tbID.Text = frm?.SelectedID;
            }
            if (tbID.Text == string.Empty || 
                _CurrentApplicationType == null ||
                clsApplicationEnumConverter.ToType(_CurrentApplicationType.ApplicationTypeID) ==
                clsApplicationEnums.enApplicationType.NewLocalDrivingLicense ||
                GetLicenseClass == null) return;
            int ID;
            int.TryParse(tbID.Text, out ID);
            _CurrentLicenseClass = 
                clsLicenseClass_BLL.FindByID(GetLicenseClass.Invoke(ID))?.LicenseClass; // محتاجة تعديل لجلب البيانات من الستاتك داتا
            
            UpdatePaidFeesLicenseClass();
        }
        private void frmCreateApplication_Load(object sender, EventArgs e)
        {
            _LoadDesign();
        }
        public void UpdateState(clsApplicationEnums.enApplicationType type)
        {
            tbID.Text = string.Empty;
            if (type == clsApplicationEnums.enApplicationType.NewLocalDrivingLicense)
            {
                ShowLicenseClass();
                OpenForm = () => new frmFind(new ucPerson(), clsPerson_BLL.Find);
                lbID.Text = "Person ID:";
                ckbOperationLicense.Visible = false;
                lbPaidFeesLicenseClass.Visible = true;
                GetLicenseClass = null;
            }
            else if (type == clsApplicationEnums.enApplicationType.RetakeTest)
            {
                HideLicenseClass();
                OpenForm = () => new frmFind(new ucLocalLicenseApplication(), clsLocalDrivingLicenseApplication_BLL.FindByLocaLicenseApplicationlID);
                lbID.Text = "Local Application ID:";
                ckbOperationLicense.Visible = false;
                lbPaidFeesLicenseClass.Visible = false;
                GetLicenseClass = clsLocalDrivingLicenseApplication_BLL.GetLicenseClassIDByLocalDrivingLicenseApplicationID;
            }
            else if (type == clsApplicationEnums.enApplicationType.NewInternationalLicense)
            {
                HideLicenseClass();
                OpenForm = () => new frmFind(new ucLicense(), clsLicense_BLL.GetLicenseCardInfo);
                lbID.Text = "License ID:";
                GetLicenseClass = null;
            }
            else
            {
                HideLicenseClass();
                OpenForm = () => new frmFind(new ucLicense(), clsLicense_BLL.GetLicenseCardInfo);
                lbID.Text = "License ID:";
                ckbOperationLicense.Visible = true;
                lbPaidFeesLicenseClass.Visible = true;
                GetLicenseClass = clsLicense_BLL.GetLicenseClassIDByLicenseID;
            }
            UpdateUIOperationLicense(type);
            UpdatePaidFeesLicenseClass();
        }

        private void ShowLicenseClass()
        {
            lbLicenseClass.Visible = true;
            cbLicenseClass.Visible = true;
            
        }

        private void HideLicenseClass()
        {
            lbLicenseClass.Visible = false;
            cbLicenseClass.Visible = false;
           
        }
        private void UpdateUIOperationLicense(clsApplicationEnums.enApplicationType type)
        {
            _CurrentApplicationType = cbApplicationTypes.SelectedItem as clsApplicationType_DTO;
            lbPaidFees.Text = _CurrentApplicationType?.ApplicationFees.ToString("F1");
            UpdatePaidFeesLicenseClass();
            switch (type)
            {
                case clsApplicationEnums.enApplicationType.NewLocalDrivingLicense:
                    break;
                case clsApplicationEnums.enApplicationType.RenewDrivingLicense:
                    ckbOperationLicense.Text = "Renew Driving License";
                    break;
                case clsApplicationEnums.enApplicationType.ReplacementForLostDrivingLicense:
                    ckbOperationLicense.Text = "Replacement For Lost Driving License";
                    break;
                case clsApplicationEnums.enApplicationType.ReplacementForDamagedDrivingLicense:
                    ckbOperationLicense.Text = "Replacement For Damaged Driving License";
                    break;
                case clsApplicationEnums.enApplicationType.ReleaseDetainedDrivingLicsense:
                    ckbOperationLicense.Text = "Release Detained Driving Licsense";
                    break;
                case clsApplicationEnums.enApplicationType.NewInternationalLicense:
                    break;
                case clsApplicationEnums.enApplicationType.RetakeTest:

                default:
                    break;
            }
        }

        private void cbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CurrentLicenseClass = cbLicenseClass.SelectedItem as clsLicenseClass_DTO;
            lbPaidFeesLicenseClass.Text = "+ " + _CurrentLicenseClass?.ClassFees.ToString("F1");
        }

        private void ckbOperationLicense_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePaidFeesLicenseClass();
        }
        private void UpdatePaidFeesLicenseClass()
        {
            clsApplicationEnums.enApplicationType type = clsApplicationEnumConverter.ToType(
                    Convert.ToInt32(_CurrentApplicationType?.ApplicationTypeID));
            if (ckbOperationLicense.Checked ||
                type == clsApplicationEnums.enApplicationType.NewLocalDrivingLicense)
                lbPaidFeesLicenseClass.Visible = true;
            else
                lbPaidFeesLicenseClass.Visible = false;
            
           lbPaidFeesLicenseClass.Text = "+ " + _CurrentLicenseClass?.ClassFees.ToString("F1");
                
        }
    }
}
