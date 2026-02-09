using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    public class clsUtil
    {
        public static string TextSepatation(string Text)
        {
            string result = Regex.Replace(Text, "([a-z])([A-Z])", "$1 $2");
            return result;
        }
        static bool AreMultiples(int a, int b)
        {
            if (a == 0 || b == 0)
                return false; 

            return a % b == 0 || b % a == 0;
        }
        public static byte CalculateAge(DateTime DateOfBirth)
        {
            DateTime Today = DateTime.Now;
            int Age = Today.Year - DateOfBirth.Year;

            if (DateOfBirth.Date > Today.AddYears(-Age))
                Age--;

            return Age > 126 ? Convert.ToByte(Age - 2000) : Convert.ToByte(Age);
        }

    }
}
