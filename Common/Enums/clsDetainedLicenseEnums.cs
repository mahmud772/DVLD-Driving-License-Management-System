using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public class clsDetainedLicenseEnums
    {
        public enum enDetainedLicenseSearchBy
        {
            DetainID = 1,
            LicenseID = 2,
            CreatedByUserID = 4
        }
        public enum enDetainedLicenseOrderBy
        {
            DetainID = 1,
            LicenseID = 2,
            IsReleased = 3,
            CreatedByUserID = 4
        }
    }
}
