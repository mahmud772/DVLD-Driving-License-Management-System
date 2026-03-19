using DVLDWinForm.UIHelper_Manger;
using DVLDWinForm.User_Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDWinForm.UIHelper
{

    public class clsFLPManager<T> : IDisplayView<T>
    {
        private FlowLayoutPanel _FLP;
        private Func<T, UserControl> _ControlCreator;
        public int CountItems { get; } = 9;

        public clsFLPManager(FlowLayoutPanel FLP, Func<T, UserControl> ControlCreator)
        {
            _FLP = FLP;
            _ControlCreator = ControlCreator;
        }

        public void Display(List<T> Data)
        {
            _FLP.Controls.Clear();
            _FLP.SuspendLayout(); 
            if(Data == null || _ControlCreator == null) return;

            foreach (T item in Data)
            {
                UserControl control = _ControlCreator(item);
                _FLP.Controls.Add(control);
            }

            _FLP.ResumeLayout();
        }
    }

    
}
