using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm.Forms;
using DVLDWinForm.UIHelper;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLDWinForm.User_Controls.Display
{
    public partial class ucTest : UserControl , IUserControl
    {
        private clsTest_DTO _TestInfo;
        ContextMenuStrip _sharedContextMenu;
        public clsTest_DTO TestInfo
        {
            get => _TestInfo;
            set
            {
                _TestInfo = value;
                SetTestInfo(value);
            }
        }
        IDTO IUserControl.Info { get => _TestInfo; set => TestInfo = value as clsTest_DTO; }

        public ucTest()
        {
            InitializeComponent();
            LoadDesign();
        }
        public ucTest(ContextMenuStrip SharedContextMenu)
        {
            InitializeComponent();
            LoadDesign();
            _sharedContextMenu = SharedContextMenu;
        }
        private void SetTestInfo(clsTest_DTO TestInfo)
        {
            if (TestInfo == null)
            {
                MessageBox.Show("This is Application Is Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lbAppointmentID.Text = TestInfo.TestAppointmentID.ToString();
            lbTestID.Text = TestInfo.TestID.ToString();
            lbNotes.Text = TestInfo.Notes.ToString();
            if (TestInfo.TestResult)
            {
                lbResult.Text = "Pass";
                lbResult.ForeColor = Color.ForestGreen;
            }
            else
            {
                lbResult.Text = "Fail";
                lbResult.ForeColor = ColorTranslator.FromHtml("#E74C3C");
            }
        }
        

        private void ucTest_Load(object sender, EventArgs e)
        {
            
        }
        private void LoadDesign()
        {
            clsUIHelper.CornerRadius(pnlIDs, 5);
            clsUIHelper.CornerRadius(pnlNotes, 5);
            clsUIHelper.CornerRadius(pnlInfo, 5);
        }

        private void btnUpdate_Delete_Click(object sender, EventArgs e)
        {
            _sharedContextMenu.Tag = this.TestInfo;
            _sharedContextMenu?.Show(btnUpdate_Delete, new Point(0, btnUpdate_Delete.Height));
        }
    }
}
