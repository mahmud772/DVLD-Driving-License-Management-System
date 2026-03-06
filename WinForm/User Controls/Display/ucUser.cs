using Common;
using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm.Forms;
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
using static System.Net.Mime.MediaTypeNames;
namespace DVLDWinForm.User_Controls
{
    public partial class ucUser : UserControl , IUserControl
    {
        private clsUser_DTO _UserInfo { get; set; }
        clsCRUDController _CRUDController;
        ContextMenuStrip _sharedContextMenu;
        public clsUser_DTO UserInfo
        {
            get => _UserInfo;
            set
            {
                _UserInfo = value;
                __LoadUserInfo(value);
            }
        }
        public IDTO Info { get => UserInfo; set => UserInfo = value as clsUser_DTO; }
        public ucUser()
        {
            InitializeComponent();
            _LoadDesign();
            UnvisibleComponents();
            ctrlPerson1.CollapseInstantly();
            this.Height = ctrlPerson1._collapsedHeight;
        }
        public ucUser(clsCRUDController CRUDController, ContextMenuStrip SharedContextMenu)
        {

            _CRUDController = CRUDController;
            _sharedContextMenu = SharedContextMenu;
            InitializeComponent();
            _LoadDesign();
            UnvisibleComponents();
            ctrlPerson1.CollapseInstantly();
            this.Height = ctrlPerson1._collapsedHeight;
        }
        private void LoadUserControlDesign()
        {
            clsUIHelper.CornerRadius(this, 25);
        }
        private void LoadImageIsActivelDesign()
        {
            clsUIHelper.CornerRadius(pbIsActive, 5);
        }
        private void _LoadDesign()
        {
            LoadUserControlDesign();
            LoadImageIsActivelDesign();
        }
        private void __LoadUserInfo(clsUser_DTO UserInfo)
        {
            if (UserInfo == null)
            {
                MessageBox.Show("This is User Is Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                //return false;
            }
            ctrlPerson1.PersonInfo = UserInfo;
            lbUserID.Text = Convert.ToString(UserInfo.UserID);
            lbUserName.Text = UserInfo.UserName;
            pbIsActive.Image = (UserInfo.IsActive) ?
                             Properties.Resources.Active : Properties.Resources.NotActive;
            lbUserName.ForeColor = (UserInfo.IsActive) ?
                             Color.FromArgb(76, 175, 80) : Color.FromArgb(244, 67, 54);
        }
        
        private void ctrlPerson1_Load(object sender, EventArgs e)
        {
            ctrlPerson1.OnVisibleChanged += VisibleComponents;
            ctrlPerson1.OnUnvisibleChanged += UnvisibleComponents;
            ctrlPerson1.SelectdDTO = () => _UserInfo;
        }
        private void VisibleComponents()
        {
            lbUserID.Visible = true;
            lbUserID_Title.Visible = true;
            this.Height = ctrlPerson1._expandedHeight;

        }
        private void UnvisibleComponents()
        {
            lbUserID.Visible = false;
            lbUserID_Title.Visible = false;
            this.Height = ctrlPerson1._collapsedHeight;
        }
        
        private void ctrlUser_Load(object sender, EventArgs e)
        {
            
        }
    }
}
