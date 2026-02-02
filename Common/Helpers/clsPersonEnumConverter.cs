using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.clsPersonEnums;

namespace Common.Helpers
{
    public class clsPersonEnumConverter
    {
        public static enGendor ToGendor(byte Gendor)
        => Enum.IsDefined(typeof(enGendor), Gendor) ?
            (enGendor)Gendor :
            enGendor.Male;

        public static byte ToByte(enGendor Gendor)
        => (byte)Gendor;
    }
}
