using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDWinForm.UIHelper_Manger
{
    
    public class clsDGVManager<T> : IDisplayView<T>
    {
        private DataGridView _DGV;
        

        // نمرر دالة تفوض إنشاء الكونترول ليكون الكود مرناً
        public clsDGVManager(DataGridView DGV)
        {
            _DGV = DGV;
             
        }
        private static int _CountItems { get; } = 22;
        public int CountItems { get; } = _CountItems;
        public static int GetCountItems() => _CountItems;
        public void Display(List<T> Data)
        {
            _DGV.DataSource = null;

            if (Data != null && Data.Count > 0)
            {
                _DGV.SuspendLayout();

                // 2. ربط البيانات الجديدة
                _DGV.DataSource = Data;

                _DGV.ResumeLayout();
            }
        }
    }
}
