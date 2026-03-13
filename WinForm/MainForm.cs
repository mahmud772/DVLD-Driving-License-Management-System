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

        public clsApplicationQuery ApplicationQuery { get; set; }
        public clsLocalDrivingLicenseApplicationQuery LocalLicenseAppQuery { get; set; }
        public clsPersonQuery PersonQuery { get; set; }
        public clsDetainedLicenseQuery DetainedLicenseQuery { get; set; }
        public clsDriverQuery DriverQuery { get; set; }
        public clsLicenseQuery LicenseQuery { get; set; }
        public clsTestAppointmentQuery TestAppointmentQuery { get; set; }
        public clsUserQuery UserQuery { get; set; }
        public clsTestQuery TestQuery { get; set; }
        private clsContextDisplay _context { get; set; }
        public MainForm()
        {
            InitializeComponent();
            _LoadDesign();

        }

        private void Form1_Load(object sender, EventArgs e)
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
            _context = new clsContextDisplay(this, dgvDisplay, flpUserControls,
                SharedContextMenu , _uiActionsManager ,
                new clsDisplayUIManager(cbSearchBy , lbTotalType_Titel , lbTotalCount, pbTotal , btnFLP , btnDGV));
            _currentQuery = PersonQuery;
            _display = new clsPeopleDisplay(PersonQuery, _context);
            dgvDisplay.ContextMenuStrip = SharedContextMenu;
            _display.Display();
        }
        
        private void _LoadDesign()
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
            using (var tempImage = Image.FromFile(@"C:\Users\m9816\Desktop\C#\DVLD\WinForm\Images\TopBackground.png"))
            {
                pnlTopForm.BackgroundImage = new Bitmap(tempImage);
            }
            using (var tempImage = Image.FromFile(@"C:\Users\m9816\Desktop\DVLD\WinForm\Images\BackgroundMainForm.jpg"))
            {
                pnlMainMenu.BackgroundImage = new Bitmap(tempImage);
            }
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
            _display = new clsPeopleDisplay(PersonQuery, _context);
            _display.Display();

        }


        private void btnUsers_Click(object sender, EventArgs e)
        {
            _currentQuery = UserQuery;
            _display = new clsUsersDisplay(UserQuery, _context);
            _display.Display();
        }

        private void btnDrivers_Click(object sender, EventArgs e)
        {
            _currentQuery = DriverQuery;
            _display = new clsDriversDisplay(DriverQuery, _context);
            _display.Display();
        }


        private void btnApplications_Click(object sender, EventArgs e)
        {
            _currentQuery = ApplicationQuery;
            _display = new clsDisplayApplications(ApplicationQuery, _context);
            _display.Display();
        }

        private void btnTestAppointments_Click(object sender, EventArgs e)
        {
            _currentQuery = TestAppointmentQuery;
            _display = new clsTestAppointmentsDisplay(TestAppointmentQuery, _context);
            _display.Display();
        }

        private void btnLicenses_Click(object sender, EventArgs e)
        {
            _currentQuery = LicenseQuery;
            _display = new clsLicensesDisplay(LicenseQuery, _context);
            _display.Display();
        }
        private void btnLocalLicenseApp_Click(object sender, EventArgs e)
        {
            _currentQuery = LocalLicenseAppQuery;
            _display = new clsLocalDrivingLicenseApplicationsDisplay(LocalLicenseAppQuery, _context);
            _display.Display();
        }

        private void btnInternationalLicenses_Click(object sender, EventArgs e)
        {
            _currentQuery = LicenseQuery;
            _display = new clsInternationalLicensesDisplay(LicenseQuery, _context);
            _display.Display();
        }

        private void btnDetainedLicenses_Click(object sender, EventArgs e)
        {
            _currentQuery = DetainedLicenseQuery;
            _display = new clsDetaindLicensesDisplay(DetainedLicenseQuery, _context);
            _display.Display();
        }

        private void btnTests_Click(object sender, EventArgs e)
        {
            _currentQuery = TestQuery;
            _display = new clsTestDisplay(TestQuery , _context);
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
