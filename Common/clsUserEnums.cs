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
            All = -1,
            None = 0,
            ManageUsers = 1,   
            ManageDrivers = 2,  
            ManageLicenses = 3, 
            ManageTests = 4,    
            ManageApplications = 5,
            ManageApplicationTypes = 6, 
            ManageTestTypes = 7,
            ManageLicenseClasses = 8
        }

        
    }
}
