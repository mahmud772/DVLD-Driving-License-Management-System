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
    public partial class ucPeopleFilter : UserControl, IUserControlFilter
    {
        private clsPersonFilter _PersonFilter;

        public clsPersonFilter PersonFilter
        {
            get => _Get();
            set
            {
                _PersonFilter = value;
                _Set(_PersonFilter);
            }
        }

        IFilter IUserControlFilter.Filter
        {
            get => PersonFilter;
            set
            {
                if (value is clsPersonFilter filter)
                    PersonFilter = filter;
            }
        }

        public ucPeopleFilter()
        {
            InitializeComponent();

            _InitializeControls();
        }

        // ===================== UI =====================

        private void _LoadDesign()
        {
            clsUIHelper.CornerRadius(pnlAge, 5);
            clsUIHelper.CornerRadius(pnlFromToAge, 5);
            clsUIHelper.CornerRadius(pnlGender, 5);
            clsUIHelper.CornerRadius(pnlNNationality, 5);
        }

        private void _InitializeControls()
        {
            cboNationality.DataSource = clsStaticData_BLL.Countries;
            cboNationality.DisplayMember = "CountryName";
            cboNationality.ValueMember = "CountryID";

            pnlFromToAge.Enabled = false;
            pnlMaleFemale.Enabled = false;
            cboNationality.Enabled = false;
        }


        private clsPersonFilter _Get()
        {
            if (_PersonFilter == null)
                _PersonFilter = new clsPersonFilter();

            _PersonFilter.AgeOlderThen = null;
            _PersonFilter.AgeYoungerThen = null;
            _PersonFilter.Gendor = null;
            _PersonFilter.NationalityCountryID = null;

            if (chkAge.Checked)
            {
                _PersonFilter.AgeOlderThen = (int)nudAgeFrom.Value;
                _PersonFilter.AgeYoungerThen = (int)nudAgeTo.Value;
            }

            if (chkGender.Checked)
            {
                if (rbMale.Checked)
                    _PersonFilter.Gendor = clsPersonEnums.enGendor.Male;
                else if (rbFemale.Checked)
                    _PersonFilter.Gendor = clsPersonEnums.enGendor.Female;
            }

            if (chkNationality.Checked && cboNationality.SelectedValue != null)
            {
                _PersonFilter.NationalityCountryID =
                    Convert.ToInt32(cboNationality.SelectedValue);
            }

            return _PersonFilter;
        }


        private void _Set(clsPersonFilter filter)
        {
            if (filter == null) return;

            if (filter.AgeOlderThen.HasValue && filter.AgeYoungerThen.HasValue)
            {
                chkAge.Checked = true;
                pnlFromToAge.Enabled = true;
                nudAgeFrom.Value = filter.AgeOlderThen.Value;
                nudAgeTo.Value = filter.AgeYoungerThen.Value;
            }

            if (filter.Gendor.HasValue)
            {
                chkGender.Checked = true;
                pnlMaleFemale.Enabled = true;
                rbMale.Checked = filter.Gendor == clsPersonEnums.enGendor.Male;
                rbFemale.Checked = filter.Gendor == clsPersonEnums.enGendor.Female;
            }

            if (filter.NationalityCountryID.HasValue)
            {
                cboNationality.Enabled = true;
                chkNationality.Checked = true;
               
                cboNationality.SelectedValue = filter.NationalityCountryID.Value;
            }
        }


        private void chkAge_CheckedChanged(object sender, EventArgs e)
        {
            pnlFromToAge.Enabled = chkAge.Checked;
        }

        private void chkGender_CheckedChanged(object sender, EventArgs e)
        {
            pnlMaleFemale.Enabled = chkGender.Checked;
        }

        private void chkNationality_CheckedChanged(object sender, EventArgs e)
        {
            cboNationality.Enabled = chkNationality.Checked;
        }

        private void ucPeopleFilter_Load(object sender, EventArgs e)
        {

            _LoadDesign();
            _Set(PersonFilter);
        }
    }
}
