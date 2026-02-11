using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DTOs
{
    public class clsLicenseCardInfo_DTO : IDTO
    {
        public int ID { get => LicenseID; set => LicenseID = value; }
        public int LicenseID { get; set; }
        public int DriverID { get; set; }
        public clsLicenseEnums.enLicenseClasses LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
        public clsLicenseEnums.enIssueReason IssueReason { get; set; }
       
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public clsPersonEnums.enGendor Gendor { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImagePath { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
            }
            private set { }
        }
    }
}
