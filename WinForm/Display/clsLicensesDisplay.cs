using Common;
using Common.Queries;
using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm.Forms;
using DVLDWinForm.Forms.Add_New___Update.Add_New;
using DVLDWinForm.UIHelper_Manger;
using DVLDWinForm.User_Controls;
using DVLDWinForm.User_Controls.Filters;
using System;
using System.Windows.Forms;

namespace DVLDWinForm.Display
{
    public class clsLicensesDisplay : clsBaseDisplay
    {
        public clsLicensesDisplay(clsLicenseQuery CurrentQuery, clsContextDisplay Context)
            : base(Context)
        {
            _currentQuery = CurrentQuery;
        }
        public override void Load(clsUIEnums.enDisplayMode DisplayMode, IQuery Query)
        {
            _currentQuery = Query;
            InitializeAdapter(clsLicense_BLL.GetLicensesCardsInfo,
               clsLicense_BLL.GetCount,
               GetDisplayView<clsLicenseCardInfo_DTO>(license => new ucLicense(_context.SharedContextMenu) { LicenseInfo = license } , DisplayMode));

        }
        public override void InitializeUIActionsManager()
        {
            clsUIActionsManager ui = _context.UIActionsManager;
            ui.Reset();

            ui.RegisterCreate(() => new frmAddNewLicense());

            ui.RegisterDelete(clsLicense_BLL.DeleteLicense);

            ui.RegisterFilter(() =>
                new frmSortAndFilter(new ucLicensesFilter(), _currentQuery));
        }
        public override void UpdateUI(ComboBox cbSearchBy, Label lbTotalType_Titel,
            Label lbTotalCount, PictureBox pbTotal)
        {
            cbSearchBy.DataSource = Enum.GetValues(typeof(clsLicenseEnums.enLicenseSearchBy));
            lbTotalType_Titel.Text = "Licenses";
            lbTotalCount.Text = _paginator.TotalItems.ToString();
            pbTotal.Image = Properties.Resources.Licenses;
        }
    }
}
