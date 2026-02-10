using Common;
using Common.Enums;
using Common.Queries;
using DVLD_BLL;
using DVLD_DTO;
using DVLD_Models;
using DVLDWinForm;
using DVLDWinForm.Forms;
using DVLDWinForm.Forms.Add_New___Update;
using DVLDWinForm.Forms.Add_New___Update.Add_New;
using DVLDWinForm.Forms.Add_New___Update.Update;
using DVLDWinForm.User_Controls;
using DVLDWinForm.User_Controls.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DVLDWinForm
{
    public partial class MainForm 
    {
        private void _LoadPeople()
        {
            _currentQuery = PersonQuery;
            CRUDController.CreateForm = () => new frmAddNew_UpdatePerson();
            CRUDController.PrepareUpdate = Person => new frmAddNew_UpdatePerson(Person as clsPerson_DTO);
            CRUDController.TryDelete = clsPerson_BLL.DeletePerson;
            CRUDController.Search = () => new frmSortAndFilter(new ucPeopleFilter(),PersonQuery);
            CRUDController.iUserControl = new ucPerson();
            cbSearchBy.DataSource = Enum.GetValues(typeof(clsPersonEnums.enPersonSearchBy));

            _InitializeAdapter(clsPerson_BLL.GetPeople,
                clsPerson_BLL.GetCount,
                _GetDisplayView<clsPerson_DTO>(person => new ucPerson { PersonInfo = person })
            );
            lbTotalType_Titel.Text = "People";
            lbTotalCount.Text = _paginator.TotalItems.ToString();
            pbTotal.Image = Properties.Resources.People;
        }

        private void _LoadUsers()
        {
            _currentQuery = UserQuery;
            CRUDController.TryDelete = clsUser_BLL.DeleteUser;
            CRUDController.Search = () => new frmSortAndFilter(new ucUsersFilter(), UserQuery);
            cbSearchBy.DataSource = Enum.GetValues(typeof(clsUserEnums.enUserSearchBy));
            CRUDController.CreateForm = () => new frmAddNew_UpdateUser();
            CRUDController.PrepareUpdate = User => new frmAddNew_UpdateUser(User as clsUser_DTO);
            _InitializeAdapter(clsUser_BLL.GetUsers,
               clsUser_BLL.GetCount,
               _GetDisplayView<clsUser_DTO>(user => new ucUser { UserInfo = user }));
            lbTotalType_Titel.Text = "Users";
            lbTotalCount.Text = _paginator.TotalItems.ToString();
            pbTotal.Image = Properties.Resources.Users;
        }
        private void _LoadDrivers()
        {
            _currentQuery = DriverQuery;
            CRUDController.TryDelete = clsDriver_BLL.DeleteDriver;
            CRUDController.Search = () => new frmSortAndFilter(new ucDriversFilter(), DriverQuery);
            cbSearchBy.DataSource = Enum.GetValues(typeof(clsDriverEnums.enDriverSearchBy));

            CRUDController.CreateForm = () => new frmAddNew_UpdateDriver();
            CRUDController.PrepareUpdate = Driver => new frmAddNew_UpdateDriver(Driver as clsDriver_DTO);
            _InitializeAdapter(clsDriver_BLL.GetDrivers,
               clsDriver_BLL.GetCount,
               _GetDisplayView<clsDriver_DTO>(driver => new ucDriver { DriverInfo = driver }));
            lbTotalType_Titel.Text = "Drivers";
            lbTotalCount.Text = _paginator.TotalItems.ToString();
            pbTotal.Image = Properties.Resources.Drivers;
        }
        private void _LoadApplications()
        {
            _currentQuery = ApplicationQuery;
            CRUDController.CreateForm = () => new frmCreateApplication();

            CRUDController.PrepareUpdate = Application => new frmUpdateApplication(Application as clsApplication_DTO);

            CRUDController.TryDelete = clsApplication_BLL.DeleteApplication;
            CRUDController.Search = () => new frmSortAndFilter(new ucApplicationsFilter(), ApplicationQuery);
            cbSearchBy.DataSource = Enum.GetValues(typeof(clsApplicationEnums.enApplicationSearchBy));

            _InitializeAdapter(clsApplication_BLL.GetApplications,
               clsApplication_BLL.GetCount,
               _GetDisplayView<clsApplication_DTO>(application => new ucApplication { ApplicationInfo = application }));
            
            lbTotalType_Titel.Text = "Applications";
            lbTotalCount.Text = _paginator.TotalItems.ToString();
            pbTotal.Image = Properties.Resources.Applications;
        }
        private void _LoadDetaindLicenses()
        {
            _currentQuery = DetainedLicenseQuery;
            CRUDController.TryDelete = clsDetainedLicense_BLL.DeleteDetain;
            CRUDController.Search = () => new frmSortAndFilter(new ucDetainedLicensesFilter(), DetainedLicenseQuery);
            cbSearchBy.DataSource = Enum.GetValues(typeof(clsDetainedLicenseEnums.enDetainedLicenseSearchBy));

            _InitializeAdapter(clsDetainedLicense_BLL.GetDetainedLicensesCardsInfo,
               clsDetainedLicense_BLL.GetCount,
               _GetDisplayView<clsLicenseCardInfo_DTO>(license => new ucLicense { LicenseInfo = license }));
            lbTotalType_Titel.Text = "Detaind Licenses";
            lbTotalCount.Text = _paginator.TotalItems.ToString();
            pbTotal.Image = Properties.Resources.Licenses;
        }
        private void _LoadInternationalLicenses()
        {
            _currentQuery = LicenseQuery;
            CRUDController.TryDelete = clsInternationalLicense_BLL.DeleteInternationalLicense;
            CRUDController.Search = () => new frmSortAndFilter(new ucLicensesFilter(), LicenseQuery);
            cbSearchBy.DataSource = Enum.GetValues(typeof(clsLicenseEnums.enLicenseSearchBy));

            _InitializeAdapter(clsInternationalLicense_BLL.GetInternationalLicensesCardsInfo,
               clsInternationalLicense_BLL.GetCount,
               _GetDisplayView<clsLicenseCardInfo_DTO>(license => new ucLicense { LicenseInfo = license }));
            lbTotalType_Titel.Text = "International Licenses";
            lbTotalCount.Text = _paginator.TotalItems.ToString();
            pbTotal.Image = Properties.Resources.Licenses;
        }
        private void _LoadLicenses()
        {
            _currentQuery = LicenseQuery;
            CRUDController.CreateForm = () => new frmAddNewLicense();
            //CRUDController.PrepareUpdate = License => new frmAddNew_UpdateAppointment(License as clsTestAppointment_DTO);
            CRUDController.TryDelete = clsLicense_BLL.DeleteLicense;
            CRUDController.Search = () => new frmSortAndFilter(new ucLicensesFilter(), LicenseQuery);
            cbSearchBy.DataSource = Enum.GetValues(typeof(clsLicenseEnums.enLicenseSearchBy));

            _InitializeAdapter(clsLicense_BLL.GetLicensesCardsInfo,
               clsLicense_BLL.GetCount,
               _GetDisplayView<clsLicenseCardInfo_DTO>(license => new ucLicense { LicenseInfo = license }));
            lbTotalType_Titel.Text = "Licenses";
            lbTotalCount.Text = _paginator.TotalItems.ToString();
            pbTotal.Image = Properties.Resources.Licenses;
        }

        private void _LoadLocalDrivingLicenseApplications()
        {
            _currentQuery = ApplicationQuery;
            CRUDController.CreateForm = () => new frmCreateApplication();
            CRUDController.PrepareUpdate = Application => new frmUpdateApplication(Application as clsLocalDrivingLicenseApplication_DTO);
            CRUDController.TryDelete = clsLocalDrivingLicenseApplication_BLL.DeleteLocalDrivingLicenseApplicationByApplicationID;
            CRUDController.Search = () => new frmSortAndFilter(new ucLocalDrivingLicenseApplicationsFilter(), ApplicationQuery);
            cbSearchBy.DataSource = Enum.GetValues(typeof(clsApplicationEnums.enApplicationSearchBy));

            _InitializeAdapter(clsLocalDrivingLicenseApplication_BLL.GetLocalDrivingLicenseApplications,
               clsLocalDrivingLicenseApplication_BLL.GetCount,
               _GetDisplayView<clsLocalDrivingLicenseApplication_DTO>(application => new ucApplication { ApplicationInfo = application }));
            lbTotalType_Titel.Text = "Local License App";
            lbTotalCount.Text = _paginator.TotalItems.ToString();
            pbTotal.Image = Properties.Resources.Applications;
        }
        private void _LoadTestAppointment()
        {
            _currentQuery = TestAppointmentQuery;
            CRUDController.CreateForm = () => new frmAddNew_UpdateAppointment();
            CRUDController.PrepareUpdate = Appointment => new frmAddNew_UpdateAppointment(Appointment as clsTestAppointment_DTO);
            CRUDController.TryDelete = clsTestAppointment_BLL.DeleteTestAppointment;
            CRUDController.Search = () => new frmSortAndFilter(new ucTestAppointmentsFilter(), TestAppointmentQuery);
            cbSearchBy.DataSource = Enum.GetValues(typeof(clsTestEnums.enTestAppointmentSearchBy));

            _InitializeAdapter(clsTestAppointment_BLL.GetTestAppointments,
               clsTestAppointment_BLL.GetCount,
               _GetDisplayView<clsTestAppointment_DTO>(Appointment => new ucTestAppointment { AppointmentInfo = Appointment }));
            lbTotalType_Titel.Text = "Test Appointment";
            lbTotalCount.Text = _paginator.TotalItems.ToString();
            pbTotal.Image = Properties.Resources.TestAppointment;
        }
    }
}
