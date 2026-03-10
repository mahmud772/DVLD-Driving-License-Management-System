using Common.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Queries
{
    public class clsTestQuery :
        clsBaseQuery<clsTestEnums.enTestSearchBy, clsTestEnums.enTestOrderBy>
    {
        public clsTestQuery()
        {
            base.Filter = new clsTestFilter();
            OrderBy = clsTestEnums.enTestOrderBy.TestID;
        }
        public new clsTestFilter Filter => base.Filter as clsTestFilter;
    }
}
