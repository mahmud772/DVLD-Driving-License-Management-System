using Common;
using Common.Helpers;
using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm.Forms.Add_New___Update.Add_New;
using DVLDWinForm.UIHelper;
using DVLDWinForm.UIHelper_Manger;
using DVLDWinForm.User_Controls;
using DVLDWinForm.User_Controls.Display.ucApplication;
using System;
using System.Collections.Generic;
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
            ckbOperationLicense.Checked = true;
            ckbOperationLicense.Location = lbLicenseClass.Location;
            lbPaidFees2.Visible = false;
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
                lbPaidFees2.Visible = true;
            }
            else if (type == clsApplicationEnums.enApplicationType.RetakeTest)
            {
                HideLicenseClass();
                OpenForm = () => new frmFind(new ucApplication(), clsLocalDrivingLicenseApplication_BLL.FindByLocaLicenseApplicationlID);
                lbID.Text = "Local Application ID:";
                ckbOperationLicense.Visible = false;
                lbPaidFees2.Visible = false;
            }
            else
            {
                HideLicenseClass();
                OpenForm = () => new frmFind(new ucLicense(), clsLicense_BLL.GetLicenseCardInfo);
                lbID.Text = "License ID:";
                ckbOperationLicense.Visible = true;
                lbPaidFees2.Visible = true;
            }
            UpdateUIOperationLicense(type);
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
            lbPaidFees2.Text = " + " +  _CurrentLicenseClass?.ClassFees.ToString("F1");
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
            lbPaidFees2.Text = "+ " + _CurrentLicenseClass?.ClassFees.ToString("F1");
        }

        private void ckbOperationLicense_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePaidFees2();
        }
        private void UpdatePaidFees2()
        {
            if(!ckbOperationLicense.Checked)
            {
                lbPaidFees2.Visible = false;
                return;
            }
            lbPaidFees2.Visible = true;
        }
    }
}
