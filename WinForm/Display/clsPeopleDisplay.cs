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
        public override void Load(clsEnums.enDisplayMode DisplayMode , IQuery PersonQuery)
        {
            _currentQuery = PersonQuery;
            InitializeAdapter(clsPerson_BLL.GetPeople,
                clsPerson_BLL.GetCount,
                GetDisplayView<clsPerson_DTO>(person => new ucPerson(_context.CRUDController , _context.SharedContextMenu) { PersonInfo = person } , DisplayMode)
            );
            
        }
        public override void InitializeCRUDController()
        {
            _context.CRUDController.CreateForm = () => new frmAddNew_UpdatePerson();
            _context.CRUDController.PrepareUpdate = Person => new frmAddNew_UpdatePerson(Person as clsPerson_DTO);
            _context.CRUDController.TryDelete = clsPerson_BLL.DeletePerson;
            _context.CRUDController.Search = () => new frmSortAndFilter(new ucPeopleFilter(), _currentQuery);
        }
        public override void UpdateUI(ComboBox cbSearchBy , Label lbTotalType_Titel ,
            Label lbTotalCount , PictureBox pbTotal)
        {
            cbSearchBy.DataSource = Enum.GetValues(typeof(clsPersonEnums.enPersonSearchBy));
            lbTotalType_Titel.Text = "People";
            lbTotalCount.Text = _paginator.TotalItems.ToString();
            pbTotal.Image = Properties.Resources.People;
        }
    }
}
