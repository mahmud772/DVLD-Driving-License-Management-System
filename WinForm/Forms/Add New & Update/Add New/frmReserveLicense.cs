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
    public partial class frmReserveLicense : Form
    {
        clsDetainedLicense_DTO _detain;
        public frmReserveLicense()
        {
            InitializeComponent();
            clsUIHelper.CornerRadius(pnlLicenseDetails, 5);
        }
        public frmReserveLicense(clsLicenseCardInfo_DTO license)
        {
            InitializeComponent();
            clsUIHelper.CornerRadius(pnlLicenseDetails, 5);
            IsDetained(license);
        }
        private void IsDetained(clsLicenseCardInfo_DTO license)
        {
            if (license == null) return;
            if (clsDetainedLicense_BLL.IsDetained(license.LicenseID))
                tbID.Text = license.LicenseID.ToString();
            else
                MessageBox.Show("This license is not Detained.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private bool LoadFromForm()
        {
            clsValidation.ep.Clear();
            if(!clsValidation.IsValidPaidFees(tbPaidFees) ||
                !clsValidation.IsNumber(tbID , "Enter a Valid ID")) return false;
            int ID;
            int.TryParse(tbID.Text, out ID);
            decimal PaidFees;
            decimal.TryParse(tbPaidFees.Text, out PaidFees);
            _detain.LicenseID = ID;
            _detain.PaidFees = PaidFees;
            _detain.IsReleased = false;
            _detain.CreatedByUserID = clsCurrentUser.User.UserID;
            return true;
        }
        private void frmReserveLicense_Load(object sender, EventArgs e)
        {
            _detain = new clsDetainedLicense_DTO();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(LoadFromForm())
            {
                clsDetainedLicense_BLL detainedLicense = new clsDetainedLicense_BLL();
                detainedLicense.Detain = _detain;
                if(detainedLicense.Save())
                {
                    MessageBox.Show("The license has been reserved.",
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

        private void pbSelectedID_Click(object sender, EventArgs e)
        {
            frmFind frm = new frmFind(new ucLicense() , clsLicense_BLL.GetLicenseCardInfo);
            frm.ShowDialog();
            tbID.Text = frm.SelectedID;
        }
    }
}
