using Common;
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
    public class clsInternationalLicense_BLL : IBLL
    {
        enMode Mode = enMode.Create;
        public bool IsNew => Mode == enMode.Create;
        public clsInternationalLicense_DTO InternationalLicense { get; set; }
        public IDTO DTO { get => InternationalLicense; set=> InternationalLicense = value as clsInternationalLicense_DTO; }
        public clsInternationalLicense_BLL()
        {
            this.InternationalLicense = new clsInternationalLicense_DTO
            {
                InternationalLicenseID = -1,
                ApplicationID = -1,
                DriverID = -1,
                IssuedUsingLocalLicenseID = -1,
                IssueDate = DateTime.MinValue,
                ExpirationDate = DateTime.MinValue,
                IsActive = false,
                CreatedByUserID = -1
            };
            this.Mode = enMode.Create;
        }

        private clsInternationalLicense_BLL(clsInternationalLicense_DTO Model)
        {
            this.InternationalLicense = Model;
            this.Mode = enMode.Update;
        }

        public static int GetCount(IQuery query)
        {
            return clsInternationalLicense_DAL.LoadCount(query as clsLicenseQuery);
        }

        public static clsInternationalLicense_BLL FindByID(int InternationalLicenseID)
        {
            clsInternationalLicense_DTO Model = clsInternationalLicense_DAL.LoadInternationalLicenseByID(InternationalLicenseID);
            return Model == null ? null : new clsInternationalLicense_BLL(Model);
        }

        public static bool FindByID(int InternationalLicenseID, out clsInternationalLicense_BLL InternationalLicense)
        {
            clsInternationalLicense_DTO Model = clsInternationalLicense_DAL.LoadInternationalLicenseByID(InternationalLicenseID);
            if (Model == null)
            {
                InternationalLicense = null;
                return false;
            }
            InternationalLicense = new clsInternationalLicense_BLL(Model);
            return true;
        }


        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicense.IssueDate = clsBLHelper.GetDate_Now();
            this.InternationalLicense.ExpirationDate = clsBLHelper.GetDate_Now().AddYears(clsLicenseClass_BLL.GetDefaultValidityLength(clsLicense_DAL.LoadLicenseClassIDByLicenseID(this.InternationalLicense.IssuedUsingLocalLicenseID)));
            this.InternationalLicense.InternationalLicenseID = clsInternationalLicense_DAL.AddNewInternationalLicense(this.InternationalLicense);
            return (this.InternationalLicense.InternationalLicenseID > -1);
        }

        private bool _UpdateInternationalLicense()
        {
            return clsInternationalLicense_DAL.UpdateInternationalLicense(this.InternationalLicense);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Create:
                    if (_AddNewInternationalLicense())
                    {
                        Mode = enMode.Update;
                        clsApplication_BLL.SetComplete(this.InternationalLicense.ApplicationID);
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _UpdateInternationalLicense();
            }
            return false;
        }

        public static List<clsInternationalLicense_DTO> GetInternationalLicenses()
        {
            return clsInternationalLicense_DAL.LoadInternationalLicenses();
        }
        public static List<clsInternationalLicense_DTO> GetInternationalLicenses(int Offset, int CountRows)
        {
            return clsInternationalLicense_DAL.LoadInternationalLicenses(Offset , CountRows);
        }
        public static List<clsLicenseCardInfo_DTO> GetInternationalLicensesCardsInfo(int Offset, int CountRows, IQuery Query)
        {
            return clsInternationalLicense_DAL.LoadInternationalLicensesCardsInfo(Offset, CountRows , Query as clsLicenseQuery);
        }
        public static bool DeleteInternationalLicense(int InternationalLicense)
        {
            return clsInternationalLicense_DAL.DeleteInternationalLicenseByID(InternationalLicense);
        }
        public static int GetPersonIDByInternationalLicenseID(int InternationalLicenseID)
        {
            return clsInternationalLicense_DAL.LoadPersonIDByInternationalLicenseID(InternationalLicenseID);
        }
    }
}
