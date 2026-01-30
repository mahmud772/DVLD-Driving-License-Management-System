using Common;
using DVLD_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DTO
{
    public class clsLocalDrivingLicenseApplication_DTO : clsApplication_DTO
    {
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public clsLicenseEnums.enLicenseClasses LicenseClass
        {
            get
            {
                return clsLicenseEnums.ConvertLicenseClassToEnum(LicenseClassID);
            }

            set
            {
                LicenseClassID = clsLicenseEnums.ConvertLicenseClassToInt(value);
            }
        }
    }
}
