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
        public override void Load(clsEnums.enDisplayMode DisplayMode, IQuery Query)
        {
            _currentQuery = Query;
            InitializeAdapter(clsUser_BLL.GetUsers,
               clsUser_BLL.GetCount,
               GetDisplayView<clsUser_DTO>(user => new ucUser(_context.CRUDController, _context.SharedContextMenu) { UserInfo = user }, DisplayMode));

        }
        public override void InitializeCRUDController()
        {
            _context.CRUDController.TryDelete = clsUser_BLL.DeleteUser;
            _context.CRUDController.Search = () => new frmSortAndFilter(new ucUsersFilter(), _currentQuery);
            _context.CRUDController.CreateForm = () => new frmAddNewUser();
            _context.CRUDController.PrepareUpdate = User => new frmUpdateUser(User as clsUser_DTO);
        }
        public override void UpdateUI(ComboBox cbSearchBy, Label lbTotalType_Titel,
            Label lbTotalCount, PictureBox pbTotal)
        {
            cbSearchBy.DataSource = Enum.GetValues(typeof(clsUserEnums.enUserSearchBy));
            lbTotalType_Titel.Text = "Users";
            lbTotalCount.Text = _paginator.TotalItems.ToString();
            pbTotal.Image = Properties.Resources.Users;
        }
    }
}
