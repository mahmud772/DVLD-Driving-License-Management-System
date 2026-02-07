using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Filters
{
    public class clsPersonFilter : IFilter
    {
        public int? AgeOlderThen { get; set; }
        public int? AgeYoungerThen { get; set; }
        public clsPersonEnums.enGendor? Gendor { get; set; }
        public int? NationalityCountryID { get; set; }
    }
}
