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
            _displayMode = DisplayMode;
            InitializeAdapter(clsDriver_BLL.GetDrivers,
               clsDriver_BLL.GetCount,
               GetDisplayView<clsDriver_DTO>(Driver => new ucDriver(_context.SharedContextMenu) { DriverInfo = Driver }, DisplayMode));

        }
        public override void InitializeUIActionsManager()
        {
            clsUIActionsManager ui = _context.UIActionsManager;
            ui.Reset();

            ui.RegisterCreate(() => new frmAddNew_UpdateDriver());

            ui.RegisterUpdate(dto =>
                 new frmAddNew_UpdateDriver(dto as clsDriver_DTO));

            ui.RegisterDelete(clsDriver_BLL.DeleteDriver);

            ui.RegisterFilter(() =>
                new frmSortAndFilter(new ucDriversFilter(), _currentQuery));
            
        }
        public override void UpdateUI(ComboBox cbSearchBy, Label lbTotalType_Titel,
            Label lbTotalCount, PictureBox pbTotal)
        {
            cbSearchBy.DataSource = Enum.GetValues(typeof(clsDriverEnums.enDriverSearchBy));
            lbTotalType_Titel.Text = "Drivers";
            lbTotalCount.Text = _paginator.TotalItems.ToString();
            pbTotal.Image = Properties.Resources.Drivers;
        }
        public override void UpdateContextMenu()
        {
            base.UpdateContextMenu();
        }
    }
}
