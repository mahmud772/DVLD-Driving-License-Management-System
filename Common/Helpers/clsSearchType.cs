using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class clsSearchType
    {

        public static bool IsTypeEnumString(Enum searchBy)
        {
            if (searchBy == null) return false;

            string value = searchBy.ToString();

            return value == "NationalNo" || value == "UserName" || value == "FullName";
        }
    }
}
