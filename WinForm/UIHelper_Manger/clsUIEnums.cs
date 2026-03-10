using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDWinForm.UIHelper_Manger
{
    public class clsUIEnums
    {
        public enum enDisplayMode { FLP = 1, DGV = 2 }
        public enum enUIAction
        {
            AddNew = 1,
            Update = 2,
            Delete = 3,
            Filter = 4,
            DetainLicense = 5,
            ReleaseLicense = 6,
            PassedTest = 7,
            FailedTest = 8,
        }
    }
}
