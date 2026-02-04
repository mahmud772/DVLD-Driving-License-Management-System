using Common.Filters;
using Common.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDWinForm.Forms
{
    public partial class frmSortAndFilter : Form
    {
        UserControl _control;

        public frmSortAndFilter(UserControl control)
        {
            InitializeComponent();
            _control = control;
        }

        private void frmSortAndFilter_Load(object sender, EventArgs e)
        {
            _LoadDesign();
        }
        private void _LoadDesign()
        {
            if (_control != null)
            {
                pnlContainer.Controls.Clear();
                pnlContainer.Size = _control.Size;
                pnlContainer.Controls.Add(_control);
                _control.Show();
            }
        }
        private void _Get()
        {

        }
        private void _Set()
        {

        }



    }
}
