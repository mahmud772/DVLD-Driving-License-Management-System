using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public class clsDriverEnums
    {
        public enum enDriverSearchBy
        {
            DriverID = 1,
            CreatedByUserID = 2,
            PersonID = 3,
            NationalNo = 4
        }
        public enum enDriverOrderBy
        {
            DriverID = 1,
            CreatedByUserID = 2,
            PersonID = 3,
            NationalNo = 4,
            Gendor = 5,
            NationalityCountryID = 6
        }

    }
}
