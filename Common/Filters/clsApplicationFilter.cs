using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Filters
{
    public class clsApplicationFilter : IFilter
    {
        public clsApplicationEnums.enApplicationStatus? ApplicationStatus { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public int? ApplicationTypeID { get; set; }
        public DateTime? LastStatusDate { get; set; }
    }
}
