using Common.Filters;
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
    public partial class ucTestAppointmentsFilter : UserControl , IUserControlFilter
    {
        private clsTestAppointmentFilter _TestAppointmentFilter;

        public ucTestAppointmentsFilter()
        {
            InitializeComponent();
            _LoadDesign();
            _Initialize();
        }
        private void _LoadDesign()
        {
            // ===== Rounded Corners =====
            clsUIHelper.CornerRadius(pnlTestType, 5);
            clsUIHelper.CornerRadius(pnlAppiontmentDate, 5);
            clsUIHelper.CornerRadius(pnlLockStatus, 5);
            clsUIHelper.CornerRadius(pnlTestResult, 5);
        }
            // =============================
            // IUserControlFilter
            // =============================
            IFilter IUserControlFilter.Filter
        {
            get => TestAppointmentFilter;
            set
            {
                if (value is clsTestAppointmentFilter filter)
                    TestAppointmentFilter = filter;
            }
        }

        // =============================
        // Public Filter Property
        // =============================
        public clsTestAppointmentFilter TestAppointmentFilter
        {
            get => _Get();
            set
            {
                _TestAppointmentFilter = value;
                _Set(value);
            }
        }

        // =============================
        // Get Filter From UI
        // =============================
        private clsTestAppointmentFilter _Get()
        {
            if (_TestAppointmentFilter == null)
                _TestAppointmentFilter = new clsTestAppointmentFilter();

            
            _TestAppointmentFilter.TestTypeID =
                ckbTestType.Checked
                ? (int?)cbTestType.SelectedValue
                : null;

            
            _TestAppointmentFilter.FromAppointmentDate =
                ckbAppointmentDate.Checked ? dtpFromDate.Value.Date : null;

            _TestAppointmentFilter.ToAppointmentDate =
                ckbAppointmentDate.Checked ? dtpToDate.Value.Date : null;

            
            if (ckbIsLocked.Checked)
                _TestAppointmentFilter.IsLocked = rbLocked.Checked;
            else
                _TestAppointmentFilter.IsLocked = null;

            if (ckbTestResult.Checked)
                _TestAppointmentFilter.TestResult = rbPassed.Checked;
            else
                _TestAppointmentFilter.TestResult = null;

            return _TestAppointmentFilter;
        }

        // =============================
        // Set UI From Filter
        // =============================
        private void _Set(clsTestAppointmentFilter filter)
        {
            if (filter == null) return;

            // Test Type
            ckbTestType.Checked = filter.TestTypeID.HasValue;
            if (filter.TestTypeID.HasValue)
                cbTestType.SelectedValue = filter.TestTypeID.Value;

            // Appointment Date
            ckbAppointmentDate.Checked =
                filter.FromAppointmentDate.HasValue || filter.ToAppointmentDate.HasValue;

            if (filter.FromAppointmentDate.HasValue)
                dtpFromDate.Value = filter.FromAppointmentDate.Value;

            if (filter.ToAppointmentDate.HasValue)
                dtpToDate.Value = filter.ToAppointmentDate.Value;

            // Lock Status
            ckbIsLocked.Checked = filter.IsLocked.HasValue;
            if (filter.IsLocked.HasValue)
            {
                rbLocked.Checked = filter.IsLocked.Value;
                rbNotLocked.Checked = !filter.IsLocked.Value;
            }

            // Test Result
            ckbTestResult.Checked = filter.TestResult.HasValue;
            if (filter.TestResult.HasValue)
            {
                rbPassed.Checked = filter.TestResult.Value;
                rbFailed.Checked = !filter.TestResult.Value;
            }
        }

        // =============================
        // Initialize Defaults
        // =============================
        private void _Initialize()
        {
            // CheckBoxes default
            ckbTestType.Checked = false;
            ckbAppointmentDate.Checked = false;
            ckbIsLocked.Checked = false;
            ckbTestResult.Checked = false;

            // RadioButtons default
            rbLocked.Checked = true;
            rbPassed.Checked = true;

            // Dates
            dtpFromDate.Value = DateTime.Today;
            dtpToDate.Value = DateTime.Today;

            // ComboBoxes (binding يتم من الخارج)
            cbTestType.SelectedIndex = -1;
        }
    }


}

