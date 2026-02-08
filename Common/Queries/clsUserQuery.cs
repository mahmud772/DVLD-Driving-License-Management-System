using Common.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Queries
{
    public class clsUserQuery :
    clsBaseQuery<clsUserEnums.enUserSearchBy, clsUserEnums.enUserOrderBy>
    {
        public clsUserQuery() { base.Filter = new clsUserFilter(); }
        public new clsUserFilter Filter => base.Filter as clsUserFilter;
    }
}
