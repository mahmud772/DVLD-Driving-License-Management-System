using Common;
using Common.Helpers;
using Common.Queries;
using DVLD_DAL;
using DVLD_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    public class clsTestAppointment_BLL : IBLL
    {
        enMode Mode = enMode.Create;
        public bool IsNew => Mode == enMode.Create;
        public bool IsRetakeTest { get; private set; }
        public clsTestAppointment_DTO Appointment { get; set; }
        public IDTO DTO { get => Appointment; set => value = Appointment; }

        public clsTestAppointment_BLL()
        {
            this.Appointment = new clsTestAppointment_DTO
            {
                TestAppointmentID = -1,
                TestType = clsTestEnums.enTestTypes.VisionTest,
                LocalDrivingLicenseApplicationID = -1,
                AppointmentDate = DateTime.MinValue,
                PaidFees = -1,
                CreatedByUserID = -1,
                IsLocked = false,
                RetakeTestApplicationID = -1
            };
            this.Mode = enMode.Create;
        }

        private clsTestAppointment_BLL(clsTestAppointment_DTO Model)
        {
            this.Appointment = Model;
            this.Mode = enMode.Update;
        }

        public static int GetCount(IQuery query)
        {
            return clsTestAppointment_DAL.LoadCount(query as clsTestAppointmentQuery);
        }

        public static clsTestAppointment_BLL FindByID(int TestAppointmentID)
        {
            clsTestAppointment_DTO Model = clsTestAppointment_DAL.LoadTestAppointmentByID(TestAppointmentID);
            return Model == null ? null : new clsTestAppointment_BLL(Model);
        }

        public static bool FindByID(int TestAppointmentID, out clsTestAppointment_BLL Appointment)
        {
            clsTestAppointment_DTO Model = clsTestAppointment_DAL.LoadTestAppointmentByID(TestAppointmentID);
            if (Model == null)
            {
                Appointment = null;
                return false;
            }
            Appointment = new clsTestAppointment_BLL(Model);
            return true;
        }


        private bool _IsTestOrderValid()
        {
            int LastPassed = clsTestAppointment_DAL.LoadLastTestTypePassed(this.Appointment.LocalDrivingLicenseApplicationID);
            clsTestEnums.enTestTypes LastTest = clsTestEnumConverter.ConvertTestTypeToEnum(clsTestAppointment_DAL.LoadLastTestType(this.Appointment.LocalDrivingLicenseApplicationID));

            if (LastPassed == 0 && LastTest != clsTestEnums.enTestTypes.VisionTest) return false;
            if (LastPassed == (int)clsTestEnums.enTestTypes.PracticalTest) return false;

            if (this.Appointment.TestType == clsTestEnums.enTestTypes.WrittenTest)
                return (LastPassed == (int)clsTestEnums.enTestTypes.VisionTest);

            if (this.Appointment.TestType == clsTestEnums.enTestTypes.PracticalTest)
                return (LastPassed == (int)clsTestEnums.enTestTypes.WrittenTest);

            return true;
        }
        private bool _AddNewAppointment()
        {
            decimal PaidFeesApplication = 0;
            this.Appointment.RetakeTestApplicationID = 0;
            if (this.Appointment.AppointmentDate < clsBLHelper.GetDate_Now()) return false;
            if (clsTestAppointment_DAL.IsTestedBefor(this.Appointment.LocalDrivingLicenseApplicationID))
                if (!_IsTestOrderValid()) return false;

            if (!clsTestAppointment_DAL.IsPassedInLastTest(this.Appointment.LocalDrivingLicenseApplicationID)
                && clsTestAppointment_DAL.IsTestedBeforInthisType(this.Appointment.LocalDrivingLicenseApplicationID, this.Appointment.TestType)
                )
            {
                clsApplication_BLL Application = new clsApplication_BLL();

                Application.Application.ApplicantPersonID = clsLocalDrivingLicenseApplication_DAL.GetPersonIDByLocalDrivingLicenseApplicationID(this.Appointment.LocalDrivingLicenseApplicationID);
                //Application.Application.ApplicationDate = clsBLHelper.GetDate_Now();
                Application.Application.ApplicationTypeID = clsApplicationEnumConverter.ToInt(clsApplicationEnums.enApplicationType.RetakeTest);
                Application.Application.ApplicationStatus = clsApplicationEnums.enApplicationStatus.Completed;
                Application.Application.CreatedByUserID = this.Appointment.CreatedByUserID;
                //Application.Application.LastStatusDate = clsBLHelper.GetDate_Now();
                //Application.Application.PaidFees = clsApplicationType_BLL.GetApplicationFees(clsApplicationEnums.ConvertApplicationTypeToInt(clsApplicationEnums.enApplicationType.RetakeTest));
                if (!Application.Save()) return false;
                this.Appointment.RetakeTestApplicationID = Application.Application.ApplicationID;
                this.IsRetakeTest = true;
                PaidFeesApplication = Application.Application.PaidFees;
            }
            this.Appointment.PaidFees = clsTestType_BLL.GetPaidFees(clsTestEnumConverter.ConvertTestTypeToInt(this.Appointment.TestType));

            this.Appointment.TestAppointmentID = clsTestAppointment_DAL.AddNewTestAppointment(this.Appointment);
            return (this.Appointment.TestAppointmentID > 0);
        }

        private bool _UpdateAppointment()
        {
            if (this.Appointment.AppointmentDate < clsBLHelper.GetDate_Now()) return false;
            if (this.Appointment.IsLocked == false && clsTestAppointment_DAL.IsLockedForLastTest(this.Appointment.LocalDrivingLicenseApplicationID)) return false;
            return clsTestAppointment_DAL.UpdateTestAppointment(this.Appointment);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Create:
                    if (_AddNewAppointment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _UpdateAppointment();
            }
            return false;
        }


        public static List<clsTestAppointment_DTO> GetTestAppointments()
        {
            return clsTestAppointment_DAL.LoadTestAppointments();
        }
        public static List<clsTestAppointment_DTO> GetTestAppointments(int Offset, int CountRows, IQuery Query)
        {
            return clsTestAppointment_DAL.LoadTestAppointments(Offset, CountRows , Query as clsTestAppointmentQuery);
        }
        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            return clsTestAppointment_DAL.DeleteTestAppointmentByID(TestAppointmentID);
        }


        public static bool LockedTestAppointment(int TestAppointmentID)
        {
            return clsTestAppointment_DAL.LockedTestAppointment(TestAppointmentID);
        }
        public static int GetPersonIDByTestAppointmentID(int TestAppointmentID)
        {
            return clsTestAppointment_DAL.LoadPersonIDByTestAppointmentID(TestAppointmentID);
        }
        public static decimal GetPaidFeesByTestAppointmentID(int TestAppointmentID)
        {
            return clsTestAppointment_DAL.LoadPaidFeesByTestAppointmentID(TestAppointmentID) ;
        }
        public static clsTestEnums.enTestTypes GetLastTestType(int TestAppointmentID)
        {
            return clsTestEnumConverter.ConvertTestTypeToEnum(clsTestAppointment_DAL.LoadLastTestType(TestAppointmentID));
        }
    }
}
