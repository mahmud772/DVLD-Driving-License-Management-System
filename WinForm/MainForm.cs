using Common.Helpers;
using Common.Queries;
using DVLD_BLL;
using DVLDWinForm.Display;
using DVLDWinForm.UIHelper;
using DVLDWinForm.UIHelper_Manger;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using static DVLDWinForm.UIHelper_Manger.clsEnums;

namespace DVLDWinForm
{

    public partial class MainForm : Form , IPaginationView
    {
        private IQuery _currentQuery;
        enDisplayMode DisplayMode = enDisplayMode.FLP;
        private IDisplay _display;
        public static clsCRUDController CRUDController { get; set; }
        public static ContextMenuStrip SharedContextMenu { get; private set; }


        public clsApplicationQuery ApplicationQuery { get; set; }
        public clsPersonQuery PersonQuery { get; set; }
        public clsDetainedLicenseQuery DetainedLicenseQuery { get; set; }
        public clsDriverQuery DriverQuery { get; set; }
        public clsLicenseQuery LicenseQuery { get; set; }
        public clsTestAppointmentQuery TestAppointmentQuery { get; set; }
        public clsUserQuery UserQuery { get; set; }

        private clsContextDisplay _context { get; set; }
        public MainForm()
        {
            InitializeComponent();
            _LoadDesign();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            SharedContextMenu = this.cmsUpdate_Delete;
            CRUDController = new clsCRUDController(dgvDisplay, flpUserControls);
            ApplicationQuery = new clsApplicationQuery();
            PersonQuery = new clsPersonQuery();
            DriverQuery = new clsDriverQuery();
            LicenseQuery = new clsLicenseQuery();
            UserQuery = new clsUserQuery();
            TestAppointmentQuery = new clsTestAppointmentQuery();
            DetainedLicenseQuery = new clsDetainedLicenseQuery();
            CRUDController.Refresh = _Refresh;
            _context = new clsContextDisplay(this, dgvDisplay, flpUserControls, CRUDController , SharedContextMenu);
            _currentQuery = PersonQuery;
            _display = new clsPeopleDisplay(PersonQuery, _context);
            _ShowFLP();
            //Test1 form1 = new Test1();
            //form1.ShowDialog();


            //Test1 form1 = new Test1();
            //form1.ShowDialog();
            //btnDGV.Parent = btnFLP;
            //btnDGV.Location = new Point(10, 10);


        }
        
        private void _LoadDesign()
        {
            clsUIHelper.CornerRadius(pnlMainMenu, 25);
            clsUIHelper.CornerRadius(pnlTopForm, 25);
            //clsUIHelper.CornerRadius(pnlMain, 25);
            clsUIHelper.CornerRadius(pnlDisplayMethod, 15);
            clsUIHelper.CornerRadius(pnlTypes, 15);
            clsUIHelper.CornerRadius(btnPeople, 5);
            clsUIHelper.CornerRadius(btnUsers, 5);
            clsUIHelper.CornerRadius(btnDrivers, 5);
            clsUIHelper.CornerRadius(pnlShowTotal, 5);
            using (var tempImage = Image.FromFile(@"C:\Users\m9816\Desktop\C#\DVLD\WinForm\Images\TopBackground.png"))
            {
                pnlTopForm.BackgroundImage = new Bitmap(tempImage);
            }
        }
        private void _Refresh()
        {
            _display.Load(DisplayMode, _currentQuery);
        }

        public void SetPageNumber(int pageNumber)
        {
            lbPageNumber.Text = pageNumber.ToString();
        }

        public void SetNextButtonVisible(bool visible)
        {
            btnNextPage.Visible = visible;
        }

        public void SetPreviousButtonVisible(bool visible)
        {
            btnPreviousPage.Visible = visible;
        }
        private void _ShowDGV()
        {
            btnFLP.BackgroundImage = Properties.Resources.Menu_Gray_FLP;
            btnDGV.BackgroundImage = Properties.Resources.Menu_RGB_DGV;
            DisplayMode = enDisplayMode.DGV;
            flpUserControls.Visible = false;
            dgvDisplay.Visible = true;
            _display.Load(DisplayMode , _currentQuery);
            _display.UpdateUI(cbSearchBy, lbTotalType_Titel, lbTotalCount, pbTotal);
            _display.InitializeCRUDController();
        }
        private void _ShowFLP()
        {
            btnFLP.BackgroundImage = Properties.Resources.Menu_RGB_FLP;
            btnDGV.BackgroundImage = Properties.Resources.Menu_Gray_DGV;
            DisplayMode = enDisplayMode.FLP;
            flpUserControls.Visible = true;
            dgvDisplay.Visible = false;
            _display.Load(DisplayMode, _currentQuery);
            _display.UpdateUI(cbSearchBy, lbTotalType_Titel, lbTotalCount, pbTotal);
            _display.InitializeCRUDController();
        }

        private void btnFLP_Click(object sender, EventArgs e)
        {

            _ShowFLP();
        }

        private void btnDGV_Click(object sender, EventArgs e)
        {

            _ShowDGV();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            _display.NextPage();
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            _display.PreviousPage();
        }



        private void btnPeople_Click(object sender, EventArgs e)
        {
            _currentQuery = PersonQuery;
            _display = new clsPeopleDisplay(PersonQuery, _context);
            _ShowFLP();
        }


        private void btnUsers_Click(object sender, EventArgs e)
        {
            _currentQuery = UserQuery;
            _display = new clsUsersDisplay(UserQuery, _context);
            _ShowFLP();
        }

        private void btnDrivers_Click(object sender, EventArgs e)
        {
            _currentQuery = DriverQuery;
            _display = new clsDriversDisplay(DriverQuery, _context);
            _ShowFLP();
        }


        private void btnApplications_Click(object sender, EventArgs e)
        {
            _currentQuery = ApplicationQuery;
            _display = new clsDisplayApplications(ApplicationQuery, _context);
            _ShowFLP();
        }

        private void btnTestAppointments_Click(object sender, EventArgs e)
        {
            _currentQuery = TestAppointmentQuery;
            _display = new clsTestAppointmentsDisplay(TestAppointmentQuery, _context);
            _ShowFLP();
        }

        private void btnLicenses_Click(object sender, EventArgs e)
        {
            _currentQuery = LicenseQuery;
            _display = new clsLicensesDisplay(LicenseQuery, _context);
            _ShowFLP();
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
        private void btnAddNew_Click(object sender, EventArgs e) => CRUDController.ShowCreateForm();
        public void updateToolStripMenuItem_Click(object sender, EventArgs e) => CRUDController.ShowUpdateForm();

        public void deleteToolStripMenuItem_Click(object sender, EventArgs e) => CRUDController.ConfirmAndDelete();
        private void btnSort_Filter_Click(object sender, EventArgs e) => CRUDController.ShowFilterForm();
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int ID;
            int.TryParse(tbSearch.Text, out ID);
            _currentQuery.SearchBy = (Enum)cbSearchBy.SelectedItem;
            _currentQuery.SearchValue = clsSearchType.IsTypeEnumString(_currentQuery.SearchBy) ?
                ID : tbSearch.Text;
            _display.Load(DisplayMode, _currentQuery);
            _currentQuery.SearchBy = null;
            _currentQuery.SearchValue = null;
        }


    }
}
