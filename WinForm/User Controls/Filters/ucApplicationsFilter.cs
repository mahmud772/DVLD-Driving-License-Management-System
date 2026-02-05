using Common;
using Common.Filters;
using DVLD_BLL;
using DVLDWinForm.UIHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DVLDWinForm.User_Controls.Filters
{
    public partial class ucApplicationsFilter : UserControl , IUserControlFilter
    {
        private clsApplicationFilter _ApplicationFilter;
        public clsApplicationFilter ApplicationFilter 
        { 
            get => _Get();
            set
            { 
                _ApplicationFilter = value;
                _Set(_ApplicationFilter);
            } 
        }
        IFilter IUserControlFilter.Filter 
        { 
            get => ApplicationFilter; 
            set
            {
                if (value is clsApplicationFilter filter)
                    ApplicationFilter = filter;
            } 
        }
        public ucApplicationsFilter()
        {
            InitializeComponent();
            _LoadDesign();
        }
        private void _LoadDesign()
        {
            clsUIHelper.CornerRadius(pnlDate, 25);
            clsUIHelper.CornerRadius(pnlFromToDate, 25);
            clsUIHelper.CornerRadius(pnlStatus, 25);
        }
        private clsApplicationFilter _Get()
        {
            if (_ApplicationFilter == null)
                _ApplicationFilter = new clsApplicationFilter();
            if(ckbApplicationStatus.Checked)
                _ApplicationFilter.ApplicationStatus = (clsApplicationEnums.enApplicationStatus)cbApplicationStatus?.SelectedItem;
            if (ckbApplicationType.Checked)
                _ApplicationFilter.ApplicationTypeID = Convert.ToInt32(cbApplicationType.SelectedValue);
            if(ckbApplicationDate.Checked)
            {
                _ApplicationFilter.FromApplicationDate = dtpFrom.Value;
                _ApplicationFilter.ToApplicationDate = dtpTo.Value;
            }
            return _ApplicationFilter;
        }
        private void _Set(clsApplicationFilter ApplicationFilter)
        {
            cbApplicationType.DataSource = clsStaticData_BLL.ApplicationTypes;
            cbApplicationStatus.DataSource = Enum.GetValues(typeof(clsApplicationEnums.enApplicationStatus));
            cbApplicationType.DisplayMember = "ApplicationTypeTitle";
            cbApplicationType.ValueMember = "ApplicationTypeID";
            if (_ApplicationFilter == null) return;
            if(_ApplicationFilter.ApplicationStatus.HasValue)
            { 
                ckbApplicationStatus.Checked = true;
                cbApplicationStatus.SelectedItem = _ApplicationFilter.ApplicationStatus;
            }
            if (_ApplicationFilter.ApplicationTypeID.HasValue)
            {
                ckbApplicationType.Checked = true;
                cbApplicationType.SelectedItem = _ApplicationFilter.ApplicationTypeID;
            }
            if (_ApplicationFilter.ToApplicationDate.HasValue && _ApplicationFilter.FromApplicationDate.HasValue)
            {
                ckbApplicationDate.Checked = true;
                dtpFrom.Value = _ApplicationFilter.FromApplicationDate.Value;
                dtpTo.Value = _ApplicationFilter.ToApplicationDate.Value;
            }
        }

        private void ckbApplicationDate_CheckedChanged(object sender, EventArgs e)
        {
            pnlFromToDate.Enabled = ckbApplicationDate.Checked ? true : false;  
        }
    }
}
