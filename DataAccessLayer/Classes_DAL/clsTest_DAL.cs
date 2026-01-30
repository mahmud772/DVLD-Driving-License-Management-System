using Common;
using DVLD_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public class clsTest_DAL
    {

        public static int LoadCount()
        {
            string Query = "Select Count (*) From Tests;";
            return DbHelper.ExecuteScalar<int>(Query, null);
        }

        public static clsTest_DTO LoadTestByID(int TestID)
        {
            clsTest_DTO Model = null;
            string Query = "SELECT * FROM Tests WHERE TestID = @TestID";

            DbHelper.ExecuteReader(Query, Command => DbHelper.SetValue(Command, "@TestID", TestID),
                Reader =>
                {
                    Model = new clsTest_DTO
                    {
                        TestID = TestID,
                        TestAppointmentID = DbHelper.GetValue<int>(Reader, "TestAppointmentID"),
                        TestResult = DbHelper.GetValue<bool>(Reader, "TestResult"),
                        Notes = DbHelper.GetValue<string>(Reader, "Notes"),
                        CreatedByUserID = DbHelper.GetValue<int>(Reader, "CreatedByUserID")
                    };
                });
            return Model;
        }

        // إضافة اختبار جديد
        public static int AddNewTest(clsTest_DTO Model)
        {
            string Query = @"INSERT INTO Tests (TestAppointmentID, TestResult, Notes, CreatedByUserID)
                         VALUES (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);
                         SELECT SCOPE_IDENTITY();";

            return DbHelper.ExecuteScalar<int>(Query, Command =>
            {
                DbHelper.SetValue(Command, "@TestAppointmentID", Model.TestAppointmentID);
                DbHelper.SetValue(Command, "@TestResult", Model.TestResult);
                DbHelper.SetValue(Command, "@Notes", Model.Notes, ValidNull: true);
                DbHelper.SetValue(Command, "@CreatedByUserID", Model.CreatedByUserID);
            });
        }

        // تحديث اختبار
        public static bool UpdateTest(clsTest_DTO Model)
        {
            string Query = @"UPDATE Tests SET
                         Notes = @Notes
                         WHERE TestID = @TestID";

            int RowsAffected = DbHelper.ExecuteNonQuery(Query, Command =>
            {
                DbHelper.SetValue(Command, "@TestID", Model.TestID); // شرط التحديث
                DbHelper.SetValue(Command, "@Notes", Model.Notes, ValidNull: true);
            });
            return RowsAffected > 0;
        }

        // حذف اختبار
        public static bool DeleteTest(int TestID)
        {
            string Query = "DELETE FROM Tests WHERE TestID = @TestID";
            int RowsAffected = DbHelper.ExecuteNonQuery(Query, Command => DbHelper.SetValue(Command, "@TestID", TestID));
            return RowsAffected > 0;
        }

        public static bool DeleteByUserID(int CreatedByUserID)
        {
            int RowsAffected = 0;
            string QueryLicensesTable = @"Delete From Tests Where CreatedByUserID = @CreatedByUserID;";

            RowsAffected = DbHelper.ExecuteNonQuery(QueryLicensesTable, Command =>
            {
                DbHelper.SetValue<int>(Command, "@CreatedByUserID", CreatedByUserID);
            });

            return RowsAffected > 0;
        }

        public static bool TestResultByTestAppointmentID(int TestAppointmentID)
        {
            string Query = "Select TestResult From Tests Where TestAppointmentID = @TestAppointmentID;";

            return DbHelper.ExecuteScalar<bool>(Query, Command => DbHelper.SetValue(Command, "@TestAppointmentID", TestAppointmentID));
        }

        public static bool IsPersonPassedInAllTests(int PersonID, clsApplicationEnums.enApplicationType ApplicationType)
        {
            string Query = @"Select T.TestResult From Tests T 
                            Join TestAppointments TA ON T.TestAppointmentID = TA.TestAppointmentID
                            Join LocalDrivingLicenseApplications LDLA ON LDLA.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID
                            Join Applications A ON A.ApplicationID = LDLA.ApplicationID
                            Where A.ApplicantPersonID = @ApplicantPersonID
                            And TA.TestTypeID = @TestTypeID
                            And A.ApplicationTypeID = @ApplicationTypeID;";
            return DbHelper.Exists(Query, Command =>
            {
                DbHelper.SetValue(Command, "@ApplicantPersonID", PersonID);
                DbHelper.SetValue(Command, "@TestTypeID", clsTestEnums.ConvertTestTypeToInt(clsTestEnums.enTestTypes.PracticalTest));
                DbHelper.SetValue(Command, "@ApplicationTypeID", clsApplicationEnums.ConvertApplicationTypeToInt(ApplicationType));
            });
        }

        public static List<clsTest_DTO> LoadTests()
        {
            string Query = "Select * From Tests;";
            return DbHelper.ReadList(Query, null,
                Reader => new clsTest_DTO
                {
                    TestID = DbHelper.GetValue<int>(Reader, "TestID"),
                    TestAppointmentID = DbHelper.GetValue<int>(Reader, "TestAppointmentID"),
                    TestResult = DbHelper.GetValue<bool>(Reader, "TestResult"),
                    Notes = DbHelper.GetValue<string>(Reader, "Notes"),
                    CreatedByUserID = DbHelper.GetValue<int>(Reader, "CreatedByUserID")
                });
        }

        public static List<clsTest_DTO> LoadTests(int Offset, int CountRows)
        {
            string Query = $@"SELECT * FROM Tests 
                      ORDER BY TestID
                      OFFSET @Offset ROWS FETCH NEXT @CountRows ROWS ONLY;";

            return DbHelper.ReadList(Query,
                Command => {
                    DbHelper.SetValue(Command, "@Offset", Offset);
                    DbHelper.SetValue(Command, "@CountRows", CountRows);
                },
                Reader => new clsTest_DTO
                {
                    TestID = DbHelper.GetValue<int>(Reader, "TestID"),
                    TestAppointmentID = DbHelper.GetValue<int>(Reader, "TestAppointmentID"),
                    TestResult = DbHelper.GetValue<bool>(Reader, "TestResult"),
                    Notes = DbHelper.GetValue<string>(Reader, "Notes"),
                    CreatedByUserID = DbHelper.GetValue<int>(Reader, "CreatedByUserID")
                });
        }

        public static bool IsDriverPassedInAllTests(int DriverID, int LicenseClassID)
        {
            string Query = @"IF EXISTS (
                            SELECT 1
                            FROM TestAppointments TA
                            JOIN LocalDrivingLicenseApplications LDLA 
                                ON TA.LocalDrivingLicenseApplicationID = LDLA.LocalDrivingLicenseApplicationID
                            JOIN Applications A 
                                ON A.ApplicationID = LDLA.ApplicationID
                            JOIN Tests T 
                                ON T.TestAppointmentID = TA.TestAppointmentID
                            JOIN Drivers D 
                                ON D.PersonID = A.ApplicantPersonID
                            WHERE D.DriverID = @DriverID
                              AND LDLA.LicenseClassID = @LicenseClassID
                              AND TA.TestTypeID = @FinalTestTypeID  
                              AND T.TestResult = 1                  
                        )
                            SELECT 1;
                        ELSE
                            SELECT 0;
                        ";
            return DbHelper.Exists(Query, Command =>
            {
                DbHelper.SetValue<int>(Command, "@DriverID", DriverID);
                DbHelper.SetValue<int>(Command, "@LicenseClassID", LicenseClassID);
                DbHelper.SetValue<int>(Command, "@FinalTestTypeID", clsTestEnums.ConvertTestTypeToInt(clsTestEnums.enTestTypes.PracticalTest));
            }
            );
        }
    }
}
