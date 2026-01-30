using DVLD_BLL;
using DVLD_Models;
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

namespace DVLDWinForm.Forms
{
    public partial class frmFindPerson : Form
    {
        public Func<int> GetPersonID { get; set; }
        enum enFindBy { PersonID = 1, NationalNo = 2 }

        public frmFindPerson()
        {
            InitializeComponent();
            _LoadDesign();
        }

        private void frmFindPerson_Load(object sender, EventArgs e)
        {
            cbFindBy.DataSource = Enum.GetValues(typeof(enFindBy));
        }
        private void _LoadDesign()
        {
            clsUIHelper.CornerRadius(pnlFind, 15);
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {

            string Value = tbFindBy.Text.Trim();
            if (Value == string.Empty) return;
            if (ctrlPerson1.PersonInfo?.PersonID == Convert.ToInt32(Value) || ctrlPerson1.PersonInfo?.NationalNo == Value) return;
            clsPerson_DTO Person =
                            cbFindBy.SelectedIndex == 0
                            ? clsPerson_BLL.Find(Convert.ToInt32(Value))?.Person
                            : clsPerson_BLL.Find(Value)?.Person;
            if (Person != null)
            {
                ctrlPerson1.PersonInfo = Person;
                GetPersonID = () => Person.PersonID;
            }
            else
                MessageBox.Show("This is Person Is Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
