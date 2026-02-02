using Common;
using Common.Helpers;
using DVLD_DTO;
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

        public static int LoadCount()
        {
            string Query = "Select Count (*) From Drivers;";
            return DbHelper.ExecuteScalar<int>(Query, null);
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


            bool IsFound = DbHelper.ExecuteReader(Query, Command => DbHelper.SetValue<int>(Command, "@DriverID", DriverID),
                Reader =>
                {
                    Model = new clsDriver_DTO
                    {
                        // الخصائص الموروثة من clsPerson_DTO
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

                        // الخصائص الخاصة بـ clsDriver_DTO
                        DriverID = DbHelper.GetValue<int>(Reader, "DriverID"),
                        CreatedByUserID = DbHelper.GetValue<int>(Reader, "CreatedByUserID"),
                        CreatedDate = DbHelper.GetValue<DateTime>(Reader, "CreatedDate")
                    };
                });

            return IsFound ? Model : null;
        }


        public static clsDriver_DTO LoadDriverByPersonID(int PersonID)
        {
            clsDriver_DTO Model = null;
            string Query = "SELECT * FROM Drivers WHERE PersonID = @PersonID";

            bool IsFound = DbHelper.ExecuteReader(Query, Command => DbHelper.SetValue<int>(Command, "@PersonID", PersonID),
                Reader =>
                {
                    Model = new clsDriver_DTO
                    {
                        DriverID = DbHelper.GetValue<int>(Reader, "DriverID"),
                        PersonID = PersonID,
                        CreatedByUserID = DbHelper.GetValue<int>(Reader, "CreatedByUserID"),
                        CreatedDate = DbHelper.GetValue<DateTime>(Reader, "CreatedDate")
                    };
                });
            return IsFound ? Model : null;
        }
        public static int LoadPersonIDByDriverID(int DriverID)
        {
            string Query = "Select PersonID From Drivers Where DriverID = @DriverID;";
            return DbHelper.ExecuteScalar<int>(Query, Command => DbHelper.SetValue<int>(Command, "@DriverID", DriverID));
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

            return DbHelper.ExecuteScalar<int>(Query, Command =>
            {
                DbHelper.SetValue<int>(Command, "@PersonID", Model.PersonID);
                DbHelper.SetValue<int>(Command, "@CreatedByUserID", Model.CreatedByUserID);
                DbHelper.SetValue<DateTime>(Command, "@CreatedDate", Model.CreatedDate);
            });
        }


        public static bool UpdateDriver(clsDriver_DTO Model)
        {
            string Query = @"UPDATE Drivers SET
                         PersonID = @PersonID
                         WHERE DriverID = @DriverID";

            int RowsAffected = DbHelper.ExecuteNonQuery(Query, Command =>
            {
                DbHelper.SetValue<int>(Command, "@DriverID", Model.DriverID); // شرط التحديث
                DbHelper.SetValue<int>(Command, "@PersonID", Model.PersonID);
                DbHelper.SetValue<int>(Command, "@CreatedByUserID", Model.CreatedByUserID);
                DbHelper.SetValue<DateTime>(Command, "@CreatedDate", Model.CreatedDate);
            });
            return RowsAffected > 0;
        }

        public static bool DeleteDriverByID(int DriverID)
        {
            string QueryDriversTable = @"Delete From Drivers Where DriverID = @DriverID;";

            int DeletedDriverCount = DbHelper.ExecuteNonQuery(QueryDriversTable, Command => DbHelper.SetValue<int>(Command, "@DriverID", DriverID));
            return (DeletedDriverCount > 0);
        }
        public static bool DeleteDriverByPersonID(int PersonID)
        {
            string QueryDriversTable = @"Delete From Drivers Where PersonID = @PersonID;";

            int DeletedDriverCount = DbHelper.ExecuteNonQuery(QueryDriversTable, Command => DbHelper.SetValue<int>(Command, "@PersonID", PersonID));
            return (DeletedDriverCount > 0);
        }
        public static bool DeleteByUserID(int CreatedByUserID)
        {
            int RowsAffected = 0;
            string QueryLicensesTable = @"Delete From Drivers Where CreatedByUserID = @CreatedByUserID;";

            RowsAffected = DbHelper.ExecuteNonQuery(QueryLicensesTable, Command =>
            {
                DbHelper.SetValue<int>(Command, "@CreatedByUserID", CreatedByUserID);
            });

            return RowsAffected > 0;
        }




        public static bool IsPersonIsDriver(int PersonID)
        {
            string Query = "Select DriverID From Drivers Where PersonID = @PersonID;";
            return DbHelper.Exists(Query, Command => DbHelper.SetValue<int>(Command, "@PersonID", PersonID));
        }

        public static int LoadLocalApplicationIDByDriverID(int DriverID, int LicenseClassID)
        {
            string Query = @"Select Top 1  A.ApplicationID From Tests T 
                        Join TestAppointments TA ON T.TestAppointmentID = TA.TestAppointmentID
                        Join LocalDrivingLicenseApplications LDLA ON LDLA.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID
                        Join Applications A ON A.ApplicationID = LDLA.ApplicationID
                        Join Drivers D ON D.PersonID = A.ApplicantPersonID
                        Where D.DriverID = @DriverID And TA.TestTypeID = @TestTypeID And A.ApplicationTypeID = @ApplicationTypeID And LDLA.LicenseClassID = @LicenseClassID And A.ApplicationStatus = @ApplicationStatus;";
            return DbHelper.ExecuteScalar<int>(Query, (Action<SqlCommand>)(Command =>
            {
                DbHelper.SetValue(Command, "@DriverID", DriverID);
                DbHelper.SetValue(Command, "@TestTypeID", clsTestEnumConverter.ConvertTestTypeToInt(clsTestEnums.enTestTypes.PracticalTest));
                DbHelper.SetValue(Command, "@ApplicationTypeID", clsApplicationEnumConverter.ToInt(clsApplicationEnums.enApplicationType.NewLocalDrivingLicense));
                DbHelper.SetValue(Command, "@LicenseClassID", LicenseClassID);
                DbHelper.SetValue(Command, "@ApplicationStatus", clsApplicationEnumConverter.ToByte(clsApplicationEnums.enApplicationStatus.Completed));
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
            return DbHelper.ExecuteScalar<int>(Query, (Action<SqlCommand>)(Command =>
            {
                DbHelper.SetValue(Command, "@DriverID", DriverID);
                DbHelper.SetValue(Command, "@ApplicationTypeID", clsApplicationEnumConverter.ToInt(clsApplicationEnums.enApplicationType.NewInternationalLicense));
                DbHelper.SetValue(Command, "@LicenseClassID", LicenseClassID);
                DbHelper.SetValue(Command, "@ApplicationStatus", clsApplicationEnumConverter.ToByte(clsApplicationEnums.enApplicationStatus.Completed));
            }));
        }
        public static List<clsDriver_DTO> LoadDrivers()
        {
            string Query = @"SELECT 
                                P.*,
                                D.DriverID, D.CreatedByUserID, D.CreatedDate 
                            FROM People P
                            INNER JOIN Drivers D ON P.PersonID = D.PersonID;";
            return DbHelper.ReadList(Query, null,
                Reader => new clsDriver_DTO
                {
                    // الخصائص الموروثة من clsPerson_DTO
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

                    // الخصائص الخاصة بـ clsDriver_DTO
                    DriverID = DbHelper.GetValue<int>(Reader, "DriverID"),
                    CreatedByUserID = DbHelper.GetValue<int>(Reader, "CreatedByUserID"),
                    CreatedDate = DbHelper.GetValue<DateTime>(Reader, "CreatedDate")
                });
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

            return DbHelper.ReadList(Query,
                Command => {
                    DbHelper.SetValue(Command, "@Offset", Offset);
                    DbHelper.SetValue(Command, "@CountRows", CountRows);
                },
                Reader => new clsDriver_DTO
                {
                    // الخصائص الموروثة من clsPerson_DTO
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

                    // الخصائص الخاصة بـ clsDriver_DTO
                    DriverID = DbHelper.GetValue<int>(Reader, "DriverID"),
                    CreatedByUserID = DbHelper.GetValue<int>(Reader, "CreatedByUserID"),
                    CreatedDate = DbHelper.GetValue<DateTime>(Reader, "CreatedDate")
                });
        }

    }
}
