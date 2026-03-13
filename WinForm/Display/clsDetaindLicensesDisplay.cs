using Common;
using Common.Enums;
using Common.Queries;
using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm.Forms;
using DVLDWinForm.Forms.Add_New___Update;
using DVLDWinForm.Forms.Add_New___Update.Add_New;
using DVLDWinForm.Forms.Add_New___Update.Update;
using DVLDWinForm.UIHelper_Manger;
using DVLDWinForm.User_Controls;
using DVLDWinForm.User_Controls.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDWinForm.Display
{
    public class clsDetaindLicensesDisplay : clsBaseDisplay
    {

        public clsDetaindLicensesDisplay(clsDetainedLicenseQuery CurrentQuery, clsContextDisplay Context)
            : base(Context)
        {
            _currentQuery = CurrentQuery;
        }
        public override void Load(clsUIEnums.enDisplayMode DisplayMode, IQuery Query)
        {
            _currentQuery = Query;
            base.DisplayMode = DisplayMode;
            InitializeAdapter(clsDetainedLicense_BLL.GetDetainedLicensesCardsInfo,
               clsDetainedLicense_BLL.GetCount,
               GetDisplayView<clsLicenseCardInfo_DTO>(license => new ucLicense( _context.SharedContextMenu) { LicenseInfo = license } , DisplayMode));
        }
        public override void InitializeUIActionsManager()
        {
            clsUIActionsManager ActionManager = _context.UIActionsManager;
            ActionManager.Reset();
            
            ActionManager.Register(clsUIActionService.Create(() => new frmReserveLicense()
            , clsUserEnums.enPermissions.ManageLicenses));

            ActionManager.Register(clsUIActionService.Update(dto =>
                   new frmReleaseLicense(dto as clsLicenseCardInfo_DTO)
                   , clsUserEnums.enPermissions.ManageLicenses));

            ActionManager.Register(clsUIActionService.Delete(clsDetainedLicense_BLL.DeleteDetain
                , clsUserEnums.enPermissions.ManageLicenses));

            ActionManager.Register(clsUIActionService.Filter(() =>
                new frmSortAndFilter(new ucDetainedLicensesFilter(), _currentQuery)
                , clsUserEnums.enPermissions.ManageLicenses));
        }
        public override void UpdateUI()
        {
            _context.DisplayUIManager.InitializeHeaderBox
                <clsDetainedLicenseEnums.enDetainedLicenseSearchBy>
                ("Detaind Licenses", Properties.Resources.Licenses);
            UpdateContextMenu();
        }
        public override void UpdateContextMenu()
        {
            base.UpdateContextMenu();
        }
    }
}
