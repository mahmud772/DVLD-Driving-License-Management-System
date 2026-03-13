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
            base.DisplayMode = DisplayMode;
            InitializeAdapter(clsTest_BLL.GetTests,
               clsTest_BLL.GetCount,
               GetDisplayView<clsTest_DTO>(application => new ucTest(_context.SharedContextMenu) { TestInfo = application }, DisplayMode));

        }
        public override void InitializeUIActionsManager()
        {
            clsUIActionsManager ActionManager = _context.UIActionsManager;
            ActionManager.Reset();

            ActionManager.Register(
                clsUIActionService.Create(() => new frmAddNewTest(),
                clsUserEnums.enPermissions.ManageTests));

            ActionManager.Register(
                clsUIActionService.Update(dto =>
                    new frmUpdateTest(dto as clsTest_DTO),
                clsUserEnums.enPermissions.ManageTests));

            ActionManager.Register(
                clsUIActionService.Delete(
                    clsTest_BLL.DeleteTest,
                clsUserEnums.enPermissions.ManageTests));

            ActionManager.Register(
                clsUIActionService.Filter(() =>
                    new frmSortAndFilter(new ucTestsFilter(), _currentQuery),
                clsUserEnums.enPermissions.ManageTests));
        }

        public override void UpdateUI()
        {
            _context.DisplayUIManager.InitializeHeaderBox
          <clsTestEnums.enTestSearchBy>
          ("Tests", Properties.Resources.TestAppointment);
            UpdateContextMenu();
        }
        public override void UpdateContextMenu()
        {
            base.UpdateContextMenu();
        }
    }
}
