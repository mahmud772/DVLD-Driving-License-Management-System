using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.clsApplicationEnums;

namespace Common
{
    public class clsLicenseEnums
    {
        public enum enLicenseSearchBy
        {
            LicenseID = 1,
            DriverID = 2,
            CreatedByUserID = 3
        }
        public enum enLicenseOrderBy
        {
            LicenseID = 1,
            LicenseClassID = 2,
            DriverID = 3,
            IsActive = 4,
            CreatedByUserID = 5,
            IssueReason = 6
        }
        public enum enIssueReason : byte
        {
            New = 1,
            Renew = 2,
            ReplacementForDamaged = 3,
            ReplacementForLost = 4 
        }
        public enum enLicenseClasses
        {
            SmallMotorcycle = 1,
            HeavyMotorcycleLicense = 2,
            OrdinaryDrivingLicense = 3,
            Commercial = 4,
            Agricultural = 5,
            SmallAndMediumBus = 6,
            TruckAndHeavyVehicle = 7
        }
        

    }
}
