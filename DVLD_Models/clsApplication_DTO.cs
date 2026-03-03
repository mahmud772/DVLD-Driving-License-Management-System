using Common;
using DVLD_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DTOs
{
    public class clsApplication_DTO : IDTO
    {
        int IDTO.ID { get => ApplicationID; set => value = ApplicationID; }
        public clsApplicationEnums.enApplicationStatus ApplicationStatus { get; set; }
        public int ApplicationID { get;  set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicantPersonID { get; set; }
        public int ApplicationTypeID { get; set; }
        public DateTime LastStatusDate { get;  set; }
        public decimal PaidFees { get;  set; }
        public int CreatedByUserID { get; set; }

        
    }
}
