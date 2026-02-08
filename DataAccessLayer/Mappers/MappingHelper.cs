using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL.Mappers
{
    public class MappingHelper
    {
        public static void AddCondition(bool condition, string sql, ref string query)
        {
            if (condition)
                query += " AND " + sql;
        }

        public static void ApplyDateRange(DateTime? from,DateTime? to,string column,ref string query)
        {
            if (from.HasValue)
                query += $" AND {column} >= @{column}From";

            if (to.HasValue)
                query += $" AND {column} <= @{column}To";
        }

    }
}
