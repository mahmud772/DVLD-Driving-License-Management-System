using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL.Mappers
{
    public static class clsDetainedLicenseMapper
    {
        public static string MapSearchBy(clsDetainedLicenseEnums.enDetainedLicenseSearchBy value)
        {
            switch (value)
            {
                case clsDetainedLicenseEnums.enDetainedLicenseSearchBy.DetainID:
                    return "DetainID";

                case clsDetainedLicenseEnums.enDetainedLicenseSearchBy.LicenseID:
                    return "LicenseID";

                case clsDetainedLicenseEnums.enDetainedLicenseSearchBy.CreatedByUserID:
                    return "CreatedByUserID";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string MapOrderBy(clsDetainedLicenseEnums.enDetainedLicenseOrderBy value)
        {
            switch (value)
            {
                case clsDetainedLicenseEnums.enDetainedLicenseOrderBy.DetainID:
                    return "DetainID";

                case clsDetainedLicenseEnums.enDetainedLicenseOrderBy.LicenseID:
                    return "LicenseID";

                case clsDetainedLicenseEnums.enDetainedLicenseOrderBy.IsReleased:
                    return "IsReleased";

                case clsDetainedLicenseEnums.enDetainedLicenseOrderBy.CreatedByUserID:
                    return "CreatedByUserID";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

}
