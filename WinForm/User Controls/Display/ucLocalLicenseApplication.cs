using DVLD_DTOs;
using DVLDWinForm.Forms;
using DVLDWinForm.UIHelper;
using System;
using System.Windows.Forms;

namespace DVLDWinForm.User_Controls.Display
{
    public partial class ucLocalLicenseApplication : UserControl , IUserControl
    {
        private clsLocalDrivingLicenseApplication_DTO _ApplicationInfo;
        ContextMenuStrip _sharedContextMenu;
        public clsLocalDrivingLicenseApplication_DTO ApplicationInfo
        {
            get => _ApplicationInfo;
            set
            {
                _ApplicationInfo = value;
                ucApplication1.ApplicationInfo = value;
            }
        }
        IDTO IUserControl.Info { get => _ApplicationInfo; set => ApplicationInfo = value as clsLocalDrivingLicenseApplication_DTO; }
        public ucLocalLicenseApplication()
        {
            InitializeComponent();
        }
        public ucLocalLicenseApplication(ContextMenuStrip SharedContextMenu)
        {
            _sharedContextMenu = SharedContextMenu;
            InitializeComponent();
        }

        private void ucApplication1_Load(object sender, EventArgs e)
        {
            ucApplication1.SelectdDTO = () => this.ApplicationInfo;
            clsUIHelper.CornerRadius(this, 25);
        }
    }
}
