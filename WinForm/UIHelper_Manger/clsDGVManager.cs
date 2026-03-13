using Common.Helpers;
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
        

        public clsDGVManager(DataGridView DGV)
        {
            _DGV = DGV;
             
        }
        private void ApplyAttributes()
        {
            var props = typeof(T).GetProperties();

            foreach (var prop in props)
            {
                if (Attribute.IsDefined(prop, typeof(DGVIgnoreAttribute)))
                {
                    if (_DGV.Columns.Contains(prop.Name))
                        _DGV.Columns[prop.Name].Visible = false;
                }
            }
        }
        public int CountItems { get; } = 22;
        public void Display(List<T> Data)
        {
            _DGV.DataSource = null;

            if (Data != null && Data.Count > 0)
            {
                _DGV.SuspendLayout();

                _DGV.DataSource = Data;
                ApplyAttributes();
                _DGV.ResumeLayout();
            }
        }
    }
}
