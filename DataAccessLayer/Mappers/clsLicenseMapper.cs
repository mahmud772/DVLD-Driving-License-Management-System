using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL.Mappers
{
    public static class clsLicenseMapper
    {
        public static string MapSearchBy(clsLicenseEnums.enLicenseSearchBy value)
        {
            switch (value)
            {
                case clsLicenseEnums.enLicenseSearchBy.LicenseID:
                    return "LicenseID";

                case clsLicenseEnums.enLicenseSearchBy.DriverID:
                    return "DriverID";

                case clsLicenseEnums.enLicenseSearchBy.CreatedByUserID:
                    return "CreatedByUserID";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string MapOrderBy(clsLicenseEnums.enLicenseOrderBy value)
        {
            switch (value)
            {
                case clsLicenseEnums.enLicenseOrderBy.LicenseID:
                    return "LicenseID";

                case clsLicenseEnums.enLicenseOrderBy.LicenseClassID:
                    return "LicenseClassID";

                case clsLicenseEnums.enLicenseOrderBy.DriverID:
                    return "DriverID";

                case clsLicenseEnums.enLicenseOrderBy.IsActive:
                    return "IsActive";

                case clsLicenseEnums.enLicenseOrderBy.CreatedByUserID:
                    return "CreatedByUserID";

                case clsLicenseEnums.enLicenseOrderBy.IssueReason:
                    return "IssueReason";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

}
