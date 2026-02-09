using Common;
using Common.Queries;
using DVLD_DAL;
using DVLD_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    public class clsLocalDrivingLicenseApplication_BLL : clsApplication_BLL, IBLL
    {
        enMode Mode = enMode.Create;
        public clsLocalDrivingLicenseApplication_DTO LocalApplication { get; set; }

        public clsLocalDrivingLicenseApplication_BLL() : base()
        {
            this.LocalApplication = new clsLocalDrivingLicenseApplication_DTO
            {
                LocalDrivingLicenseApplicationID = -1,
                ApplicationID = -1,
                LicenseClassID = -1,

                ApplicationStatus = 0,
                ApplicationDate = DateTime.MinValue,
                ApplicantPersonID = -1,
                ApplicationTypeID = -1,
                LastStatusDate = DateTime.MinValue,
                PaidFees = -1,
                CreatedByUserID = -1
            };
            base.Application = this.LocalApplication;
            this.Mode = enMode.Create;
        }

        private clsLocalDrivingLicenseApplication_BLL(clsLocalDrivingLicenseApplication_DTO Model) : base(Model)
        {
            this.LocalApplication = Model;
            base.Application = this.LocalApplication;
            this.Mode = enMode.Update;
        }

        public static int GetCount(IQuery query)
        {
            return clsLocalDrivingLicenseApplication_DAL.LoadCount(query as clsLocalDrivingLicenseApplicationQuery);
        }

        public static clsLocalDrivingLicenseApplication_BLL FindByLocaLicenseApplicationlID(int LocalDrivingLicenseApplicationID)
        {

            clsLocalDrivingLicenseApplication_DTO Model = clsLocalDrivingLicenseApplication_DAL.LoadLocalDrivingLicenseApplicationByID(LocalDrivingLicenseApplicationID);
            return Model == null ? null : new clsLocalDrivingLicenseApplication_BLL(Model);
        }

        public static bool FindByLocaLicenseApplicationlID(int LocalDrivingLicenseApplicationID, out clsLocalDrivingLicenseApplication_BLL LocalApplication)
        {
            clsLocalDrivingLicenseApplication_DTO Model = clsLocalDrivingLicenseApplication_DAL.LoadLocalDrivingLicenseApplicationByID(LocalDrivingLicenseApplicationID);
            if (Model == null)
            {
                LocalApplication = null;
                return false;
            }
            LocalApplication = new clsLocalDrivingLicenseApplication_BLL(Model);
            return true;
        }

        private bool _CreateLocalApplication()
        {
            this.LocalApplication.ApplicationID = base.Application.ApplicationID;
            this.LocalApplication.ApplicantPersonID = base.Application.ApplicantPersonID;
            byte Age = clsUtil.CalculateAge(clsApplication_DAL.GetDateOfBirthByApplicationID(this.LocalApplication.ApplicationID));
            if (Age < clsLicenseClass_BLL.MinimumAllowedAge(this.LocalApplication.LicenseClassID)) return false;
            this.Application.ApplicationStatus = clsApplicationEnums.enApplicationStatus.New;

            this.Application.ApplicationTypeID = (int)clsApplicationEnums.enApplicationType.NewLocalDrivingLicense;

            this.LocalApplication.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplication_DAL.AddNewLocalDrivingLicenseApplication(this.LocalApplication);

            return (this.LocalApplication.LocalDrivingLicenseApplicationID > -1);
        }

        private bool _UpdateLocalApplication()
        {
            this.Application.ApplicationTypeID = (int)clsApplicationEnums.enApplicationType.NewLocalDrivingLicense;

            return clsLocalDrivingLicenseApplication_DAL.UpdateLocalDrivingLicenseApplication(this.LocalApplication);
        }

        public override bool Save()
        {

            if (!base.Save()) { return false; }
            ;

            switch (Mode)
            {
                case enMode.Create:
                    if (_CreateLocalApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _UpdateLocalApplication();
            }
            return false;
        }

        public static bool DeleteLocalDrivingLicenseApplicationByApplicationID(int ApplicationID)
        {
            return (clsLocalDrivingLicenseApplication_DAL.DeleteLocalDrivingLicenseApplicationByApplicationID(ApplicationID));
        }

        public static List<clsLocalDrivingLicenseApplication_DTO> GetLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplication_DAL.LoadLocalDrivingLicenseApplications();
        }
        public static List<clsLocalDrivingLicenseApplication_DTO> GetLocalDrivingLicenseApplications(int Offset, int CountRows , IQuery Query)
        {
            return clsLocalDrivingLicenseApplication_DAL.LoadLocalDrivingLicenseApplications(Offset, CountRows , Query as clsLocalDrivingLicenseApplicationQuery);
        }

    }
}
