using Common.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDWinForm.UIHelper_Manger
{
    public interface IPageableLoader
    {
        void LoadPage(int offset, int pageSize , IQuery Query);
        int GetTotalCount(IQuery Query);
        int CurrentPage { get; set; }
        
    }
}
