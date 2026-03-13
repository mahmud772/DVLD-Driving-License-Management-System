using Common;
using Common.Enums;
using Common.Queries;
using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm.Forms;
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
    public class clsDriversDisplay : clsBaseDisplay
    {
        public clsDriversDisplay(clsDriverQuery CurrentQuery, clsContextDisplay Context)
            : base(Context)
        {
            _currentQuery = CurrentQuery;
        }
        public override void Load(clsUIEnums.enDisplayMode DisplayMode, IQuery Query)
        {
            _currentQuery = Query;
            base.DisplayMode = DisplayMode;
            InitializeAdapter(clsDriver_BLL.GetDrivers,
               clsDriver_BLL.GetCount,
               GetDisplayView<clsDriver_DTO>(Driver => new ucDriver(_context.SharedContextMenu) { DriverInfo = Driver }, DisplayMode));

        }
        public override void InitializeUIActionsManager()
        {
            clsUIActionsManager ActionManager = _context.UIActionsManager;
            ActionManager.Reset();

            ActionManager.Register(
                clsUIActionService.Create(() => new frmAddNewDriver(),
                clsUserEnums.enPermissions.ManageDrivers));

            ActionManager.Register(
                clsUIActionService.Update(dto =>
                    new frmAddNew_UpdatePerson(dto as clsDriver_DTO),
                clsUserEnums.enPermissions.ManageDrivers));

            ActionManager.Register(
                clsUIActionService.Delete(clsDriver_BLL.DeleteDriver,
                clsUserEnums.enPermissions.ManageDrivers));

            ActionManager.Register(
                clsUIActionService.Filter(() =>
                    new frmSortAndFilter(new ucDriversFilter(), _currentQuery),
                clsUserEnums.enPermissions.ManageDrivers));
        }
        public override void UpdateUI()
        {
            _context.DisplayUIManager.InitializeHeaderBox
                <clsDriverEnums.enDriverSearchBy>
                ("Drivers", Properties.Resources.Drivers);
            UpdateContextMenu();
        }
        public override void UpdateContextMenu()
        {
            base.UpdateContextMenu();
        }
    }
}
