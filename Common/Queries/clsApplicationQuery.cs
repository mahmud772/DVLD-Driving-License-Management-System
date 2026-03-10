using Common.Enums;
using Common.Filters;

namespace Common.Queries
{
    public class clsApplicationQuery :
        clsBaseQuery<clsApplicationEnums.enApplicationSearchBy , clsApplicationEnums.enApplicationOrderBy>
    {
        public clsApplicationQuery() 
        { 
            base.Filter = new clsApplicationFilter();  
            OrderBy = clsApplicationEnums.enApplicationOrderBy.ApplicationID;
        }
        public new clsApplicationFilter Filter => base.Filter as clsApplicationFilter;
        
    }
}
