using DVLD_DTOs;
using System;
using System.Windows.Forms;
using DVLD_BLL;
using DVLDWinForm.UIHelper;
namespace DVLDWinForm.Forms
{
    public partial class frmAddNewDriver : Form
    {
        
        public frmAddNewDriver()
        {
            InitializeComponent();
        }

        private void frmAddNew_UpdateDriver_Load(object sender, EventArgs e)
        {
            clsUIHelper.CornerRadius(pnlDriver, 5);
        }

        private void pbSelectedID_Click(object sender, EventArgs e)
        {
            frmFind frm = new frmFind(new ucPerson() , clsPerson_BLL.Find);
            frm.ShowDialog();
            tbID.Text = frm.SelectedID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(tbID.Text.Trim() == string.Empty) return;
            int ID;
            int.TryParse(tbID.Text, out ID);
            clsDriver_BLL driver = new clsDriver_BLL();
            driver.Driver.PersonID = ID;
            driver.Driver.CreatedByUserID = clsCurrentUser.User.UserID;
            if(!driver.Save())
            {
                MessageBox.Show("This person either did not pass all the tests\n or is already a driver.",
                    "Erorr" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
            DialogResult = DialogResult.OK;
        }
    }
}
