using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm.UIHelper;
using DVLDWinForm.UIHelper_Manger;
using DVLDWinForm.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDWinForm.Forms.Add_New___Update.Add_New
{
    public partial class frmAddNewInternationalLicense : Form
    {
        clsInternationalLicense_DTO _license;
        public frmAddNewInternationalLicense()
        {
            InitializeComponent();
        }

        private void pbSelectedApplicationID_Click(object sender, EventArgs e)
        {
            frmFind frm = new frmFind(new ucApplication(), clsApplication_BLL.FindByApplicationID);
            frm.ShowDialog();
            tbApplicationID.Text = frm.SelectedID;
        }

        private void frmAddNewInternationalLicense_Load(object sender, EventArgs e)
        {
            _license = new clsInternationalLicense_DTO();
            clsUIHelper.CornerRadius(pnlLicense, 5);
        }

        private void pbSelectedDriverID_Click(object sender, EventArgs e)
        {
            frmFind frm = new frmFind(new ucDriver(), clsDriver_BLL.FindByID);
            frm.ShowDialog();
            tbDriverID.Text = frm.SelectedID;
        }
        private bool LoadFromForm()
        {
            clsValidation.ep.Clear();
            if(!clsValidation.IsNumber(tbApplicationID , "Enter a valid ID") ||
                !clsValidation.IsNumber(tbDriverID, "Enter a valid ID")) return false;
            int ApplicationID;
            int DriverID;
            int.TryParse(tbApplicationID.Text, out ApplicationID);
            int.TryParse(tbDriverID.Text, out DriverID);
            if(ApplicationID == 0 || DriverID == 0) return false;
            _license.DriverID = DriverID;
            _license.ApplicationID = ApplicationID;
            int IssuedUsingLocalLicenseID = -1;
            if(!clsDriver_BLL.IsDriverHaveActiveLicenseFromClass3(DriverID ,ref IssuedUsingLocalLicenseID))
                return false;
            _license.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            _license.CreatedByUserID = clsCurrentUser.User.UserID;
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(LoadFromForm())
            {
                clsInternationalLicense_BLL InternationalLicense = new clsInternationalLicense_BLL();
                InternationalLicense.InternationalLicense = _license;
                if(InternationalLicense.Save() )
                {
                    MessageBox.Show("A new international license\n has been added.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The Data Is Not Valid .", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
