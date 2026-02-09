using Common.Enums;
using Common.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Queries
{
    public class clsDetainedLicenseQuery :
    clsBaseQuery<clsDetainedLicenseEnums.enDetainedLicenseSearchBy, clsDetainedLicenseEnums.enDetainedLicenseOrderBy>
    {
        public clsDetainedLicenseQuery() 
        { 
            base.Filter = new clsDetainedLicenseFilter(); 
            OrderBy = clsDetainedLicenseEnums.enDetainedLicenseOrderBy.DetainID;
        }
        public new clsDetainedLicenseFilter Filter => base.Filter as clsDetainedLicenseFilter;
    }
}
