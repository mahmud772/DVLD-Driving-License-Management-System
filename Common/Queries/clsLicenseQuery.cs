using Common.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Queries
{
    public class clsLicenseQuery :
    clsBaseQuery<clsLicenseEnums.enLicenseSearchBy, clsLicenseEnums.enLicenseOrderBy>
    {
        public clsLicenseQuery(){ base.Filter = new clsLicenseFilter(); }
        public new clsLicenseFilter Filter => base.Filter as clsLicenseFilter;
    }
}
