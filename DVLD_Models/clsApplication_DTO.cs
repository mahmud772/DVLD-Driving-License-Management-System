using Common;
using DVLD_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Models
{
    public class clsApplication_DTO : IDTO
    {
       
        public clsApplicationEnums.enApplicationStatus ApplicationStatus { get; set; }
        public int ID { get => ApplicationID; set => value = ApplicationID; }
        public int ApplicationID { get;  set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicantPersonID { get; set; }
        public int ApplicationTypeID { get; set; }
        public DateTime LastStatusDate { get;  set; }
        public decimal PaidFees { get;  set; }
        public int CreatedByUserID { get; set; }

        
    }
}
