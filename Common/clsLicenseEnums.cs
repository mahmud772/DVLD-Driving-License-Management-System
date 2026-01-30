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
        public enum enIssueReason 
        {
            New = 1,
            Renew = 2,
            ReplacementForDamaged = 3,
            ReplacementForLost = 4 
        }
        public static enIssueReason ConvertIssueReasonToEnum(byte StatusID)
        {
            if (StatusID > 0 && StatusID < 4)
                return (enIssueReason)StatusID;
            return enIssueReason.New;
        }
        
        public static byte ConvertIssueReasonToByte(enIssueReason Status)
        {
            switch (Status)
            {
                case enIssueReason.New:
                    return 1;
                case enIssueReason.Renew:
                    return 2;
                case enIssueReason.ReplacementForDamaged:
                    return 3;
                case enIssueReason.ReplacementForLost:
                    return 4;
                default:
                    break;
            }
            return 1;
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

        public static enLicenseClasses ConvertLicenseClassToEnum(int ClassID)
        {

            if (ClassID >= 1 && ClassID <= 7)
                return (enLicenseClasses)ClassID;


            return enLicenseClasses.SmallMotorcycle;
        }

        public static int ConvertLicenseClassToInt(enLicenseClasses Class)
        {
            switch (Class)
            {
                case enLicenseClasses.SmallMotorcycle:
                    return 1;
                case enLicenseClasses.HeavyMotorcycleLicense:
                    return 2;
                case enLicenseClasses.OrdinaryDrivingLicense:
                    return 3;
                case enLicenseClasses.Commercial:
                    return 4;
                case enLicenseClasses.Agricultural:
                    return 5;
                case enLicenseClasses.SmallAndMediumBus:
                    return 6;
                case enLicenseClasses.TruckAndHeavyVehicle:
                    return 7;
                default:
                    return 1;
            }
        }

    }
}
