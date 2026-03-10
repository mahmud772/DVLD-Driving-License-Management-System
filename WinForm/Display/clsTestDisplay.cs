using Common;
using Common.Queries;
using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm.Forms;
using DVLDWinForm.Forms.Add_New___Update.Add_New;
using DVLDWinForm.Forms.Add_New___Update.Update;
using DVLDWinForm.UIHelper_Manger;
using DVLDWinForm.User_Controls.Display;
using DVLDWinForm.User_Controls.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLDWinForm.UIHelper_Manger.clsUIEnums;

namespace DVLDWinForm.Display
{
    public class clsTestDisplay : clsBaseDisplay
    {
        public clsTestDisplay(clsTestQuery CurrentQuery, clsContextDisplay Context)
            : base(Context)
        {
            _currentQuery = CurrentQuery;
        }
        public override void Load(clsUIEnums.enDisplayMode DisplayMode, IQuery Query)
        {
            _currentQuery = Query;
            _displayMode = DisplayMode;
            InitializeAdapter(clsTest_BLL.GetTests,
               clsTest_BLL.GetCount,
               GetDisplayView<clsTest_DTO>(application => new ucTest(_context.SharedContextMenu) { TestInfo = application }, DisplayMode));

        }
        public override void InitializeUIActionsManager()
        {
            clsUIActionsManager ui = _context.UIActionsManager;
            ui.Reset();

            ui.RegisterCreate(() => new frmAddNewTest());

            ui.RegisterUpdate(dto =>
                new frmUpdateTest(dto as clsTest_DTO));

            ui.RegisterDelete(clsTest_BLL.DeleteTest);

            ui.RegisterFilter(() =>
                new frmSortAndFilter(new ucTestsFilter(), _currentQuery));
        }

        public override void UpdateUI(ComboBox cbSearchBy, Label lbTotalType_Titel,
            Label lbTotalCount, PictureBox pbTotal)
        {
            cbSearchBy.DataSource = Enum.GetValues(typeof(clsTestEnums.enTestSearchBy));
            lbTotalType_Titel.Text = "Test";
            lbTotalCount.Text = _paginator.TotalItems.ToString();
            pbTotal.Image = Properties.Resources.Applications;
            UpdateContextMenu();
        }
        public override void UpdateContextMenu()
        {
            base.UpdateContextMenu();
        }
    }
}
