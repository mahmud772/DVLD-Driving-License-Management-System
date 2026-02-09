using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    public class clsBLHelper
    {

        public static DateTime GetDate_Now()
        {
            return DateTime.Now;
        }

       
        public static int GetBitValue(int Number)
        {
            return 1 << (Number - 1);
        }

    }
}
