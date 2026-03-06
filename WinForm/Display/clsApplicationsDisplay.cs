using Common;
using Common.Queries;
using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm.Forms;
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
    public class clsDisplayApplications : clsBaseDisplay
    {

        public clsDisplayApplications(clsApplicationQuery CurrentQuery, clsContextDisplay Context)
            : base(Context)
        {
            _currentQuery = CurrentQuery;
        }
        public override void Load(clsEnums.enDisplayMode DisplayMode, IQuery Query)
        {
            _currentQuery = Query;
            InitializeAdapter(clsApplication_BLL.GetApplications,
               clsApplication_BLL.GetCount,
               GetDisplayView<clsApplication_DTO>(application => new ucApplication(_context.CRUDController, _context.SharedContextMenu) { ApplicationInfo = application } , DisplayMode));

        }
        public override void InitializeCRUDController()
        {
            _context.CRUDController.CreateForm = () => new frmCreateApplication();
            _context.CRUDController.PrepareUpdate = Application => new frmUpdateApplication(Application as clsApplication_DTO);
            _context.CRUDController.TryDelete = clsApplication_BLL.DeleteApplication;
            _context.CRUDController.Search = () => new frmSortAndFilter(new ucApplicationsFilter(), _currentQuery);
            _context.CRUDController.iUserControl = new ucApplication();
        }
        public override void UpdateUI(ComboBox cbSearchBy, Label lbTotalType_Titel,
            Label lbTotalCount, PictureBox pbTotal)
        {
            cbSearchBy.DataSource = Enum.GetValues(typeof(clsApplicationEnums.enApplicationSearchBy));
            lbTotalType_Titel.Text = "Applications";
            lbTotalCount.Text = _paginator.TotalItems.ToString();
            pbTotal.Image = Properties.Resources.Applications;
        }
    }
}
