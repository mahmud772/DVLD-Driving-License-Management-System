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
    public partial class ucUsersFilter : UserControl , IUserControlFilter
    {
        private clsUserFilter _UserFilter;

        public clsUserFilter UserFilter
        {
            get => _Get();
            set
            {
                _UserFilter = value;
                _Set(value);
            }
        }

        IFilter IUserControlFilter.Filter
        {
            get => UserFilter;
            set
            {
                if (value is clsUserFilter filter)
                    UserFilter = filter;
            }
        }

        private clsUserFilter _Get()
        {
            var personFilter = ucPeopleFilter1.PersonFilter;

            if (_UserFilter == null)
                _UserFilter = new clsUserFilter();

            // بما أن User لا يملك خصائص إضافية
            // فقط ننسخ خصائص Person
            _UserFilter.AgeOlderThen = personFilter.AgeOlderThen;
            _UserFilter.AgeYoungerThen = personFilter.AgeYoungerThen;
            _UserFilter.Gendor = personFilter.Gendor;
            _UserFilter.NationalityCountryID = personFilter.NationalityCountryID;

            return _UserFilter;
        }

        private void _Set(clsUserFilter filter)
        {
            if (filter == null) return;

            // نمرر الفلتر مباشرة إلى PeopleFilter
            ucPeopleFilter1.PersonFilter = filter;
        }
        public ucUsersFilter()
        {
            InitializeComponent();
        }
    }
}
