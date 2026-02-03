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
        
        public enum enPersonSearchBy
        {
            PersonID = 1,
            NationalNo = 2
        }
        public enum enPersonOrderBy
        {
            PersonID = 1,
            NationalNo = 2,
            FirstName = 3,
            Gendor = 4,
            NationalityCountryID = 5
        }
        
        public enum enGendor : byte
        { Male = 0 , Female = 1 };
    }
}
