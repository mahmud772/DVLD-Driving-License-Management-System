using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL.Mappers
{
    public static class clsTestAppointmentMapper
    {
        public static string MapSearchBy(clsTestEnums.enTestAppointmentSearchBy value)
        {
            switch (value)
            {
                case clsTestEnums.enTestAppointmentSearchBy.TestAppointmentID:
                    return "TestAppointmentID";

                case clsTestEnums.enTestAppointmentSearchBy.LocalDrivingLicenseApplicationID:
                    return "LocalDrivingLicenseApplicationID";

                case clsTestEnums.enTestAppointmentSearchBy.CreatedByUserID:
                    return "CreatedByUserID";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string MapOrderBy(clsTestEnums.enTestAppointmentOrderBy value)
        {
            switch (value)
            {
                case clsTestEnums.enTestAppointmentOrderBy.TestAppointmentID:
                    return "TestAppointmentID";

                case clsTestEnums.enTestAppointmentOrderBy.TestTypeID:
                    return "TestTypeID";

                case clsTestEnums.enTestAppointmentOrderBy.LocalDrivingLicenseApplicationID:
                    return "LocalDrivingLicenseApplicationID";

                case clsTestEnums.enTestAppointmentOrderBy.CreatedByUserID:
                    return "CreatedByUserID";

                case clsTestEnums.enTestAppointmentOrderBy.IsLocked:
                    return "IsLocked";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

}
