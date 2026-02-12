using Common;
using DVLD_BLL;
using DVLD_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDWinForm.User_Controls.Display.ucApplication
{
    public class ApplicationFactory
    {
        public void CreateApplication(clsApplication_DTO AppInfo,clsLocalDrivingLicenseApplication_DTO localInfo,
            clsApplicationEnums.enApplicationType type,bool ExecuteLicenseOperation)
        {
            if (type == clsApplicationEnums.enApplicationType.NewLocalDrivingLicense)
            {
                CreateLocalApplication(AppInfo, localInfo);
            }
            else
            {
                CreateGeneralApplication(AppInfo, type, ExecuteLicenseOperation);
            }
        }

        private void CreateLocalApplication(clsApplication_DTO appInfo,clsLocalDrivingLicenseApplication_DTO localInfo)
        {
            clsLocalDrivingLicenseApplication_BLL application = new clsLocalDrivingLicenseApplication_BLL();

            application.Application = appInfo;
            application.LocalApplication = localInfo;
            application.Save();
        }

        private void CreateGeneralApplication(clsApplication_DTO appInfo,clsApplicationEnums.enApplicationType type,
            bool executeLicenseOperation)
        {
            clsApplication_BLL application = new clsApplication_BLL();
            application.Application = appInfo;
            application.Save();

            if (executeLicenseOperation)
            {
                LicenseOperationManager manager = new LicenseOperationManager();
                manager.ExecuteOperation(type,appInfo.ApplicantPersonID,application.Application.ApplicationID);
            }
        }

    }
}
