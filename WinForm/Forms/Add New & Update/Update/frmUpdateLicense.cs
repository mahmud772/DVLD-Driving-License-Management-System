using DVLD_BLL;
using DVLD_DTOs;
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

namespace DVLDWinForm.Forms.Add_New___Update.Update
{
    public partial class frmUpdateLicense : Form
    {
        clsLicenseCardInfo_DTO _license;
        public frmUpdateLicense(clsLicenseCardInfo_DTO License)
        {
            InitializeComponent();
            _license = License;
            LoadDesign();
        }

        private void LoadDesign()
        {
            clsUIHelper.CornerRadius(pnlLicense, 5);
        }

        private bool LoadFromForm()
        {
            if (_license == null) return false;
            _license.Notes = tbNotes.Text;
            _license.IsActive = rbActive.Checked;
            return true;
        }
        private void frmUpdateLicense_Load(object sender, EventArgs e)
        {
            if (_license == null) return;
            tbNotes.Text = _license.Notes;
            rbActive.Checked = _license.IsActive;
            rbInActive.Checked = !_license.IsActive;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(LoadFromForm())
            {
                clsLicense_BLL License = clsLicense_BLL.FindByID(_license.LicenseID);
                License.License.Notes = _license.Notes;
                License.License.IsActive = _license.IsActive;
                if(License.Save())
                {
                    MessageBox.Show("The license has been updated.",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("This test result has already been recorded. .",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
