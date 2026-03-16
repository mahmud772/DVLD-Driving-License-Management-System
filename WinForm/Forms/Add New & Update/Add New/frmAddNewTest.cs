using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm.UIHelper;
using DVLDWinForm.UIHelper_Manger;
using DVLDWinForm.User_Controls;
using System.Windows.Forms;

namespace DVLDWinForm.Forms.Add_New___Update.Add_New
{
    public partial class frmAddNewTest : Form
    {
        clsTest_DTO _Test;
        public frmAddNewTest()
        {
            InitializeComponent();
            LoadDesign();
        }
        public frmAddNewTest(clsTestAppointment_DTO appointment)
        {
            InitializeComponent();
            LoadDesign();
            IsTestingAppointment(appointment);
        }
        private void IsTestingAppointment(clsTestAppointment_DTO appointment)
        {
            if (appointment == null) return;
            if (!clsTest_BLL.IsTestingAppointment(appointment.TestAppointmentID))
                tbID.Text = appointment.TestAppointmentID.ToString();
            else
                MessageBox.Show("The result of this test appointment \nhas been recorded.",
                           "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void LoadDesign()
        {
            clsUIHelper.CornerRadius(pnlTest, 5);
        }
        private bool LoadFromForm()
        {
            _Test.TestResult = rbPassed.Checked;
            _Test.Notes = tbNotes.Text;
            _Test.CreatedByUserID = clsCurrentUser.User.UserID;
            clsValidation.ep.Clear();
            if (clsValidation.IsEmpty(tbID, "Select a valid ID")) return false;
            int ID;
            int.TryParse(tbID.Text, out ID);
            _Test.TestAppointmentID = ID;
            return true;
        }

        private void frmAddNewTest_Load(object sender, System.EventArgs e)
        {
            _Test = new clsTest_DTO();
        }

        private void pbSelectedID_Click(object sender, System.EventArgs e)
        {
            frmFind frm = new frmFind(new ucTestAppointment() , clsTestAppointment_BLL.FindByID);
            frm.ShowDialog();
            tbID.Text = frm.SelectedID;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (LoadFromForm())
            {
                clsTest_BLL Test = new clsTest_BLL();
                Test.Test = _Test;
                if (Test.Save() && Test.Test.TestResult)
                {
                    MessageBox.Show("Test result added .",
                            "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clsDriver_BLL NewDriver = new clsDriver_BLL();
                    NewDriver.Driver.PersonID = clsTestAppointment_BLL.GetPersonIDByTestAppointmentID(_Test.TestAppointmentID);
                    NewDriver.Driver.CreatedByUserID = _Test.CreatedByUserID;
                    if(NewDriver.Save())
                    {
                        MessageBox.Show("This person has become a driver .",
                            "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("This test result has already been recorded. .", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("The Data Is Not Valid .", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
