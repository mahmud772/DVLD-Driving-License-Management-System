using DVLDWinForm;
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
using static Common.clsApplicationEnums;

namespace DVLDWinForm.User_Controls
{
    public partial class ucTestAppointment : UserControl
    {
        private clsTestAppointment_DTO _AppointmentInfo;

        public clsTestAppointment_DTO AppointmentInfo
        {
            get => _AppointmentInfo;
            set
            {
                _AppointmentInfo = value;
                _SetAppointmentInfo(value);
            }
        }
        public ucTestAppointment()
        {
            InitializeComponent();
            clsUIHelper.CornerRadius(this, 25);
        }
        

        private void _SetAppointmentInfo(clsTestAppointment_DTO AppointmentInfo)
        {
            if (AppointmentInfo == null)
            {
                MessageBox.Show("This is Appointment Is Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lbAppointmentID.Text = AppointmentInfo.TestAppointmentID.ToString();
            lbTestID.Text = AppointmentInfo.TestAppointmentID.ToString();
            lbAppointmentDate.Text = AppointmentInfo.AppointmentDate.ToString("yyyy/MM/dd");
            lbTestType.Text = clsTestType_BLL.GetTestTypeTitle(AppointmentInfo.TestTypeID);
            lbTestResult.Text = AppointmentInfo.RetakeTestApplicationID.ToString();
            lbPaidFees.Text = AppointmentInfo.PaidFees.ToString();
            clsUIHelper.FitText(lbTestType, 7.0f);

            //MainForm.CRUDController.PrepareUpdate = Person => new frmAddNew_UpdatePerson(Person as clsPerson_DTO);
            MainForm.CRUDController.TryDelete = clsTestAppointment_BLL.DeleteTestAppointment;
        }

        private void btnUpdate_Delete_Click(object sender, EventArgs e)
        {
            MainForm.CRUDController?.DTO = this.AppointmentInfo;
            MainForm.SharedContextMenu?.Show(btnUpdate_Delete, new Point(0, btnUpdate_Delete.Height));
        }
    }
}
