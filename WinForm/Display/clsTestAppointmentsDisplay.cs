using Common;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDWinForm.Display
{
    public class clsTestAppointmentsDisplay : clsBaseDisplay
    {
        public clsTestAppointmentsDisplay(clsTestAppointmentQuery CurrentQuery, clsContextDisplay Context)
            : base(Context)
        {
            _currentQuery = CurrentQuery;
        }
        public override void Load(clsUIEnums.enDisplayMode DisplayMode, IQuery Query)
        {
            _currentQuery = Query;
            _displayMode = DisplayMode;
            InitializeAdapter(clsTestAppointment_BLL.GetTestAppointments,
              clsTestAppointment_BLL.GetCount,
              GetDisplayView<clsTestAppointment_DTO>(Appointment => new ucTestAppointment( _context.SharedContextMenu) { AppointmentInfo = Appointment } , DisplayMode));
        }
        public override void InitializeUIActionsManager()
        {
            clsUIActionsManager ui = _context.UIActionsManager;
            ui.Reset();

            ui.RegisterCreate(() => new frmAddNew_UpdateAppointment());

            ui.RegisterUpdate(dto =>
                new frmAddNew_UpdateAppointment(dto as clsTestAppointment_DTO));

            ui.RegisterDelete(clsTestAppointment_BLL.DeleteTestAppointment);

            ui.RegisterFilter(() =>
                new frmSortAndFilter(new ucTestAppointmentsFilter(), _currentQuery));
        }
        public override void UpdateUI(ComboBox cbSearchBy, Label lbTotalType_Titel,
            Label lbTotalCount, PictureBox pbTotal)
        {
            cbSearchBy.DataSource = Enum.GetValues(typeof(clsTestEnums.enTestAppointmentSearchBy));
            lbTotalType_Titel.Text = "Test Appointment";
            lbTotalCount.Text = _paginator.TotalItems.ToString();
            pbTotal.Image = Properties.Resources.TestAppointment;
        }
        public override void UpdateContextMenu()
        {
            base.UpdateContextMenu();
        }
    }
}
