using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DTOs
{
    public class clsCountry_DTO : IDTO
    {
        int IDTO.ID { get => CountryID; set => value = CountryID; }
        public int CountryID { get; set; }
        public string CountryName { get; set; }
    }
}
