using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.clsTestEnums;

namespace Common.Helpers
{
    public class clsTestEnumConverter
    {
        public static enTestTypes ConvertTestTypeToEnum(int TypeID)
        => Enum.IsDefined(typeof(enTestTypes), TypeID) ?
            (enTestTypes)TypeID :
            enTestTypes.VisionTest;

        public static int ConvertTestTypeToInt(enTestTypes Type)
        => (int)Type;
    }
}
