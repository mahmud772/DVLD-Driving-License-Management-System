using Common;
using Common.Queries;
using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm.Forms;
using DVLDWinForm.Forms.Add_New___Update.Update;
using DVLDWinForm.UIHelper_Manger;
using DVLDWinForm.User_Controls;
using DVLDWinForm.User_Controls.Display;
using DVLDWinForm.User_Controls.Filters;
using System;
using System.Windows.Forms;

namespace DVLDWinForm.Display
{
    public class clsLocalDrivingLicenseApplicationsDisplay : clsBaseDisplay
    {

        public clsLocalDrivingLicenseApplicationsDisplay(clsLocalDrivingLicenseApplicationQuery CurrentQuery, clsContextDisplay Context)
            : base(Context)
        {
            _currentQuery = CurrentQuery;
        }
        public override void Load(clsUIEnums.enDisplayMode DisplayMode, IQuery Query)
        {
            _currentQuery = Query;
            base.DisplayMode = DisplayMode;
            InitializeAdapter(clsLocalDrivingLicenseApplication_BLL.GetLocalDrivingLicenseApplications,
               clsLocalDrivingLicenseApplication_BLL.GetCount,
               GetDisplayView<clsLocalDrivingLicenseApplication_DTO>(application => new ucLocalLicenseApplication( _context.SharedContextMenu) { ApplicationInfo = application } , DisplayMode));

        }
        public override void InitializeUIActionsManager()
        {
            clsUIActionsManager ActionManager = _context.UIActionsManager;
            ActionManager.Reset();

            ActionManager.Register(
                clsUIActionService.Create(() => new frmCreateApplication(),
                clsUserEnums.enPermissions.ManageApplications));

            ActionManager.Register(
                clsUIActionService.Update(dto =>
                    new frmUpdateApplication(dto as clsLocalDrivingLicenseApplication_DTO),
                clsUserEnums.enPermissions.ManageApplications));

            ActionManager.Register(
                clsUIActionService.Delete(
                    clsLocalDrivingLicenseApplication_BLL
                    .DeleteLocalDrivingLicenseApplicationByApplicationID,
                clsUserEnums.enPermissions.ManageApplications));

            ActionManager.Register(
                clsUIActionService.Filter(() =>
                    new frmSortAndFilter(
                        new ucLocalDrivingLicenseApplicationsFilter(),
                        _currentQuery),
                clsUserEnums.enPermissions.ManageApplications));
        }
        public override void UpdateUI()
        {
            _context.DisplayUIManager.InitializeHeaderBox
            <clsApplicationEnums.enApplicationSearchBy>
            ("Local License App", Properties.Resources.Applications);
            UpdateContextMenu();
        }
        public override void UpdateContextMenu()
        {
            base.UpdateContextMenu();
        }
    }
}
