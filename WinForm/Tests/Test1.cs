using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BLL;
using DVLD_Models;
using DVLDWinForm.Forms;
namespace DVLDWinForm.Tests
{
    public partial class Test1 : Form
    {
        public Test1()
        {
            InitializeComponent();
            clsStaticData_BLL.LoadAllStaticData();
        }

        private void Test1_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //dataGridView1.DataSource = clsPerson.GetPeople();
            //dataGridView1.DataSource = clsApplication.GetAllApplication();
            dataGridView1.DataSource = clsPerson_BLL.GetPeople();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //int PersonID = Convert.ToInt32((textBox1.Text).ToString());
            //clsPerson_BLL Person = clsPerson_BLL.Find(PersonID);
            //textBox2.Text = Person.Person.FirstName.ToString();
            clsPerson_DTO PersonInfo = clsPerson_BLL.Find(1).Person;
            frmAddNew_UpdatePerson form = new frmAddNew_UpdatePerson(PersonInfo);
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //clsPerson_BLL Person = new clsPerson_BLL();
            //Person.Person.NationalNo = "n4";
            //Person.Person.FirstName = "Ali";
            //Person.Person.SecondName = "Omar";
            //Person.Person.ThirdName = "Osama";
            //Person.Person.LastName = "Ahmed";
            //Person.Person.DateOfBirth = DateTime.Now;
            //Person.Person.Gendor = 0;
            //Person.Person.Address = "HDK";
            //Person.Person.Email = "aliomar@gmail.com";
            //Person.Person.Phone = "0911204353";
            //Person.Person.NationalityCountryID = 1;
            //Person.Person.ImagePath = string.Empty;
            //if (Person.Save())
            //    label1.Text = "Done";

            //clsPerson Person = clsPerson.Find("n111");
            //Person.Person.Email = "m9816094@gmail.com";
            //if (Person.Save())
            //    label1.Text = "Done";

            //if (clsPerson.DeletePerson("n111"))
            //    label1.Text = "Done";
            //ctrlUser2.Visible = ctrlUser2.Visible == false ?  true : false;

        }

        private void ctrlPerson1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlPerson2_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAddNewPerson1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlDriver1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlUser1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlLicense1_Load_1(object sender, EventArgs e)
        {

        }










        // ctrlUser2.UserID = 16;




    }
}
