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

namespace DVLDWinForm.Forms.Add_New___Update.Update
{
    public partial class frmReleaseLicense : Form
    {
        clsLicenseCardInfo_DTO _license;
        public frmReleaseLicense(clsLicenseCardInfo_DTO License)
        {
            InitializeComponent();
            _license = License;
        }

        private void frmReleaseLicense_Load(object sender, EventArgs e)
        {
            clsUIHelper.CornerRadius(pnlLicense, 5);
        }
        private bool LoadFromForm()
        {
            clsValidation.ep.Clear();
            if(!clsValidation.IsNumber(tbID , "Enter a Valid ID") || _license == null) return false;

            return true;
        }
        private void pbSelectedID_Click(object sender, EventArgs e)
        {
            ucApplication app = new ucApplication();
            frmFind frm = new frmFind(app, clsApplication_BLL.FindByApplicationID);
            frm.ShowDialog();
            tbID.Text = frm.SelectedID;
            lbPaidFees.Text = app.ApplicationInfo?.PaidFees.ToString("F1");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(LoadFromForm())
            {
                int ID;
                int.TryParse(tbID.Text, out ID);
                if(clsDetainedLicense_BLL.ReleaseLicense(_license.LicenseID, ID))
                {
                    MessageBox.Show("The license reservation has been released.",
                           "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The Data Is Not Valid .", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }
    }
}
