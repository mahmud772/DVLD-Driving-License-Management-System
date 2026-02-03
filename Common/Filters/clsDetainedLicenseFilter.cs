using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Filters
{
    public class clsDetainedLicenseFilter : IFilter
    {
        public DateTime? DetainDate { get; set; }
        public bool? IsReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
