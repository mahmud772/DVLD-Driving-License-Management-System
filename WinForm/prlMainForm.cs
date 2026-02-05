using DVLD_BLL;
using DVLD_DTO;
using DVLD_Models;
using DVLDWinForm;
using DVLDWinForm.Forms;
using DVLDWinForm.User_Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDWinForm
{
    public partial class MainForm : Form
    {
        private void _LoadPeople()
        {
            CRUDController.CreateForm = () => new frmAddNew_UpdatePerson();
            CRUDController.PrepareUpdate = Person => new frmAddNew_UpdatePerson(Person as clsPerson_DTO);
            CRUDController.TryDelete = clsPerson_BLL.DeletePerson;
            //CRUDController.Search = clsPerson_BLL.Find;
            CRUDController.iUserControl = new ucPerson();
            _InitializeAdapter(clsPerson_BLL.GetPeople,
                clsPerson_BLL.GetCount,
                _GetDisplayView<clsPerson_DTO>(person => new ucPerson { PersonInfo = person })
            );

        }

        private void _LoadUsers()
        {
            CRUDController.TryDelete = clsUser_BLL.DeleteUser;
            //CRUDController.Search = clsUser_BLL.Find;
            _InitializeAdapter(clsUser_BLL.GetUsers,
               clsUser_BLL.GetCount,
               _GetDisplayView<clsUser_DTO>(user => new ucUser { UserInfo = user }));
        }
        private void _LoadDrivers()
        {
            CRUDController.TryDelete = clsDriver_BLL.DeleteDriver;
            //CRUDController.Search = clsDriver_BLL.FindByID;
            _InitializeAdapter(clsDriver_BLL.GetDrivers,
               clsDriver_BLL.GetCount,
               _GetDisplayView<clsDriver_DTO>(driver => new ucDriver { DriverInfo = driver }));
        }
        private void _LoadApplications()
        {
            CRUDController.CreateForm = () => new frmCreateApplication();

            //CRUDController.PrepareUpdate = Application => new frmUpdateApplication(Application as clsApplication_DTO);

            CRUDController.TryDelete = clsApplication_BLL.DeleteApplication;
            //CRUDController.Search = clsApplication_BLL.FindByApplicationID;
            _InitializeAdapter(clsApplication_BLL.GetApplications,
               clsApplication_BLL.GetCount,
               _GetDisplayView<clsApplication_DTO>(application => new ucApplication { ApplicationInfo = application }));
        }
        private void _LoadDetaindLicenses()
        {
            CRUDController.TryDelete = clsDetainedLicense_BLL.DeleteDetain;
            //CRUDController.Search = clsDetainedLicense_BLL.FindByDetainID;
            _InitializeAdapter(clsDetainedLicense_BLL.GetDetainedLicensesCardsInfo,
               clsDetainedLicense_BLL.GetCount,
               _GetDisplayView<clsLicenseCardInfo_DTO>(license => new ucLicense { LicenseInfo = license }));
        }
        private void _LoadInternationalLicenses()
        {
            CRUDController.TryDelete = clsInternationalLicense_BLL.DeleteInternationalLicense;
            //CRUDController.Search = clsInternationalLicense_BLL.FindByID;
            _InitializeAdapter(clsInternationalLicense_BLL.GetInternationalLicensesCardsInfo,
               clsInternationalLicense_BLL.GetCount,
               _GetDisplayView<clsLicenseCardInfo_DTO>(license => new ucLicense { LicenseInfo = license }));
        }
        private void _LoadLicenses()
        {
            //CRUDController.CreateForm = () => new frmAddNewLicense();
            //CRUDController.PrepareUpdate = License => new frmAddNew_UpdateAppointment(License as clsTestAppointment_DTO);
            CRUDController.TryDelete = clsLicense_BLL.DeleteLicense;
            //CRUDController.Search = clsLicense_BLL.GetLicenseCardInfo;
            _InitializeAdapter(clsLicense_BLL.GetLicensesCardsInfo,
               clsLicense_BLL.GetCount,
               _GetDisplayView<clsLicenseCardInfo_DTO>(license => new ucLicense { LicenseInfo = license }));
        }

        private void _LoadLocalDrivingLicenseApplications()
        {
            CRUDController.CreateForm = () => new frmCreateApplication();
            //CRUDController.PrepareUpdate = Application => new frmUpdateApplication(Application as clsLocalDrivingLicenseApplication_DTO);
            CRUDController.TryDelete = clsLocalDrivingLicenseApplication_BLL.DeleteLocalDrivingLicenseApplicationByApplicationID;
            //CRUDController.Search = clsLocalDrivingLicenseApplication_BLL.FindByLocaLicenseApplicationlID;
            _InitializeAdapter(clsLocalDrivingLicenseApplication_BLL.GetLocalDrivingLicenseApplications,
               clsLocalDrivingLicenseApplication_BLL.GetCount,
               _GetDisplayView<clsLocalDrivingLicenseApplication_DTO>(application => new ucApplication { ApplicationInfo = application }));
        }
        private void _LoadTestAppointment()
        {

            //CRUDController.CreateForm = () => new frmAddNew_UpdateAppointment();
            //CRUDController.PrepareUpdate = Appointment => new frmAddNew_UpdateAppointment(Appointment as clsTestAppointment_DTO);
            CRUDController.TryDelete = clsTestAppointment_BLL.DeleteTestAppointment;
            //CRUDController.Search = clsTestAppointment_BLL.FindByID;
            _InitializeAdapter(clsTestAppointment_BLL.GetTestAppointments,
               clsTestAppointment_BLL.GetCount,
               _GetDisplayView<clsTestAppointment_DTO>(Appointment => new ucTestAppointment { AppointmentInfo = Appointment }));
        }
    }
}
