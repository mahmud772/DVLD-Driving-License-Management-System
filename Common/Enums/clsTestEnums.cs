using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class clsTestEnums
    {
        public enum enTestAppointmentSearchBy
        {
            TestAppointmentID = 1,
            LocalDrivingLicenseApplicationID = 2,
            CreatedByUserID = 3
        }
        public enum enTestAppointmentOrderBy
        {
            TestAppointmentID = 1,
            TestTypeID = 2,
            LocalDrivingLicenseApplicationID = 3,
            CreatedByUserID = 4,
            IsLocked = 5
        }


        public enum enTestTypes { VisionTest = 1 , WrittenTest = 2 , PracticalTest = 3 }

        
    }
}
