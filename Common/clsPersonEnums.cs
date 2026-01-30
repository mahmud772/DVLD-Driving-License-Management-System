using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.clsLicenseEnums;

namespace Common
{
    public class clsPersonEnums
    {
        public enum enGendor { Male = 0 , Female = 1 };


        public static enGendor ConvertGendorToEnum(byte Gendor)
        {
            if (Gendor >= 0 && Gendor <= 1)
                return (enGendor)Gendor;
            return enGendor.Male;
        }

        public static byte ConvertGendorToByte(enGendor Gendor)
        {
            switch (Gendor)
            {
                case enGendor.Male:
                    return 0;
                case enGendor.Female:
                    return 1;
                default:
                    break;
            }
            return 1;
        }
    }
}
