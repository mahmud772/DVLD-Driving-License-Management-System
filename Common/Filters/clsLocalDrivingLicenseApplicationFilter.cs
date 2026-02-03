using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Filters
{
    public class clsLocalDrivingLicenseApplicationFilter : clsApplicationFilter , IFilter
    {
        public int? LicenseClassID { get; set; }
    }
}
