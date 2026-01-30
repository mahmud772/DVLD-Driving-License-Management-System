using DVLD_DAL;
using DVLD_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    public class clsLicenseClass_BLL
    {
        enMode Mode = enMode.Create;
        public bool IsNew => Mode == enMode.Create;
        public clsLicenseClass_DTO LicenseClass { get; set; }

        public clsLicenseClass_BLL()
        {
            this.LicenseClass = new clsLicenseClass_DTO
            {
                LicenseClassID = -1,
                ClassName = string.Empty,
                ClassDescription = string.Empty,
                MinimumAllowedAge = 0,
                DefaultValidityLength = 0, // عدد سنوات الصلاحية
                ClassFees = 0
            };
            this.Mode = enMode.Create;
        }

        private clsLicenseClass_BLL(clsLicenseClass_DTO Model)
        {
            this.LicenseClass = Model;
            this.Mode = enMode.Update;
        }

        public static int GetCount()
        {
            return clsLicenseClass_DAL.LoadCount();
        }

        public static clsLicenseClass_BLL FindByID(int LicenseClassID)
        {
            clsLicenseClass_DTO Model = clsLicenseClass_DAL.LoadLicenseClassByID(LicenseClassID);
            return Model == null ? null : new clsLicenseClass_BLL(Model);
        }

        public static bool FindByID(int LicenseClassID, out clsLicenseClass_BLL LicenseClass)
        {
            clsLicenseClass_DTO Model = clsLicenseClass_DAL.LoadLicenseClassByID(LicenseClassID);
            if (Model == null)
            {
                LicenseClass = null;
                return false;
            }
            LicenseClass = new clsLicenseClass_BLL(Model);
            return true;
        }

        // --- منطق الحفظ والتحديث ---

        private bool _AddNewLicenseClass()
        {
            // 💡 يفترض وجود دالة AddNewLicenseClass في DAL تعيد الـ ID
            this.LicenseClass.LicenseClassID = clsLicenseClass_DAL.AddNewLicenseClass(this.LicenseClass);
            return (this.LicenseClass.LicenseClassID > -1);
        }

        private bool _UpdateLicenseClass()
        {
            // 💡 يفترض وجود دالة UpdateLicenseClass في DAL
            return clsLicenseClass_DAL.UpdateLicenseClass(this.LicenseClass);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Create:
                    if (_AddNewLicenseClass())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _UpdateLicenseClass();
            }
            return false;
        }

       
        public static List<clsLicenseClass_DTO> GetAllLicenseClasses()
        {
            return clsLicenseClass_DAL.LoadAllLicenseClasses();
        }

        public static decimal GetClassFees(int LicenseClassID)
        {
            return clsStaticData_BLL.LicenseClasses[LicenseClassID].ClassFees;
        }
        
        public static byte GetDefaultValidityLength(int LicenseClassID)
        {
            return clsStaticData_BLL.LicenseClasses[LicenseClassID].DefaultValidityLength;
        }


        public static bool DeleteLicenseClass(int LicenseClassID)
        {
            return clsLicenseClass_DAL.DeleteLicenseClass(LicenseClassID);
        }

        public static byte MinimumAllowedAge(int LicenseClassID)
        {
            return clsStaticData_BLL.LicenseClasses[LicenseClassID].MinimumAllowedAge;
        }

    }
}
