using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm.UIHelper;
using DVLDWinForm.UIHelper_Manger;
using DVLDWinForm.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _AppointmentInfo = new clsTestAppointment_DTO();
            Mode = enMode.AddNew;
        }
        public frmAddNew_UpdateAppointment(clsTestAppointment_DTO AppointmentInfo)
        {
            InitializeComponent();
            _AppointmentInfo = AppointmentInfo;
            pbSelectedID.Enabled = false;
            Mode = enMode.Update;
        }

        private void frmAddNewAppointment_Load(object sender, EventArgs e)
        {
            _SetApplicationInfo();
            _LoadDesign();
        }
        private void _LoadDesign()
        {
            clsUIHelper.CornerRadius(pnlAppointment, 5);
        }
        private void _SetApplicationInfo()
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
        private bool _GetApplicationInfo()
        {
            clsValidation.ep.Clear();
            if (clsValidation.IsEmpty(tbID, "Select a valid ID")) return false;

            _AppointmentInfo?.AppointmentDate = dtpAppointmentDate.Value;
            _AppointmentInfo?.LocalDrivingLicenseApplicationID = Convert.ToInt32(tbID.Text?.Trim());
            _AppointmentInfo?.CreatedByUserID = clsCurrentUser.User.UserID;
            if (_AppointmentInfo.AppointmentDate <= DateTime.Now) return false;

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (_GetApplicationInfo())
            {
                clsTestAppointment_BLL Appointment = Mode == enMode.AddNew ?
                    new clsTestAppointment_BLL()
                    : clsTestAppointment_BLL.FindByID(_AppointmentInfo.TestAppointmentID);
                Appointment.Appointment = _AppointmentInfo;
                Appointment.Save();
                this.Close();
            }
            else
            {
                MessageBox.Show("The Data Is Not Valid .", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pbSelectedID_Click(object sender, EventArgs e)
        {
            frmFind frm = new frmFind(new ucApplication(), clsLocalDrivingLicenseApplication_BLL.FindByLocaLicenseApplicationlID);
            frm?.ShowDialog();
            tbID.Text = frm?.SelectedID;

        }
    }
}
