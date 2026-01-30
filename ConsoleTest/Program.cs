using DVLD_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using DVLD_DTO;
namespace ConsoleTest
{
    delegate bool ConditionAge(int Age);
    internal class Program
    {
        static void Main(string[] args)
        {
            /*clsApplication application;
            if (!clsApplication.FindByApplicationID(43,out application))
                return;
            Console.WriteLine("______________________________________");
            Console.WriteLine("Application ID : " + application.Application.ApplicationID);
            Console.WriteLine("Application Type ID : " + application.Application.ApplicationTypeID);
            Console.WriteLine("Application Person ID : " + application.Application.ApplicatPersonID);
            Console.WriteLine("Last Status Date : " + application.Application.LastStatusDate);
            Console.WriteLine("Application Date : " + application.Application.ApplicationDate);
            Console.WriteLine("Created By User ID : " + application.Application.CreatedByUserID);
            Console.WriteLine("______________________________________");*/

            /*clsUser_BLL User = clsUser_BLL.Find(16);
            if (User == null)
                return;
            Console.WriteLine("\n\n_________________User1_____________________");
            Console.WriteLine("______________________________________");
            Console.WriteLine("User ID : " + User.User.UserID);
            Console.WriteLine("User Name : " + User.User.UserName);
            Console.WriteLine("Password : " + User.User.Password);
            Console.WriteLine("Is Active : " + User.User.IsActive);
            Console.WriteLine("Person ID : " + User.User.PersonID);
            Console.WriteLine("National No : " + User.User.NationalNo);
            Console.WriteLine("First Name : " + User.User.FirstName);
            Console.WriteLine("Second Name : " + User.User.SecondName);
            Console.WriteLine("Third Name : " + User.User.ThirdName);
            Console.WriteLine("Last Name : " + User.User.LastName);
            Console.WriteLine("Date Of Birth : " + User.User.DateOfBirth);
            Console.WriteLine("Email : " + User.User.Email);
            Console.WriteLine("Phone : " + User.User.Phone);
            Console.WriteLine("Gendor : " + User.User.Gendor);
            Console.WriteLine("Nationality Country ID : " + User.User.NationalityCountryID);
            Console.WriteLine("Image Path : " + User.User.ImagePath);
            Console.WriteLine("______________________________________");*/

            /*clsUser_BLL User2 = new clsUser_BLL();
            User2.User.PersonID = 1024;
            User2.User.UserName = "Ahmed";
            User2.User.IsActive = true;
            User2.User.Password = "1111";
            User2.Save();
            if (User2 == null)
                return;
            Console.WriteLine("\n\n_________________User2_____________________");
            
            Console.WriteLine("______________________________________");
            Console.WriteLine("User ID : " + User2.User.UserID);
            Console.WriteLine("User Name : " + User2.User.UserName);
            Console.WriteLine("Password : " + User2.User.Password);
            Console.WriteLine("Is Active : " + User2.User.IsActive);
            Console.WriteLine("Person ID : " + User2.User.PersonID);
            Console.WriteLine("National No : " + User2.User.NationalNo);
            Console.WriteLine("First Name : " + User2.User.FirstName);
            Console.WriteLine("Second Name : " + User2.User.SecondName);
            Console.WriteLine("Third Name : " + User2.User.ThirdName);
            Console.WriteLine("Last Name : " + User2.User.LastName);
            Console.WriteLine("Date Of Birth : " + User2.User.DateOfBirth);
            Console.WriteLine("Email : " + User2.User.Email);
            Console.WriteLine("Phone : " + User2.User.Phone);
            Console.WriteLine("Gendor : " + User2.User.Gendor);
            Console.WriteLine("Nationality Country ID : " + User2.User.NationalityCountryID);
            Console.WriteLine("Image Path : " + User2.User.ImagePath);
            Console.WriteLine("______________________________________");*/

            //PrintNameWhenOlderThen("Mahmoud Amer Labah", 23,Age =>  Age > 45 );

            /*clsLocalDrivingLicenseApplication_BLL Application = clsLocalDrivingLicenseApplication_BLL.FindByLocaLicenseApplicationlID(35);
            Application.LocalApplication.ApplicationTypeID = 3;
            Application.LocalApplication.ApplicantPersonID = 1023;
            Application.LocalApplication.CreatedByUserID = 1;
            Application.LocalApplication.LicenseClassID = 1;
            if(!Application.Save())
                return;
            Console.WriteLine("______________________________________");
            Console.WriteLine("Application ID : " + Application.LocalApplication.ApplicationID);
            Console.WriteLine("Application Type ID : " + Application.LocalApplication.ApplicationTypeID);
            Console.WriteLine("Applicantion Person ID : " + Application.LocalApplication.ApplicantPersonID);
            Console.WriteLine("Last Status Date : " + Application.LocalApplication.LastStatusDate);
            Console.WriteLine("Application Date : " + Application.LocalApplication.ApplicationDate);
            Console.WriteLine("Created By User ID : " + Application.LocalApplication.CreatedByUserID);
            Console.WriteLine("License Class ID : " + Application.LocalApplication.LicenseClassID);
            Console.WriteLine("______________________________________"); */

            /*if (clsLocalDrivingLicenseApplication_BLL.DeleteLocalDrivingLicenseApplicationByApplicationID(72))
                Console.WriteLine("Done");*/

            /*clsDetainedLicense_BLL License = clsDetainedLicense_BLL.FindByDetainID(7);
            License.Detain.CreatedByUserID = 16;
            License.Detain.DetainDate = DateTime.Now;
            License.Detain.FineFees = 50;
            
            License.Detain.IsReleased = false;
            License.Detain.LicenseID = 14;
            License.Detain.ReleaseApplicationID = 10;
            License.Detain.ReleaseDate = DateTime.MinValue;

            if (License.Save())
                Console.WriteLine("Done!");*/

            /*clsDetainedLicense_BLL License = clsDetainedLicense_BLL.FindByDetainID(6);
            
            if(License.ReleaseLicense())
            {
                Console.WriteLine("Detain ID : " + License.Detain.DetainID);
                Console.WriteLine("Detain Date : " + License.Detain.DetainDate);
                Console.WriteLine("Release Date : " + License.Detain.ReleaseDate);
                Console.WriteLine("Fine Fees : " + License.Detain.FineFees);
                Console.WriteLine("Released By User ID : " + License.Detain.ReleasedByUserID);
                Console.WriteLine("Release Application ID : " + License.Detain.ReleaseApplicationID);
                Console.WriteLine("License ID : " + License.Detain.LicenseID);
                Console.WriteLine("Created By User ID : " + License.Detain.CreatedByUserID); 
            }*/

            /*if (clsDetainedLicense_BLL.DeleteDetain(6))
                Console.WriteLine("Done");*/
            /*clsStaticData_BLL.LoadAllStaticData();
            DateTime Date = new DateTime();
            Date = DateTime.Now;
            Date = Date.AddDays(1);
            clsTestAppointment_BLL Appointment = new clsTestAppointment_BLL();
            Appointment.Appointment.AppointmentDate = Date;
            Appointment.Appointment.TestType = Common.clsTestEnums.enTestTypes.VisionTest;
            Appointment.Appointment.RetakeTestApplicationID = 3;
            Appointment.Appointment.LocalDrivingLicenseApplicationID = 32;
            Appointment.Appointment.CreatedByUserID = 1;
            Appointment.Appointment.IsLocked = false;
            Appointment.Appointment.PaidFees = 10;
            //clsTestAppointment_BLL Appointment = clsTestAppointment_BLL.FindByID(75);
            //Appointment.Appointment.IsLocked = true;
            
            if (Appointment.Save())
            {
                Console.WriteLine("Appointment Date : " + Appointment.Appointment.AppointmentDate);
                Console.WriteLine("Test Type ID : " + Appointment.Appointment.TestTypeID);
                Console.WriteLine("Retake Test Application ID : " + Appointment.Appointment.RetakeTestApplicationID);
                Console.WriteLine("Local Driving License Application ID : " + Appointment.Appointment.LocalDrivingLicenseApplicationID);
                Console.WriteLine("Created By User ID : " + Appointment.Appointment.CreatedByUserID);
                Console.WriteLine("Is Locked : " + Appointment.Appointment.IsLocked);
                Console.WriteLine("Paid Fees : " + Appointment.Appointment.PaidFees);
                Console.WriteLine("Test Type : " + Appointment.Appointment.TestType);
            }*/
            


        }

        static void PrintNameWhenOlderThen(string name , int Age , ConditionAge Condition)
        {
            if(Condition(Age))
                Console.WriteLine(name);
            else 
                Console.WriteLine("You Are So Young ^_^");
        }
        static bool Condition(int Age)
        {
            return Age > 18;
        }
    }
}
