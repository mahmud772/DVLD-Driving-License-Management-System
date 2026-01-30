using DVLD;
using DVLD_BLL;
using DVLD_DTO;
using DVLD_Models;
using DVLDWinForm.Forms;
using DVLDWinForm.UIHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DVLDWinForm.User_Controls
{
    public partial class ctrlApplication : UserControl , IUserControl
    {
        
        private clsApplication_DTO _ApplicationInfo;

        public clsApplication_DTO ApplicationInfo
        {
            get => _ApplicationInfo;
            set
            {
                _ApplicationInfo = value;
                _SetApplicationInfo(value);
            }
        }
        public IDTO Info { get => _ApplicationInfo; set => ApplicationInfo = value as clsApplication_DTO; }
        public ctrlApplication()
        {
            InitializeComponent();
            clsUIHelper.CornerRadius(this, 25);
        }
        
        private void _SetApplicationInfo(clsApplication_DTO ApplicationInfo)
        {
            if (ApplicationInfo == null)
            {
                MessageBox.Show("This is Application Is Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lbApplicationID.Text = ApplicationInfo.ApplicationID.ToString();
            lbPersonID.Text = ApplicationInfo.ApplicantPersonID.ToString();
            lbApplicationDate.Text = ApplicationInfo.ApplicationDate.ToString("yyyy/MM/dd");
            lbApplicationType.Text = clsApplicationType_BLL.GetApplicationTypeTitle(ApplicationInfo.ApplicationTypeID);
            lbStatus.Text = ApplicationInfo.ApplicationStatus.ToString();
            lbPaidFees.Text = ApplicationInfo.PaidFees.ToString();
            clsUIHelper.FitText(lbApplicationType, 7.0f);

            //MainForm.CRUDController.PrepareUpdate = Person => new frmAddNew_UpdatePerson(Person as clsPerson_DTO);
            MainForm.CRUDController.TryDelete = clsApplication_BLL.DeleteApplication;
        }

        private void btnUpdate_Delete_Click(object sender, EventArgs e)
        {
            MainForm.CRUDController?.DTO = this.ApplicationInfo;
            MainForm.SharedContextMenu?.Show(btnUpdate_Delete, new Point(0, btnUpdate_Delete.Height));
        }
    }
}
