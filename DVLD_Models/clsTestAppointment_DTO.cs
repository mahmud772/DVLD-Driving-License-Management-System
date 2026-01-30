using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DTO
{
    public class clsTestAppointment_DTO : IDTO
    {
        public int ID { get => TestAppointmentID; set => value = TestAppointmentID; }
        public int TestAppointmentID { get; set; }
        public int TestTypeID { get;private set; }
        public clsTestEnums.enTestTypes TestType 
        {
            get
            { 
                return clsTestEnums.ConvertTestTypeToEnum(TestTypeID);
            }
            set 
            { 
                TestTypeID = clsTestEnums.ConvertTestTypeToInt(value);
            }
        }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }
    }
}
