using Common;
using Common.Filters;
using Common.Helpers;
using Common.Queries;
using DVLD_DAL.Mappers;
using DVLD_DTO;
using DVLD_Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public class clsTestAppointment_DAL
    {
        private static clsTestAppointment_DTO _Reader(SqlDataReader Reader)
        {
            return new clsTestAppointment_DTO
            {
                TestAppointmentID = DbHelper.GetValue<int>(Reader, "TestAppointmentID"),
                TestType = clsTestEnumConverter.ConvertTestTypeToEnum(DbHelper.GetValue<int>(Reader, "TestTypeID")),
                LocalDrivingLicenseApplicationID = DbHelper.GetValue<int>(Reader, "LocalDrivingLicenseApplicationID"),
                AppointmentDate = DbHelper.GetValue<DateTime>(Reader, "AppointmentDate"),
                PaidFees = DbHelper.GetValue<decimal>(Reader, "PaidFees"),
                CreatedByUserID = DbHelper.GetValue<int>(Reader, "CreatedByUserID"),
                IsLocked = DbHelper.GetValue<bool>(Reader, "IsLocked"),
                RetakeTestApplicationID = DbHelper.GetValue<int>(Reader, "RetakeTestApplicationID")
            };
        }
        public static int LoadCount(clsTestAppointmentQuery clsQuery)
        {
            string Query = "Select Count (*) From TestAppointments Where 1 = 1 ";

            Query += clsQuery.SearchBy.HasValue && clsQuery.SearchValue != null
                ? $" AND {clsTestAppointmentMapper.MapSearchBy(clsQuery.SearchBy.Value)} = @SearchValue"
                : "";

            _ApplyTestAppointmentFilter(clsQuery.Filter, ref Query);

            return DbHelper.ExecuteScalar<int>(Query,
                Command =>
                {
                    DbHelper.SetValue(Command, "@SearchValue", clsQuery.SearchValue,
                        IsHasValue: clsQuery.SearchValue != null);

                    DbHelper.SetValue(Command, "@TestTypeID",
                        clsQuery.Filter.TestTypeID,
                        clsQuery.Filter.TestTypeID.HasValue);

                    DbHelper.SetValue(Command, "@IsLocked",
                        clsQuery.Filter.IsLocked,
                        clsQuery.Filter.IsLocked.HasValue);

                    DbHelper.SetValue(Command, "@TestResult",
                        clsQuery.Filter.TestResult,
                        clsQuery.Filter.TestResult.HasValue);

                    DbHelper.SetValue(Command, "@FromAppointmentDate",
                        clsQuery.Filter.FromAppointmentDate,
                        clsQuery.Filter.FromAppointmentDate.HasValue);

                    DbHelper.SetValue(Command, "@ToAppointmentDate",
                        clsQuery.Filter.ToAppointmentDate,
                        clsQuery.Filter.ToAppointmentDate.HasValue);

                });
        }
        public static clsTestAppointment_DTO LoadTestAppointmentByID(int TestAppointmentID)
        {
            clsTestAppointment_DTO Model = null;
            string Query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";

            DbHelper.ExecuteReader(Query, Command => DbHelper.SetValue(Command, "@TestAppointmentID", TestAppointmentID),
                Reader =>
                {
                    Model = _Reader(Reader);
                });
            return Model;
        }

        // إضافة موعد اختبار جديد
        public static int AddNewTestAppointment(clsTestAppointment_DTO DTO)
        {
            string Query = @"INSERT INTO TestAppointments (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID)
                            SELECT @TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, 0, @RetakeTestApplicationID
                            WHERE NOT EXISTS (
                                SELECT 1 FROM TestAppointments 
                                WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                                AND TestTypeID = @TestTypeID 
                                AND IsLocked = 0 
                             );
                            IF @@ROWCOUNT > 0
                                SELECT SCOPE_IDENTITY();
                            ELSE
                                SELECT -1;";

            return DbHelper.ExecuteScalar<int>(Query, Command =>
            {
                DbHelper.SetValue(Command, "@TestTypeID", clsTestEnumConverter.ConvertTestTypeToInt(DTO.TestType));
                DbHelper.SetValue(Command, "@LocalDrivingLicenseApplicationID", DTO.LocalDrivingLicenseApplicationID);
                DbHelper.SetValue(Command, "@AppointmentDate", DTO.AppointmentDate);
                DbHelper.SetValue(Command, "@PaidFees", DTO.PaidFees);
                DbHelper.SetValue(Command, "@CreatedByUserID", DTO.CreatedByUserID);
                DbHelper.SetValue(Command, "@IsLocked", DTO.IsLocked);
                DbHelper.SetValue(Command, "@RetakeTestApplicationID", DTO.RetakeTestApplicationID, true);
            });
        }

        // تحديث موعد اختبار
        public static bool UpdateTestAppointment(clsTestAppointment_DTO Model)
        {
            string Query = @"UPDATE TestAppointments SET
                         AppointmentDate = @AppointmentDate,
                         IsLocked = @IsLocked
                         WHERE TestAppointmentID = @TestAppointmentID
                         And IsLocked = 0";

            int RowsAffected = DbHelper.ExecuteNonQuery(Query, Command =>
            {
                DbHelper.SetValue(Command, "@TestAppointmentID", Model.TestAppointmentID); // شرط التحديث

                DbHelper.SetValue(Command, "@AppointmentDate", Model.AppointmentDate);

                DbHelper.SetValue(Command, "@IsLocked", Model.IsLocked);
            });
            return RowsAffected > 0;
        }
        public static bool LockedTestAppointment(int TestAppointmentID)
        {
            string Query = @"UPDATE TestAppointments
                            SET IsLocked = 1
                            WHERE TestAppointmentID = @TestAppointmentID;";

            return DbHelper.ExecuteNonQuery(Query, Command => { DbHelper.SetValue(Command, "@TestAppointmentID", TestAppointmentID); }) > 0;
        }
        // حذف موعد اختبار
        public static bool DeleteTestAppointmentByID(int TestAppointmentID)
        {
            string Query = "DELETE FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";
            int RowsAffected = DbHelper.ExecuteNonQuery(Query, Command => DbHelper.SetValue(Command, "@TestAppointmentID", TestAppointmentID));
            return RowsAffected > 0;
        }

        public static bool DeleteTestAppointmentByTestType(int TestTypeID)
        {
            string Query = "DELETE FROM TestAppointments WHERE TestTypeID = @TestTypeID";
            int RowsAffected = DbHelper.ExecuteNonQuery(Query, Command => DbHelper.SetValue(Command, "@TestTypeID", TestTypeID));
            return RowsAffected > 0;
        }

        public static bool DeleteByUserID(int CreatedByUserID)
        {
            int RowsAffected = 0;
            string QueryLicensesTable = @"Delete From TestAppointments Where CreatedByUserID = @CreatedByUserID;";

            RowsAffected = DbHelper.ExecuteNonQuery(QueryLicensesTable, Command =>
            {
                DbHelper.SetValue<int>(Command, "@CreatedByUserID", CreatedByUserID);
            });

            return RowsAffected > 0;
        }

        public static int LoadLastTestTypePassed(int LocalDrivingLicenseApplicationID)
        {
            string Query = @"Select ISNULL(MAX(TA.TestTypeID), 0) 
                            From TestAppointments TA
                            Join Tests T ON TA.TestAppointmentID = T.TestAppointmentID
                            Where T.TestResult = 1 
                            And TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";
            return DbHelper.ExecuteScalar<int>(Query, Common => DbHelper.SetValue(Common, "@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID));
        }


        //public static bool LoadResultLastTestAndTestType() 

        public static bool IsTestedBeforInthisType(int LocalDrivingLicenseApplicationID, clsTestEnums.enTestTypes Type)
        {
            string Query = @"Select TestAppointmentID From TestAppointments Where
                            LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                            And TestTypeID = @TestTypeID And IsLocked = 1;";

            return DbHelper.Exists(Query, Command =>
            {
                DbHelper.SetValue(Command, "@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                DbHelper.SetValue(Command, "@TestTypeID", clsTestEnumConverter.ConvertTestTypeToInt(Type));

            });
        }

        public static bool IsTestedBefor(int LocalDrivingLicenseApplicationID)
        {
            string Query = @"Select TestAppointmentID From TestAppointments Where
                            LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID ;";

            return DbHelper.Exists(Query, Command =>
            {
                DbHelper.SetValue(Command, "@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            });
        }
        public static bool IsLocked(int TestAppointmentID)
        {
            string Query = "Select IsLocked From TestAppointments Where TestAppointmentID = @TestAppointmentID;";

            return DbHelper.ExecuteScalar<bool>(Query, Command => DbHelper.SetValue(Command, "@TestAppointmentID", TestAppointmentID));
        }
        public static bool IsLockedForLastTest(int LocalDrivingLicenseApplicationID)
        {
            string Query = @"Select IsLocked From TestAppointments Where
                            AppointmentDate IN 
                            (Select Max (AppointmentDate) From TestAppointments Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)
                            ;";

            return DbHelper.ExecuteScalar<bool>(Query, Command => DbHelper.SetValue(Command, "@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID));
        }
        public static bool IsPassedInLastTest(int LocalDrivingLicenseApplicationID)
        {
            string Query = @"Select T.TestResult From TestAppointments TA
                            Join Tests T ON TA.TestAppointmentID = T.TestAppointmentID
                            Where AppointmentDate IN 
                            (Select Max (AppointmentDate) From TestAppointments Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID);
                            ";
            return DbHelper.ExecuteScalar<bool>(Query, Command => DbHelper.SetValue(Command, "@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID));


        }

        public static int LoadLastTestType(int LocalDrivingLicenseApplicationID)
        {
            string Query = @"Select TestTypeID From TestAppointments Where
                            AppointmentDate IN 
                            (Select Max (AppointmentDate) From TestAppointments Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)
                            ;";
            return DbHelper.ExecuteScalar<int>(Query, Command => DbHelper.SetValue(Command, "@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID));
        }

        public static List<clsTestAppointment_DTO> LoadTestAppointments()
        {
            string Query = "Select * From TestAppointments;";
            return DbHelper.ReadList(Query, null,
                Reader => _Reader(Reader) );

        }

        public static List<clsTestAppointment_DTO> LoadTestAppointments(int Offset, int CountRows)
        {
            string Query = $@"SELECT * FROM TestAppointments 
                      ORDER BY TestAppointmentID 
                      OFFSET @Offset ROWS FETCH NEXT @CountRows ROWS ONLY;";

            return DbHelper.ReadList(Query,
                Command => {
                    DbHelper.SetValue(Command, "@Offset", Offset);
                    DbHelper.SetValue(Command, "@CountRows", CountRows);
                },
                Reader => _Reader(Reader));
        }

        public static List<clsTestAppointment_DTO> LoadTestAppointments(int Offset, int CountRows , clsTestAppointmentQuery clsQuery)
        {
            string Query = "SELECT * FROM TestAppointments Where 1 = 1 ";

            Query += clsQuery.SearchBy.HasValue && clsQuery.SearchValue != null
                ? $" AND {clsTestAppointmentMapper.MapSearchBy(clsQuery.SearchBy.Value)} = @SearchValue"
                : "";

            _ApplyTestAppointmentFilter(clsQuery.Filter, ref Query);

            Query += $@" ORDER BY {clsTestAppointmentMapper.MapOrderBy(clsQuery.OrderBy)}
                 {clsOrderDirectionMapper.MapOrderDirection(clsQuery.OrderDirection)}
                 OFFSET @Offset ROWS FETCH NEXT @CountRows ROWS ONLY;";

            return DbHelper.ReadList(Query,
                Command =>
                {
                    DbHelper.SetValue(Command, "@SearchValue", clsQuery.SearchValue,
                        IsHasValue: clsQuery.SearchValue != null);

                    DbHelper.SetValue(Command, "@TestTypeID",
                        clsQuery.Filter.TestTypeID,
                        clsQuery.Filter.TestTypeID.HasValue);

                    DbHelper.SetValue(Command, "@IsLocked",
                        clsQuery.Filter.IsLocked,
                        clsQuery.Filter.IsLocked.HasValue);

                    DbHelper.SetValue(Command, "@TestResult",
                        clsQuery.Filter.TestResult,
                        clsQuery.Filter.TestResult.HasValue);

                    DbHelper.SetValue(Command, "@FromAppointmentDate",
                        clsQuery.Filter.FromAppointmentDate,
                        clsQuery.Filter.FromAppointmentDate.HasValue);

                    DbHelper.SetValue(Command, "@ToAppointmentDate",
                        clsQuery.Filter.ToAppointmentDate,
                        clsQuery.Filter.ToAppointmentDate.HasValue);

                    DbHelper.SetValue(Command, "@Offset", Offset);
                    DbHelper.SetValue(Command, "@CountRows", CountRows);
                },
                Reader => _Reader(Reader));
        }

        public static int LoadPersonIDByTestAppointmentID(int TestAppointmentID)
        {
            string Query = @"Select A.ApplicantPersonID From Applications A
                            Join LocalDrivingLicenseApplications LDLA ON LDLA.ApplicationID = A.ApplicationID
                            Join TestAppointments TA ON TA.LocalDrivingLicenseApplicationID = LDLA.LocalDrivingLicenseApplicationID
                            Where TA.TestAppointmentID = @TestAppointmentID;";
            return DbHelper.ExecuteScalar<int>(Query, Command => DbHelper.SetValue(Command, "@TestAppointmentID", TestAppointmentID));
        }

        private static void _ApplyTestAppointmentFilter(clsTestAppointmentFilter filter,ref string query)
        {
            if (filter == null) return;

            MappingHelper.AddCondition(
                filter.TestTypeID.HasValue,
                "TestTypeID = @TestTypeID",
                ref query);

            MappingHelper.AddCondition(
                filter.IsLocked.HasValue,
                "IsLocked = @IsLocked",
                ref query);

            MappingHelper.AddCondition(
                filter.TestResult.HasValue,
                "TestResult = @TestResult",
                ref query);

            MappingHelper.ApplyDateRange(
                filter.FromAppointmentDate,
                filter.ToAppointmentDate,
                "AppointmentDate",
                ref query);
        }


    }
}
