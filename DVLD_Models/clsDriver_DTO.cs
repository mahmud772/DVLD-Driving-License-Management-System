using DVLD_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DTO
{
    public class clsDriver_DTO : clsPerson_DTO 
    {
        public int DriverID { get; set; }
        
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
