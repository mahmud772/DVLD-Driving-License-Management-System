using Common;
using Common.Filters;
using Common.Helpers;
using Common.Queries;
using DVLD_DAL.Mappers;
using DVLD_Models;
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
                PersonID = DbHelper.GetValue<int>(Reader, "PersonID"),
                NationalNo = DbHelper.GetValue<string>(Reader, "NationalNo"),
                FirstName = DbHelper.GetValue<string>(Reader, "FirstName"),
                SecondName = DbHelper.GetValue<string>(Reader, "SecondName"),
                ThirdName = DbHelper.GetValue<string>(Reader, "ThirdName"),
                LastName = DbHelper.GetValue<string>(Reader, "LastName"),
                DateOfBirth = DbHelper.GetValue<DateTime>(Reader, "DateOfBirth"),
                Gendor = clsPersonEnumConverter.ToGendor(DbHelper.GetValue<byte>(Reader, "Gendor")),
                Address = DbHelper.GetValue<string>(Reader, "Address"),
                Phone = DbHelper.GetValue<string>(Reader, "Phone"),
                Email = DbHelper.GetValue<string>(Reader, "Email"),
                NationalityCountryID = DbHelper.GetValue<int>(Reader, "NationalityCountryID"),
                ImagePath = DbHelper.GetValue<string>(Reader, "ImagePath")
            };
        }
        public static int LoadCount(clsPersonQuery clsQuery)
        {
            string Query = "Select Count (*) From People Where 1 = 1 ";
            Query += clsQuery.SearchBy.HasValue && clsQuery.SearchValue != null
               ? $" AND {clsPersonMapper.MapSearchBy(clsQuery.SearchBy.Value)} = @SearchValue"
               : "";

            ApplyPersonFilter(clsQuery.Filter, ref Query);

            return DbHelper.ExecuteScalar<int>(Query,
                Command =>
                {
                    DbHelper.SetValue(Command, "@SearchValue", clsQuery.SearchValue,
                        IsHasValue: clsQuery.SearchValue != null);

                    DbHelper.SetValue(Command, "@AgeOlderThen",
                        clsQuery.Filter.AgeOlderThen,
                        clsQuery.Filter.AgeOlderThen.HasValue);

                    DbHelper.SetValue(Command, "@AgeYoungerThen",
                        clsQuery.Filter.AgeYoungerThen,
                        clsQuery.Filter.AgeYoungerThen.HasValue);

                    DbHelper.SetValue(Command, "@Gendor",
                        clsQuery.Filter.Gendor,
                        clsQuery.Filter.Gendor.HasValue);

                    DbHelper.SetValue(Command, "@NationalityCountryID",
                        clsQuery.Filter.NationalityCountryID,
                        clsQuery.Filter.NationalityCountryID.HasValue);

                });
            
        }

        public static clsPerson_DTO LoadPersonInfoByID(int PersonID)
        {
            clsPerson_DTO Model = null;
            bool IsFound = false;
            string Query = "Select * From People Where PersonID = @PersonID";
            IsFound = DbHelper.ExecuteReader(Query, Command => DbHelper.SetValue<int>(Command, "@PersonID", PersonID)
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
            if (DbHelper.FindID<string>(Query, "@NationalNo", NationalNo, ref PersonID))
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
            RowsEffected = DbHelper.ExecuteScalar<int>(Query, Command =>
            {
                DbHelper.SetValue<int>(Command, "@PersonID", Model.PersonID);
                DbHelper.SetValue<string>(Command, "@NationalNo", Model.NationalNo);
                DbHelper.SetValue<string>(Command, "@FirstName", Model.FirstName);
                DbHelper.SetValue<string>(Command, "@SecondName", Model.SecondName);
                DbHelper.SetValue<string>(Command, "@ThirdName", Model.ThirdName);
                DbHelper.SetValue<string>(Command, "@LastName", Model.LastName);
                DbHelper.SetValue<DateTime>(Command, "@DateOfBirth", Model.DateOfBirth);
                DbHelper.SetValue<byte>(Command, "@Gendor", clsPersonEnumConverter.ToByte(Model.Gendor));
                DbHelper.SetValue<string>(Command, "@Address", Model.Address);
                DbHelper.SetValue<string>(Command, "@Phone", Model.Phone);
                DbHelper.SetValue<string>(Command, "@Email", Model.Email);
                DbHelper.SetValue<int>(Command, "@NationalityCountryID", Model.NationalityCountryID);
                DbHelper.SetValue<string>(Command, "@ImagePath", Model.ImagePath);
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
            IsUpdate = DbHelper.ExecuteNonQuery(Query, Command =>
            {
                DbHelper.SetValue<int>(Command, "@PersonID", Model.PersonID);
                DbHelper.SetValue<string>(Command, "@NationalNo", Model.NationalNo);
                DbHelper.SetValue<string>(Command, "@FirstName", Model.FirstName);
                DbHelper.SetValue<string>(Command, "@SecondName", Model.SecondName);
                DbHelper.SetValue<string>(Command, "@ThirdName", Model.ThirdName);
                DbHelper.SetValue<string>(Command, "@LastName", Model.LastName);
                DbHelper.SetValue<DateTime>(Command, "@DateOfBirth", Model.DateOfBirth);
                DbHelper.SetValue<byte>(Command, "@Gendor", clsPersonEnumConverter.ToByte(Model.Gendor));
                DbHelper.SetValue<string>(Command, "@Address", Model.Address);
                DbHelper.SetValue<string>(Command, "@Phone", Model.Phone);
                DbHelper.SetValue<string>(Command, "@Email", Model.Email);
                DbHelper.SetValue<int>(Command, "@NationalityCountryID", Model.NationalityCountryID);
                DbHelper.SetValue<string>(Command, "@ImagePath", Model.ImagePath);
            }) > 0;
            return IsUpdate;
        }

        public static bool DeletePerson(int PersonID)
        {
            string Query = @"Delete From People Where PersonID = @PersonID;";
            int DeletedPersonCount = DbHelper.ExecuteNonQuery(Query, Command => DbHelper.SetValue<int>(Command, "@PersonID", PersonID));

            return (DeletedPersonCount > 0);
        }

        public static bool DeletePersonByCountryID(int NationalityCountryID)
        {
            string Query = @"Delete From People Where NationalityCountryID = @NationalityCountryID;";
            int DeletedPersonCount = DbHelper.ExecuteNonQuery(Query, Command => DbHelper.SetValue<int>(Command, "@NationalityCountryID", NationalityCountryID));

            return (DeletedPersonCount > 0);
        }

        public static bool DeletePerson(string NationalNo)
        {
            int PersonID = -1;
            string Query = @"Select PersonID From People Where NationalNo = @NationalNo;";
            if (DbHelper.FindID<string>(Query, "@NationalNo", NationalNo, ref PersonID))
                return DeletePerson(PersonID);
            return false;
        }

        public static List<clsPerson_DTO> LoadPeople()
        {

            string Query = "SELECT * FROM People;";
            return DbHelper.ReadList(Query, null,
                Reader => _Reader(Reader));

        }

        public static List<clsPerson_DTO> LoadPeople(int Offset, int CountRows)
        {
            string Query = $@"SELECT * FROM People 
                      ORDER BY PersonID
                      OFFSET @Offset ROWS FETCH NEXT @CountRows ROWS ONLY;";

            return DbHelper.ReadList(Query,
                Command => {
                    DbHelper.SetValue(Command, "@Offset", Offset);
                    DbHelper.SetValue(Command, "@CountRows", CountRows);
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

            return DbHelper.ReadList(Query,
                Command =>
                {
                    DbHelper.SetValue(Command, "@SearchValue", clsQuery.SearchValue,
                        IsHasValue: clsQuery.SearchValue != null);

                    DbHelper.SetValue(Command, "@AgeOlderThen",
                        clsQuery.Filter.AgeOlderThen,
                        clsQuery.Filter.AgeOlderThen.HasValue);

                    DbHelper.SetValue(Command, "@AgeYoungerThen",
                        clsQuery.Filter.AgeYoungerThen,
                        clsQuery.Filter.AgeYoungerThen.HasValue);

                    DbHelper.SetValue(Command, "@Gendor",
                        clsQuery.Filter.Gendor,
                        clsQuery.Filter.Gendor.HasValue);

                    DbHelper.SetValue(Command, "@NationalityCountryID",
                        clsQuery.Filter.NationalityCountryID,
                        clsQuery.Filter.NationalityCountryID.HasValue);

                    DbHelper.SetValue(Command, "@Offset", Offset);
                    DbHelper.SetValue(Command, "@CountRows", CountRows);
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
