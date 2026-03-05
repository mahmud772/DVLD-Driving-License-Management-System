using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDWinForm.Display
{
    public interface IPaginationView
    {
        void SetPageNumber(int pageNumber);
        void SetNextButtonVisible(bool visible);
        void SetPreviousButtonVisible(bool visible);
    }
}
