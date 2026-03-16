using Common;
using Common.Queries;
using DVLD_DAL;
using DVLD_DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DVLD_BLL
{
    public class clsDriver_BLL : IBLL
    {
        enMode Mode = enMode.Create;
        public bool IsNew => Mode == enMode.Create;

        public clsDriver_DTO Driver { get; set; }
        public IDTO DTO { get => Driver; set => value = Driver; }

        public clsDriver_BLL()
        {
            this.Driver = new clsDriver_DTO
            {
                DriverID = -1,
                CreatedByUserID = -1,
                CreatedDate = DateTime.MinValue,

                PersonID = -1,
                NationalNo = "",
                FirstName = string.Empty,
                SecondName = string.Empty,
                ThirdName = string.Empty,
                LastName = string.Empty,
                DateOfBirth = DateTime.Now,
                Gendor = 0,
                Address = string.Empty,
                Phone = string.Empty,
                Email = string.Empty,
                NationalityCountryID = -1,
                ImagePath = string.Empty
            };
            this.Mode = enMode.Create;
        }
        private clsDriver_BLL(clsDriver_DTO Driver)
        {
            this.Driver = Driver;
            this.Mode = enMode.Update;
        }
        public static int GetCount(IQuery query)
        {
            return clsDriver_DAL.LoadCount(query as clsDriverQuery);
        }
        private bool _AddNewDriver()
        {
            if (clsDriver_DAL.IsPersonIsDriver(this.Driver.PersonID)) return false;
            if (!clsTest_DAL.IsPersonPassedInAllTests(Driver.PersonID, clsApplicationEnums.enApplicationType.NewLocalDrivingLicense)) return false;
            this.Driver.CreatedDate = clsBLHelper.GetDate_Now();
            this.Driver.DriverID = clsDriver_DAL.AddNewDriver(this.Driver);
            return this.Driver.DriverID > 0;
        }



        public static clsDriver_BLL FindByID(int DriverID)
        {
            clsDriver_DTO Driver = clsDriver_DAL.LoadDriverByID(DriverID);
            return Driver == null ? null : new clsDriver_BLL(Driver);
        }
        public static int GetPersonIDByDriverID(int DriverID)
        {
            return clsDriver_DAL.LoadPersonIDByDriverID(DriverID);
        }
        public static bool DeleteDriver(int DriverID)
        {
            return clsDriver_DAL.DeleteDriverByID(DriverID);
        }
        public static bool DeleteDriverByPersonID(int PersonID)
        {
            return clsDriver_DAL.DeleteDriverByPersonID(PersonID);
        }
        public static List<clsDriver_DTO> GetDrivers()
        {
            return clsDriver_DAL.LoadDrivers();
        }
        public static List<clsDriver_DTO> GetDrivers(int Offset, int CountRows, IQuery Query)
        {
            return clsDriver_DAL.LoadDrivers(Offset, CountRows , Query as clsDriverQuery);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Create:
                    if (_AddNewDriver())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;
            }
            return false;
        }
        public static bool IsDriverHaveActiveLicenseFromClass3(int DriverID , ref int LicenseID)
        {
            return clsDriver_DAL.IsDriverHaveActiveLicenseFromClass3(DriverID , ref LicenseID); 
        }
        public static bool IsPersonIsDriver(int PersonID)
        {

            return clsDriver_DAL.IsPersonIsDriver(PersonID);
        }
    }
}
