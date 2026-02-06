using Common.Filters;
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
    public partial class ucDriversFilter : UserControl , IUserControlFilter
    {
        private clsDriverFilter _DriverFilter;

        public clsDriverFilter DriverFilter
        {
            get => _Get();
            set
            {
                _DriverFilter = value;
                _Set(value);
            }
        }

        IFilter IUserControlFilter.Filter
        {
            get => DriverFilter;
            set
            {
                if (value is clsDriverFilter filter)
                    DriverFilter = filter;
            }
        }
        public ucDriversFilter()
        {
            InitializeComponent();
        }


        private clsDriverFilter _Get()
        {
            var personFilter = ucPeopleFilter1.PersonFilter;

            if (_DriverFilter == null)
                _DriverFilter = new clsDriverFilter();

            _DriverFilter.AgeOlderThen = personFilter.AgeOlderThen;
            _DriverFilter.AgeYoungerThen = personFilter.AgeYoungerThen;
            _DriverFilter.Gendor = personFilter.Gendor;
            _DriverFilter.NationalityCountryID = personFilter.NationalityCountryID;


            return _DriverFilter;
        }

        private void _Set(clsDriverFilter filter)
        {
            if (filter == null) return;

            ucPeopleFilter1.PersonFilter = filter;

        }
    }
}
