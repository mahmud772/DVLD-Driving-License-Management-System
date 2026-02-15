using Common.Enums;
using Common.Filters;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            = clsOrderDirectionEnums.enOrderDirection.Asc;

        public IFilter Filter { get; set; }

        public static bool operator ==(clsBaseQuery<TSearchEnum, TOrderEnum> left,
        clsBaseQuery<TSearchEnum, TOrderEnum> right)
        {
            if (ReferenceEquals(left, right))
                return true;

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;

            return left.SearchBy.Equals(right.SearchBy) &&
                   Equals(left.SearchValue, right.SearchValue) &&
                   left.OrderBy.Equals(right.OrderBy) &&
                   left.OrderDirection == right.OrderDirection &&
                   Equals(left.Filter, right.Filter);
        }

        public static bool operator !=(
            clsBaseQuery<TSearchEnum, TOrderEnum> left,
            clsBaseQuery<TSearchEnum, TOrderEnum> right)
        {
            return !(left == right);
        }


        public override bool Equals(object obj)
            => Equals(obj as clsBaseQuery<TSearchEnum, TOrderEnum>);

    }

}
