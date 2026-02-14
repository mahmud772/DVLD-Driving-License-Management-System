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
namespace DVLDWinForm.Forms.Add_New___Update
{
    public partial class frmAddNewUser : Form
    {
        
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
        private void SetUserInfoAtForm()
        {
            
        }

        private void pbSelectedID_Click(object sender, EventArgs e)
        {
            frmFind frm = new frmFind(new ucPerson() , clsPerson_BLL.Find);
            frm?.ShowDialog();
            tbID.Text = frm?.SelectedID;
            CheckPersonID(frm?.SelectedID);
        }
        private void CheckPersonID(string PersonID)
        {
            int ID;
            int.TryParse(PersonID, out ID);
            if (ID == 0) return;
            if(clsUser_BLL.IsPersonIsUser(ID))
            {
                MessageBox.Show("This person is already a user \n Select person else", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbID.Text = string.Empty;
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
