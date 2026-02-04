using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Common.Filters;
using DVLD_BLL;
namespace DVLDWinForm.User_Controls.Filters
{
    public partial class ctrlApplicationFilter : UserControl
    {
        public static clsApplicationFilter ApplicationFilter { get; set; }
        public ctrlApplicationFilter()
        {
            InitializeComponent();
        }
        private void _Get()
        {
            if (ApplicationFilter == null)
                ApplicationFilter = new clsApplicationFilter();
            if(ckbApplicationStatus.Checked)
                ApplicationFilter.ApplicationStatus = (clsApplicationEnums.enApplicationStatus)cbApplicationStatus?.SelectedItem;
            if (ckbApplicationType.Checked)
                ApplicationFilter.ApplicationTypeID = Convert.ToInt32(cbApplicationType.SelectedValue);
            if(ckbApplicationDate.Checked)
            {
                ApplicationFilter.FromApplicationDate = dtpFrom.Value;
                ApplicationFilter.ToApplicationDate = dtpTo.Value;
            }
        }
        private void _Set()
        {
            cbApplicationType.DataSource = clsStaticData_BLL.ApplicationTypes;
            cbApplicationStatus.DataSource = Enum.GetValues(typeof(clsApplicationEnums.enApplicationStatus));
            cbApplicationType.DisplayMember = "ApplicationTypeTitle";
            cbApplicationType.ValueMember = "ApplicationTypeID";
            if (ApplicationFilter == null) return;
            if(ApplicationFilter.ApplicationStatus.HasValue)
            { 
                ckbApplicationStatus.Checked = true;
                cbApplicationStatus.SelectedItem = ApplicationFilter.ApplicationStatus;
            }
            if (ApplicationFilter.ApplicationTypeID.HasValue)
            {
                ckbApplicationType.Checked = true;
                cbApplicationType.SelectedItem = ApplicationFilter.ApplicationTypeID;
            }
            if (ApplicationFilter.ToApplicationDate.HasValue && ApplicationFilter.FromApplicationDate.HasValue)
            {
                ckbApplicationDate.Checked = true;
                dtpFrom.Value = ApplicationFilter.FromApplicationDate.Value;
                dtpTo.Value = ApplicationFilter.ToApplicationDate.Value;
            }
        }
    }
}
