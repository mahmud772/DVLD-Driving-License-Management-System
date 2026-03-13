using Common;
using Common.Queries;
using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm.Forms;
using DVLDWinForm.Forms.Add_New___Update;
using DVLDWinForm.Forms.Add_New___Update.Update;
using DVLDWinForm.UIHelper_Manger;
using DVLDWinForm.User_Controls;
using DVLDWinForm.User_Controls.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDWinForm.Display
{
    public class clsUsersDisplay : clsBaseDisplay
    {
        public clsUsersDisplay(clsUserQuery CurrentQuery, clsContextDisplay Context)
            : base(Context)
        {
            _currentQuery = CurrentQuery;
        }
        public override void Load(clsUIEnums.enDisplayMode DisplayMode, IQuery Query)
        {
            _currentQuery = Query;
            base.DisplayMode = DisplayMode;
            InitializeAdapter(clsUser_BLL.GetUsers,
               clsUser_BLL.GetCount,
               GetDisplayView<clsUser_DTO>(user => new ucUser(_context.SharedContextMenu) { UserInfo = user }, DisplayMode));

        }
        public override void InitializeUIActionsManager()
        {
            clsUIActionsManager ActionManager = _context.UIActionsManager;
            ActionManager.Reset();

            ActionManager.Register(
                clsUIActionService.Create(() => new frmAddNewUser(),
                clsUserEnums.enPermissions.ManageUsers));

            ActionManager.Register(
                clsUIActionService.Update(dto =>
                    new frmUpdateUser(dto as clsUser_DTO),
                clsUserEnums.enPermissions.ManageUsers));

            ActionManager.Register(
                clsUIActionService.Delete(
                    clsUser_BLL.DeleteUser,
                clsUserEnums.enPermissions.ManageUsers));

            ActionManager.Register(
                clsUIActionService.Filter(() =>
                    new frmSortAndFilter(new ucUsersFilter(), _currentQuery),
                clsUserEnums.enPermissions.ManageUsers));
        }
        public override void UpdateUI()
        {
            _context.DisplayUIManager.InitializeHeaderBox
          <clsUserEnums.enUserSearchBy>
          ("Users", Properties.Resources.Users);
            UpdateContextMenu();
        }
        public override void UpdateContextMenu()
        {
            base.UpdateContextMenu();
        }
    }
}
