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
        public override void Load(clsUIEnums.enDisplayMode DisplayMode, IQuery Query)
        {
            _currentQuery = Query;
            InitializeAdapter(clsApplication_BLL.GetApplications,
               clsApplication_BLL.GetCount,
               GetDisplayView<clsApplication_DTO>(application => new ucApplication(_context.SharedContextMenu) { ApplicationInfo = application } , DisplayMode));

        }
        public override void InitializeUIActionsManager()
        {
            clsUIActionsManager ui = _context.UIActionsManager;
            ui.Reset();

            ui.RegisterCreate(() => new frmCreateApplication());

            ui.RegisterUpdate(dto =>
                new frmUpdateApplication(dto as clsApplication_DTO));

            ui.RegisterDelete(clsApplication_BLL.DeleteApplication);

            ui.RegisterFilter(() =>
                new frmSortAndFilter(new ucApplicationsFilter(), _currentQuery));
        }
        
        public override void UpdateUI(ComboBox cbSearchBy, Label lbTotalType_Titel,
            Label lbTotalCount, PictureBox pbTotal)
        {
            cbSearchBy.DataSource = Enum.GetValues(typeof(clsApplicationEnums.enApplicationSearchBy));
            lbTotalType_Titel.Text = "Applications";
            lbTotalCount.Text = _paginator.TotalItems.ToString();
            pbTotal.Image = Properties.Resources.Applications;
            UpdateContextMenu();
        }
        public void UpdateContextMenu()
        {
            _context.SharedContextMenu.Items.Clear();
            _context.SharedContextMenu.Items.Add("UPDATE" , Properties.Resources.Update_Person);
            _context.SharedContextMenu.Items.Add("DELETE" , Properties.Resources.Delete_Person);
        }
    }
}
