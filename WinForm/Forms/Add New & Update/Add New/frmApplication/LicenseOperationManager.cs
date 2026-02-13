using Common;
using DVLD_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDWinForm.User_Controls.Display.ucApplication
{
    public class LicenseOperationManager
    {
        public bool ExecuteOperation(clsApplicationEnums.enApplicationType ApplicationType,int ID,int ApplicationID)
        {
            if (!ConfirmOperation(ApplicationType))
                return false;

            bool result = false;
            switch (ApplicationType)
            {
                case clsApplicationEnums.enApplicationType.NewLocalDrivingLicense:
                    break;
                case clsApplicationEnums.enApplicationType.RenewDrivingLicense:
                    result = clsLicense_BLL.RenewLicense(ID, ApplicationID);
                    break;
                case clsApplicationEnums.enApplicationType.ReplacementForLostDrivingLicense:
                    result = clsLicense_BLL.ReplacementforLostLicense(ID, ApplicationID);
                    break;
                case clsApplicationEnums.enApplicationType.ReplacementForDamagedDrivingLicense:
                    result = clsLicense_BLL.ReplacementforDamagedLicense(ID, ApplicationID);
                    break;
                case clsApplicationEnums.enApplicationType.ReleaseDetainedDrivingLicsense:
                    result = clsDetainedLicense_BLL.ReleaseLicense(ID, ApplicationID);
                    break;
                case clsApplicationEnums.enApplicationType.NewInternationalLicense:
                    break;
                case clsApplicationEnums.enApplicationType.RetakeTest:
                    break;
                default:
                    break;
            }

            return result;
        }

        private bool ConfirmOperation(clsApplicationEnums.enApplicationType type)
        {
            string message = "";
            
            if (type == clsApplicationEnums.enApplicationType.RenewDrivingLicense)
                message = "Do you want to renew your license?";
            else if (type == clsApplicationEnums.enApplicationType.ReplacementForLostDrivingLicense)
                message = "Do you want to replace lost license?";
            else if (type == clsApplicationEnums.enApplicationType.ReplacementForDamagedDrivingLicense)
                message = "Do you want to replace damaged license?";
            else if (type == clsApplicationEnums.enApplicationType.ReleaseDetainedDrivingLicsense)
                message = "Do you want to release detained license?";
            else
                return false;

            return MessageBox.Show(
                message,
                "Question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) ==
                DialogResult.Yes;
        }
    }
}
