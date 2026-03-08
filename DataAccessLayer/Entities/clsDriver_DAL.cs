using Common;
using Common.Filters;
using Common.Helpers;
using Common.Queries;
using DVLD_DAL.Mappers;
using DVLD_DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public class clsDriver_DAL
    {
        private static clsDriver_DTO _Reader(SqlDataReader Reader)
        {
            return new clsDriver_DTO
            {
                // الخصائص الموروثة من clsPerson_DTO
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

                // الخصائص الخاصة بـ clsDriver_DTO
                DriverID = clsDbHelper.GetValue<int>(Reader, "DriverID"),
                CreatedByUserID = clsDbHelper.GetValue<int>(Reader, "CreatedByUserID"),
                CreatedDate = clsDbHelper.GetValue<DateTime>(Reader, "CreatedDate")
            };
        }
        public static int LoadCount(clsDriverQuery clsQuery)
        {
            string Query = "Select Count (*) From Drivers Where 1 = 1 ";
            Query += clsQuery.SearchBy.HasValue && clsQuery.SearchValue != null
               ? $" AND {clsDriverMapper.MapSearchBy(clsQuery.SearchBy.Value)} = @SearchValue"
               : "";

            _ApplyDriverFilter(clsQuery.Filter, ref Query);

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

        public static clsDriver_DTO LoadDriverByID(int DriverID)
        {

            string Query = @"
                            SELECT 
                                P.PersonID, P.NationalNo, P.FirstName, P.SecondName, P.ThirdName, 
                                P.LastName, P.DateOfBirth, P.Gendor, P.Address, P.Phone, P.Email, 
                                P.NationalityCountryID, P.ImagePath,
                                D.DriverID, D.CreatedByUserID, D.CreatedDate 
                            FROM People P
                            INNER JOIN Drivers D ON P.PersonID = D.PersonID
                            WHERE D.DriverID = @DriverID;";

            clsDriver_DTO Model = null;


            bool IsFound = clsDbHelper.ExecuteReader(Query, Command => clsDbHelper.SetValue<int>(Command, "@DriverID", DriverID),
                Reader =>
                {
                    Model = _Reader(Reader);
                });

            return IsFound ? Model : null;
        }


        public static clsDriver_DTO LoadDriverByPersonID(int PersonID)
        {
            clsDriver_DTO Model = null;
            string Query = "SELECT * FROM Drivers WHERE PersonID = @PersonID";

            bool IsFound = clsDbHelper.ExecuteReader(Query, Command => clsDbHelper.SetValue<int>(Command, "@PersonID", PersonID),
                Reader =>
                {
                    Model = new clsDriver_DTO
                    {
                        DriverID = clsDbHelper.GetValue<int>(Reader, "DriverID"),
                        PersonID = PersonID,
                        CreatedByUserID = clsDbHelper.GetValue<int>(Reader, "CreatedByUserID"),
                        CreatedDate = clsDbHelper.GetValue<DateTime>(Reader, "CreatedDate")
                    };
                });
            return IsFound ? Model : null;
        }
        public static int LoadPersonIDByDriverID(int DriverID)
        {
            string Query = "Select PersonID From Drivers Where DriverID = @DriverID;";
            return clsDbHelper.ExecuteScalar<int>(Query, Command => clsDbHelper.SetValue<int>(Command, "@DriverID", DriverID));
        }

        public static int AddNewDriver(clsDriver_DTO Model)
        {
            string Query = @"INSERT INTO Drivers (PersonID, CreatedByUserID, CreatedDate)
                         Select @PersonID, @CreatedByUserID, @CreatedDate
                         Where Not Exists (Select 1 From Drivers PersonID = @PersonID)
                         And Exists (Select 1 From People PersonID = @PersonID);
                         IF @@ROWCOUNT > 0
                                SELECT SCOPE_IDENTITY();
                            ELSE
                                SELECT -1;";

            return clsDbHelper.ExecuteScalar<int>(Query, Command =>
            {
                clsDbHelper.SetValue<int>(Command, "@PersonID", Model.PersonID);
                clsDbHelper.SetValue<int>(Command, "@CreatedByUserID", Model.CreatedByUserID);
                clsDbHelper.SetValue<DateTime>(Command, "@CreatedDate", Model.CreatedDate);
            });
        }


        public static bool UpdateDriver(clsDriver_DTO Model)
        {
            string Query = @"UPDATE Drivers SET
                         PersonID = @PersonID
                         WHERE DriverID = @DriverID";

            int RowsAffected = clsDbHelper.ExecuteNonQuery(Query, Command =>
            {
                clsDbHelper.SetValue<int>(Command, "@DriverID", Model.DriverID); // شرط التحديث
                clsDbHelper.SetValue<int>(Command, "@PersonID", Model.PersonID);
                clsDbHelper.SetValue<int>(Command, "@CreatedByUserID", Model.CreatedByUserID);
                clsDbHelper.SetValue<DateTime>(Command, "@CreatedDate", Model.CreatedDate);
            });
            return RowsAffected > 0;
        }

        public static bool DeleteDriverByID(int DriverID)
        {
            string QueryDriversTable = @"Delete From Drivers Where DriverID = @DriverID;";

            int DeletedDriverCount = clsDbHelper.ExecuteNonQuery(QueryDriversTable, Command => clsDbHelper.SetValue<int>(Command, "@DriverID", DriverID));
            return (DeletedDriverCount > 0);
        }
        public static bool DeleteDriverByPersonID(int PersonID)
        {
            string QueryDriversTable = @"Delete From Drivers Where PersonID = @PersonID;";

            int DeletedDriverCount = clsDbHelper.ExecuteNonQuery(QueryDriversTable, Command => clsDbHelper.SetValue<int>(Command, "@PersonID", PersonID));
            return (DeletedDriverCount > 0);
        }
        public static bool DeleteByUserID(int CreatedByUserID)
        {
            int RowsAffected = 0;
            string QueryLicensesTable = @"Delete From Drivers Where CreatedByUserID = @CreatedByUserID;";

            RowsAffected = clsDbHelper.ExecuteNonQuery(QueryLicensesTable, Command =>
            {
                clsDbHelper.SetValue<int>(Command, "@CreatedByUserID", CreatedByUserID);
            });

            return RowsAffected > 0;
        }




        public static bool IsPersonIsDriver(int PersonID)
        {
            string Query = "Select DriverID From Drivers Where PersonID = @PersonID;";
            return clsDbHelper.Exists(Query, Command => clsDbHelper.SetValue<int>(Command, "@PersonID", PersonID));
        }

        public static int LoadLocalApplicationIDByDriverID(int DriverID, int LicenseClassID)
        {
            string Query = @"Select Top 1  A.ApplicationID From Tests T 
                        Join TestAppointments TA ON T.TestAppointmentID = TA.TestAppointmentID
                        Join LocalDrivingLicenseApplications LDLA ON LDLA.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID
                        Join Applications A ON A.ApplicationID = LDLA.ApplicationID
                        Join Drivers D ON D.PersonID = A.ApplicantPersonID
                        Where D.DriverID = @DriverID And TA.TestTypeID = @TestTypeID And A.ApplicationTypeID = @ApplicationTypeID And LDLA.LicenseClassID = @LicenseClassID And A.ApplicationStatus = @ApplicationStatus;";
            return clsDbHelper.ExecuteScalar<int>(Query, (Action<SqlCommand>)(Command =>
            {
                clsDbHelper.SetValue(Command, "@DriverID", DriverID);
                clsDbHelper.SetValue(Command, "@TestTypeID", clsTestEnumConverter.ConvertTestTypeToInt(clsTestEnums.enTestTypes.PracticalTest));
                clsDbHelper.SetValue(Command, "@ApplicationTypeID", clsApplicationEnumConverter.ToInt(clsApplicationEnums.enApplicationType.NewLocalDrivingLicense));
                clsDbHelper.SetValue(Command, "@LicenseClassID", LicenseClassID);
                clsDbHelper.SetValue(Command, "@ApplicationStatus", clsApplicationEnumConverter.ToByte(clsApplicationEnums.enApplicationStatus.Completed));
            }));
        }

        public static int LoadInternationalApplicationIDByDriverID(int DriverID, int LicenseClassID)
        {
            string Query = @"Select Top 1  A.ApplicationID From InternationalLicenses IL
                        Join Applications A ON A.ApplicationID = IL.ApplicationID
                        Join Drivers D ON D.PersonID = A.ApplicantPersonID
                        Join Licenses L ON L.LicenseID = IL.IssuedUsingLocalLicenseID
                        Where D.DriverID = @DriverID And A.ApplicationTypeID = @ApplicationTypeID
                        And A.ApplicationStatus = @ApplicationStatus And L.LicenseClassID = @LicenseClassID;";
            return clsDbHelper.ExecuteScalar<int>(Query, (Action<SqlCommand>)(Command =>
            {
                clsDbHelper.SetValue(Command, "@DriverID", DriverID);
                clsDbHelper.SetValue(Command, "@ApplicationTypeID", clsApplicationEnumConverter.ToInt(clsApplicationEnums.enApplicationType.NewInternationalLicense));
                clsDbHelper.SetValue(Command, "@LicenseClassID", LicenseClassID);
                clsDbHelper.SetValue(Command, "@ApplicationStatus", clsApplicationEnumConverter.ToByte(clsApplicationEnums.enApplicationStatus.Completed));
            }));
        }
        public static List<clsDriver_DTO> LoadDrivers()
        {
            string Query = @"SELECT 
                                P.*,
                                D.DriverID, D.CreatedByUserID, D.CreatedDate 
                            FROM People P
                            INNER JOIN Drivers D ON P.PersonID = D.PersonID;";
            return clsDbHelper.ReadList(Query, null,
                Reader => _Reader(Reader));
        }
        public static List<clsDriver_DTO> LoadDrivers(int Offset, int CountRows)
        {
            string Query = $@"SELECT 
                                P.*,
                                D.DriverID, D.CreatedByUserID, D.CreatedDate 
                            FROM People P
                            INNER JOIN Drivers D ON P.PersonID = D.PersonID
                      ORDER BY D.DriverID
                      OFFSET @Offset ROWS FETCH NEXT @CountRows ROWS ONLY;";

            return clsDbHelper.ReadList(Query,
                Command => {
                    clsDbHelper.SetValue(Command, "@Offset", Offset);
                    clsDbHelper.SetValue(Command, "@CountRows", CountRows);
                },
                Reader => _Reader(Reader));
        }
        public static List<clsDriver_DTO> LoadDrivers(int Offset, int CountRows, clsDriverQuery clsQuery)
        {
            string Query = @"SELECT 
            P.*,
            D.DriverID, D.CreatedByUserID, D.CreatedDate
        FROM People P
        INNER JOIN Drivers D ON P.PersonID = D.PersonID
        WHERE 1 = 1 ";

            Query += clsQuery.SearchBy.HasValue && clsQuery.SearchValue != null
                ? $" AND {clsDriverMapper.MapSearchBy(clsQuery.SearchBy.Value)} = @SearchValue"
                : "";

            _ApplyDriverFilter(clsQuery.Filter, ref Query);

            Query += $@" ORDER BY {clsDriverMapper.MapOrderBy(clsQuery.OrderBy)}
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

        private static void _ApplyDriverFilter(clsDriverFilter filter,ref string query)
        {
            if (filter == null)
                return;

            clsPerson_DAL.ApplyPersonFilter(filter, ref query);
        }

    }
}
