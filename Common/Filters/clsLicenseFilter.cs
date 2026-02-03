using Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Filters
{
    public class clsLicenseFilter : IFilter
    {
        public int? LicenseClassID { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? IsActive { get; set; }
        public clsLicenseEnums.enIssueReason? IssueReason { get; set; }
    }
}
