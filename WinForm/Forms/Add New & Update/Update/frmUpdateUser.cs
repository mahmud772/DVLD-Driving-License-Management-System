using Common;
using DVLD_BLL;
using DVLD_DTOs;
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

namespace DVLDWinForm.Forms.Add_New___Update.Update
{
    public partial class frmUpdateUser : Form
    {
        clsUser_DTO _User;
        public frmUpdateUser(clsUser_DTO User)
        {
            InitializeComponent();
            _User = User;
        }
        private void _LoadDesign()
        {
            clsUIHelper.CornerRadius(pnlUserInfo, 5);
        }
        private void frmUpdateUser_Load(object sender, EventArgs e)
        {
            _LoadDesign();
            InitializeDataForm();
            LoadDataFromDtoToForm();
        }
        private void LoadDataFromDtoToForm()
        {
            if (_User == null) return;
            rbActive.Checked = _User.IsActive;
            rbDeactivate.Checked = !rbActive.Checked;
            LoadPermissionsToCheckedComboBox(_User.Permissions);
        }
        private void InitializeDataForm()
        {
            foreach (var value in Enum.GetValues(typeof(clsUserEnums.enPermissions)))
                ckcbPermissions.AddItem(value);
        }
        public void LoadPermissionsToCheckedComboBox(int permissionsValue)
        {
            if (permissionsValue == 0) 
            {
                ckcbPermissions.SetItemChecked(0, true);
                return;
            }
            if (permissionsValue == (int)clsUserEnums.enPermissions.All)
            {
                for (int i = 1; i < ckcbPermissions.ItemsList.Count; i++)
                    ckcbPermissions.SetItemChecked(i, true);
                
                return;
            }

            for (int i = 1; i < ckcbPermissions.ItemsList.Count; i++)
            {
                var item = (clsUserEnums.enPermissions)ckcbPermissions.ItemsList[i];

                bool isChecked = (permissionsValue & (int)item) == (int)item;

                ckcbPermissions.SetItemChecked(i, isChecked);
            }
        }

        private clsUser_DTO GetDataFromForm()
        {
            _User.Permissions = 0;
            _User.IsActive = rbActive.Checked;
            List<clsUserEnums.enPermissions> Permissions = new List<clsUserEnums.enPermissions>();

            foreach (var item in ckcbPermissions.CheckedItems)
            {
                Permissions.Add((clsUserEnums.enPermissions)item);
            }

            foreach (clsUserEnums.enPermissions Permission in Permissions)
            {
                _User.Permissions |= (int)Permission;
            }
            return _User;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsUser_DTO User = GetDataFromForm();
            if (User == null) return;
            clsUser_BLL UserBLL = clsUser_BLL.Find(_User.UserID);
            UserBLL.User = User;
            if (!UserBLL.Save())
            {
                MessageBox.Show("Dont Saved", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Saved successfully", "Information",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
