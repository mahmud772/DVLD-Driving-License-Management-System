using DVLD_DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public class clsCountry_DAL
    {

        public static int LoadCount()
        {
            string Query = "Select Count (*) From Countries;";
            return clsDbHelper.ExecuteScalar<int>(Query, null);
        }

        public static clsCountry_DTO LoadCountryNameByID(int CountryID)
        {
            bool IsFound = false;

            clsCountry_DTO Country = null;
            string Query = "SELECT CountryName FROM Countries WHERE CountryID = @CountryID";
            IsFound = clsDbHelper.ExecuteReader
                (
                Query,
                Command => clsDbHelper.SetValue<int>(Command, "@CountryID", CountryID),
                Reader => Country = new clsCountry_DTO
                {
                    CountryName = clsDbHelper.GetValue<string>(Reader, "CountryName")
                }
                );

            return IsFound ? Country : null;
        }

        public static int AddNewCountry(clsCountry_DTO Country)
        {
            int RowsEffected = -1;
            string Query =
                "INSERT INTO Countries (CountryName) VALUES (@CountryName); SELECT SCOPE_IDENTITY();";
            RowsEffected = clsDbHelper.ExecuteNonQuery
                (
                Query,
                Command => clsDbHelper.SetValue<string>(Command, "@CountryName", Country.CountryName));
            return RowsEffected;
        }

        public static bool UpdateCountry(clsCountry_DTO Country)
        {
            int RowsAffected = -1;
            string Query =
                "UPDATE Countries SET CountryName = @CountryName WHERE CountryID = @CountryID";

            RowsAffected = clsDbHelper.ExecuteNonQuery
                (
                Query,
                Command =>
                {
                    clsDbHelper.SetValue<int>(Command, "@CountryID", Country.CountryID);
                    clsDbHelper.SetValue<string>(Command, "@CountryName", Country.CountryName);
                });
            return RowsAffected > -1;
        }

        public static bool DeleteCountry(int CountryID)
        {
            int DeletedCountryCount = 0;

            string QueryCountriesTable = @"Delete From Countries Where CountryID = @CountryID;";


            bool TransactionSuccess = clsDbHelper.ExecuteTransaction(Command =>
            {

                clsDbHelper.SetValue<int>(Command, "@CountryID", CountryID);


                clsPerson_DAL.DeletePersonByCountryID(CountryID);

                Command.CommandText = QueryCountriesTable;
                DeletedCountryCount = Command.ExecuteNonQuery();
            });


            return TransactionSuccess && (DeletedCountryCount > 0);
        }


        public static List<clsCountry_DTO> LoadAllCountries()
        {



            string Query = "SELECT * FROM Countries;";
            return clsDbHelper.ReadList<clsCountry_DTO>(Query, null,
                Reader => new clsCountry_DTO
                {
                    CountryID = clsDbHelper.GetValue<int>(Reader, "CountryID"),
                    CountryName = clsDbHelper.GetValue<string>(Reader, "CountryName")
                }
                );


        }

    }
}
