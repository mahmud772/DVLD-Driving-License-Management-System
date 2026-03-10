using DVLD_BLL;
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

namespace DVLDWinForm.Forms.Add_New___Update.Update
{
    public partial class frmUpdateTest : Form
    {
        clsTest_DTO _Test;
        public frmUpdateTest(clsTest_DTO Test)
        {
            InitializeComponent();
            _Test = Test;
            LoadDesign();
        }
        private void LoadDesign()
        {
            clsUIHelper.CornerRadius(pnlTest , 5);
        }

        private void frmUpdateTest_Load(object sender, EventArgs e)
        {
            if(_Test == null) return;
            tbNotes.Text = _Test.Notes;
        }
        private bool LoadFromForm()
        {
            if(_Test == null) return false;
            _Test.Notes = tbNotes.Text;
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(LoadFromForm())
            {
                clsTest_BLL Test = clsTest_BLL.FindByID(_Test.TestID);
                Test.Test = _Test;
                Test.Save();
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
