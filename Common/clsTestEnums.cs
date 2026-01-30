using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class clsTestEnums
    {
        public enum enTestTypes { VisionTest = 1 , WrittenTest = 2 , PracticalTest = 3 }

        public static enTestTypes ConvertTestTypeToEnum(int TypeID)
        {

            if (TypeID >= 1 && TypeID <= 3)
                return (enTestTypes)TypeID;


            return enTestTypes.VisionTest;
        }

        public static int ConvertTestTypeToInt(enTestTypes Type)
        {
            switch (Type)
            {
                case enTestTypes.VisionTest:
                    return 1;
                case enTestTypes.WrittenTest:
                    return 2;
                case enTestTypes.PracticalTest:
                    return 3;

                default:
                    return 1;
            }
        }
    }
}
