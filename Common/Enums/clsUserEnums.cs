using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.clsApplicationEnums;

namespace Common
{
    public class clsUserEnums
    {
        [Flags] // ضرورية جداً للتعامل مع الصلاحيات كـ بتات في النصوص
        public enum enPermissions
        {
            None = 0,
            ManageUsers = 1 << 0,
            ManageDrivers = 1 << 1,
            ManageLicenses = 1 << 2,
            ManageTests = 1 << 3,
            ManageApplications = 1 << 4,
            ManageApplicationTypes = 1 << 5,
            ManageTestTypes = 1 << 6,
            ManageLicenseClasses = 1 << 7,
            All = ~0
        }
        public enum enUserSearchBy
        {
            UserID = 1,
            UserName = 2,
            NationalNo = 3,
            PersonID = 4
        }
        public enum enUserOrderBy
        {
            UserID = 1,
            UserName = 2,
            IsActive = 3,
            NationalNo = 4,
            Gendor = 5,
            NationalityCountryID = 6,
            PersonID = 7
        }

    }
}
