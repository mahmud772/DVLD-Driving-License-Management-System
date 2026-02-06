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
    public partial class ucLocalDrivingLicenseApplicationsFilter : UserControl , IUserControlFilter
    {
        private clsLocalDrivingLicenseApplicationFilter _Filter;

        public clsLocalDrivingLicenseApplicationFilter Filter
        {
            get => _Get();
            set
            {
                _Filter = value;
                _Set(value);
            }
        }

        IFilter IUserControlFilter.Filter
        {
            get => Filter;
            set
            {
                if (value is clsLocalDrivingLicenseApplicationFilter filter)
                    Filter = filter;
            }
        }

        public ucLocalDrivingLicenseApplicationsFilter()
        {
            InitializeComponent();
            _LoadDesign();
            _Set(Filter);
        }

        // =========================
        // Load Design
        // =========================
        private void _LoadDesign()
        {
            clsUIHelper.CornerRadius(pnlLicenseClass, 5);
        }

        // =========================
        // Get Filter
        // =========================
        private clsLocalDrivingLicenseApplicationFilter _Get()
        {
            if (_Filter == null)
                _Filter = new clsLocalDrivingLicenseApplicationFilter();

            // 1️⃣ خذ فلتر التطبيقات العام كما هو
            var appFilter =
                (clsApplicationFilter)ucApplicationsFilter1.ApplicationFilter;

            _Filter.ApplicationStatus = appFilter.ApplicationStatus;
            _Filter.ApplicationTypeID = appFilter.ApplicationTypeID;
            _Filter.FromApplicationDate = appFilter.FromApplicationDate;
            _Filter.ToApplicationDate = appFilter.ToApplicationDate;

            // 2️⃣ الخصائص الخاصة بـ Local Driving License
            if (ckbLicenseClass.Checked)
                _Filter.LicenseClassID = Convert.ToInt32(cbLicenseClass.SelectedValue);
            else
                _Filter.LicenseClassID = null;

            return _Filter;
        }

        // =========================
        // Set Filter
        // =========================
        private void _Set(clsLocalDrivingLicenseApplicationFilter filter)
        {
            if (filter == null)
                filter = new clsLocalDrivingLicenseApplicationFilter();

            _Filter = filter;

            // 1️⃣ مرّر الفلتر للـ ucApplicationsFilter
            ucApplicationsFilter1.ApplicationFilter = filter;

            // 2️⃣ تعبئة License Class
            cbLicenseClass.DataSource = clsStaticData_BLL.LicenseClasses;
            cbLicenseClass.DisplayMember = "ClassName";
            cbLicenseClass.ValueMember = "LicenseClassID";

            if (filter.LicenseClassID.HasValue)
            {
                ckbLicenseClass.Checked = true;
                cbLicenseClass.SelectedValue = filter.LicenseClassID.Value;
            }
            else
            {
                ckbLicenseClass.Checked = false;
            }
        }
    }
}

