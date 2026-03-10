using DVLD_BLL;
using DVLD_DTOs;
using DVLDWinForm.UIHelper;
using DVLDWinForm.UIHelper_Manger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDWinForm.Forms
{
    public partial class frmAddNew_UpdatePerson : Form
    {
        enum enMode { AddNew = 1 , Update = 2 } 
        enMode Mode = enMode.AddNew;
        private clsPerson_DTO _PersonInfo;
        public frmAddNew_UpdatePerson()
        {
            InitializeComponent();
            _LoadDesign();
            Mode = enMode.AddNew;
            lbTitel.Text = "ADD NEW PERSON";
            this.Text = "ADD NEW PERSON";
            
        }
        public frmAddNew_UpdatePerson(clsPerson_DTO PersonInfo)
        {
            InitializeComponent();
            _PersonInfo = PersonInfo;
            _LoadDesign();
            Mode = enMode.Update;
            lbTitel.Text = "UPDATE PERSON";
            this.Text = "UPDATE PERSON";
            
        }
        private void _LoadDesign()
        {
            
            clsUIHelper.CornerRadius(dtpDateOfBirth, 5);
            clsUIHelper.CornerRadius(pnlName, 15);
            clsUIHelper.CornerRadius(pnlContacts, 15);
            clsUIHelper.CornerRadius(pnlLocation, 15);
            clsUIHelper.CornerRadius(pnlDateofBirthAndGender, 15);
            clsUIHelper.CornerRadius(pnlNationalNo, 15);
            clsUIHelper.MakePictureBoxCircular(pbImage);
        }

        private void pbImage_Paint(object sender, PaintEventArgs e)
        {
            clsUIHelper.MakeFramePictureBox(sender, e);
        }

        private void _SetPersonInfo()
        {
            List<clsCountry_DTO> countriesList = clsStaticData_BLL.Countries;

            cbCountry.DataSource = countriesList;

            cbCountry.DisplayMember = "CountryName"; 
            cbCountry.ValueMember = "CountryID";     
            if (_PersonInfo == null) return;
            
            tbNationalNo.Text = _PersonInfo.NationalNo;
            tbFirstName.Text = _PersonInfo.FirstName;
            tbSecondName.Text = _PersonInfo.SecondName;
            tbThirdName.Text = _PersonInfo.ThirdName;
            tbLastName.Text = _PersonInfo.LastName;
            tbPhone.Text = _PersonInfo.Phone;
            tbEmail.Text = _PersonInfo.Email;
            tbAddress.Text = _PersonInfo.Address;

            cbCountry.Text = clsCountry_BLL.GetCountryName(_PersonInfo.NationalityCountryID);
            dtpDateOfBirth.Value = _PersonInfo.DateOfBirth;
            rdbtnMale.Checked = _PersonInfo.Gendor == Common.clsPersonEnums.enGendor.Male;
            rdbtnFemale.Checked = _PersonInfo.Gendor == Common.clsPersonEnums.enGendor.Female;
            clsUIHelper.LoadImage(_PersonInfo.ImagePath, _PersonInfo.Gendor, pbImage);
        }
        
        private bool _GetPersonInfo()
        {
            clsValidation.ep.Clear();
            if (!(
                clsValidation.IsValidNationalNo(tbNationalNo) &&
                clsValidation.IsValidWord(tbFirstName) &&
                clsValidation.IsValidWord(tbSecondName) &&
                clsValidation.IsValidWord(tbThirdName) &&
                clsValidation.IsValidWord(tbLastName) &&
                clsValidation.IsValidEmail(tbEmail) &&
                clsValidation.IsValidAddress(tbAddress) &&
                clsValidation.IsValidPhoneNumber(tbPhone)&&
                clsValidation.IsValidDateOfBirth(dtpDateOfBirth)
                )) return false;
            if (_PersonInfo == null) return false;

            _PersonInfo.NationalNo = tbNationalNo.Text.Trim();
            _PersonInfo.FirstName = tbFirstName.Text.Trim();
            _PersonInfo.SecondName = tbSecondName.Text.Trim();
            _PersonInfo.ThirdName = tbThirdName.Text.Trim();
            _PersonInfo.LastName = tbLastName.Text.Trim();
            _PersonInfo.Phone = tbPhone.Text.Trim();
            _PersonInfo.Email = tbEmail.Text.Trim();
            _PersonInfo.Address = tbAddress.Text.Trim();

            // الدولة (نأخذ الـ ValueMember وهو CountryID)
            if (cbCountry.SelectedValue != null)
                _PersonInfo.NationalityCountryID = Convert.ToInt32(cbCountry.SelectedValue);

            _PersonInfo.DateOfBirth = dtpDateOfBirth.Value;

            _PersonInfo.Gendor = rdbtnMale.Checked
                ? Common.clsPersonEnums.enGendor.Male
                : Common.clsPersonEnums.enGendor.Female;


            _PersonInfo.ImagePath = pbImage.Tag?.ToString() ?? string.Empty;
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_GetPersonInfo())
            {
                clsPerson_BLL Person = (Mode == enMode.AddNew) ? new clsPerson_BLL() : clsPerson_BLL.Find(_PersonInfo.PersonID);
                Person.Person = _PersonInfo;
                if(Person.Save()) DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("The Data Is Not Valid ." , "Error" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
        }

        private void frmAddNew_UpdatePerson_Load(object sender, EventArgs e)
        {
           // _Person = new clsPerson_BLL();

            _SetPersonInfo();

        }

        private void pbImagePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "اختر صورة";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // عرض الصورة داخل PictureBox
                    pbImage.Image = Image.FromFile(ofd.FileName);

                    
                    pbImage.Tag = ofd.FileName;
                }
            }
        }
    }
}
