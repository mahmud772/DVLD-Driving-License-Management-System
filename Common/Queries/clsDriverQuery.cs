using Common.Enums;
using Common.Filters;


namespace Common.Queries
{
    public class clsDriverQuery :
    clsBaseQuery<clsDriverEnums.enDriverSearchBy, clsDriverEnums.enDriverOrderBy>
    {
        public clsDriverQuery() { base.Filter = new clsDriverFilter(); }
        public new clsDriverFilter Filter => base.Filter as clsDriverFilter;
    }
}
