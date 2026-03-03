using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DTOs
{
    public class clsDetainedLicense_DTO : IDTO
    {
        int IDTO.ID { get => LicenseID; set => value = LicenseID; }
        public int LicenseID { get; set; }
        public int DetainID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }
    }
}
