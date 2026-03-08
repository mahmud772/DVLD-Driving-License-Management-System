using Common;
using Common.Filters;
using Common.Helpers;
using Common.Queries;
using DVLD_DAL.Mappers;
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
    public class clsPerson_DAL
    {
        private static clsPerson_DTO _Reader(SqlDataReader Reader)
        {
            return new clsPerson_DTO
            {
                PersonID = clsDbHelper.GetValue<int>(Reader, "PersonID"),
                NationalNo = clsDbHelper.GetValue<string>(Reader, "NationalNo"),
                FirstName = clsDbHelper.GetValue<string>(Reader, "FirstName"),
                SecondName = clsDbHelper.GetValue<string>(Reader, "SecondName"),
                ThirdName = clsDbHelper.GetValue<string>(Reader, "ThirdName"),
                LastName = clsDbHelper.GetValue<string>(Reader, "LastName"),
                DateOfBirth = clsDbHelper.GetValue<DateTime>(Reader, "DateOfBirth"),
                Gendor = clsPersonEnumConverter.ToGendor(clsDbHelper.GetValue<byte>(Reader, "Gendor")),
                Address = clsDbHelper.GetValue<string>(Reader, "Address"),
                Phone = clsDbHelper.GetValue<string>(Reader, "Phone"),
                Email = clsDbHelper.GetValue<string>(Reader, "Email"),
                NationalityCountryID = clsDbHelper.GetValue<int>(Reader, "NationalityCountryID"),
                ImagePath = clsDbHelper.GetValue<string>(Reader, "ImagePath")
            };
        }
        public static int LoadCount(clsPersonQuery clsQuery)
        {
            string Query = "Select Count (*) From People Where 1 = 1 ";
            Query += clsQuery.SearchBy.HasValue && clsQuery.SearchValue != null
               ? $" AND {clsPersonMapper.MapSearchBy(clsQuery.SearchBy.Value)} = @SearchValue"
               : "";

            ApplyPersonFilter(clsQuery.Filter, ref Query);

            return clsDbHelper.ExecuteScalar<int>(Query,
                Command =>
                {
                    clsDbHelper.SetValue(Command, "@SearchValue", clsQuery.SearchValue,
                        IsHasValue: clsQuery.SearchValue != null);

                    clsDbHelper.SetValue(Command, "@AgeOlderThen",
                        clsQuery.Filter.AgeOlderThen,
                        clsQuery.Filter.AgeOlderThen.HasValue);

                    clsDbHelper.SetValue(Command, "@AgeYoungerThen",
                        clsQuery.Filter.AgeYoungerThen,
                        clsQuery.Filter.AgeYoungerThen.HasValue);

                    clsDbHelper.SetValue(Command, "@Gendor",
                        clsQuery.Filter.Gendor,
                        clsQuery.Filter.Gendor.HasValue);

                    clsDbHelper.SetValue(Command, "@NationalityCountryID",
                        clsQuery.Filter.NationalityCountryID,
                        clsQuery.Filter.NationalityCountryID.HasValue);

                });
            
        }

        public static clsPerson_DTO LoadPersonInfoByID(int PersonID)
        {
            clsPerson_DTO Model = null;
            bool IsFound = false;
            string Query = "Select * From People Where PersonID = @PersonID";
            IsFound = clsDbHelper.ExecuteReader(Query, Command => clsDbHelper.SetValue<int>(Command, "@PersonID", PersonID)
            , Reader =>
            {
                Model = _Reader(Reader);
            });
            return IsFound ? Model : null;



        }

        public static clsPerson_DTO LoadPersonInfoByNationalNo(string NationalNo)
        {
            string Query = "Select * From People Where NationalNo = @NationalNo";
            int PersonID = -1;
            if (clsDbHelper.FindID<string>(Query, "@NationalNo", NationalNo, ref PersonID))
                return LoadPersonInfoByID(PersonID);
            return null;
        }



        public static int AddNewPerson(clsPerson_DTO Model)

        {
            int RowsEffected = -1;

            string Query = @"Insert Into People (NationalNo , FirstName ,SecondName ,ThirdName ,LastName ,
                                DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID ,ImagePath)
                                Values (@NationalNo , @FirstName ,@SecondName ,@ThirdName ,@LastName ,
                                @DateOfBirth, @Gendor, @Address, @Phone, @Email, @NationalityCountryID ,@ImagePath);
                                SELECT SCOPE_IDENTITY();";
            RowsEffected = clsDbHelper.ExecuteScalar<int>(Query, Command =>
            {
                clsDbHelper.SetValue<int>(Command, "@PersonID", Model.PersonID);
                clsDbHelper.SetValue<string>(Command, "@NationalNo", Model.NationalNo);
                clsDbHelper.SetValue<string>(Command, "@FirstName", Model.FirstName);
                clsDbHelper.SetValue<string>(Command, "@SecondName", Model.SecondName);
                clsDbHelper.SetValue<string>(Command, "@ThirdName", Model.ThirdName);
                clsDbHelper.SetValue<string>(Command, "@LastName", Model.LastName);
                clsDbHelper.SetValue<DateTime>(Command, "@DateOfBirth", Model.DateOfBirth);
                clsDbHelper.SetValue<byte>(Command, "@Gendor", clsPersonEnumConverter.ToByte(Model.Gendor));
                clsDbHelper.SetValue<string>(Command, "@Address", Model.Address);
                clsDbHelper.SetValue<string>(Command, "@Phone", Model.Phone);
                clsDbHelper.SetValue<string>(Command, "@Email", Model.Email);
                clsDbHelper.SetValue<int>(Command, "@NationalityCountryID", Model.NationalityCountryID);
                clsDbHelper.SetValue<string>(Command, "@ImagePath", Model.ImagePath);
            }
            );
            return RowsEffected;
        }

        public static bool UpdatePerson(clsPerson_DTO Model)

        {
            bool IsUpdate = false;

            string Query = @"Update People Set 
                            NationalNo = @NationalNo, FirstName = @FirstName,
                            SecondName = @SecondName ,ThirdName = @ThirdName,LastName = @LastName,
                            DateOfBirth = @DateOfBirth, Gendor = @Gendor, Address = @Address,
                            Phone = @Phone, Email = @Email, NationalityCountryID = @NationalityCountryID,
                            ImagePath = @ImagePath
                            Where PersonID = @PersonID;";
            IsUpdate = clsDbHelper.ExecuteNonQuery(Query, Command =>
            {
                clsDbHelper.SetValue<int>(Command, "@PersonID", Model.PersonID);
                clsDbHelper.SetValue<string>(Command, "@NationalNo", Model.NationalNo);
                clsDbHelper.SetValue<string>(Command, "@FirstName", Model.FirstName);
                clsDbHelper.SetValue<string>(Command, "@SecondName", Model.SecondName);
                clsDbHelper.SetValue<string>(Command, "@ThirdName", Model.ThirdName);
                clsDbHelper.SetValue<string>(Command, "@LastName", Model.LastName);
                clsDbHelper.SetValue<DateTime>(Command, "@DateOfBirth", Model.DateOfBirth);
                clsDbHelper.SetValue<byte>(Command, "@Gendor", clsPersonEnumConverter.ToByte(Model.Gendor));
                clsDbHelper.SetValue<string>(Command, "@Address", Model.Address);
                clsDbHelper.SetValue<string>(Command, "@Phone", Model.Phone);
                clsDbHelper.SetValue<string>(Command, "@Email", Model.Email);
                clsDbHelper.SetValue<int>(Command, "@NationalityCountryID", Model.NationalityCountryID);
                clsDbHelper.SetValue<string>(Command, "@ImagePath", Model.ImagePath);
            }) > 0;
            return IsUpdate;
        }

        public static bool DeletePerson(int PersonID)
        {
            string Query = @"Delete From People Where PersonID = @PersonID;";
            int DeletedPersonCount = clsDbHelper.ExecuteNonQuery(Query, Command => clsDbHelper.SetValue<int>(Command, "@PersonID", PersonID));

            return (DeletedPersonCount > 0);
        }

        public static bool DeletePersonByCountryID(int NationalityCountryID)
        {
            string Query = @"Delete From People Where NationalityCountryID = @NationalityCountryID;";
            int DeletedPersonCount = clsDbHelper.ExecuteNonQuery(Query, Command => clsDbHelper.SetValue<int>(Command, "@NationalityCountryID", NationalityCountryID));

            return (DeletedPersonCount > 0);
        }

        public static bool DeletePerson(string NationalNo)
        {
            int PersonID = -1;
            string Query = @"Select PersonID From People Where NationalNo = @NationalNo;";
            if (clsDbHelper.FindID<string>(Query, "@NationalNo", NationalNo, ref PersonID))
                return DeletePerson(PersonID);
            return false;
        }

        public static List<clsPerson_DTO> LoadPeople()
        {

            string Query = "SELECT * FROM People;";
            return clsDbHelper.ReadList(Query, null,
                Reader => _Reader(Reader));

        }

        public static List<clsPerson_DTO> LoadPeople(int Offset, int CountRows)
        {
            string Query = $@"SELECT * FROM People 
                      ORDER BY PersonID
                      OFFSET @Offset ROWS FETCH NEXT @CountRows ROWS ONLY;";

            return clsDbHelper.ReadList(Query,
                Command => {
                    clsDbHelper.SetValue(Command, "@Offset", Offset);
                    clsDbHelper.SetValue(Command, "@CountRows", CountRows);
                },
                Reader => _Reader(Reader));
        }

        public static List<clsPerson_DTO> LoadPeople(int Offset, int CountRows , clsPersonQuery clsQuery)
        {
            string Query = $@"SELECT * FROM People 
                      Where 1 = 1 ";
            Query += clsQuery.SearchBy.HasValue && clsQuery.SearchValue != null
               ? $" AND {clsPersonMapper.MapSearchBy(clsQuery.SearchBy.Value)} = @SearchValue"
               : "";

            ApplyPersonFilter(clsQuery.Filter, ref Query);

            Query += $@" ORDER BY {clsPersonMapper.MapOrderBy(clsQuery.OrderBy)}
                 {clsOrderDirectionMapper.MapOrderDirection(clsQuery.OrderDirection)}
                 OFFSET @Offset ROWS FETCH NEXT @CountRows ROWS ONLY;";

            return clsDbHelper.ReadList(Query,
                Command =>
                {
                    clsDbHelper.SetValue(Command, "@SearchValue", clsQuery.SearchValue,
                        IsHasValue: clsQuery.SearchValue != null);

                    clsDbHelper.SetValue(Command, "@AgeOlderThen",
                        clsQuery.Filter.AgeOlderThen,
                        clsQuery.Filter.AgeOlderThen.HasValue);

                    clsDbHelper.SetValue(Command, "@AgeYoungerThen",
                        clsQuery.Filter.AgeYoungerThen,
                        clsQuery.Filter.AgeYoungerThen.HasValue);

                    clsDbHelper.SetValue(Command, "@Gendor",
                        clsQuery.Filter.Gendor,
                        clsQuery.Filter.Gendor.HasValue);

                    clsDbHelper.SetValue(Command, "@NationalityCountryID",
                        clsQuery.Filter.NationalityCountryID,
                        clsQuery.Filter.NationalityCountryID.HasValue);

                    clsDbHelper.SetValue(Command, "@Offset", Offset);
                    clsDbHelper.SetValue(Command, "@CountRows", CountRows);
                },
                Reader => _Reader(Reader));
        }

        public static void ApplyPersonFilter(clsPersonFilter filter,ref string query)
        {
            if (filter == null)
                return;

            MappingHelper.AddCondition(filter.AgeOlderThen.HasValue,
                "DateOfBirth <= DATEADD(YEAR, -@AgeOlderThen, GETDATE())",
                ref query);

            MappingHelper.AddCondition(filter.AgeYoungerThen.HasValue,
                "DateOfBirth >= DATEADD(YEAR, -@AgeYoungerThen, GETDATE())",
                ref query);

            MappingHelper.AddCondition(filter.Gendor.HasValue,
                "Gendor = @Gendor",
                ref query);

            MappingHelper.AddCondition(filter.NationalityCountryID.HasValue,
                "NationalityCountryID = @NationalityCountryID",
                ref query);
        }

    }
}
