using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL.Mappers
{
    public class clsTestMapper
    {
        public static string MapSearchBy(clsTestEnums.enTestSearchBy value)
        {
            switch (value)
            {
                case clsTestEnums.enTestSearchBy.TestAppointmentID:
                    return "TestAppointmentID";

                case clsTestEnums.enTestSearchBy.TestID:
                    return "TestID";

                case clsTestEnums.enTestSearchBy.CreatedByUserID:
                    return "CreatedByUserID";

                default:
                    return "TestAppointmentID";
            }
        }

        public static string MapOrderBy(clsTestEnums.enTestOrderBy value)
        {
            switch (value)
            {
                case clsTestEnums.enTestOrderBy.TestResult:
                    return "TestResult";

                case clsTestEnums.enTestOrderBy.TestAppointmentID:
                    return "TestAppointmentID";

                case clsTestEnums.enTestOrderBy.TestID:
                    return "TestID";

                default:
                    return "TestID";
            }
        }
    }
}
