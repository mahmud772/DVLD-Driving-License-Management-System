using Common;
using Common.Queries;
using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm.Forms;
using DVLDWinForm.UIHelper;
using DVLDWinForm.UIHelper_Manger;
using DVLDWinForm.User_Controls.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDWinForm.Display
{
    public class clsPeopleDisplay : clsBaseDisplay
    {
        public clsPeopleDisplay(clsPersonQuery CurrentQuery, clsContextDisplay Context) 
            : base (Context)
        {
            _currentQuery = CurrentQuery;
        }
        public override void Load(clsUIEnums.enDisplayMode DisplayMode , IQuery PersonQuery)
        {
            _currentQuery = PersonQuery;
            base.DisplayMode = DisplayMode;
            InitializeAdapter(clsPerson_BLL.GetPeople,
                clsPerson_BLL.GetCount,
                GetDisplayView<clsPerson_DTO>(person => new ucPerson( _context.SharedContextMenu) { PersonInfo = person } , DisplayMode)
            );
            
        }
        public override void InitializeUIActionsManager()
        {
            clsUIActionsManager ActionManager = _context.UIActionsManager;
            ActionManager.Reset();

            ActionManager.Register(
                clsUIActionService.Create(() => new frmAddNew_UpdatePerson(),
                clsUserEnums.enPermissions.ManagePeople));

            ActionManager.Register(
                clsUIActionService.Update(dto =>
                    new frmAddNew_UpdatePerson(dto as clsPerson_DTO),
                clsUserEnums.enPermissions.ManagePeople));

            ActionManager.Register(
                clsUIActionService.Delete(
                    clsPerson_BLL.DeletePerson,
                clsUserEnums.enPermissions.ManagePeople));

            ActionManager.Register(
                clsUIActionService.Filter(() =>
                    new frmSortAndFilter(new ucPeopleFilter(), _currentQuery),
                clsUserEnums.enPermissions.ManagePeople));
        }
        public override void UpdateUI()
        {
            _context.DisplayUIManager.InitializeHeaderBox
            <clsPersonEnums.enPersonSearchBy>
            ("People", Properties.Resources.People);
            UpdateContextMenu();
        }
        public override void UpdateContextMenu()
        {
            base.UpdateContextMenu();
        }
    }
}
