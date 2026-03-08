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
            _displayMode = DisplayMode;
            InitializeAdapter(clsUser_BLL.GetUsers,
               clsUser_BLL.GetCount,
               GetDisplayView<clsUser_DTO>(user => new ucUser(_context.SharedContextMenu) { UserInfo = user }, DisplayMode));

        }
        public override void InitializeUIActionsManager()
        {
            clsUIActionsManager ui = _context.UIActionsManager;
            ui.Reset();

            ui.RegisterCreate(() => new frmAddNewUser());

            ui.RegisterUpdate(dto =>
                new frmUpdateUser(dto as clsUser_DTO));

            ui.RegisterDelete(clsUser_BLL.DeleteUser);

            ui.RegisterFilter(() =>
                new frmSortAndFilter(new ucUsersFilter(), _currentQuery));
        }
        public override void UpdateUI(ComboBox cbSearchBy, Label lbTotalType_Titel,
            Label lbTotalCount, PictureBox pbTotal)
        {
            cbSearchBy.DataSource = Enum.GetValues(typeof(clsUserEnums.enUserSearchBy));
            lbTotalType_Titel.Text = "Users";
            lbTotalCount.Text = _paginator.TotalItems.ToString();
            pbTotal.Image = Properties.Resources.Users;
        }
        public override void UpdateContextMenu()
        {
            base.UpdateContextMenu();
        }
    }
}
