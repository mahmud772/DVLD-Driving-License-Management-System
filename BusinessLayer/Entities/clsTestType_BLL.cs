using DVLD_DAL;
using DVLD_DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace DVLD_BLL
{
    public class clsTestType_BLL
    {
        enMode Mode = enMode.Create;
        public bool IsNew => Mode == enMode.Create;
        public clsTestType_DTO TestType { get; set; }

        public clsTestType_BLL()
        {
            this.TestType = new clsTestType_DTO
            {
                TestTypeID = -1,
                TestTypeTitle = string.Empty,
                TestTypeDescription = string.Empty,
                TestTypeFees = -1
            };
            this.Mode = enMode.Create;
        }

        private clsTestType_BLL(clsTestType_DTO Model)
        {
            this.TestType = Model;
            this.Mode = enMode.Update;
        }

        public static int GetCount()
        {
            return clsTestType_DAL.LoadCount();
        }

        public static clsTestType_BLL FindByID(int TestTypeID)
        {
            clsTestType_DTO Model = clsTestType_DAL.LoadTestTypeByID(TestTypeID);
            return Model == null ? null : new clsTestType_BLL(Model);
        }

        public static bool FindByID(int TestTypeID, out clsTestType_BLL TestType)
        {
            clsTestType_DTO Model = clsTestType_DAL.LoadTestTypeByID(TestTypeID);
            if (Model == null)
            {
                TestType = null;
                return false;
            }
            TestType = new clsTestType_BLL(Model);
            return true;
        }

        // --- منطق الحفظ والتحديث ---

        private bool _AddNewTestType()
        {
            // 💡 يفترض وجود دالة AddNewTestType في DAL تعيد الـ ID
            this.TestType.TestTypeID = clsTestType_DAL.AddNewTestType(this.TestType);
            return (this.TestType.TestTypeID > -1);
        }

        private bool _UpdateTestType()
        {
            // 💡 يفترض وجود دالة UpdateTestType في DAL
            return clsTestType_DAL.UpdateTestType(this.TestType);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Create:
                    if (_AddNewTestType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _UpdateTestType();
            }
            return false;
        }

        
        

        public static List<clsTestType_DTO> GetAllTestTypes()
        {
            return clsTestType_DAL.LoadAllTestTypes();
        }
        public static bool DeleteTestType(int TestTypeID)
        {
            return clsTestType_DAL.DeleteTestType(TestTypeID);
        }

        public static decimal GetPaidFees(int TestTypeID)
        {
            return clsStaticData_BLL.TestTypes[TestTypeID].TestTypeFees;
        }
        public static string GetTestTypeTitle(int TestTypeID)
        {
            return clsStaticData_BLL.TestTypes[TestTypeID].TestTypeTitle;
        }
    }
}
