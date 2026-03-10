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
using static Common.clsApplicationEnums;
using static DVLDWinForm.UIHelper_Manger.clsControlAnimateHeight;

namespace DVLDWinForm.User_Controls.Filters
{
    public partial class ucTestsFilter : UserControl , IUserControlFilter
    {
        private clsTestFilter _TestFilter;

        public clsTestFilter TestFilter
        {
            get
            {
                UpdateFilterFromUI();
                return _TestFilter;
            }
            set
            {
                _TestFilter = value ?? new clsTestFilter();
                ApplyFilterToUI();
            }
        }

        IFilter IUserControlFilter.Filter
        {
            get => TestFilter;
            set
            {
                if (value is clsTestFilter filter)
                    TestFilter = filter;
            }
        }

        public ucTestsFilter()
        {
            InitializeComponent();
            LoadDesign();
            _TestFilter = new clsTestFilter();
        }

        // ================= Initialization =================

        private void LoadDesign()
        {
            clsUIHelper.CornerRadius(pnlPassFial, 25);
            clsUIHelper.CornerRadius(pnlTestResult, 25);
        }

        

        // ================= UI → Filter =================

        private void UpdateFilterFromUI()
        {
            if (_TestFilter == null)
                _TestFilter = new clsTestFilter();

            _TestFilter.TestResult = null;

            if (ckbTestResult.Checked)
                _TestFilter.TestResult = rbPassedYes.Checked;
        }

        // ================= Filter → UI =================

        private void ApplyFilterToUI()
        {
            if (_TestFilter == null) return;

            ckbTestResult.Checked = _TestFilter.TestResult.HasValue;
            if (_TestFilter.TestResult.HasValue)
            {
                rbFailedNo.Checked = _TestFilter.TestResult == false;
                rbPassedYes.Checked = _TestFilter.TestResult == true;
            }


            pnlPassFial.Enabled = ckbTestResult.Checked;
        }

        // ================= Events =================

        private void ckbApplicationDate_CheckedChanged(object sender, EventArgs e)
        {
            pnlPassFial.Enabled = ckbTestResult.Checked;
        }
    }
}
