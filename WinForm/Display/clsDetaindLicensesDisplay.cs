using Common;
using Common.Enums;
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
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDWinForm.Display
{
    public class clsDetaindLicensesDisplay : clsBaseDisplay
    {

        public clsDetaindLicensesDisplay(clsDetainedLicenseQuery CurrentQuery, clsContextDisplay Context)
            : base(Context)
        {
            _currentQuery = CurrentQuery;
        }
        public override void Load(clsEnums.enDisplayMode DisplayMode, IQuery Query)
        {
            _currentQuery = Query;
            InitializeAdapter(clsDetainedLicense_BLL.GetDetainedLicensesCardsInfo,
               clsDetainedLicense_BLL.GetCount,
               GetDisplayView<clsLicenseCardInfo_DTO>(license => new ucLicense(_context.CRUDController , _context.SharedContextMenu) { LicenseInfo = license } , DisplayMode));
        }
        public override void InitializeCRUDController()
        {
            _context.CRUDController.TryDelete = clsDetainedLicense_BLL.DeleteDetain;
            _context.CRUDController.Search = () => new frmSortAndFilter(new ucDetainedLicensesFilter(), _currentQuery);
        }
        public override void UpdateUI(ComboBox cbSearchBy, Label lbTotalType_Titel,
            Label lbTotalCount, PictureBox pbTotal)
        {
            cbSearchBy.DataSource = Enum.GetValues(typeof(clsDetainedLicenseEnums.enDetainedLicenseSearchBy));
            lbTotalType_Titel.Text = "Detaind Licenses";
            lbTotalCount.Text = _paginator.TotalItems.ToString();
            pbTotal.Image = Properties.Resources.Licenses;
        }
    }
}
