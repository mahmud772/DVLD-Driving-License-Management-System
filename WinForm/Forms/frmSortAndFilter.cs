using Common;
using Common.Enums;
using Common.Filters;
using Common.Queries;
using DVLDWinForm.UIHelper;
using DVLDWinForm.UIHelper_Manger;
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
            _Initialize();
        }

        private void frmSortAndFilter_Load(object sender, EventArgs e)
        {
            _Set();
            _LoadDesign();
        }
        private void _Initialize()
        {
            cbSortBy.Items.Clear();
            cbSortBy.DataSource = Enum.GetValues(_Query.OrderBy.GetType());
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
            clsFormLayoutHelper formLayout = new clsFormLayoutHelper(this, pnlContainer, btnCancel, btnOk);
            formLayout.ApplyLayout();
        }
        private void _Get()
        {

        }
        private void _Set()
        {
            if (_Query == null) return;
            rbASC.Checked = _Query.OrderDirection == clsOrderDirectionEnums.enOrderDirection.Asc;
            rbDESC.Checked = _Query.OrderDirection == clsOrderDirectionEnums.enOrderDirection.Desc;

            
            _icontrol.Filter = _Query.Filter;
            
            cbSortBy.SelectedItem = _Query?.OrderBy;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _Query.Filter = _icontrol.Filter;

            _Query.OrderDirection = rbASC.Checked
                ? clsOrderDirectionEnums.enOrderDirection.Asc
                : clsOrderDirectionEnums.enOrderDirection.Desc;

            if (cbSortBy.SelectedItem is Enum orderBy)
                _Query.OrderBy = orderBy;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
