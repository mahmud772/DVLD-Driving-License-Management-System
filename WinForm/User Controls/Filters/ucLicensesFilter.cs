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
    public partial class ucLicensesFilter : UserControl , IUserControlFilter
    {
        private clsLicenseFilter _LicenseFilter;

        public clsLicenseFilter LicenseFilter
        {
            get => _Get();
            set
            {
                _LicenseFilter = value;
                _Set(value);
            }
        }

        IFilter IUserControlFilter.Filter
        {
            get => LicenseFilter;
            set
            {
                if (value is clsLicenseFilter filter)
                    LicenseFilter = filter;
            }
        }

        public ucLicensesFilter()
        {
            InitializeComponent();
            _LoadDesign();
            _InitializeData();
            _Set(_LicenseFilter);
        }

        // ===================== Initialization =====================
        private void _LoadDesign()
        {
            clsUIHelper.CornerRadius(pnlLicenseClass, 5);
            clsUIHelper.CornerRadius(pnlIssueDate, 5);
            clsUIHelper.CornerRadius(pnlExpirationDate, 5);
            clsUIHelper.CornerRadius(pnlIsActive, 5);
            clsUIHelper.CornerRadius(pnlIssueReason, 5);
        }

        private void _InitializeData()
        {
            cbIssueReason.DataSource =
                Enum.GetValues(typeof(clsLicenseEnums.enIssueReason));

            cbLicenseClass.DataSource =
                clsStaticData_BLL.LicenseClasses;

            cbLicenseClass.DisplayMember = "ClassName";
            cbLicenseClass.ValueMember = "LicenseClassID";
        }

        // ===================== GET =====================
        private clsLicenseFilter _Get()
        {
            if (_LicenseFilter == null)
                _LicenseFilter = new clsLicenseFilter();

            // License Class
            if (ckbLicenseClass.Checked)
                _LicenseFilter.LicenseClassID =
                    Convert.ToInt32(cbLicenseClass.SelectedValue);

            // Issue Date
            if (ckbIssueDate.Checked)
            {
                _LicenseFilter.FromIssueDate = dtpFromIssue.Value;
                _LicenseFilter.ToIssueDate = dtpToIssue.Value;
            }

            // Expiration Date
            if (ckbExpirationDate.Checked)
            {
                _LicenseFilter.FromExpirationDate = dtpFromExpire.Value;
                _LicenseFilter.ToExpirationDate = dtpToExpire.Value;
            }

            // Is Active
            if (ckbIsActive.Checked)
            {
                if (rbActiveYes.Checked)
                    _LicenseFilter.IsActive = true;
                else if (rbActiveNo.Checked)
                    _LicenseFilter.IsActive = false;
            }

            // Issue Reason
            if (ckbIssueReason.Checked)
                _LicenseFilter.IssueReason =
                    (clsLicenseEnums.enIssueReason)cbIssueReason.SelectedItem;

            return _LicenseFilter;
        }

        // ===================== SET =====================
        private void _Set(clsLicenseFilter filter)
        {
            if (filter == null) return;

            // License Class
            if (filter.LicenseClassID.HasValue)
            {
                ckbLicenseClass.Checked = true;
                cbLicenseClass.SelectedValue = filter.LicenseClassID.Value;
            }

            // Issue Date
            if (filter.FromIssueDate.HasValue && filter.ToIssueDate.HasValue)
            {
                ckbIssueDate.Checked = true;
                dtpFromIssue.Value = filter.FromIssueDate.Value;
                dtpToIssue.Value = filter.ToIssueDate.Value;
            }

            // Expiration Date
            if (filter.FromExpirationDate.HasValue && filter.ToExpirationDate.HasValue)
            {
                ckbExpirationDate.Checked = true;
                dtpFromExpire.Value = filter.FromExpirationDate.Value;
                dtpToExpire.Value = filter.ToExpirationDate.Value;
            }

            // Is Active
            if (filter.IsActive.HasValue)
            {
                ckbIsActive.Checked = true;

                if (filter.IsActive.Value)
                    rbActiveYes.Checked = true;
                else
                    rbActiveNo.Checked = true;
            }

            // Issue Reason
            if (filter.IssueReason.HasValue)
            {
                ckbIssueReason.Checked = true;
                cbIssueReason.SelectedItem = filter.IssueReason.Value;
            }
        }

        // ===================== UI Logic =====================
        private void ckbIssueDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpFromIssue.Enabled =
            dtpToIssue.Enabled = ckbIssueDate.Checked;
        }

        private void ckbExpirationDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpFromExpire.Enabled =
            dtpToExpire.Enabled = ckbExpirationDate.Checked;
        }

        private void ckbIsActive_CheckedChanged(object sender, EventArgs e)
        {
            rbActiveYes.Enabled =
            rbActiveNo.Enabled = ckbIsActive.Checked;
        }

        private void ckbLicenseClass_CheckedChanged(object sender, EventArgs e)
        {
            cbLicenseClass.Enabled = ckbLicenseClass.Checked;
        }

        private void ckbIssueReason_CheckedChanged(object sender, EventArgs e)
        {
            cbIssueReason.Enabled = ckbIssueReason.Checked;
        }
    }
}
