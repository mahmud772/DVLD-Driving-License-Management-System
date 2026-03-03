using Common;
using Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DTOs
{
    public class clsLicense_DTO : IDTO
    {
        int IDTO.ID { get => LicenseID; set => value = LicenseID; }
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID {  get;private set; }
        public clsLicenseEnums.enLicenseClasses LicenseClass 
        { 
            get
            {
                return clsLicenseEnumConverter.ToClass(LicenseClassID);
            }
            
            set
            {
                LicenseClassID = clsLicenseEnumConverter.ToInt(value);
            }
        }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public clsLicenseEnums.enIssueReason IssueReason { get; set; }
        public int CreatedByUserID { get; set; }
    }
}
