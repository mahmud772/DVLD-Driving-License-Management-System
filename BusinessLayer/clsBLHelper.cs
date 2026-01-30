using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class clsBLHelper
    {

        public static DateTime GetDate_Now()
        {
            return DateTime.Now;
        }

        public static byte CalculateAge(DateTime DateOfBirth)
        {
            DateTime Today = DateTime.Now;
            int Age = Today.Year - DateOfBirth.Year;

            if (DateOfBirth.Date > Today.AddYears(-Age))
                Age--;

            return Age > 126 ? Convert.ToByte(Age - 2000) : Convert.ToByte(Age);
        }

        public static int GetBitValue(int Number)
        {
            return 1 << (Number - 1);
        }

    }
}
