using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.clsApplicationEnums;

namespace Common.Helpers
{
    public class clsApplicationEnumConverter
    {

        public static enApplicationStatus ToStatus(byte value)
            => Enum.IsDefined(typeof(enApplicationStatus), (int)value)
                ? (enApplicationStatus)value
                : enApplicationStatus.Cancelled;

        public static byte ToByte(enApplicationStatus status)
            => (byte)status;

        public static enApplicationType ToType(int value)
            => Enum.IsDefined(typeof(enApplicationType), value)
                ? (enApplicationType)value
                : enApplicationType.NewLocalDrivingLicense;

        public static int ToInt(enApplicationType type)
            => (int)type;

    }
}
