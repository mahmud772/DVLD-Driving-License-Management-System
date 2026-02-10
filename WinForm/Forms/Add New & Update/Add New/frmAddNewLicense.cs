using Common;
using Common.Helpers;
using DVLD_BLL;
using DVLD_DTO;
using DVLDWinForm.UIHelper;
using DVLDWinForm.UIHelper_Manger;
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
    public partial class frmAddNewLicense : Form
    {
        clsLicense_DTO _License;
        List<clsLicenseClass_DTO> _LicenseClassesList;
        public frmAddNewLicense()
        {
            InitializeComponent();
            _License = new clsLicense_DTO();
        }

        private void frmAddNewLicense_Load(object sender, EventArgs e)
        {
            _LoadDesign();
            _SetApplicationInfo();
        }
        private void _LoadDesign()
        {
            clsUIHelper.CornerRadius(pnlLicense, 5);
            //clsUIHelper.ErrorProvider.ContainerControl = this;
        }
        private void _SetApplicationInfo()
        {
            _LicenseClassesList = clsStaticData_BLL.LicenseClasses;
            cbLicenseClass?.DataSource = _LicenseClassesList;
            cbLicenseClass.DisplayMember = "ClassName";
            cbLicenseClass.ValueMember = "LicenseClassID";
        }
        private bool _GetApplicationInfo()
        {
            clsValidation.ep.Clear();
            if (clsValidation.IsEmpty( tbID, "Select a valid ID")) return false;
            _License.LicenseClass = clsLicenseEnumConverter.ToClass(cbLicenseClass.SelectedIndex + 1);
            if (clsTest_BLL.IsDriverPassedInAllTests(_License.DriverID, _License.LicenseClassID))
            {
                MessageBox.Show($"This is Driver Is Not Passed In Test of {_License.LicenseClass.ToString()} .", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (_GetApplicationInfo())
            {
                clsLicense_BLL License = new clsLicense_BLL();
                License.License = _License;
                License.Save();
                this.Close();

            }
            else
            {
                MessageBox.Show("The Data Is Not Valid .", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pbSelectedID_Click(object sender, EventArgs e)
        {
            frmFind frm = new frmFind(new ucDriver(), clsDriver_BLL.FindByID);
            frm?.ShowDialog();
            tbID.Text = frm?.SelectedID?.ToString();

        }
    }
}
