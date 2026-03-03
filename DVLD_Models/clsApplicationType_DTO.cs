using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DTOs
{
    public class clsApplicationType_DTO : IDTO
    {
        int IDTO.ID { get => ApplicationTypeID; set => value = ApplicationTypeID; }
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { get; set; }

    }
}
