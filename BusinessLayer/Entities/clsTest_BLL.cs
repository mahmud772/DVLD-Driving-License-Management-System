using DVLD_DAL;
using DVLD_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    public class clsTest_BLL : IBLL
    {
        enMode Mode = enMode.Create;
        public bool IsNew => Mode == enMode.Create;
        public clsTest_DTO Test { get; set; }
        public IDTO DTO { get => Test; set => value = Test; }

        public clsTest_BLL()
        {
            this.Test = new clsTest_DTO
            {
                TestID = -1,
                TestAppointmentID = -1,
                TestResult = false,
                Notes = string.Empty,
                CreatedByUserID = -1
            };
            this.Mode = enMode.Create;
        }

        private clsTest_BLL(clsTest_DTO Model)
        {
            this.Test = Model;
            this.Mode = enMode.Update;
        }

        public static int GetCount()
        {
            return clsTest_DAL.LoadCount();
        }

        public static clsTest_BLL FindByID(int TestID)
        {
            clsTest_DTO Model = clsTest_DAL.LoadTestByID(TestID);
            return Model == null ? null : new clsTest_BLL(Model);
        }

        public static bool FindByID(int TestID, out clsTest_BLL Test)
        {
            clsTest_DTO Model = clsTest_DAL.LoadTestByID(TestID);
            if (Model == null)
            {
                Test = null;
                return false;
            }
            Test = new clsTest_BLL(Model);
            return true;
        }

        // --- منطق الحفظ والتحديث ---

        private bool _AddNewTest()
        {
            this.Test.TestID = clsTest_DAL.AddNewTest(this.Test);
            return (this.Test.TestID > -1);
        }

        private bool _UpdateTest()
        {
            clsTestAppointment_BLL Appointment = clsTestAppointment_BLL.FindByID(this.Test.TestAppointmentID);
            Appointment.Appointment.IsLocked = true;
            if (!Appointment.Save()) return false;
            return clsTest_DAL.UpdateTest(this.Test);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Create:
                    if (_AddNewTest())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _UpdateTest();
            }
            return false;
        }

        public static List<clsTest_DTO> GetTests()
        {
            return clsTest_DAL.LoadTests();
        }
        public static List<clsTest_DTO> GetTests(int Offset, int CountRows)
        {
            return clsTest_DAL.LoadTests(Offset, CountRows);
        }
        public static bool IsDriverPassedInAllTests(int DriverID, int LicenseClassID)
        {
            return clsTest_DAL.IsDriverPassedInAllTests(DriverID, LicenseClassID);
        }
    }
}
