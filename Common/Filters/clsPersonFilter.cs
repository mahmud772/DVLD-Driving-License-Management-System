using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Filters
{
    public class clsPersonFilter : IFilter
    {
        public DateTime? DateOfBirth { get; set; }
        public clsPersonEnums.enGendor? Gendor { get; set; }
        public int? NationalityCountryID { get; set; }
    }
}
