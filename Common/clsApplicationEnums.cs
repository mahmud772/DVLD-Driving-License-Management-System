using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class clsApplicationEnums
    {
        public enum enApplicationStatus // حالات الطلب
        { 
            New = 1, // جديده او غير مكتملة
            Cancelled = 2, // ملغية
            Completed = 3  // مكتملة
        }
        public enum enApplicationType // انواع الطلب
        {
            NewLocalDrivingLicense = 1,        // رخصة قيادة محلية جديدة
            RenewDrivingLicense = 2,           // تجديد رخصة قيادة
            ReplacementForLostDrivingLicense = 3, // بدل فاقد
            ReplacementForDamagedDrivingLicense = 4, // بدل تالف
            ReleaseDetainedDrivingLicsense = 5,   // فك حجز رخصة قيادة
            NewInternationalLicense = 6,       // رخصة دولية جديدة
            RetakeTest = 8                     // إعادة اختبار
        }


        public static enApplicationStatus ConvertApplicationStatusToEnum(byte Status)
        {
            if (Status > 0 && Status < 4)
                return (enApplicationStatus)Status;
            return enApplicationStatus.Cancelled;
        }

        public static byte ConvertApplicationStatusToByte(enApplicationStatus Status)
        {
            switch (Status)
            {
                case enApplicationStatus.New:
                    return 1;
                case enApplicationStatus.Cancelled:
                    return 2;
                case enApplicationStatus.Completed:
                    return 3;
                default:
                    break;
            }
            return 2;
        }

        public static enApplicationType ConvertApplicationTypeToEnum(int TypeID)
        {

            if (TypeID >= 1 && TypeID <= 8 && TypeID != 7)
                return (enApplicationType)TypeID;


            return enApplicationType.NewLocalDrivingLicense;
        }

        public static int ConvertApplicationTypeToInt(enApplicationType Type)
        {
            switch (Type)
            {
                case enApplicationType.NewLocalDrivingLicense:
                    return 1;
                case enApplicationType.RenewDrivingLicense:
                    return 2;
                case enApplicationType.ReplacementForLostDrivingLicense:
                    return 3;
                case enApplicationType.ReplacementForDamagedDrivingLicense:
                    return 4;
                case enApplicationType.ReleaseDetainedDrivingLicsense:
                    return 5;
                case enApplicationType.NewInternationalLicense:
                    return 6;
                case enApplicationType.RetakeTest:
                    return 8;
                default:
                    return 1;
            }
        }



    }


}
