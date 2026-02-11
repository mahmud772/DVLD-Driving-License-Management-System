using Common;
using Common.Helpers;
using DVLD_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DTOs
{
    public class clsLocalDrivingLicenseApplication_DTO : clsApplication_DTO
    {
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public clsLicenseEnums.enLicenseClasses LicenseClass
        {
            get
            {
                return clsLicenseEnumConverter.ToClass(LicenseClassID);
            }

            set
            {
                LicenseClassID = clsLicenseEnumConverter.ToInt(value);
            }
        }
    }
}
