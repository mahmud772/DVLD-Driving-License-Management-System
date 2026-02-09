using DVLD_DAL;
using DVLD_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BLL
{
    public class clsCountry_BLL
    {
        enMode Mode = enMode.Create;
        public bool IsNew => Mode == enMode.Create;
        public clsCountry_DTO Country { get; set; }

        public clsCountry_BLL()
        {
            this.Country = new clsCountry_DTO
            {
                CountryID = -1,
                CountryName = ""
            };

            this.Mode = enMode.Create;
        }

        private clsCountry_BLL(clsCountry_DTO Country)
        {
            this.Country = Country;
            this.Mode = enMode.Update;

        }

        public static int GetCount()
        {
            return clsCountry_DAL.LoadCount();
        }

        public static clsCountry_BLL FindByCountryID(int CountryID)
        {

            clsCountry_DTO Country = clsCountry_DAL.LoadCountryNameByID(CountryID);

            return Country == null ? null : new clsCountry_BLL(Country);
        }

        public static bool FindByCountryID(int CountryID, out clsCountry_BLL Country)
        {
            clsCountry_DTO Model = clsCountry_DAL.LoadCountryNameByID(CountryID);

            if (Model == null)
            {
                Country = null;
                return false;
            }

            Country = new clsCountry_BLL(Model);
            return true;
        }




        private bool _AddNewCountry()
        {
            this.Country.CountryID = clsCountry_DAL.AddNewCountry(this.Country);
            return (this.Country.CountryID > -1);
        }

        private bool _UpdateCountry()
        {
            return clsCountry_DAL.UpdateCountry(this.Country);
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Create:
                    if (_AddNewCountry())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _UpdateCountry();


            }
            return false;
        }


        public static List<clsCountry_DTO> GetAllCountries()
        {
            return clsCountry_DAL.LoadAllCountries();
        }
        public static string GetCountryName(int CountryID)
        {
            return clsStaticData_BLL.Countries[CountryID].CountryName;
        }
    }
}
