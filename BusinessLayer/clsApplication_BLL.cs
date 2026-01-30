using DVLD_DAL;
using DVLD_Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DVLD_DTO;

namespace DVLD_BLL
{
    public enum enMode { Create = 1, Update = 2 }
    public class clsApplication_BLL : IBLL
    {

        enMode Mode = enMode.Create;
        public bool IsNew => Mode == enMode.Create;
        public clsApplication_DTO Application { get; set; }
        public IDTO DTO { get => Application; set => value = Application; }
        public clsApplication_BLL()
        {
            Application = new clsApplication_DTO
            {
                ApplicationStatus = 0,
                ApplicationID = -1,
                ApplicationDate = DateTime.MinValue,
                ApplicantPersonID = -1,
                ApplicationTypeID = -1,
                LastStatusDate = DateTime.MinValue,
                PaidFees = -1,
                CreatedByUserID = -1
            };
            Mode = enMode.Create;
        }

        protected clsApplication_BLL(clsApplication_DTO Application)
        {
            this.Application = Application;
            Mode = enMode.Update;

        }

        public static int GetCount()
        {
            return clsApplication_DAL.LoadCount();
        }

        public static clsApplication_BLL FindByApplicationID(int ApplicationID)
        {

            clsApplication_DTO Model = clsApplication_DAL.LoadApplicationInfoByID(ApplicationID);

            return Model == null ? null : new clsApplication_BLL(Model);
        }

        public static bool FindByApplicationID(int ApplicationID, out clsApplication_BLL Application)
        {
            clsApplication_DTO Model = clsApplication_DAL.LoadApplicationInfoByID(ApplicationID);

            if (Model == null)
            {
                Application = null;
                return false;
            }

            Application = new clsApplication_BLL(Model);
            return true;
        }


        public static clsApplication_BLL FindByPersonID(int ApplicatPersonID)
        {
            clsApplication_DTO Model = clsApplication_DAL.LoadApplicationInfoByPersonID(ApplicatPersonID);
            return Model == null ? null : new clsApplication_BLL(Model);
        }

        public static bool SetComplete(int ApplicationID)
        {
            return clsApplication_DAL.UpdateApplicationStatus(ApplicationID, clsApplicationEnums.ConvertApplicationStatusToByte(clsApplicationEnums.enApplicationStatus.Completed), DateTime.Now);
        }

        public static bool SetCancelle(int ApplicationID)
        {
            return clsApplication_DAL.UpdateApplicationStatus(ApplicationID, clsApplicationEnums.ConvertApplicationStatusToByte(clsApplicationEnums.enApplicationStatus.Cancelled), DateTime.Now);
        }

        private bool _CreateApplication()
        {
            this.Application.ApplicationStatus = clsApplicationEnums.enApplicationStatus.New;
            this.Application.LastStatusDate = clsBLHelper.GetDate_Now();
            this.Application.ApplicationDate = clsBLHelper.GetDate_Now();
            this.Application.PaidFees = clsApplicationType_BLL.GetApplicationFees(this.Application.ApplicationTypeID);

            this.Application.CreatedByUserID = 17;

            this.Application.ApplicationID = clsApplication_DAL.CreateApplication(this.Application);
            return (this.Application.ApplicationID > 0);
        }

        private bool _UpdateApplication()
        {
            this.Application.LastStatusDate = clsBLHelper.GetDate_Now();
            this.Application.PaidFees = clsApplicationType_BLL.GetApplicationFees(this.Application.ApplicationTypeID);

            return clsApplication_DAL.UpdateApplication(this.Application);
        }


        public virtual bool Save()
        {
            switch (Mode)
            {
                case enMode.Create:
                    if (_CreateApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _UpdateApplication();


            }
            return false;
        }

        public static List<clsApplication_DTO> GetApplications()
        {
            return clsApplication_DAL.LoadApplications();
        }
        public static List<clsApplication_DTO> GetApplications(int Offset, int CountRows)
        {
            return clsApplication_DAL.LoadApplications(Offset, CountRows);
        }
        public static bool DeleteApplication(int ApplicationID)
        {
            return clsApplication_DAL.DeleteApplicationByID(ApplicationID);
        }
    }
}
