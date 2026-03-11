using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm.Forms;
using DVLDWinForm.UIHelper;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLDWinForm.User_Controls
{
    public partial class ucTestAppointment : UserControl , IUserControl
    {
        private clsTestAppointment_DTO _AppointmentInfo;
        ContextMenuStrip _sharedContextMenu;
        public clsTestAppointment_DTO AppointmentInfo
        {
            get => _AppointmentInfo;
            set
            {
                _AppointmentInfo = value;
                _SetAppointmentInfo(value);
            }
        }
        public IDTO Info { get => _AppointmentInfo; set => AppointmentInfo = value as clsTestAppointment_DTO; }
        public ucTestAppointment()
        {
            InitializeComponent();
            clsUIHelper.CornerRadius(this, 25);
            clsUIHelper.CornerRadius(pnlMoreInfo, 25);
            clsUIHelper.CornerRadius(pnlIDs, 25);
        }
        public ucTestAppointment(ContextMenuStrip SharedContextMenu)
        {
            InitializeComponent();
            _sharedContextMenu = SharedContextMenu;
            Design();
        }
        
        private void Design()
        {
            clsUIHelper.CornerRadius(this, 25);
            clsUIHelper.CornerRadius(pnlMoreInfo, 25);
            clsUIHelper.CornerRadius(pnlIDs, 25);
            if (_sharedContextMenu == null)
                btnUpdate_Delete.Visible = false;
        }
        private void _SetAppointmentInfo(clsTestAppointment_DTO AppointmentInfo)
        {
            if (AppointmentInfo == null)
            {
                //MessageBox.Show("This is Appointment Is Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lbAppointmentID.Text = AppointmentInfo.TestAppointmentID.ToString();
            lbLocalLicenseAppID.Text = AppointmentInfo.LocalDrivingLicenseApplicationID.ToString();
            lbAppointmentDate.Text = AppointmentInfo.AppointmentDate.ToString("yyyy/MM/dd");
            lbTestType.Text = clsTestType_BLL.GetTestTypeTitle(AppointmentInfo.TestTypeID).Split(' ')[0];
            lbStatus.Text = AppointmentInfo.IsLocked ? "Locked" : "Unlocked";
            lbPaidFees.Text = AppointmentInfo.PaidFees.ToString();
            clsUIHelper.FitText(lbTestType, 7.0f);

        }

        private void btnUpdate_Delete_Click(object sender, EventArgs e)
        {
            _sharedContextMenu.Tag = this.AppointmentInfo;
            _sharedContextMenu?.Show(btnUpdate_Delete, new Point(0, btnUpdate_Delete.Height));
        }
    }
}
