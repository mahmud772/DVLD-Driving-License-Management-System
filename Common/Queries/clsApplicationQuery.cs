using Common.Enums;
using Common.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Queries
{
    public class clsApplicationQuery :
        clsBaseQuery<clsApplicationEnums.enApplicationSearchBy , clsApplicationEnums.enApplicationOrderBy>
    {
        public clsApplicationQuery() { base.Filter = new clsApplicationFilter(); }
        public new clsApplicationFilter Filter => base.Filter as clsApplicationFilter;
    }
}
