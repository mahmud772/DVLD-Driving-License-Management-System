using Common;
using Common.Helpers;
using Common.Queries;
using DVLD_DAL;
using DVLD_DTOs;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DVLD_BLL
{
    public class clsLicense_BLL : IBLL
    {
        enMode Mode = enMode.Create;
        public bool IsNew => Mode == enMode.Create;
        public clsLicense_DTO License { get; set; }
        public clsLicenseCardInfo_DTO CardInfo { get; set; }
        public IDTO DTO { get => CardInfo; set => CardInfo = value as clsLicenseCardInfo_DTO; }

        private static bool _IsFirstTime = true;

        public clsLicense_BLL()
        {
            this.License = new clsLicense_DTO
            {
                LicenseID = -1,
                ApplicationID = -1,
                DriverID = -1,
                LicenseClass = 0,
                IssueDate = DateTime.MinValue,
                ExpirationDate = DateTime.MinValue,
                Notes = "",
                PaidFees = -1,
                IsActive = true,
                IssueReason = 0,
                CreatedByUserID = -1
            };
            this.Mode = enMode.Create;
        }

        private clsLicense_BLL(clsLicense_DTO Model)
        {
            this.License = Model;
            this.Mode = enMode.Update;
        }
        private clsLicense_BLL(clsLicenseCardInfo_DTO Model)
        {
            this.CardInfo = Model;
            this.Mode = enMode.Create;
        }
        public static int GetCount(IQuery query)
        {
            return clsLicense_DAL.LoadCount(query as clsLicenseQuery);
        }

        public static clsLicense_BLL FindByID(int LicenseID)
        {
            clsLicense_DTO Model = clsLicense_DAL.LoadLicenseInfoByID(LicenseID);
            return Model == null ? null : new clsLicense_BLL(Model);
        }


        public static int GetDriverIDByLicenseID(int LicenseID)
        {
            return clsLicense_DAL.LoadDriverIDByLicenseID(LicenseID);
        }



        private bool _AddNewLicense()
        {
            this.License.PaidFees = clsLicenseClass_BLL.GetClassFees(clsLicenseEnumConverter.ToInt(this.License.LicenseClass));
            this.License.IssueDate = clsBLHelper.GetDate_Now();
            if (_IsFirstTime)
            {
                this.License.ApplicationID = clsDriver_DAL.LoadLocalApplicationIDByDriverID(this.License.DriverID, clsLicenseEnumConverter.ToInt(this.License.LicenseClass));
                this.License.IssueReason = clsLicenseEnums.enIssueReason.New;
            }
            if (this.License.IssueReason == clsLicenseEnums.enIssueReason.New || this.License.IssueReason == clsLicenseEnums.enIssueReason.Renew)
                this.License.ExpirationDate = clsBLHelper.GetDate_Now().AddYears(clsLicenseClass_BLL.GetDefaultValidityLength(clsLicenseEnumConverter.ToInt(this.License.LicenseClass)));


            this.License.CreatedByUserID = clsCurrentUser.User.UserID;
            this.License.IsActive = true;

            this.License.LicenseID = clsLicense_DAL.AddNewLicense(this.License);
            return (this.License.LicenseID > -1);
        }

        private bool _UpdateLicense()
        {
            this.License.PaidFees = clsLicenseClass_BLL.GetClassFees(clsLicenseEnumConverter.ToInt(this.License.LicenseClass));

            return clsLicense_DAL.UpdateLicense(this.License);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Create:
                    if (_AddNewLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _UpdateLicense();
            }
            return false;
        }
        public static List<clsLicense_DTO> GetLicenses()
        {
            return clsLicense_DAL.LoadLicenses();
        }
        public static List<clsLicenseCardInfo_DTO> GetLicensesCardsInfo()
        {
            return clsLicense_DAL.LoadLicensesCardsInfo();
        }
        public static List<clsLicense_DTO> GetLicenses(int Offset, int CountRows)
        {
            return clsLicense_DAL.LoadLicenses(Offset, CountRows);
        }
        public static List<clsLicenseCardInfo_DTO> GetLicensesCardsInfo(int Offset, int CountRows, IQuery Query)
        {
            return clsLicense_DAL.LoadLicensesCardsInfo(Offset, CountRows , Query as clsLicenseQuery);
        }
        private static bool _RenewAndReplacementLicense(int LicenseID, int ApplicationID, clsLicenseEnums.enIssueReason IssueReason)
        {
            if (ApplicationID <= 0) return false;

            clsLicense_BLL OldLicense = FindByID(LicenseID);
            if (OldLicense == null || !OldLicense.License.IsActive) return false;

            if ( IssueReason == clsLicenseEnums.enIssueReason.Renew && OldLicense.License.ExpirationDate < clsBLHelper.GetDate_Now() ) return false;
            //  إيقاف الرخصة القديمة



            OldLicense.License.IsActive = false;
            if (!OldLicense.Save()) return false;

            //  إنشاء كائن الرخصة الجديد بنسخ البيانات
            clsLicense_BLL NewLicense = new clsLicense_BLL();


            // نسخ القيم الضرورية من الرخصة القديمة
            NewLicense.License.DriverID = OldLicense.License.DriverID;
            NewLicense.License.LicenseClass = OldLicense.License.LicenseClass;
            NewLicense.License.Notes = OldLicense.License.Notes;

            // إسناد القيم الجديدة
            NewLicense.License.ApplicationID = ApplicationID;
            NewLicense.License.IssueReason = IssueReason;


            NewLicense.License.ApplicationID = ApplicationID;

            //NewLicense = OldLicense;
            NewLicense.License.IssueReason = IssueReason;
            NewLicense.License.IsActive = true;

            return NewLicense.Save();

        }
        public static bool RenewLicense(int LicenseID, int ApplicationID)
        {
            return _RenewAndReplacementLicense(LicenseID, ApplicationID, clsLicenseEnums.enIssueReason.Renew);
        }

        public static bool ReplacementforLostLicense(int LicenseID, int ApplicationID)
        {
            return _RenewAndReplacementLicense(LicenseID, ApplicationID, clsLicenseEnums.enIssueReason.ReplacementForLost);
        }

        public static bool ReplacementforDamagedLicense(int LicenseID, int ApplicationID)
        {
            return _RenewAndReplacementLicense(LicenseID, ApplicationID, clsLicenseEnums.enIssueReason.ReplacementForDamaged);
        }

        public static clsLicense_BLL GetLicenseCardInfo(int LicenseID)
        {
            clsLicenseCardInfo_DTO Model = clsLicense_DAL.LoadLicenseCardInfo(LicenseID);
            return Model == null ? null : new clsLicense_BLL(Model);
        }
        public static bool DeleteLicense(int LicenseID)
        {
            return clsLicense_DAL.DeleteLicenseByID(LicenseID);
        }
    }


}
