using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Filters
{
    public class clsDetainedLicenseFilter : IFilter
    {
        public DateTime? FromDetainDate { get; set; }
        public DateTime? ToDetainDate { get; set; }
        public bool? IsReleased { get; set; }
        public DateTime? FromReleaseDate { get; set; }
        public DateTime? ToReleaseDate { get; set; }
    }
}
