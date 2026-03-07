using Common;
using Common.Enums;
using Common.Queries;
using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm.Forms;
using DVLDWinForm.UIHelper_Manger;
using DVLDWinForm.User_Controls;
using DVLDWinForm.User_Controls.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDWinForm.Display
{
    public class clsInternationalLicensesDisplay : clsBaseDisplay
    {
        public clsInternationalLicensesDisplay(clsLicenseQuery CurrentQuery, clsContextDisplay Context)
        : base(Context)
        {
            _currentQuery = CurrentQuery;
        }
        public override void Load(clsUIEnums.enDisplayMode DisplayMode, IQuery Query)
        {
            _currentQuery = Query;
            InitializeAdapter(clsInternationalLicense_BLL.GetInternationalLicensesCardsInfo,
               clsInternationalLicense_BLL.GetCount,
               GetDisplayView<clsLicenseCardInfo_DTO>(license => new ucLicense(_context.SharedContextMenu) { LicenseInfo = license } , DisplayMode));
        }
        public override void InitializeUIActionsManager()
        {
            clsUIActionsManager ui = _context.UIActionsManager;
            ui.Reset();

            ui.RegisterDelete(clsInternationalLicense_BLL.DeleteInternationalLicense);

            ui.RegisterFilter(() =>
                new frmSortAndFilter(new ucLicensesFilter(), _currentQuery));
        }
        public override void UpdateUI(ComboBox cbSearchBy, Label lbTotalType_Titel,
            Label lbTotalCount, PictureBox pbTotal)
        {
            cbSearchBy.DataSource = Enum.GetValues(typeof(clsLicenseEnums.enLicenseSearchBy));
            lbTotalType_Titel.Text = "International Licenses";
            lbTotalCount.Text = _paginator.TotalItems.ToString();
            pbTotal.Image = Properties.Resources.Licenses;
        }
    }
}
