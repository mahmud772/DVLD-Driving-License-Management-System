using Common.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Queries
{
    public class clsLocalDrivingLicenseApplicationQuery :
        clsBaseQuery<clsApplicationEnums.enApplicationSearchBy, clsApplicationEnums.enApplicationOrderBy>
    {
        public clsLocalDrivingLicenseApplicationQuery() 
        { 
            base.Filter = new clsLocalDrivingLicenseApplicationFilter();
            OrderBy = clsApplicationEnums.enApplicationOrderBy.ApplicationID;
        }
        public new clsLocalDrivingLicenseApplicationFilter Filter => base.Filter as clsLocalDrivingLicenseApplicationFilter;
    }
}
