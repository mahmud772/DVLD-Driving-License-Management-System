using Common;
using Common.Queries;
using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm.Forms;
using DVLDWinForm.Forms.Add_New___Update;
using DVLDWinForm.Forms.Add_New___Update.Add_New;
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
            base.DisplayMode = DisplayMode;
            InitializeAdapter(clsTestAppointment_BLL.GetTestAppointments,
              clsTestAppointment_BLL.GetCount,
              GetDisplayView<clsTestAppointment_DTO>(Appointment => new ucTestAppointment( _context.SharedContextMenu) { AppointmentInfo = Appointment } , DisplayMode));
        }
        public override void InitializeUIActionsManager()
        {
            clsUIActionsManager ActionManager = _context.UIActionsManager;
            ActionManager.Reset();

            ActionManager.Register(
                clsUIActionService.Create(() => new frmAddNew_UpdateAppointment(),
                clsUserEnums.enPermissions.ManageTests));

            ActionManager.Register(
                clsUIActionService.Update(dto =>
                    new frmAddNew_UpdateAppointment(dto as clsTestAppointment_DTO),
                clsUserEnums.enPermissions.ManageTests));

            ActionManager.Register(
                clsUIActionService.Delete(
                    clsTestAppointment_BLL.DeleteTestAppointment,
                clsUserEnums.enPermissions.ManageTests));

            ActionManager.Register(
                clsUIActionService.Filter(() =>
                    new frmSortAndFilter(new ucTestAppointmentsFilter(), _currentQuery),
                clsUserEnums.enPermissions.ManageTests));
            
            ActionManager.Register(
                clsUIActionService.Testing(dto =>
                    new frmAddNewTest(dto as clsTestAppointment_DTO),
                clsUserEnums.enPermissions.ManageTests));
        }
        public override void UpdateUI()
        {
            _context.DisplayUIManager.InitializeHeaderBox
           <clsTestEnums.enTestAppointmentSearchBy>
           ("Test Appointment", Properties.Resources.TestAppointment);
            UpdateContextMenu();
        }
        public override void UpdateContextMenu()
        {
            base.UpdateContextMenu();
            _context.SharedContextMenu.Items.Add("Testing", Properties.Resources.AddNew_Gray,
            (s, e) => _context.UIActionsManager.Execute
            (clsUIEnums.enUIAction.Testing, GetSelectedDto(), Refresh));

        }
    }
}
