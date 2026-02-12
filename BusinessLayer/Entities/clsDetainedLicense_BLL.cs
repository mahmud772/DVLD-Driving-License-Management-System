using Common;
using Common.Helpers;
using Common.Queries;
using DVLD_DAL;
using DVLD_DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
namespace DVLD_BLL
{
    public class clsDetainedLicense_BLL : IBLL
    {
        enMode Mode = enMode.Create;
        public bool IsNew => Mode == enMode.Create;
        public clsDetainedLicense_DTO Detain { get; set; }
        public IDTO DTO { get => Detain; set => value = Detain; }
        public clsDetainedLicense_BLL()
        {
            this.Detain = new clsDetainedLicense_DTO
            {
                DetainID = -1,
                DetainDate = DateTime.MinValue,
                CreatedByUserID = -1,
                LicenseID = -1,
                ReleaseApplicationID = -1,
                ReleaseDate = DateTime.MinValue,
                ReleasedByUserID = -1,
                PaidFees = -1,
                IsReleased = false
            };

            this.Mode = enMode.Create;
        }

        private clsDetainedLicense_BLL(clsDetainedLicense_DTO Detain)
        {
            this.Detain = Detain;
            this.Mode = enMode.Update;

        }

        public static int GetCount(IQuery query)
        {
            return clsDetainedLicense_DAL.LoadCount(query as clsDetainedLicenseQuery);
        }

        public static clsDetainedLicense_BLL FindByDetainID(int DetainID)
        {
            clsDetainedLicense_DTO Detain = clsDetainedLicense_DAL.LoadDetainedLicenseByID(DetainID);

            return Detain == null ? null : new clsDetainedLicense_BLL(Detain);
        }
        public static clsDetainedLicense_BLL FindDetainedLicenseByLicenseID(int LicenseID)
        {
            clsDetainedLicense_DTO Detain = clsDetainedLicense_DAL.LoadDetainedLicenseByLicenseID(LicenseID);

            return Detain == null ? null : new clsDetainedLicense_BLL(Detain);
        }

        public static bool FindByDetainID(int DetainID, out clsDetainedLicense_BLL Detain)
        {
            clsDetainedLicense_DTO Model = clsDetainedLicense_DAL.LoadDetainedLicenseByID(DetainID);

            if (Model == null)
            {
                Detain = null;
                return false;
            }

            Detain = new clsDetainedLicense_BLL(Model);
            return true;
        }



        public bool ReleaseLicense()
        {

            if (this.IsNew || this.Detain.IsReleased) return false;
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    int DriverID = clsLicense_BLL.GetDriverIDByLicenseID(this.Detain.LicenseID);
                    if (DriverID < 1) return false;
                    int PersonID = clsDriver_BLL.GetPersonIDByDriverID(DriverID);
                    if (PersonID < 1) return false;
                    clsApplication_BLL Application = new clsApplication_BLL();
                    Application.Application.ApplicationTypeID = (int)clsApplicationEnums.enApplicationType.ReleaseDetainedDrivingLicsense;
                    Application.Application.ApplicationStatus = clsApplicationEnums.enApplicationStatus.Completed;
                    Application.Application.CreatedByUserID = 1;
                    Application.Application.ApplicantPersonID = PersonID;
                    Application.Application.LastStatusDate = clsBLHelper.GetDate_Now();
                    Application.Application.PaidFees = clsApplicationType_BLL.GetApplicationFees(clsApplicationEnumConverter.ToInt(clsApplicationEnums.enApplicationType.RetakeTest));
                    Application.Application.ApplicationDate = clsBLHelper.GetDate_Now();

                    if (!Application.Save()) return false;

                    this.Detain.IsReleased = true;
                    this.Detain.ReleaseDate = clsBLHelper.GetDate_Now();
                    this.Detain.ReleasedByUserID = 1;
                    this.Detain.ReleaseApplicationID = Application.Application.ApplicationID;

                    if (!clsDetainedLicense_DAL.ReleaseLicense(this.Detain)) return false;

                    scope.Complete();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }


        }

        public static bool ReleaseLicense(int LicenseID, int ApplicationID)
        {
            clsDetainedLicense_DTO detainedLicense = FindDetainedLicenseByLicenseID(LicenseID)?.Detain;
            detainedLicense.IsReleased = true;
            detainedLicense.ReleaseDate = clsBLHelper.GetDate_Now();
            detainedLicense.ReleasedByUserID = clsCurrentUser.User.UserID;
            detainedLicense.ReleaseApplicationID = ApplicationID;

            if (clsDetainedLicense_DAL.ReleaseLicense(detainedLicense)) return true;

            return false;
        }
        private bool _AddNewDetain()
        {
            this.Detain.DetainDate = clsBLHelper.GetDate_Now();
            this.Detain.CreatedByUserID = clsCurrentUser.User.UserID;
            this.Detain.DetainDate = clsBLHelper.GetDate_Now();
            this.Detain.DetainID = clsDetainedLicense_DAL.AddNewDetainedLicense(this.Detain);
            return (this.Detain.DetainID > 0);
        }

        private bool _UpdateDetain()
        {


            //this.Detain.ReleaseDate = this.Detain.IsReleased ? DateTime.Now : DateTime.MinValue;

            return clsDetainedLicense_DAL.UpdateDetainedLicense(this.Detain);
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Create:
                    if (_AddNewDetain())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _UpdateDetain();


            }
            return false;
        }

        public static List<clsDetainedLicense_DTO> GetDetainedLicenses()
        {
            return clsDetainedLicense_DAL.LoadDetainedLicenses();
        }
        public static List<clsDetainedLicense_DTO> GetDetainedLicenses(int Offset, int CountRows)
        {
            return clsDetainedLicense_DAL.LoadDetainedLicenses(Offset, CountRows);
        }
        public static List<clsLicenseCardInfo_DTO> GetDetainedLicensesCardsInfo(int Offset, int CountRows, IQuery Query)
        {
            return clsDetainedLicense_DAL.LoadDetainedLicensesCardsInfo(Offset, CountRows , Query as clsDetainedLicenseQuery);
        }
        public static bool DeleteDetain(int DetainID)
        {
            return clsDetainedLicense_DAL.IsReleaseLicense(DetainID) ? false : clsDetainedLicense_DAL.DeleteDetainedLicenseByID(DetainID);
        }


    }
}
