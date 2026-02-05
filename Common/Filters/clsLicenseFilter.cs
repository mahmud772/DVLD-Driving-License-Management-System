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
        public DateTime? FromIssueDate { get; set; }
        public DateTime? ToIssueDate { get; set; }
        public DateTime? FromExpirationDate { get; set; }
        public DateTime? ToExpirationDate { get; set; }
        public bool? IsActive { get; set; }
        public clsLicenseEnums.enIssueReason? IssueReason { get; set; }// New , Renew , ReplacementForDamaged , ReplacementForLost
    }
}
