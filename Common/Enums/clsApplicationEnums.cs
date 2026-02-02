using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class clsApplicationEnums
    {
        public enum enApplicationSearchBy
        {
            ApplicationID = 1,
            ApplicantPersonID = 2,
            CreatedByUserID = 3
        }
        public enum enApplicationOrderBy
        {
            ApplicationID = 1,
            ApplicantPersonID = 2,
            ApplicationTypeID = 3,
            CreatedByUserID = 4,
            ApplicationStatus = 5,
            ApplicationDate = 6
        }
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


        



    }


}
