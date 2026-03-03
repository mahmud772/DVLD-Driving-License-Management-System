using DVLD_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DTOs
{
    public class clsDriver_DTO : clsPerson_DTO , IDTO
    {
        public int DriverID { get; set; }
        int IDTO.ID { get => DriverID; set => DriverID = value ; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
