using Common.Enums;
using Common.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Queries
{
    public interface IQuery
    {
        Enum SearchBy { get; set; }
        object SearchValue { get; set; }
        Enum OrderBy { get; set; }
        clsOrderDirectionEnums.enOrderDirection OrderDirection { get; set; }
        IFilter Filter { get; set; }
    }
}
