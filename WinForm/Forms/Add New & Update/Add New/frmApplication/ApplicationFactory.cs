using Common;
using DVLD_BLL;
using DVLD_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDWinForm.User_Controls.Display.ucApplication
{
    public class ApplicationFactory
    {
        ComboBox _cbApplicationTypes;
        ComboBox _cbLicenseClass;
        public ApplicationFactory(ComboBox cbApplicationTypes , ComboBox cbLicenseClass) 
        { 
            _cbApplicationTypes = cbApplicationTypes;
            _cbLicenseClass = cbLicenseClass;
            _InitializeStaticDataToForm();
        }
        public void CreateApplication(clsApplication_DTO AppInfo,clsLocalDrivingLicenseApplication_DTO localInfo,
            int LicenseID,clsApplicationEnums.enApplicationType type,bool ExecuteLicenseOperation)
        {
            if (type == clsApplicationEnums.enApplicationType.NewLocalDrivingLicense)
            {
                CreateLocalApplication(AppInfo, localInfo);
            }
            else
            {
                CreateGeneralApplication(AppInfo,LicenseID, type, ExecuteLicenseOperation);
            }
        }
        private void _InitializeStaticDataToForm()
        {
            _cbApplicationTypes?.DataSource = clsStaticData_BLL.ApplicationTypes;
            _cbApplicationTypes.DisplayMember = "ApplicationTypeTitle";
            _cbApplicationTypes.ValueMember = "ApplicationTypeID";
            _cbLicenseClass?.DataSource = clsStaticData_BLL.LicenseClasses; ;
            _cbLicenseClass.DisplayMember = "ClassName";
            _cbLicenseClass.ValueMember = "LicenseClassID";
        }
        private void CreateLocalApplication(clsApplication_DTO appInfo,clsLocalDrivingLicenseApplication_DTO localInfo)
        {
            clsLocalDrivingLicenseApplication_BLL application = new clsLocalDrivingLicenseApplication_BLL();

            application.Application = appInfo;
            application.LocalApplication = localInfo;
            application.Save();
        }

        private void CreateGeneralApplication(clsApplication_DTO appInfo , int LicenseID
            ,clsApplicationEnums.enApplicationType type,
            bool executeLicenseOperation)
        {
            clsApplication_BLL application = new clsApplication_BLL();
            application.Application = appInfo;
            application.Save();
            int ID;
            if (type == clsApplicationEnums.enApplicationType.NewLocalDrivingLicense)
                ID = appInfo.ApplicantPersonID;
            else
                ID = LicenseID;             
            if (executeLicenseOperation)
            {
                LicenseOperationManager manager = new LicenseOperationManager();
                manager.ExecuteOperation(type, ID, application.Application.ApplicationID);
            }
        }
        public int GetPersonIDByApplicationType(int ID, clsApplicationEnums.enApplicationType type)
        {
            if(ID < 1) return -1;
            switch (type)
            {
                case clsApplicationEnums.enApplicationType.NewLocalDrivingLicense:
                    return ID;

                case clsApplicationEnums.enApplicationType.RenewDrivingLicense:
                case clsApplicationEnums.enApplicationType.ReplacementForLostDrivingLicense:
                case clsApplicationEnums.enApplicationType.ReplacementForDamagedDrivingLicense:
                    return clsLicense_BLL.GetPersonIDByLicenseID(ID);

                case clsApplicationEnums.enApplicationType.ReleaseDetainedDrivingLicsense:
                    return clsDetainedLicense_BLL.GetPersonIDByDetainID(ID);

                case clsApplicationEnums.enApplicationType.NewInternationalLicense:
                    return clsInternationalLicense_BLL.GetPersonIDByInternationalLicenseID(ID);

                case clsApplicationEnums.enApplicationType.RetakeTest:
                    return clsLocalDrivingLicenseApplication_BLL.GetPersonIDByLocalLicenseAppID(ID);
                default:
                    return -1;
            }
        }
    }
}
