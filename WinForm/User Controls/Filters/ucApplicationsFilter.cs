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
    public partial class ucApplicationsFilter : UserControl, IUserControlFilter
    {
        private clsApplicationFilter _ApplicationFilter;

        public clsApplicationFilter ApplicationFilter
        {
            get
            {
                UpdateFilterFromUI();
                return _ApplicationFilter;
            }
            set
            {
                _ApplicationFilter = value ?? new clsApplicationFilter();
                ApplyFilterToUI();
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
            LoadDesign();
            InitializeControls();
            _ApplicationFilter = new clsApplicationFilter();
        }

        // ================= Initialization =================

        private void LoadDesign()
        {
            clsUIHelper.CornerRadius(pnlDate, 25);
            clsUIHelper.CornerRadius(pnlFromToDate, 25);
            clsUIHelper.CornerRadius(pnlStatus, 25);
        }

        private void InitializeControls()
        {
            cbApplicationType.DataSource = clsStaticData_BLL.ApplicationTypes;
            cbApplicationType.DisplayMember = "ApplicationTypeTitle";
            cbApplicationType.ValueMember = "ApplicationTypeID";

            cbApplicationStatus.DataSource =
                Enum.GetValues(typeof(clsApplicationEnums.enApplicationStatus));

            pnlFromToDate.Enabled = false;
        }

        // ================= UI → Filter =================

        private void UpdateFilterFromUI()
        {
            if (_ApplicationFilter == null)
                _ApplicationFilter = new clsApplicationFilter();

            _ApplicationFilter.ApplicationStatus = null;
            _ApplicationFilter.ApplicationTypeID = null;
            _ApplicationFilter.FromApplicationDate = null;
            _ApplicationFilter.ToApplicationDate = null;

            if (ckbApplicationStatus.Checked && cbApplicationStatus.SelectedItem != null)
                _ApplicationFilter.ApplicationStatus =
                    (clsApplicationEnums.enApplicationStatus)cbApplicationStatus.SelectedItem;

            if (ckbApplicationType.Checked && cbApplicationType.SelectedValue != null)
                _ApplicationFilter.ApplicationTypeID =
                    Convert.ToInt32(cbApplicationType.SelectedValue);

            if (ckbApplicationDate.Checked)
            {
                _ApplicationFilter.FromApplicationDate = dtpFrom.Value;
                _ApplicationFilter.ToApplicationDate = dtpTo.Value;
            }
        }

        // ================= Filter → UI =================

        private void ApplyFilterToUI()
        {
            if (_ApplicationFilter == null) return;

            ckbApplicationStatus.Checked = _ApplicationFilter.ApplicationStatus.HasValue;
            if (_ApplicationFilter.ApplicationStatus.HasValue)
                cbApplicationStatus.SelectedItem = _ApplicationFilter.ApplicationStatus;

            ckbApplicationType.Checked = _ApplicationFilter.ApplicationTypeID.HasValue;
            if (_ApplicationFilter.ApplicationTypeID.HasValue)
                cbApplicationType.SelectedValue = _ApplicationFilter.ApplicationTypeID;

            ckbApplicationDate.Checked =
                _ApplicationFilter.FromApplicationDate.HasValue &&
                _ApplicationFilter.ToApplicationDate.HasValue;

            if (ckbApplicationDate.Checked)
            {
                dtpFrom.Value = _ApplicationFilter.FromApplicationDate.Value;
                dtpTo.Value = _ApplicationFilter.ToApplicationDate.Value;
            }

            pnlFromToDate.Enabled = ckbApplicationDate.Checked;
        }

        // ================= Events =================

        private void ckbApplicationDate_CheckedChanged(object sender, EventArgs e)
        {
            pnlFromToDate.Enabled = ckbApplicationDate.Checked;
        }
    }

}
