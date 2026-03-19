using Common;
using Common.Enums;
using Common.Helpers;
using Common.Queries;
using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm.Display;
using DVLDWinForm.UIHelper;
using DVLDWinForm.UIHelper_Manger;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLDWinForm
{

    public partial class MainForm : Form , IPaginationView
    {
        private IQuery _currentQuery;
        private IDisplay _display;
        public static ContextMenuStrip SharedContextMenu { get; private set; }
        private clsUIActionsManager _uiActionsManager;

        private clsApplicationQuery ApplicationQuery { get; set; }
        private clsLocalDrivingLicenseApplicationQuery LocalLicenseAppQuery { get; set; }
        private clsPersonQuery PersonQuery { get; set; }
        private clsDetainedLicenseQuery DetainedLicenseQuery { get; set; }
        private clsDriverQuery DriverQuery { get; set; }
        private clsLicenseQuery LicenseQuery { get; set; }
        private clsTestAppointmentQuery TestAppointmentQuery { get; set; }
        private clsUserQuery UserQuery { get; set; }
        private clsTestQuery TestQuery { get; set; }
        private clsContextDisplay _contextDisplay { get; set; }
        public MainForm()
        {
            InitializeComponent();
            LoadDesign();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SharedContextMenu = new ContextMenuStrip();
            _uiActionsManager = new clsUIActionsManager();
            ApplicationQuery = new clsApplicationQuery();
            LocalLicenseAppQuery = new clsLocalDrivingLicenseApplicationQuery();
            PersonQuery = new clsPersonQuery();
            DriverQuery = new clsDriverQuery();
            LicenseQuery = new clsLicenseQuery();
            UserQuery = new clsUserQuery();
            TestAppointmentQuery = new clsTestAppointmentQuery();
            DetainedLicenseQuery = new clsDetainedLicenseQuery();
            TestQuery = new clsTestQuery();
            _contextDisplay = new clsContextDisplay(this, dgvDisplay, flpUserControls,
                SharedContextMenu, _uiActionsManager,
                new clsDisplayUIManager(cbSearchBy, lbTotalType_Titel, lbTotalCount, pbTotal, btnFLP, btnDGV));
            _currentQuery = PersonQuery;
            _display = new clsPeopleDisplay(PersonQuery, _contextDisplay);
            dgvDisplay.ContextMenuStrip = SharedContextMenu;
            _display.Display();
        }
        private void LoadDesign()
        {
            clsUIHelper.CornerRadius(pnlMainMenu, 25);
            clsUIHelper.CornerRadius(pnlTopForm, 25);
            clsUIHelper.CornerRadius(pnlDisplayMethod, 15);
            clsUIHelper.CornerRadius(pnlShowTotal, 5);
            clsUIHelper.CornerRadius(btnPeople, 5);
            clsUIHelper.CornerRadius(btnDrivers, 5);
            clsUIHelper.CornerRadius(btnApplications, 5);
            clsUIHelper.CornerRadius(btnLocalLicenseApp, 5);
            clsUIHelper.CornerRadius(btnTestAppointments, 5);
            clsUIHelper.CornerRadius(btnTests, 5);
            clsUIHelper.CornerRadius(btnDetainedLicenses, 5);
            clsUIHelper.CornerRadius(btnInternationalLicenses, 5);
            clsUIHelper.CornerRadius(btnLicenses, 5);
            
        }

        public void SetPageNumber(int pageNumber) => lbPageNumber.Text = pageNumber.ToString();
        

        public void SetNextButtonVisible(bool visible) => btnNextPage.Visible = visible;
        

        public void SetPreviousButtonVisible(bool visible) => btnPreviousPage.Visible = visible;
        


        private void btnFLP_Click(object sender, EventArgs e) => _display.ShowFLP();
        

        private void btnDGV_Click(object sender, EventArgs e) => _display.ShowDGV();
        

        private void btnNextPage_Click(object sender, EventArgs e) => _display.NextPage();
        

        private void btnPreviousPage_Click(object sender, EventArgs e) => _display.PreviousPage();


        private void btnPeople_Click(object sender, EventArgs e)
        {
            _currentQuery = PersonQuery;
            _display = new clsPeopleDisplay(PersonQuery, _contextDisplay);
            _display.Display();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            _currentQuery = UserQuery;
            _display = new clsUsersDisplay(UserQuery, _contextDisplay);
            _display.Display();
        }

        private void btnDrivers_Click(object sender, EventArgs e)
        {
            _currentQuery = DriverQuery;
            _display = new clsDriversDisplay(DriverQuery, _contextDisplay);
            _display.Display();
        }


        private void btnApplications_Click(object sender, EventArgs e)
        {
            _currentQuery = ApplicationQuery;
            _display = new clsDisplayApplications(ApplicationQuery, _contextDisplay);
            _display.Display();
        }

        private void btnTestAppointments_Click(object sender, EventArgs e)
        {
            _currentQuery = TestAppointmentQuery;
            _display = new clsTestAppointmentsDisplay(TestAppointmentQuery, _contextDisplay);
            _display.Display();
        }

        private void btnLicenses_Click(object sender, EventArgs e)
        {
            _currentQuery = LicenseQuery;
            _display = new clsLicensesDisplay(LicenseQuery, _contextDisplay);
            _display.Display();
        }
        private void btnLocalLicenseApp_Click(object sender, EventArgs e)
        {
            _currentQuery = LocalLicenseAppQuery;
            _display = new clsLocalDrivingLicenseApplicationsDisplay(LocalLicenseAppQuery, _contextDisplay);
            _display.Display();
        }

        private void btnInternationalLicenses_Click(object sender, EventArgs e)
        {
            _currentQuery = LicenseQuery;
            _display = new clsInternationalLicensesDisplay(LicenseQuery, _contextDisplay);
            _display.Display();
        }

        private void btnDetainedLicenses_Click(object sender, EventArgs e)
        {
            _currentQuery = DetainedLicenseQuery;
            _display = new clsDetaindLicensesDisplay(DetainedLicenseQuery, _contextDisplay);
            _display.Display();
        }

        private void btnTests_Click(object sender, EventArgs e)
        {
            _currentQuery = TestQuery;
            _display = new clsTestDisplay(TestQuery , _contextDisplay);
            _display.Display();
        }
        private void dgvData_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvDisplay.ClearSelection();
                dgvDisplay.Rows[e.RowIndex].Selected = true;
                dgvDisplay.CurrentCell = dgvDisplay.Rows[e.RowIndex].Cells[0];
            }
        }
        
        private void btnAddNew_Click(object sender, EventArgs e) =>
            _uiActionsManager.Execute(clsUIEnums.enUIAction.AddNew ,null , _display.Refresh);
        
        private void btnSort_Filter_Click(object sender, EventArgs e) =>
            _uiActionsManager.Execute(clsUIEnums.enUIAction.Filter, null , _display.Refresh);
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int ID;
            int.TryParse(tbSearch.Text, out ID);
            _currentQuery.SearchBy = (Enum)cbSearchBy.SelectedItem;
            _currentQuery.SearchValue = clsSearchType.IsTypeEnumString(_currentQuery.SearchBy) ?
                ID : tbSearch.Text;
            _display.Display();
            _currentQuery.SearchValue = null;
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick(); 
                e.SuppressKeyPress = true; 
            }
        }

        
    }
}
