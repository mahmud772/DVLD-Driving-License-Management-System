using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDWinForm.UIHelper_Manger
{
    public interface IPageableLoader
    {
        void LoadPage(int offset, int pageSize);
        int GetTotalCount();
        int CurrentPage { get; set; }
        
    }
}
