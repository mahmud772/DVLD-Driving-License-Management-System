using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.clsLicenseEnums;

namespace Common.Helpers
{
    public class clsLicenseEnumConverter
    {
        public static enIssueReason ToIssueReason(byte StatusID)
         => Enum.IsDefined(typeof(enIssueReason), StatusID) ?
            (enIssueReason)StatusID :
            enIssueReason.New;

        public static byte ToByte(enIssueReason Status)
        => (byte)Status;




        public static enLicenseClasses ToClass(int ClassID)
        => Enum.IsDefined(typeof(enLicenseClasses) , ClassID) ?
            (enLicenseClasses)ClassID :
            enLicenseClasses.SmallMotorcycle;

        public static int ToInt(enLicenseClasses Class)
        => (int)Class;
    }
}
