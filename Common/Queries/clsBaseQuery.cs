using Common.Enums;
using Common.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Queries
{
    public abstract class clsBaseQuery<TSearchEnum, TOrderEnum> : IQuery
    where TSearchEnum : struct, Enum
    where TOrderEnum : struct, Enum 
    {
        public TSearchEnum? SearchBy { get; set; }
        public object SearchValue { get; set; }
        Enum IQuery.SearchBy
        {
            get => SearchBy;
            set => SearchBy = (TSearchEnum?)value;
        }

        Enum IQuery.OrderBy
        {
            get => OrderBy;
            set => OrderBy = (TOrderEnum)value;
        }
        public TOrderEnum OrderBy { get; set; } 
        public clsOrderDirectionEnums.enOrderDirection OrderDirection { get; set; }
            = clsOrderDirectionEnums.enOrderDirection.Desc;

        public IFilter Filter { get; set; }
    }

}
