using DVLD_BLL;
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

namespace DVLDWinForm.User_Controls
{
    public partial class ucLogout : UserControl
    {
        public ucLogout()
        {
            InitializeComponent();

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            clsCurrentUser.Logout();
        }

        private void ucLogout_Load(object sender, EventArgs e)
        {
            clsUIHelper.CornerRadius(this, 5);
            if (clsCurrentUser.User == null) return;
            clsUIHelper.MakePictureBoxCircular(pbUserImage);
            clsUIHelper.LoadImage(clsCurrentUser.User.ImagePath , clsCurrentUser.User.Gendor , pbUserImage);
            lbFirstAndSecondName.Text = clsCurrentUser.User.FirstName;
            lbFirstAndSecondName.Text += " " + clsCurrentUser.User.SecondName;
            lbUserName.Text = clsCurrentUser.User.UserName;
        }

        private void pbUserImage_Paint(object sender, PaintEventArgs e)
        {
            clsUIHelper.MakeFramePictureBox(sender , e);
        }
    }
}
