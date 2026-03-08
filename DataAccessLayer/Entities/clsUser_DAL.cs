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
                ImagePath = clsDbHelper.GetValue<string>(Reader, "ImagePath"),


                UserID = clsDbHelper.GetValue<int>(Reader, "UserID"),
                UserName = clsDbHelper.GetValue<string>(Reader, "UserName"),
                IsActive = clsDbHelper.GetValue<bool>(Reader, "IsActive"),
            };
        }
        public static int LoadCount(clsUserQuery clsQuery)
        {
            string Query = "Select Count (*) From Users Where 1 = 1  ";
            Query += clsQuery.SearchBy.HasValue && clsQuery.SearchValue != null
               ? $" AND {clsUserMapper.MapSearchBy(clsQuery.SearchBy.Value)} = @SearchValue"
               : "";

            _ApplyUserFilter(clsQuery.Filter, ref Query);

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
            bool IsFound = clsDbHelper.ExecuteReader(Query, Command => clsDbHelper.SetValue<int>(Command, "@UserID", UserID),
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
            if (!clsDbHelper.FindID<string>(Query, "@UserName", UserName, ref UserID))
                return null;
            return LoadUserByID(UserID);
        }


        public static bool GetIsActiveStatus(int UserID)
        {

            string Query = @"Select IsActive From Users 
                             Where UserID = @UserID";
            return clsDbHelper.ExecuteScalar<bool>(Query, Command =>
                clsDbHelper.SetValue<int>(Command, "@UserID", UserID));
        }
        public static bool GetIsActiveStatus(string UserName)
        {
            int UserID = -1;
            string Query = "Select UserID From Users Where UserName = @UserName";
            if (!clsDbHelper.FindID<string>(Query, "@UserName", UserName, ref UserID))
                return false;
            return GetIsActiveStatus(UserID);
        }
        public static bool GetPermissions(int UserID)
        {
            string Query = @"Select Permissions From Users 
                             Where UserID = @UserID";
            return clsDbHelper.ExecuteScalar<bool>(Query, Command =>
                clsDbHelper.SetValue<int>(Command, "@UserID", UserID));
        }
        public static bool GetPermissions(string UserName)
        {
            int UserID = -1;
            string Query = "Select UserID From Users Where UserName = @UserName";
            if (!clsDbHelper.FindID<string>(Query, "@UserName", UserName, ref UserID))
                return false;
            return GetPermissions(UserID);
        }

        public static int CreateUser(clsUser_DTO Model)
        {

            string Query = @"Insert Into Users (PersonID , UserName , Password , IsActive , Permissions)
                             Select @PersonID , @UserName , @Password , @IsActive , @Permissions
                             Where Exists (Select 1 From People Where PersonID = @PersonID)
                             And Not Exists (Select 1 From Users Where UserName = @UserName);
                             IF @@ROWCOUNT > 0
                                SELECT SCOPE_IDENTITY();
                             ELSE
                                SELECT -1;";
            return clsDbHelper.ExecuteScalar<int>(Query, Command =>
            {
                clsDbHelper.SetValue<int>(Command, "@PersonID", Model.PersonID);
                clsDbHelper.SetValue<string>(Command, "@UserName", Model.UserName);
                clsDbHelper.SetValue<string>(Command, "@Password", Model.Password);
                clsDbHelper.SetValue<bool>(Command, "@IsActive", Model.IsActive);
                clsDbHelper.SetValue<int>(Command, "@Permissions", Model.Permissions);
            });

        }

        public static bool UpdateUser(clsUser_DTO Model)
        {

            string Query = @"Update Users Set IsActive = @IsActive , 
                             Permissions = @Permissions
                             Where UserID = @UserID ";
            return clsDbHelper.ExecuteNonQuery
                (Query, Command =>
                {
                    clsDbHelper.SetValue<int>(Command, "@UserID", Model.UserID);
                    clsDbHelper.SetValue<bool>(Command, "@IsActive", Model.IsActive);
                    clsDbHelper.SetValue<int>(Command, "@Permissions", Model.Permissions);
                }
                ) > 0;

        }

        public static bool DeleteUser(int UserID)
        {

            int DeletedUserCount = 0;

            string QueryUsersTable = @"Delete From Users Where UserID = @UserID;";


            bool TransactionSuccess = clsDbHelper.ExecuteTransaction(Command =>
            {

                clsDbHelper.SetValue<int>(Command, "@UserID", UserID);


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
            if (!clsDbHelper.FindID<string>(Query, "@UserName", UserName, ref UserID))
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
            clsDbHelper.ExecuteReader(Query, Command =>
            {
                clsDbHelper.SetValue<string>(Command, "@UserName", UserName);
                clsDbHelper.SetValue<string>(Command, "@Password", Password);
            },
            Reader => DTO = _Reader(Reader));
            return DTO;
        }

        public static bool DeleteUserByPersonID(int PersonID)
        {
            int UserID = -1;
            string Query = "Select UserID From Users Where PersonID = @PersonID";
            if (!clsDbHelper.FindID<int>(Query, "@PersonID", PersonID, ref UserID))
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
            return clsDbHelper.ReadList(Query, null,
                Reader => _Reader(Reader));
        }

        public static List<clsUser_DTO> LoadUsers(int Offset, int CountRows)
        {
            string Query = $@"SELECT P.*, U.UserID, U.UserName, U.Password, U.IsActive, U.Permissions
                      FROM People P JOIN Users U ON P.PersonID = U.PersonID
                      ORDER BY U.UserID
                      OFFSET @Offset ROWS FETCH NEXT @CountRows ROWS ONLY;";

            return clsDbHelper.ReadList(Query,
                Command => {
                    clsDbHelper.SetValue(Command, "@Offset", Offset);
                    clsDbHelper.SetValue(Command, "@CountRows", CountRows);
                },
                Reader => _Reader(Reader));
        }
        public static List<clsUser_DTO> LoadUsers(int Offset, int CountRows , clsUserQuery clsQuery)
        {
            string Query = $@"SELECT P.*, U.UserID, U.UserName, U.IsActive
                      FROM People P JOIN Users U ON P.PersonID = U.PersonID
                      Where 1 = 1 ";

            Query += clsQuery.SearchBy.HasValue && clsQuery.SearchValue != null
               ? $" AND {clsUserMapper.MapSearchBy(clsQuery.SearchBy.Value)} = @SearchValue"
               : "";

            _ApplyUserFilter(clsQuery.Filter, ref Query);

            Query += $@" ORDER BY {clsUserMapper.MapOrderBy(clsQuery.OrderBy)}
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
        private static void _ApplyUserFilter(clsUserFilter filter, ref string query)
        {
            if (filter == null)
                return;

            clsPerson_DAL.ApplyPersonFilter(filter, ref query);
        }
        public static bool IsPersonIsUser(int PersonID)
        {
            string Query = @"Select 1 From Users Where PersonID = @PersonID;";
            return clsDbHelper.Exists(Query , Command => clsDbHelper.SetValue(Command , "@PersonID" , PersonID));
        }
    }
}
