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
    public class clsLocalDrivingLicenseApplicationsDisplay : clsBaseDisplay
    {

        public clsLocalDrivingLicenseApplicationsDisplay(clsLocalDrivingLicenseApplicationQuery CurrentQuery, clsContextDisplay Context)
            : base(Context)
        {
            _currentQuery = CurrentQuery;
        }
        public override void Load(clsUIEnums.enDisplayMode DisplayMode, IQuery Query)
        {
            _currentQuery = Query;
            InitializeAdapter(clsLocalDrivingLicenseApplication_BLL.GetLocalDrivingLicenseApplications,
               clsLocalDrivingLicenseApplication_BLL.GetCount,
               GetDisplayView<clsLocalDrivingLicenseApplication_DTO>(application => new ucApplication( _context.SharedContextMenu) { ApplicationInfo = application } , DisplayMode));

        }
        public override void InitializeUIActionsManager()
        {
            clsUIActionsManager ui = _context.UIActionsManager;
            ui.Reset();

            ui.RegisterCreate(() => new frmCreateApplication());

            ui.RegisterUpdate(dto =>
                new frmUpdateApplication(dto as clsLocalDrivingLicenseApplication_DTO));

            ui.RegisterDelete(clsLocalDrivingLicenseApplication_BLL
                .DeleteLocalDrivingLicenseApplicationByApplicationID);

            ui.RegisterFilter(() =>
                new frmSortAndFilter(new ucLocalDrivingLicenseApplicationsFilter(), _currentQuery));
        }
        public override void UpdateUI(ComboBox cbSearchBy, Label lbTotalType_Titel,
            Label lbTotalCount, PictureBox pbTotal)
        {
            cbSearchBy.DataSource = Enum.GetValues(typeof(clsApplicationEnums.enApplicationSearchBy));
            lbTotalType_Titel.Text = "Local License App";
            lbTotalCount.Text = _paginator.TotalItems.ToString();
            pbTotal.Image = Properties.Resources.Applications;
        }
    }
}
