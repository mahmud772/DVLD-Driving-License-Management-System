using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDWinForm.UIHelper_Manger
{
    public interface IDisplayView<T>
    {
        public void Display(List<T> Data);
        int CountItems { get; }

    }
}
