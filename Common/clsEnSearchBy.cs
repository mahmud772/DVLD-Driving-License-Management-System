using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class clsEnSearchBy
    {
        public enum enApplication 
        {
            ApplicationID = 1,
            ApplicantPersonID = 2,
            ApplicationTypeID = 3,
            CreatedByUserID = 4,
            ApplicationStatus = 5,
            ApplicationDate = 6
        }
        public enum enDetainedLicense
        {
            DetainID = 1,
            LicenseID = 2,
            IsReleased = 3,
            CreatedByUserID = 4
        }
        public enum enDriver 
        {
            DriverID = 1,
            CreatedByUserID = 2,
            PersonID = 3,
            NationalNo = 4,
            Gendor = 5,
            NationalityCountryID = 6
        }
        public enum enPerson
        {
            PersonID = 1,
            NationalNo = 2,
            Gendor = 3,
            NationalityCountryID = 4
        }
        public enum enInternationalLicense
        {
            InternationalLicenseID = 1,
            DriverID = 2,
            IsActive = 3,
            CreatedByUserID = 4,
            IssuedUsingLocalLicenseID = 5
        }
        public enum enLicense
        {
            LicenseID = 1,
            LicenseClassID = 2,
            DriverID = 3,
            IsActive = 4,
            CreatedByUserID = 5,
            IssueReason = 6
        }
        public enum enLocalDrivingLicenseApplication
        {
            LocalDrivingLicenseApplicationID = 1,
            LicenseClassID = 2,
            ApplicantPersonID = 3,
            CreatedByUserID = 4,
            ApplicationStatus = 5
        }
        public enum enTestAppointment
        {
            TestAppointmentID = 1,
            TestTypeID = 2,
            LocalDrivingLicenseApplicationID = 3,
            CreatedByUserID = 4,
            IsLocked = 5,
        }
        public enum enUser
        {
            UserID = 1,
            UserName = 2,
            IsActive = 3,
            NationalNo = 4,
            Gendor = 5,
            NationalityCountryID = 6,
            PersonID = 7
        }
    }
}
