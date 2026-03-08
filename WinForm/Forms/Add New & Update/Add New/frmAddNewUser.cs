using Common;
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
using DVLD_BLL;
using DVLDWinForm.UIHelper_Manger;
namespace DVLDWinForm.Forms.Add_New___Update
{
    public partial class frmAddNewUser : Form , IForm
    {
        public bool IsChange { get; set; } = false;
        public frmAddNewUser()
        {
            InitializeComponent();
        }
        private void LoadDesign()
        {
            clsUIHelper.CornerRadius(pnlUserInfo, 5);
        }
        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            LoadDesign();
            InitializeDataForm();
        }
        private void InitializeDataForm()
        {
            foreach (var value in Enum.GetValues(typeof(clsUserEnums.enPermissions)))
            {
                ckcbPermissions.AddItem(value);
            }
        }

        private void pbSelectedID_Click(object sender, EventArgs e)
        {
            frmFind frm = new frmFind(new ucPerson() , clsPerson_BLL.Find);
            frm?.ShowDialog();
            tbID.Text = CheckPersonID(frm?.SelectedID);
        }
        private string CheckPersonID(string PersonID)
        {
            int ID;
            int.TryParse(PersonID, out ID);
            if (ID == 0) return string.Empty;
            if(clsUser_BLL.IsPersonIsUser(ID))
            {
                MessageBox.Show("This person is already a user \n Select person else", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
            return PersonID;
        }
        private clsUser_DTO GetDataFromForm()
        {
            clsValidation.ep.Clear();
            if(tbID.Text == string.Empty)
            {
                MessageBox.Show("Select a Person", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            if(!clsValidation.IsValidUserName(tbUserName) ||
                !clsValidation.IsValidPassword(tbPassword)) return null;
            clsUser_DTO User = new clsUser_DTO();
            User.PersonID = Convert.ToInt32(tbID.Text);
            User.UserName = tbUserName.Text;
            User.Password = tbPassword.Text;
            User.IsActive = true;
            User.Permissions = 0;
            List<clsUserEnums.enPermissions> Permissions = new List<clsUserEnums.enPermissions>();

            foreach (var item in ckcbPermissions.CheckedItems)
            {
                Permissions.Add((clsUserEnums.enPermissions)item);
            }

            foreach (clsUserEnums.enPermissions Permission in Permissions)
            {
                User.Permissions |= (int)Permission;
            }
            return User;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            clsUser_DTO User = GetDataFromForm();
            if(User == null) return;
            clsUser_BLL UserBLL = new clsUser_BLL();
            UserBLL.User = User;
            if(!UserBLL.Save())
            {
                MessageBox.Show("Dont Saved", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IsChange = true;
            MessageBox.Show("Saved successfully", "Information",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
