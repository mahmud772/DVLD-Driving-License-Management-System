using Common;
using Common.Queries;
using DVLD_BLL;
using DVLD_DTO;
using DVLD_Models;
using DVLDWinForm;
using DVLDWinForm.Forms;
using DVLDWinForm.Tests;
using DVLDWinForm.UIHelper;
using DVLDWinForm.UIHelper_Manger;
using DVLDWinForm.User_Controls;
using DVLDWinForm.User_Controls.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDWinForm
{

    public partial class MainForm : Form
    {
        private IPageableLoader _currentLoader;
        private clsPaginationManager _paginator;
        enum enDisplayMode { FLP = 1, DGV = 2 }
        enDisplayMode DisplayMode = enDisplayMode.FLP;
        private Action LoadType;

        public static clsCRUDController CRUDController { get; set; }
        public static ContextMenuStrip SharedContextMenu { get; private set; }


        public  clsApplicationQuery ApplicationQuery { get; set; }
        public  clsPersonQuery PersonQuery { get; set; }
        public  clsDetainedLicenseQuery DetainedLicenseQuery { get; set; }
        public  clsDriverQuery DriverQuery { get; set; }
        public  clsLicenseQuery LicenseQuery { get; set; }
        public  clsTestAppointmentQuery TestAppointmentQuery { get; set; }
        public  clsUserQuery UserQuery { get; set; }
        
        
        public MainForm()
        {
            InitializeComponent();
            _LoadDesign();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            clsStaticData_BLL.LoadAllStaticData();
            SharedContextMenu = this.cmsUpdate_Delete;
            CRUDController = new clsCRUDController(dgvDisplay, flpUserControls);
            LoadType = _LoadPeople;
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
            using (var tempImage = System.Drawing.Image.FromFile(@"C:\Users\m9816\Desktop\C#\DVLD\WinForm\Images\TopBackground.png"))
            {
                pnlTopForm.BackgroundImage = new Bitmap(tempImage);
            }

        }

        private void pnlMainMenu_Paint(object sender, PaintEventArgs e)
        {
            //clsUIHelper.ApplyGradient(pnlMainMenu,e, Color.FromArgb(236, 240, 241), Color.FromArgb(189, 195, 199), 45F);
        }

        private void pnlTopForm_Paint(object sender, PaintEventArgs e)
        {
            //clsUIHelper.ApplyGradient(pnlTopForm, e, Color.FromArgb(236, 240, 241), Color.FromArgb(189, 195, 199), 45F);

        }


        private void _InitializeAdapter<T>(Func<int, int, List<T>> fetcher, Func<int> counter, IDisplayView<T> viewManager)
        {
            _currentLoader = new clsDataDisplayAdapter<T>(fetcher, counter, viewManager);

            _paginator = new clsPaginationManager(viewManager.CountItems, _currentLoader.GetTotalCount());

            _LoadData();
        }
        private void _LoadData()
        {
            _currentLoader.LoadPage(_paginator.Offset, _paginator.PageSize);
            _UpdateUI();
        }
        private void _UpdateUI()
        {
            lbPageNumber.Text = _paginator.CurrentPage.ToString();
            btnNextPage.Visible = _paginator.HasNextPage;
            btnPreviousPage.Visible = _paginator.HasPreviousPage;
        }
        private void _ShowDGV()
        {
            btnFLP.BackgroundImage = DVLDWinForm.Properties.Resources.Menu_Gray_FLP;
            btnDGV.BackgroundImage = DVLDWinForm.Properties.Resources.Menu_RGB_DGV;
            DisplayMode = enDisplayMode.DGV;
            flpUserControls.Visible = false;
            dgvDisplay.Visible = true;
            LoadType?.Invoke();

        }
        private void _ShowFLP()
        {
            btnFLP.BackgroundImage = DVLDWinForm.Properties.Resources.Menu_RGB_FLP;
            btnDGV.BackgroundImage = DVLDWinForm.Properties.Resources.Menu_Gray_DGV;
            DisplayMode = enDisplayMode.FLP;
            flpUserControls.Visible = true;
            dgvDisplay.Visible = false;
            LoadType?.Invoke();

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
            if (_paginator.HasNextPage)
            {
                _paginator.NextPage();
                _LoadData();
            }

        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {

            if (_paginator.HasPreviousPage)
            {
                _paginator.PreviousPage();
                _LoadData();
            }
        }




        private IDisplayView<T> _GetDisplayView<T>(Func<T, UserControl> ControlCeartor)
        {
            return DisplayMode == enDisplayMode.DGV ?
                new clsDGVManager<T>(dgvDisplay) :
                new clsFLPManager<T>
                (flpUserControls, ControlCeartor);
        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            LoadType = _LoadPeople;
            _ShowFLP();
        }
        

        private void btnUsers_Click(object sender, EventArgs e)
        {

            LoadType = _LoadUsers;
            _ShowFLP();
        }

        private void btnDrivers_Click(object sender, EventArgs e)
        {
            LoadType = _LoadDrivers;
            _ShowFLP();
        }


        private void btnApplications_Click(object sender, EventArgs e)
        {
            LoadType = _LoadApplications;
            _ShowFLP();
        }

        private void btnTestAppointments_Click(object sender, EventArgs e)
        {
            LoadType = _LoadTestAppointment;
            _ShowFLP();
        }

        private void btnLicenses_Click(object sender, EventArgs e)
        {
            LoadType = _LoadLicenses;
            _ShowFLP();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            CRUDController.ShowCreateForm();
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

        public void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CRUDController.ShowUpdateForm();
        }

        public void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CRUDController.ConfirmAndDelete();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //CRUDController.ShowDTO(Convert.ToInt32(tbSearch?.Text));
        }

        private void btnSort_Filter_Click(object sender, EventArgs e)
        {
            frmSortAndFilter frm = new frmSortAndFilter(new ucApplicationsFilter() , ApplicationQuery );
            frm.ShowDialog();
        }
    }
}
