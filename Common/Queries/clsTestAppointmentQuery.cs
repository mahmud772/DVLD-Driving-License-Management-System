using Common.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Queries
{
    public class clsTestAppointmentQuery :
    clsBaseQuery<clsTestEnums.enTestAppointmentSearchBy, clsTestEnums.enTestAppointmentOrderBy>
    {
        public clsTestAppointmentQuery() { base.Filter = new clsTestAppointmentFilter(); }
        public new clsTestAppointmentFilter Filter => base.Filter as clsTestAppointmentFilter;
    }
}
