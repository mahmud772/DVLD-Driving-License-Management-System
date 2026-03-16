using Common;
using Common.Queries;
using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm.Forms;
using DVLDWinForm.Forms.Add_New___Update.Add_New;
using DVLDWinForm.Forms.Add_New___Update.Update;
using DVLDWinForm.UIHelper_Manger;
using DVLDWinForm.User_Controls;
using DVLDWinForm.User_Controls.Filters;
using System;
using System.Windows.Forms;

namespace DVLDWinForm.Display
{
    public class clsLicensesDisplay : clsBaseDisplay
    {
        public clsLicensesDisplay(clsLicenseQuery CurrentQuery, clsContextDisplay Context)
            : base(Context)
        {
            _currentQuery = CurrentQuery;
        }
        public override void Load(clsUIEnums.enDisplayMode DisplayMode, IQuery Query)
        {
            _currentQuery = Query;
            base.DisplayMode = DisplayMode;
            InitializeAdapter(clsLicense_BLL.GetLicensesCardsInfo,
               clsLicense_BLL.GetCount,
               GetDisplayView<clsLicenseCardInfo_DTO>(license => new ucLicense(_context.SharedContextMenu) { LicenseInfo = license } , DisplayMode));

        }
        public override void InitializeUIActionsManager()
        {
            clsUIActionsManager ActionManager = _context.UIActionsManager;
            ActionManager.Reset();

            ActionManager.Register(
                clsUIActionService.Create(() => new frmAddNewLicense(),
                clsUserEnums.enPermissions.ManageLicenses));

            ActionManager.Register(
                clsUIActionService.Update(dto =>
                    new frmUpdateLicense(dto as clsLicenseCardInfo_DTO),
                clsUserEnums.enPermissions.ManageLicenses));
            ActionManager.Register(
                clsUIActionService.Delete(
                    clsLicense_BLL.DeleteLicense,
                clsUserEnums.enPermissions.ManageLicenses));

            ActionManager.Register(
                clsUIActionService.Filter(() =>
                    new frmSortAndFilter(new ucLicensesFilter(), _currentQuery),
                clsUserEnums.enPermissions.ManageLicenses));
           
            ActionManager.Register(
                clsUIActionService.DetaindLicense(dto =>
                    new frmReserveLicense(dto as clsLicenseCardInfo_DTO),
                clsUserEnums.enPermissions.ManageLicenses));

        }
        public override void UpdateUI()
        {
            _context.DisplayUIManager.InitializeHeaderBox
                <clsLicenseEnums.enLicenseSearchBy>
                ("Licenses", Properties.Resources.Licenses);
            UpdateContextMenu();
        }
        public override void UpdateContextMenu()
        {
            base.UpdateContextMenu();
            _context.SharedContextMenu.Items.Add("Detain", Properties.Resources.AddNew_Gray,
               (s, e) => _context.UIActionsManager.Execute
               (clsUIEnums.enUIAction.DetainLicense, GetSelectedDto(), Refresh));

        }
    }
}
