using Common.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Queries
{
    public class clsPersonQuery :
    clsBaseQuery<clsPersonEnums.enPersonSearchBy, clsPersonEnums.enPersonOrderBy>
    {
        public clsPersonQuery() 
        { 
            base.Filter = new clsPersonFilter(); 
            OrderBy = clsPersonEnums.enPersonOrderBy.PersonID;
        }
        public new clsPersonFilter Filter => base.Filter as clsPersonFilter;
    }
}
