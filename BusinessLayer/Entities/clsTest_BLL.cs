using Common.Queries;
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
        public static int GetCount(IQuery query)
        {
            return clsTest_DAL.LoadCount(query as clsTestQuery);
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

        

        private bool _AddNewTest()
        {
            this.Test.TestID = clsTest_DAL.AddNewTest(this.Test);
            
            if (this.Test.TestID > -1) clsTestAppointment_BLL.LockedTestAppointment(this.Test.TestAppointmentID);

            if (clsTestAppointment_BLL.GetLastTestType(this.Test.TestAppointmentID) ==
                Common.clsTestEnums.enTestTypes.PracticalTest && this.Test.TestResult)
            {
                clsApplication_BLL.SetComplete(clsTestAppointment_BLL.GetApplicationIDByTestAppointmentID(this.Test.TestAppointmentID));
            }
            return (this.Test.TestID > -1);
        }

        private bool _UpdateTest()
        {
            clsTestAppointment_BLL.LockedTestAppointment(this.Test.TestAppointmentID);
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
        public static List<clsTest_DTO> GetTests(int Offset, int CountRows , IQuery Query)
        {
            return clsTest_DAL.LoadTests(Offset, CountRows , Query as clsTestQuery);
        }
        public static bool IsDriverPassedInAllTests(int DriverID, int LicenseClassID)
        {
            return clsTest_DAL.IsDriverPassedInAllTests(DriverID, LicenseClassID);
        }
        public static bool DeleteTest(int TestID)
        {
            return clsTest_DAL.DeleteTest(TestID);
        }
    }
}
