using Common;
using Common.Filters;
using Common.Helpers;
using Common.Queries;
using DVLD_DAL;
using DVLD_DAL.Mappers;
using DVLD_DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD_DAL
{

    public class clsUser_DAL
    {
        private static clsUser_DTO _Reader(SqlDataReader Reader)
        {
            return new clsUser_DTO
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
                ImagePath = DbHelper.GetValue<string>(Reader, "ImagePath"),


                UserID = DbHelper.GetValue<int>(Reader, "UserID"),
                UserName = DbHelper.GetValue<string>(Reader, "UserName"),
                Password = DbHelper.GetValue<string>(Reader, "Password"),
                IsActive = DbHelper.GetValue<bool>(Reader, "IsActive"),
                Permissions = DbHelper.GetValue<int>(Reader, "Permissions")
            };
        }
        public static int LoadCount(clsUserQuery clsQuery)
        {
            string Query = "Select Count (*) From Users Where 1 = 1  ";
            Query += clsQuery.SearchBy.HasValue && clsQuery.SearchValue != null
               ? $" AND {clsUserMapper.MapSearchBy(clsQuery.SearchBy.Value)} = @SearchValue"
               : "";

            _ApplyUserFilter(clsQuery.Filter, ref Query);

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

        public static clsUser_DTO LoadUserByID(int UserID)
        {
            string Query = @"
                        SELECT 
                            P.PersonID AS PersonID, P.NationalNo, P.FirstName, P.SecondName, P.ThirdName, 
                            P.LastName, P.DateOfBirth, P.Gendor, P.Address, P.Phone, P.Email, 
                            P.NationalityCountryID, P.ImagePath,
                            U.UserID, U.UserName, U.Password, U.IsActive , U.Permissions
                        FROM People P
                        JOIN Users U ON P.PersonID = U.PersonID
                        WHERE U.UserID = @UserID;";
            clsUser_DTO Model = null;
            bool IsFound = DbHelper.ExecuteReader(Query, Command => DbHelper.SetValue<int>(Command, "@UserID", UserID),
                Reader =>
                {
                    Model = _Reader(Reader);
                });
            return IsFound ? Model : null;
        }


        public static clsUser_DTO LoadUserByUserName(string UserName)
        {
            int UserID = -1;
            string Query = "Select UserID From Users Where UserName = @UserName";
            if (!DbHelper.FindID<string>(Query, "@UserName", UserName, ref UserID))
                return null;
            return LoadUserByID(UserID);
        }


        public static bool GetIsActiveStatus(int UserID)
        {

            string Query = @"Select IsActive From Users 
                             Where UserID = @UserID";
            return DbHelper.ExecuteScalar<bool>(Query, Command =>
                DbHelper.SetValue<int>(Command, "@UserID", UserID));
        }
        public static bool GetIsActiveStatus(string UserName)
        {
            int UserID = -1;
            string Query = "Select UserID From Users Where UserName = @UserName";
            if (!DbHelper.FindID<string>(Query, "@UserName", UserName, ref UserID))
                return false;
            return GetIsActiveStatus(UserID);
        }
        public static bool GetPermissions(int UserID)
        {
            string Query = @"Select Permissions From Users 
                             Where UserID = @UserID";
            return DbHelper.ExecuteScalar<bool>(Query, Command =>
                DbHelper.SetValue<int>(Command, "@UserID", UserID));
        }
        public static bool GetPermissions(string UserName)
        {
            int UserID = -1;
            string Query = "Select UserID From Users Where UserName = @UserName";
            if (!DbHelper.FindID<string>(Query, "@UserName", UserName, ref UserID))
                return false;
            return GetPermissions(UserID);
        }

        public static int CreateUser(clsUser_DTO Model)
        {

            string Query = @"Insert Into Users (PersonID , UserName , Password , IsActive , Permissions)
                             Select @PersonID , @UserName , @Password , @IsActive , @Permissions
                             Where Exists (Select 1 From People PersonID = @PersonID)
                             And Not Exists (Select 1 From Users UserName = @UserName);
                             IF @@ROWCOUNT > 0
                                SELECT SCOPE_IDENTITY();
                             ELSE
                                SELECT -1;";
            return DbHelper.ExecuteScalar<int>(Query, Command =>
            {
                DbHelper.SetValue<int>(Command, "@PersonID", Model.PersonID);
                DbHelper.SetValue<string>(Command, "@UserName", Model.UserName);
                DbHelper.SetValue<string>(Command, "@Password", Model.Password);
                DbHelper.SetValue<bool>(Command, "@IsActive", Model.IsActive);
                DbHelper.SetValue<int>(Command, "@Permissions", Model.Permissions);
            });

        }

        public static bool UpdateUser(clsUser_DTO Model)
        {

            string Query = @"Update Users Set IsActive = @IsActive , 
                             Permissions = @Permissions ,Password = @Password
                             Where UserID = @UserID ";
            return DbHelper.ExecuteNonQuery
                (Query, Command =>
                {
                    DbHelper.SetValue<int>(Command, "@UserID", Model.UserID);
                    DbHelper.SetValue<bool>(Command, "@IsActive", Model.IsActive);
                    DbHelper.SetValue<string>(Command, "@Password", Model.Password);
                    DbHelper.SetValue<int>(Command, "@Permissions", Model.Permissions);
                }
                ) > 0;

        }

        public static bool DeleteUser(int UserID)
        {

            int DeletedUserCount = 0;

            string QueryUsersTable = @"Delete From Users Where UserID = @UserID;";


            bool TransactionSuccess = DbHelper.ExecuteTransaction(Command =>
            {

                DbHelper.SetValue<int>(Command, "@UserID", UserID);


                clsApplication_DAL.DeleteByUserID(UserID);

                clsDetainedLicense_DAL.DeleteByUserID(UserID);

                clsDriver_DAL.DeleteByUserID(UserID);

                clsInternationalLicense_DAL.DeleteByUserID(UserID);

                clsTest_DAL.DeleteByUserID(UserID);

                clsTestAppointment_DAL.DeleteByUserID(UserID);

                clsLicense_DAL.DeleteByUserID(UserID);


                Command.CommandText = QueryUsersTable;
                DeletedUserCount = Command.ExecuteNonQuery();
            });


            return TransactionSuccess && (DeletedUserCount > 0);
        }

        public static bool DeleteUser(string UserName)
        {
            int UserID = -1;
            string Query = "Select UserID From Users Where UserName = @UserName";
            if (!DbHelper.FindID<string>(Query, "@UserName", UserName, ref UserID))
                return false;
            return DeleteUser(UserID);
        }


        public static clsUser_DTO Login(string UserName, string Password)
        {
            string Query = @"
                        SELECT 
                            P.PersonID AS PersonID, P.NationalNo, P.FirstName, P.SecondName, P.ThirdName, 
                            P.LastName, P.DateOfBirth, P.Gendor, P.Address, P.Phone, P.Email, 
                            P.NationalityCountryID, P.ImagePath,
                            U.UserID, U.UserName, U.Password, U.IsActive , U.Permissions
                        FROM People P
                        JOIN Users U ON P.PersonID = U.PersonID
                        Where UserName = @UserName And Password = @Password;";
            clsUser_DTO DTO = null;
            DbHelper.ExecuteReader(Query, Command =>
            {
                DbHelper.SetValue<string>(Command, "@UserName", UserName);
                DbHelper.SetValue<string>(Command, "@Password", Password);
            },
            Reader => DTO = _Reader(Reader));
            return DTO;
        }

        public static bool DeleteUserByPersonID(int PersonID)
        {
            int UserID = -1;
            string Query = "Select UserID From Users Where PersonID = @PersonID";
            if (!DbHelper.FindID<int>(Query, "@PersonID", PersonID, ref UserID))
                return false;
            return DeleteUser(UserID);
        }


        public static List<clsUser_DTO> LoadUsers()
        {
            string Query = @"
                        
                        SELECT 
                            P.*,
                            U.UserID, U.UserName, U.Password, U.IsActive , U.Permissions
                        FROM People P
                        JOIN Users U ON P.PersonID = U.PersonID;";
            return DbHelper.ReadList(Query, null,
                Reader => _Reader(Reader));
        }

        public static List<clsUser_DTO> LoadUsers(int Offset, int CountRows)
        {
            string Query = $@"SELECT P.*, U.UserID, U.UserName, U.Password, U.IsActive, U.Permissions
                      FROM People P JOIN Users U ON P.PersonID = U.PersonID
                      ORDER BY U.UserID
                      OFFSET @Offset ROWS FETCH NEXT @CountRows ROWS ONLY;";

            return DbHelper.ReadList(Query,
                Command => {
                    DbHelper.SetValue(Command, "@Offset", Offset);
                    DbHelper.SetValue(Command, "@CountRows", CountRows);
                },
                Reader => _Reader(Reader));
        }
        public static List<clsUser_DTO> LoadUsers(int Offset, int CountRows , clsUserQuery clsQuery)
        {
            string Query = $@"SELECT P.*, U.UserID, U.UserName, U.Password, U.IsActive, U.Permissions
                      FROM People P JOIN Users U ON P.PersonID = U.PersonID
                      Where 1 = 1 ";

            Query += clsQuery.SearchBy.HasValue && clsQuery.SearchValue != null
               ? $" AND {clsUserMapper.MapSearchBy(clsQuery.SearchBy.Value)} = @SearchValue"
               : "";

            _ApplyUserFilter(clsQuery.Filter, ref Query);

            Query += $@" ORDER BY {clsUserMapper.MapOrderBy(clsQuery.OrderBy)}
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
        private static void _ApplyUserFilter(clsUserFilter filter, ref string query)
        {
            if (filter == null)
                return;

            clsPerson_DAL.ApplyPersonFilter(filter, ref query);
        }
        public static bool IsPersonIsUser(int PersonID)
        {
            string Query = @"Select 1 From Users Where PersonID = @PersonID;";
            return DbHelper.Exists(Query , Command => DbHelper.SetValue(Command , "@PersonID" , PersonID));
        }
    }
}
