using DVLD_DAL;
using DVLD_DTO;
using DVLD_Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    public class clsApplicationType_BLL
    {


        enMode Mode = enMode.Create;
        public bool IsNew => Mode == enMode.Create;
        public clsApplicationType_DTO ApplicationType { get; set; }

        public clsApplicationType_BLL()
        {
            this.ApplicationType = new clsApplicationType_DTO
            {
                ApplicationTypeID = -1,
                ApplicationFees = -1,
                ApplicationTypeTitle = ""
            };
            Mode = enMode.Create;
        }

        private clsApplicationType_BLL(clsApplicationType_DTO ApplicationType)
        {
            this.ApplicationType = ApplicationType;
            Mode = enMode.Update;

        }

        public static int GetCount()
        {
            return clsApplicationType_DAL.LoadCount();
        }

        public static clsApplicationType_BLL FindByApplicationTypeID(int ApplicationID)
        {

            clsApplicationType_DTO ApplicationType = clsApplicationType_DAL.LoadApplicationTypeByID(ApplicationID);

            return ApplicationType == null ? null : new clsApplicationType_BLL(ApplicationType);
        }

        public static bool FindByApplicationTypeID(int ApplicationTypeID, out clsApplicationType_BLL ApplicationType)
        {
            clsApplicationType_DTO Model = clsApplicationType_DAL.LoadApplicationTypeByID(ApplicationTypeID);

            if (Model == null)
            {
                ApplicationType = null;
                return false;
            }

            ApplicationType = new clsApplicationType_BLL(Model);
            return true;
        }




        private bool _CreateApplicationType()
        {
            this.ApplicationType.ApplicationTypeID = clsApplicationType_DAL.AddNewApplicationType(this.ApplicationType);
            return (this.ApplicationType.ApplicationTypeID > -1);
        }

        private bool _UpdateApplicationType()
        {
            return clsApplicationType_DAL.UpdateApplicationType(this.ApplicationType);
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Create:
                    if (_CreateApplicationType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _UpdateApplicationType();


            }
            return false;
        }



        public static List<clsApplicationType_DTO> GetAllApplicationTypes()
        {
            return clsApplicationType_DAL.LoadAllApplicationTypes();
        }
        public static decimal GetApplicationFees(int ApplicationTypeID)
        {
            return clsStaticData_BLL.ApplicationTypes[ApplicationTypeID].ApplicationFees;

        }
        public static string GetApplicationTypeTitle(int ApplicationTypeID)
        {
            return clsStaticData_BLL.ApplicationTypes[ApplicationTypeID].ApplicationTypeTitle;

        }
    }
}
