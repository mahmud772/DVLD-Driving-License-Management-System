using Common;
using Common.Filters;
using Common.Helpers;
using Common.Queries;
using DVLD_DAL.Mappers;
using DVLD_DTOs;
using DVLD_DTOs;
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
                TestAppointmentID = clsDbHelper.GetValue<int>(Reader, "TestAppointmentID"),
                TestType = clsTestEnumConverter.ConvertTestTypeToEnum(clsDbHelper.GetValue<int>(Reader, "TestTypeID")),
                LocalDrivingLicenseApplicationID = clsDbHelper.GetValue<int>(Reader, "LocalDrivingLicenseApplicationID"),
                AppointmentDate = clsDbHelper.GetValue<DateTime>(Reader, "AppointmentDate"),
                PaidFees = clsDbHelper.GetValue<decimal>(Reader, "PaidFees"),
                CreatedByUserID = clsDbHelper.GetValue<int>(Reader, "CreatedByUserID"),
                IsLocked = clsDbHelper.GetValue<bool>(Reader, "IsLocked"),
                RetakeTestApplicationID = clsDbHelper.GetValue<int>(Reader, "RetakeTestApplicationID")
            };
        }
        public static int LoadCount(clsTestAppointmentQuery clsQuery)
        {
            string Query = "Select Count (*) From TestAppointments Where 1 = 1 ";

            Query += clsQuery.SearchBy.HasValue && clsQuery.SearchValue != null
                ? $" AND {clsTestAppointmentMapper.MapSearchBy(clsQuery.SearchBy.Value)} = @SearchValue"
                : "";

            _ApplyTestAppointmentFilter(clsQuery.Filter, ref Query);

            return clsDbHelper.ExecuteScalar<int>(Query,
                Command =>
                {
                    clsDbHelper.SetValue(Command, "@SearchValue", clsQuery.SearchValue,
                        IsHasValue: clsQuery.SearchValue != null);

                    clsDbHelper.SetValue(Command, "@TestTypeID",
                        clsQuery.Filter.TestTypeID,
                        clsQuery.Filter.TestTypeID.HasValue);

                    clsDbHelper.SetValue(Command, "@IsLocked",
                        clsQuery.Filter.IsLocked,
                        clsQuery.Filter.IsLocked.HasValue);

                    clsDbHelper.SetValue(Command, "@TestResult",
                        clsQuery.Filter.TestResult,
                        clsQuery.Filter.TestResult.HasValue);

                    clsDbHelper.SetValue(Command, "@FromAppointmentDate",
                        clsQuery.Filter.FromAppointmentDate,
                        clsQuery.Filter.FromAppointmentDate.HasValue);

                    clsDbHelper.SetValue(Command, "@ToAppointmentDate",
                        clsQuery.Filter.ToAppointmentDate,
                        clsQuery.Filter.ToAppointmentDate.HasValue);

                });
        }
        public static clsTestAppointment_DTO LoadTestAppointmentByID(int TestAppointmentID)
        {
            clsTestAppointment_DTO Model = null;
            string Query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";

            clsDbHelper.ExecuteReader(Query, Command => clsDbHelper.SetValue(Command, "@TestAppointmentID", TestAppointmentID),
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

            return clsDbHelper.ExecuteScalar<int>(Query, Command =>
            {
                clsDbHelper.SetValue(Command, "@TestTypeID", clsTestEnumConverter.ConvertTestTypeToInt(DTO.TestType));
                clsDbHelper.SetValue(Command, "@LocalDrivingLicenseApplicationID", DTO.LocalDrivingLicenseApplicationID);
                clsDbHelper.SetValue(Command, "@AppointmentDate", DTO.AppointmentDate);
                clsDbHelper.SetValue(Command, "@PaidFees", DTO.PaidFees);
                clsDbHelper.SetValue(Command, "@CreatedByUserID", DTO.CreatedByUserID);
                clsDbHelper.SetValue(Command, "@IsLocked", DTO.IsLocked);
                clsDbHelper.SetValue(Command, "@RetakeTestApplicationID", DTO.RetakeTestApplicationID, true);
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

            int RowsAffected = clsDbHelper.ExecuteNonQuery(Query, Command =>
            {
                clsDbHelper.SetValue(Command, "@TestAppointmentID", Model.TestAppointmentID); // شرط التحديث

                clsDbHelper.SetValue(Command, "@AppointmentDate", Model.AppointmentDate);

                clsDbHelper.SetValue(Command, "@IsLocked", Model.IsLocked);
            });
            return RowsAffected > 0;
        }
        public static bool LockedTestAppointment(int TestAppointmentID)
        {
            string Query = @"UPDATE TestAppointments
                            SET IsLocked = 1
                            WHERE TestAppointmentID = @TestAppointmentID;";

            return clsDbHelper.ExecuteNonQuery(Query, Command => { clsDbHelper.SetValue(Command, "@TestAppointmentID", TestAppointmentID); }) > 0;
        }
        // حذف موعد اختبار
        public static bool DeleteTestAppointmentByID(int TestAppointmentID)
        {
            string Query = "DELETE FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";
            int RowsAffected = clsDbHelper.ExecuteNonQuery(Query, Command => clsDbHelper.SetValue(Command, "@TestAppointmentID", TestAppointmentID));
            return RowsAffected > 0;
        }

        public static bool DeleteTestAppointmentByTestType(int TestTypeID)
        {
            string Query = "DELETE FROM TestAppointments WHERE TestTypeID = @TestTypeID";
            int RowsAffected = clsDbHelper.ExecuteNonQuery(Query, Command => clsDbHelper.SetValue(Command, "@TestTypeID", TestTypeID));
            return RowsAffected > 0;
        }

        public static bool DeleteByUserID(int CreatedByUserID)
        {
            int RowsAffected = 0;
            string QueryLicensesTable = @"Delete From TestAppointments Where CreatedByUserID = @CreatedByUserID;";

            RowsAffected = clsDbHelper.ExecuteNonQuery(QueryLicensesTable, Command =>
            {
                clsDbHelper.SetValue<int>(Command, "@CreatedByUserID", CreatedByUserID);
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
            return clsDbHelper.ExecuteScalar<int>(Query, Common => clsDbHelper.SetValue(Common, "@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID));
        }


        //public static bool LoadResultLastTestAndTestType() 

        public static bool IsTestedBeforInthisType(int LocalDrivingLicenseApplicationID, clsTestEnums.enTestTypes Type)
        {
            string Query = @"Select TestAppointmentID From TestAppointments Where
                            LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                            And TestTypeID = @TestTypeID And IsLocked = 1;";

            return clsDbHelper.Exists(Query, Command =>
            {
                clsDbHelper.SetValue(Command, "@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                clsDbHelper.SetValue(Command, "@TestTypeID", clsTestEnumConverter.ConvertTestTypeToInt(Type));

            });
        }

        public static bool IsTestedBefor(int LocalDrivingLicenseApplicationID)
        {
            string Query = @"Select TestAppointmentID From TestAppointments Where
                            LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID ;";

            return clsDbHelper.Exists(Query, Command =>
            {
                clsDbHelper.SetValue(Command, "@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            });
        }
        public static bool IsLocked(int TestAppointmentID)
        {
            string Query = "Select IsLocked From TestAppointments Where TestAppointmentID = @TestAppointmentID;";

            return clsDbHelper.ExecuteScalar<bool>(Query, Command => clsDbHelper.SetValue(Command, "@TestAppointmentID", TestAppointmentID));
        }
        public static bool IsLockedForLastTest(int LocalDrivingLicenseApplicationID)
        {
            string Query = @"Select IsLocked From TestAppointments Where
                            AppointmentDate IN 
                            (Select Max (AppointmentDate) From TestAppointments Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)
                            ;";

            return clsDbHelper.ExecuteScalar<bool>(Query, Command => clsDbHelper.SetValue(Command, "@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID));
        }
        public static bool IsPassedInLastTest(int LocalDrivingLicenseApplicationID)
        {
            string Query = @"Select T.TestResult From TestAppointments TA
                            Join Tests T ON TA.TestAppointmentID = T.TestAppointmentID
                            Where AppointmentDate IN 
                            (Select Max (AppointmentDate) From TestAppointments Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID);
                            ";
            return clsDbHelper.ExecuteScalar<bool>(Query, Command => clsDbHelper.SetValue(Command, "@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID));


        }

        public static int LoadLastTestType(int LocalDrivingLicenseApplicationID)
        {
            string Query = @"Select TestTypeID From TestAppointments Where
                            AppointmentDate IN 
                            (Select Max (AppointmentDate) From TestAppointments Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)
                            ;";
            return clsDbHelper.ExecuteScalar<int>(Query, Command => clsDbHelper.SetValue(Command, "@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID));
        }

        public static List<clsTestAppointment_DTO> LoadTestAppointments()
        {
            string Query = "Select * From TestAppointments;";
            return clsDbHelper.ReadList(Query, null,
                Reader => _Reader(Reader) );

        }

        public static List<clsTestAppointment_DTO> LoadTestAppointments(int Offset, int CountRows)
        {
            string Query = $@"SELECT * FROM TestAppointments 
                      ORDER BY TestAppointmentID 
                      OFFSET @Offset ROWS FETCH NEXT @CountRows ROWS ONLY;";

            return clsDbHelper.ReadList(Query,
                Command => {
                    clsDbHelper.SetValue(Command, "@Offset", Offset);
                    clsDbHelper.SetValue(Command, "@CountRows", CountRows);
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

            return clsDbHelper.ReadList(Query,
                Command =>
                {
                    clsDbHelper.SetValue(Command, "@SearchValue", clsQuery.SearchValue,
                        IsHasValue: clsQuery.SearchValue != null);

                    clsDbHelper.SetValue(Command, "@TestTypeID",
                        clsQuery.Filter.TestTypeID,
                        clsQuery.Filter.TestTypeID.HasValue);

                    clsDbHelper.SetValue(Command, "@IsLocked",
                        clsQuery.Filter.IsLocked,
                        clsQuery.Filter.IsLocked.HasValue);

                    clsDbHelper.SetValue(Command, "@TestResult",
                        clsQuery.Filter.TestResult,
                        clsQuery.Filter.TestResult.HasValue);

                    clsDbHelper.SetValue(Command, "@FromAppointmentDate",
                        clsQuery.Filter.FromAppointmentDate,
                        clsQuery.Filter.FromAppointmentDate.HasValue);

                    clsDbHelper.SetValue(Command, "@ToAppointmentDate",
                        clsQuery.Filter.ToAppointmentDate,
                        clsQuery.Filter.ToAppointmentDate.HasValue);

                    clsDbHelper.SetValue(Command, "@Offset", Offset);
                    clsDbHelper.SetValue(Command, "@CountRows", CountRows);
                },
                Reader => _Reader(Reader));
        }

        public static int LoadPersonIDByTestAppointmentID(int TestAppointmentID)
        {
            string Query = @"Select A.ApplicantPersonID From Applications A
                            Join LocalDrivingLicenseApplications LDLA ON LDLA.ApplicationID = A.ApplicationID
                            Join TestAppointments TA ON TA.LocalDrivingLicenseApplicationID = LDLA.LocalDrivingLicenseApplicationID
                            Where TA.TestAppointmentID = @TestAppointmentID;";
            return clsDbHelper.ExecuteScalar<int>(Query, Command => clsDbHelper.SetValue(Command, "@TestAppointmentID", TestAppointmentID));
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
        public static decimal LoadPaidFeesByTestAppointmentID(int TestAppointmentID)
        {
            string Query = "Select PaidFees From TestAppointments Where TestAppointmentID = @TestAppointmentID";
            return clsDbHelper.ExecuteScalar<decimal>(Query, Command => clsDbHelper.SetValue(Command, "@TestAppointmentID", TestAppointmentID));
        }
        public static int LoadApplicationIDByTestAppointmentID(int TestAppointmentID)
        {
            string Query = @"Select LDLA.ApplicationID From TestAppointments TA
                            Join LocalDrivingLicenseApplications LDLA ON 
                            LDLA.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID 
                            
                            Where TestAppointmentID = @TestAppointmentID";
            
            return clsDbHelper.ExecuteScalar<int>(Query, Command => clsDbHelper.SetValue(Command, "@TestAppointmentID", TestAppointmentID));
        }

    }
}
