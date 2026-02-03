using Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Filters
{
    public class clsTestAppointmentFilter : IFilter
    {
        public int? TestTypeID { get;  set; }
        public DateTime? AppointmentDate { get; set; }
        public bool? IsLocked { get; set; }
        public bool? TestResult { get; set; }
    }
}
