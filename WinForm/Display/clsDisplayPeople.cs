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
    public class clsDisplayPeople : clsBaseDisplay
    {
        public clsDisplayPeople(clsPersonQuery CurrentQuery,
            IPaginationView paginationView,
             DataGridView dgvDisplay , FlowLayoutPanel flpUserControls , clsCRUDController CRUDController) 
            : base (dgvDisplay , flpUserControls , paginationView , CRUDController)
        {
            _currentQuery = CurrentQuery;
        }
        public override void Load(clsEnums.enDisplayMode DisplayMode , IQuery PersonQuery)
        {
            _currentQuery = PersonQuery;
            InitializeAdapter(clsPerson_BLL.GetPeople,
                clsPerson_BLL.GetCount,
                GetDisplayView<clsPerson_DTO>(person => new ucPerson { PersonInfo = person } , DisplayMode)
            );
            
        }
        public override void InitializeCRUDController()
        {
            CRUDController.CreateForm = () => new frmAddNew_UpdatePerson();
            CRUDController.PrepareUpdate = Person => new frmAddNew_UpdatePerson(Person as clsPerson_DTO);
            CRUDController.TryDelete = clsPerson_BLL.DeletePerson;
            CRUDController.Search = () => new frmSortAndFilter(new ucPeopleFilter(), _currentQuery);
            CRUDController.iUserControl = new ucPerson();
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
