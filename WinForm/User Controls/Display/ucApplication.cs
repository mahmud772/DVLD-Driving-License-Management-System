using DVLDWinForm;
using DVLD_BLL;
using DVLD_DTOs;
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
    public partial class ucApplication : UserControl , IUserControl
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
        public ucApplication()
        {
            InitializeComponent();
            clsUIHelper.CornerRadius(pnlIDs, 25);
            clsUIHelper.CornerRadius(pnlMoreInfo, 25);
            clsUIHelper.CornerRadius(this, 25);
            lbPaidFees.Visible = false;
            pctrPaidFees.Visible = false;
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
            clsUIHelper.FitText(lbApplicationType, 4.0f);

        }

        private void btnUpdate_Delete_Click(object sender, EventArgs e)
        {
            MainForm.CRUDController?.DTO = this.ApplicationInfo;
            MainForm.SharedContextMenu?.Show(btnUpdate_Delete, new Point(0, btnUpdate_Delete.Height));
        }
    }
}
