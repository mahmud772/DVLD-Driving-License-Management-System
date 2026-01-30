using DVLD_DAL;
using DVLD_DTO;
using DVLD_Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace DVLD_BLL
{
    public class clsPerson_BLL : IBLL
    {

        enMode Mode = enMode.Create;
        public bool IsNew => Mode == enMode.Create;
        public clsPerson_DTO Person { get; set; }
        public IDTO DTO { get => Person; set => value = Person; }

        public clsPerson_BLL()
        {
            this.Person = new clsPerson_DTO
            {
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

        protected clsPerson_BLL(clsPerson_DTO Person)
        {
            this.Person = Person;
            this.Mode = enMode.Update;
        }
        public static int GetCount()
        {
            return clsPerson_DAL.LoadCount();
        }
        private bool _AddNewPerson()
        {
            this.Person.PersonID = clsPerson_DAL.AddNewPerson(this.Person);
            return (this.Person.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            return clsPerson_DAL.UpdatePerson(this.Person);
        }

        public static clsPerson_BLL Find(int ID)
        {
            clsPerson_DTO Model = clsPerson_DAL.LoadPersonInfoByID(ID);

            return Model == null ? null : new clsPerson_BLL(Model);
        }

        public static clsPerson_BLL Find(string NationalNo)
        {
            clsPerson_DTO Model = clsPerson_DAL.LoadPersonInfoByNationalNo(NationalNo);

            return Model == null ? null : new clsPerson_BLL(Model);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Create:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _UpdatePerson();

            }

            return false;
        }

        public static List<clsPerson_DTO> GetPeople()
        {
            return clsPerson_DAL.LoadPeople();
        }
        public static List<clsPerson_DTO> GetPeople(int Offset, int CountRows)
        {
            return clsPerson_DAL.LoadPeople(Offset, CountRows);
        }


        public static bool DeletePerson(int PersonID)
        {
            return clsPerson_DAL.DeletePerson(PersonID);
        }
        public static bool DeletePerson(string NationalNo)
        {
            return clsPerson_DAL.DeletePerson(NationalNo);
        }
    }
}
