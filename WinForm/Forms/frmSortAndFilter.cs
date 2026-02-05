using Common.Filters;
using Common.Queries;
using DVLDWinForm.UIHelper;
using DVLDWinForm.User_Controls.Filters;
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
        IUserControlFilter _icontrol;
        IQuery _Query;
        public frmSortAndFilter(IUserControlFilter icontrol , IQuery Query)
        {
            InitializeComponent();
            _icontrol = icontrol;
            _control = icontrol as UserControl;
            _Query = Query;
        }

        private void frmSortAndFilter_Load(object sender, EventArgs e)
        {
            _Set();
            _LoadDesign();
        }
        private void _LoadDesign()
        {
            clsUIHelper.CornerRadius(pnlSort, 5);
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
            if(_Query == null) return;
            cbSortBy.DataSource = _Query.OrderBy;
            _icontrol?.Filter = _Query?.Filter;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_Query == null) return;
            _Query.Filter = _icontrol?.Filter;
            _Query.OrderDirection = rbASC.Checked ? 
                Common.Enums.clsOrderDirectionEnums.enOrderDirection.Asc :
                Common.Enums.clsOrderDirectionEnums.enOrderDirection.Desc;
            _Query.OrderBy = (Enum)cbSortBy.SelectedItem;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
