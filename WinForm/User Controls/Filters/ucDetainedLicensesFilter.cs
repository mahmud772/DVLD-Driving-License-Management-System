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
    public partial class ucDetainedLicensesFilter : UserControl , IUserControlFilter
    {
        private clsDetainedLicenseFilter _DetainedLicenseFilter;

        public clsDetainedLicenseFilter DetainedLicenseFilter
        {
            get => _Get();
            set
            {
                _DetainedLicenseFilter = value;
                _Set(value);
            }
        }

        IFilter IUserControlFilter.Filter
        {
            get => DetainedLicenseFilter;
            set
            {
                if (value is clsDetainedLicenseFilter filter)
                    DetainedLicenseFilter = filter;
            }
        }

        public ucDetainedLicensesFilter()
        {
            InitializeComponent();
            _LoadDesign();
            _InitializeControls();
            _Set(_DetainedLicenseFilter);
        }
        // ===================== Initialization =====================
        private void _InitializeControls()
        {
            pnlFromToDetainDate.Enabled = false;
            pnlReleaseNotRelease.Enabled = false;
            pnlFromToReleaseDate.Enabled = false;
        }

        // ------------------ Design ------------------
        private void _LoadDesign()
        {
            clsUIHelper.CornerRadius(pnlReleaseDate, 5);
            clsUIHelper.CornerRadius(pnlReleaseStatus, 5);
            clsUIHelper.CornerRadius(pnlDetainDate, 5);
        }

        // ------------------ GET ------------------
        private clsDetainedLicenseFilter _Get()
        {
            if (_DetainedLicenseFilter == null)
                _DetainedLicenseFilter = new clsDetainedLicenseFilter();

            // Detain Date
            if (ckbDetainDate.Checked)
            {
                _DetainedLicenseFilter.FromDetainDate = dtpFromDetain.Value;
                _DetainedLicenseFilter.ToDetainDate = dtpToDetain.Value;
            }

            // Release Status
            if (ckbIsReleased.Checked)
            {
                if (rbReleasedYes.Checked)
                    _DetainedLicenseFilter.IsReleased = true;
                else if (rbReleasedNo.Checked)
                    _DetainedLicenseFilter.IsReleased = false;
            }

            // Release Date
            if (ckbReleaseDate.Checked)
            {
                _DetainedLicenseFilter.FromReleaseDate = dtpFromRelease.Value;
                _DetainedLicenseFilter.ToReleaseDate = dtpToRelease.Value;
            }

            return _DetainedLicenseFilter;
        }

        // ------------------ SET ------------------
        private void _Set(clsDetainedLicenseFilter filter)
        {
            if (filter == null) return;

            // Detain Date
            if (filter.FromDetainDate.HasValue && filter.ToDetainDate.HasValue)
            {
                ckbDetainDate.Checked = true;
                dtpFromDetain.Value = filter.FromDetainDate.Value;
                dtpToDetain.Value = filter.ToDetainDate.Value;
            }

            // Release Status
            if (filter.IsReleased.HasValue)
            {
                ckbIsReleased.Checked = true;

                if (filter.IsReleased.Value)
                    rbReleasedYes.Checked = true;
                else
                    rbReleasedNo.Checked = true;
            }

            // Release Date
            if (filter.FromReleaseDate.HasValue && filter.ToReleaseDate.HasValue)
            {
                ckbReleaseDate.Checked = true;
                dtpFromRelease.Value = filter.FromReleaseDate.Value;
                dtpToRelease.Value = filter.ToReleaseDate.Value;
            }
        }

        // ------------------ UI Logic ------------------
        private void ckbDetainDate_CheckedChanged(object sender, EventArgs e)
        {
            pnlFromToDetainDate.Enabled = ckbDetainDate.Checked;
        }

        private void ckbReleaseDate_CheckedChanged(object sender, EventArgs e)
        {
            pnlFromToReleaseDate.Enabled = ckbReleaseDate.Checked;
        }

        private void ckbIsReleased_CheckedChanged(object sender, EventArgs e)
        {
            pnlReleaseNotRelease.Enabled = ckbIsReleased.Checked;
        }
    }
}
