using Common;
using Common.Helpers;
using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm.UIHelper;
using DVLDWinForm.UIHelper_Manger;
using DVLDWinForm.User_Controls;
using DVLDWinForm.User_Controls.Display;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DVLDWinForm.Forms.Add_New___Update
{
    public partial class frmAddNew_UpdateAppointment : Form
    {
        clsTestAppointment_DTO _AppointmentInfo;
        enum enMode { AddNew = 1, Update = 2 };
        enMode Mode = enMode.AddNew;
        public frmAddNew_UpdateAppointment()
        {
            InitializeComponent();
            LoadDesign();
            _AppointmentInfo = new clsTestAppointment_DTO();
            Mode = enMode.AddNew;
        }
        public frmAddNew_UpdateAppointment(clsLocalDrivingLicenseApplication_DTO LocalApplication)
        {
            InitializeComponent();
            LoadDesign();
            _AppointmentInfo = new clsTestAppointment_DTO();
            Mode = enMode.AddNew;
            UpdateFormAfterSelectedLDLA(LocalApplication);
        }
        public frmAddNew_UpdateAppointment(clsTestAppointment_DTO AppointmentInfo)
        {
            InitializeComponent();
            _AppointmentInfo = AppointmentInfo;
            pbSelectedID.Enabled = false;
            Mode = enMode.Update;
            lbTitel.Text = "UPDATE APPOINTMENT";
            this.Text = "UPDATE APPOINTMENT";
        }

        private void frmAddNewAppointment_Load(object sender, EventArgs e)
        {
            SetApplicationInfo();
        }
        private void LoadDesign()
        {
            clsUIHelper.CornerRadius(pnlAppointment, 5);
            lbRetakeTestApp.Visible = false;
            tbRetakeTestAppID.Visible = false;
            pbSelectedRetakeAppID.Visible = false;
        }
        private void SetApplicationInfo()
        {
            if (Mode == enMode.Update && _AppointmentInfo != null)
            {
                tbID.Text = _AppointmentInfo.LocalDrivingLicenseApplicationID.ToString();
                lbTitel.Text = "UPDATE APPOINTMENT";
                lbType.Text = clsStaticData_BLL.TestTypes
                    .FirstOrDefault(T => T.TestTypeID == _AppointmentInfo.TestTypeID)
                    .TestTypeTitle.ToString().Split(' ')[0];
                dtpAppointmentDate.Value = _AppointmentInfo.AppointmentDate;
                lbPaidFees.Text = _AppointmentInfo.PaidFees.ToString();
            }
        }
        private bool GetApplicationInfo()
        {
            clsValidation.ep.Clear();
            if (clsValidation.IsEmpty(tbID, "Select a valid ID")) return false;

            _AppointmentInfo?.AppointmentDate = dtpAppointmentDate.Value;
            _AppointmentInfo?.LocalDrivingLicenseApplicationID = Convert.ToInt32(tbID.Text?.Trim());
            _AppointmentInfo?.CreatedByUserID = clsCurrentUser.User.UserID;
            if (_AppointmentInfo.AppointmentDate < DateTime.Now) return false;
            int RetakeID;
            if(tbRetakeTestAppID.Visible && int.TryParse(tbRetakeTestAppID.Text ,out RetakeID))
                _AppointmentInfo.RetakeTestApplicationID = RetakeID;
           
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (GetApplicationInfo())
            {
                clsTestAppointment_BLL Appointment = Mode == enMode.AddNew ?
                    new clsTestAppointment_BLL()
                    : clsTestAppointment_BLL.FindByID(_AppointmentInfo.TestAppointmentID);
                Appointment.Appointment = _AppointmentInfo;
                if(Appointment.Save())
                {
                    MessageBox.Show("A new date has been set .", "Information", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    MessageBox.Show("The Data Is Not Valid .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("The Data Is Not Valid .", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void pbSelectedID_Click(object sender, EventArgs e)
        {
            ucLocalLicenseApplication app = new ucLocalLicenseApplication();
            frmFind frm = new frmFind(app, clsLocalDrivingLicenseApplication_BLL.FindByLocaLicenseApplicationlID);
            frm?.ShowDialog();
            UpdateFormAfterSelectedLDLA(app.ApplicationInfo);

        }
        private void UpdateFormAfterSelectedLDLA(clsLocalDrivingLicenseApplication_DTO LocalApp)
        {
            if (LocalApp == null) return;
            tbID.Text = LocalApp.LocalDrivingLicenseApplicationID.ToString();
            clsTestEnums.enTestTypes eTestType = clsTestAppointment_BLL.GetLastTestType(LocalApp.LocalDrivingLicenseApplicationID);
            bool IsNeedRetakeTestApp = 
                clsTestAppointment_BLL.IsNeedRetakeTestApp(LocalApp.LocalDrivingLicenseApplicationID, eTestType);
            eTestType = SelectTestType(eTestType, LocalApp.LocalDrivingLicenseApplicationID , IsNeedRetakeTestApp);
            int TestType = clsTestEnumConverter.ConvertTestTypeToInt(eTestType);
            lbType.Text = eTestType.ToString().Split(' ')[0];
            lbPaidFees.Text = clsTestType_BLL.GetPaidFees(TestType).ToString("F1");
            if(LocalApp != null && IsNeedRetakeTestApp)
            {
                lbRetakeTestApp.Visible = true;
                tbRetakeTestAppID.Visible = true;
                pbSelectedRetakeAppID.Visible = true;
            }
            else
            {
                lbRetakeTestApp.Visible = false;
                tbRetakeTestAppID.Visible = false;
                pbSelectedRetakeAppID.Visible = false;
            }
            _AppointmentInfo.TestType = eTestType;
        }
        private clsTestEnums.enTestTypes SelectTestType(clsTestEnums.enTestTypes eTestType ,int LocalLicenseAppID , bool IsNeedRetakeTestApp)
        {

            if (IsNeedRetakeTestApp)
                return eTestType;
            if (!clsTestAppointment_BLL.IsTestedBefor(LocalLicenseAppID))
                return clsTestEnums.enTestTypes.VisionTest;
            else if (eTestType == clsTestEnums.enTestTypes.VisionTest)
                return clsTestEnums.enTestTypes.WrittenTest;
            else if (eTestType == clsTestEnums.enTestTypes.WrittenTest)
                return clsTestEnums.enTestTypes.PracticalTest;
            return eTestType ;
        }
        private void pbSelectedRetakeAppID_Click(object sender, EventArgs e)
        {
            frmFind frm = new frmFind(new ucApplication() , clsApplication_BLL.FindByApplicationID);
            frm.ShowDialog();
            tbRetakeTestAppID.Text = frm.SelectedID;
        }
    }
}
