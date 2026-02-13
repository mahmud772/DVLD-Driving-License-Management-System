using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_BLL;
using System.Windows.Forms;
using DVLDWinForm.UIHelper_Manger;
using DVLDWinForm.UIHelper;

namespace DVLDWinForm.Forms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsValidation.ep.Clear();
            if(!clsValidation.IsValidWord(tbUsername , "Enter a Valid User Name") || clsValidation.IsEmpty(tbPassword , "Enter a Valid Password")) return;
            if (!clsUser_BLL.Login(tbUsername?.Text , tbPassword?.Text))
            {
                lblError.Text = "Incorrect Password or User Name";
                lblError.Visible = true;
                return;
            }

            lblError.Visible = false;
            MessageBox.Show("Login Successful");
            this.DialogResult = DialogResult.OK;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            clsUIHelper.CornerRadius(pnlContainer , 10);
        }
    }
}
