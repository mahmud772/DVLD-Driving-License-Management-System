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
        public override void Load(clsEnums.enDisplayMode DisplayMode, IQuery Query)
        {
            _currentQuery = Query;
            InitializeAdapter(clsDriver_BLL.GetDrivers,
               clsDriver_BLL.GetCount,
               GetDisplayView<clsDriver_DTO>(Driver => new ucDriver(_context.CRUDController, _context.SharedContextMenu) { DriverInfo = Driver }, DisplayMode));

        }
        public override void InitializeCRUDController()
        {
            _context.CRUDController.TryDelete = clsDriver_BLL.DeleteDriver;
            _context.CRUDController.Search = () => new frmSortAndFilter(new ucDriversFilter(), _currentQuery);
            _context.CRUDController.CreateForm = () => new frmAddNew_UpdateDriver();
            _context.CRUDController.PrepareUpdate = Driver => new frmAddNew_UpdateDriver(Driver as clsDriver_DTO);
        }
        public override void UpdateUI(ComboBox cbSearchBy, Label lbTotalType_Titel,
            Label lbTotalCount, PictureBox pbTotal)
        {
            cbSearchBy.DataSource = Enum.GetValues(typeof(clsDriverEnums.enDriverSearchBy));
            lbTotalType_Titel.Text = "Drivers";
            lbTotalCount.Text = _paginator.TotalItems.ToString();
            pbTotal.Image = Properties.Resources.Drivers;
        }
    }
}
