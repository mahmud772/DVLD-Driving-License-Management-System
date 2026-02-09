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

        // دالة واحدة عامة لكل الأنواع
        public static bool IsTypeEnumString(Enum searchBy)
        {
            if (searchBy == null) return false;

            string value = searchBy.ToString();

            // فحص الكلمات المفتاحية التي تعتبر "نصوص"
            // The function checks if the value is a string-based field. (الدالة تفحص ما إذا كانت القيمة حقلاً نصياً.)
            return value == "NationalNo" || value == "UserName" || value == "FullName";
        }
    }
}
