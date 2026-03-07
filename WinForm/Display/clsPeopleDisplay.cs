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
            InitializeAdapter(clsPerson_BLL.GetPeople,
                clsPerson_BLL.GetCount,
                GetDisplayView<clsPerson_DTO>(person => new ucPerson( _context.SharedContextMenu) { PersonInfo = person } , DisplayMode)
            );
            
        }
        public override void InitializeUIActionsManager()
        {
            clsUIActionsManager ui = _context.UIActionsManager;
            ui.Reset();

            ui.RegisterCreate(() => new frmAddNew_UpdatePerson());

            ui.RegisterUpdate(dto =>
                new frmAddNew_UpdatePerson(dto as clsPerson_DTO));

            ui.RegisterDelete(clsPerson_BLL.DeletePerson);

            ui.RegisterFilter(() =>
                new frmSortAndFilter(new ucPeopleFilter(), _currentQuery));
        }
        public override void UpdateUI(ComboBox cbSearchBy , Label lbTotalType_Titel ,
            Label lbTotalCount , PictureBox pbTotal)
        {
            cbSearchBy.DataSource = Enum.GetValues(typeof(clsPersonEnums.enPersonSearchBy));
            lbTotalType_Titel.Text = "People";
            lbTotalCount.Text = _paginator.TotalItems.ToString();
            pbTotal.Image = Properties.Resources.People;
            UpdateContextMenu();
        }
        public void UpdateContextMenu()
        {
            _context.SharedContextMenu.Items.Clear();
            _context.SharedContextMenu.Items.Add("UPDATE", Properties.Resources.Update_Person);
            _context.SharedContextMenu.Items.Add("DELETE", Properties.Resources.Delete_Person);
        }
    }
}
