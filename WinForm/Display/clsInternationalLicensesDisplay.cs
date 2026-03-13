using Common;
using Common.Enums;
using Common.Queries;
using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm.Forms;
using DVLDWinForm.UIHelper_Manger;
using DVLDWinForm.User_Controls;
using DVLDWinForm.User_Controls.Filters;
using System;
using System.Windows.Forms;
using DVLDWinForm.Forms.Add_New___Update.Add_New;
using DVLDWinForm.Forms.Add_New___Update.Update;
namespace DVLDWinForm.Display
{
    public class clsInternationalLicensesDisplay : clsBaseDisplay
    {
        public clsInternationalLicensesDisplay(clsLicenseQuery CurrentQuery, clsContextDisplay Context)
        : base(Context)
        {
            _currentQuery = CurrentQuery;
        }
        public override void Load(clsUIEnums.enDisplayMode DisplayMode, IQuery Query)
        {
            _currentQuery = Query;
            base.DisplayMode = DisplayMode;
            InitializeAdapter(clsInternationalLicense_BLL.GetInternationalLicensesCardsInfo,
               clsInternationalLicense_BLL.GetCount,
               GetDisplayView<clsLicenseCardInfo_DTO>(license => new ucLicense(_context.SharedContextMenu) { LicenseInfo = license } , DisplayMode));
        }
        public override void InitializeUIActionsManager()
        {
            clsUIActionsManager ActionManager = _context.UIActionsManager;
            ActionManager.Reset();

            ActionManager.Register(
                clsUIActionService.Create(() => new frmAddNewInternationalLicense(),
                clsUserEnums.enPermissions.ManageLicenses));

            ActionManager.Register(
                clsUIActionService.Update(dto =>
                    new frmUpdateInternationalLicense(dto as clsLicenseCardInfo_DTO),
                clsUserEnums.enPermissions.ManageLicenses));

            ActionManager.Register(
                clsUIActionService.Delete(
                    clsInternationalLicense_BLL.DeleteInternationalLicense,
                clsUserEnums.enPermissions.ManageLicenses));

            ActionManager.Register(
                clsUIActionService.Filter(() =>
                    new frmSortAndFilter(new ucLicensesFilter(), _currentQuery),
                clsUserEnums.enPermissions.ManageLicenses));
        }
        public override void UpdateUI()
        {
            _context.DisplayUIManager.InitializeHeaderBox
                <clsLicenseEnums.enLicenseSearchBy>
                ("International Licenses", Properties.Resources.InternationalLicense);
            UpdateContextMenu();
        }
        public override void UpdateContextMenu()
        {
            base.UpdateContextMenu();
        }
    }
}
