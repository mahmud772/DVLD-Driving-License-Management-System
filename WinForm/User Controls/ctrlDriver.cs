using DVLD_BLL;
using DVLD_DTO;
using DVLDWinForm.Forms;
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

namespace DVLDWinForm
{
    public partial class ctrlDriver : UserControl
    {
        public clsDriver_DTO DriverInfo {  get; set => _LoadDriverInfo(value); }
        
        public ctrlDriver()
        {
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
        private void _LoadDesign()
        {
            LoadUserControlDesign();
        }

        
        private void _LoadDriverInfo(clsDriver_DTO DriverInfo)
        {
            
            if (DriverInfo == null)
            {
                MessageBox.Show("This is Driver Is Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                //return false;
            }
            ctrlPerson1.PersonInfo = DriverInfo;
            lbDriverID.Text = Convert.ToString(DriverInfo.DriverID);


        }

        private void ctrlPerson1_Load(object sender, EventArgs e)
        {
            ctrlPerson1.OnVisibleChanged += VisibleComponents;
            ctrlPerson1.OnUnvisibleChanged += UnvisibleComponents;
            
            ctrlPerson1.SelectdDTO = () => DriverInfo;
        }
        private void VisibleComponents()
        {
            lbDriverID.Visible = true;
            lbDriverID_Title.Visible = true;
            this.Height = ctrlPerson1._expandedHeight;
        }
        private void UnvisibleComponents()
        {
            lbDriverID.Visible = false;
            lbDriverID_Title.Visible = false;
            this.Height = ctrlPerson1._collapsedHeight;
        }
        
        private void ctrlDriver_Load(object sender, EventArgs e)
        {
           
        }
    }
}
