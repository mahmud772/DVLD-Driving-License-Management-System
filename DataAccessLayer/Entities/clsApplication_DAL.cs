using Common;
using Common.Filters;
using Common.Helpers;
using Common.Queries;
using DVLD_DAL.Mappers;
using DVLD_DTOs;
using DVLD_DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace DVLD_DAL
{
    public class clsApplication_DAL
    {
        private static clsApplication_DTO _Reader(SqlDataReader Reader)
        {
            return new clsApplication_DTO
            {
                ApplicationID = DbHelper.GetValue<int>(Reader, "ApplicationID"),
                ApplicationStatus = clsApplicationEnumConverter.ToStatus(DbHelper.GetValue<byte>(Reader, "ApplicationStatus")),
                ApplicationDate = DbHelper.GetValue<DateTime>(Reader, "ApplicationDate"),
                ApplicantPersonID = DbHelper.GetValue<int>(Reader, "ApplicantPersonID"),
                ApplicationTypeID = DbHelper.GetValue<int>(Reader, "ApplicationTypeID"),
                LastStatusDate = DbHelper.GetValue<DateTime>(Reader, "LastStatusDate"),
                PaidFees = DbHelper.GetValue<decimal>(Reader, "PaidFees"),
                CreatedByUserID = DbHelper.GetValue<int>(Reader, "CreatedByUserID")
            };
        }
        
        public static int LoadCount(clsApplicationQuery clsQuery)
        {
            string Query = "Select Count (*) From Applications Where 1 = 1 ";
            Query += clsQuery.SearchBy.HasValue && clsQuery.SearchValue != null
               ? $" AND {clsApplicationMapper.MapSearchBy(clsQuery.SearchBy.Value)} = @SearchValue"
               : "";

            ApplyApplicationFilter(clsQuery.Filter, ref Query);

            return DbHelper.ExecuteScalar<int>(Query,
                Command =>
                {
                    DbHelper.SetValue(Command, "@ApplicationStatus", clsQuery.Filter.ApplicationStatus, IsHasValue: clsQuery.Filter.ApplicationStatus.HasValue);
                    DbHelper.SetValue(Command, "@ApplicationTypeID", clsQuery.Filter.ApplicationTypeID, IsHasValue: clsQuery.Filter.ApplicationTypeID.HasValue);
                    DbHelper.SetValue(Command, "@FromApplicationDate",
                    clsQuery.Filter.FromApplicationDate,
                    clsQuery.Filter.FromApplicationDate.HasValue);

                    DbHelper.SetValue(Command, "@ToApplicationDate",
                        clsQuery.Filter.ToApplicationDate,
                        clsQuery.Filter.ToApplicationDate.HasValue);

                    DbHelper.SetValue(Command, "@SearchValue", clsQuery.SearchValue, IsHasValue: clsQuery.SearchValue != null);


                });
        }
        public static clsApplication_DTO LoadApplicationInfoByID(int ApplicationID)
        {
            bool IsFound = false;
            clsApplication_DTO DTO = null;
            string Query = "Select * From Applications Where ApplicationID = @ApplicationID";
            IsFound = DbHelper.ExecuteReader(Query,
                Command => DbHelper.SetValue<int>(Command, "@ApplicationID", ApplicationID),
                Reader => { DTO = _Reader(Reader); });
            return DTO ;
        }

        public static clsApplication_DTO LoadApplicationInfoByPersonID(int ApplicantPersonID)
        {
            int ApplicationID = -1;
            string Query = "Select ApplicationID From Applications Where ApplicantPersonID = @ApplicantPersonID";
            if (DbHelper.FindID<int>(Query, "@ApplicantPersonID", ApplicantPersonID, ref ApplicationID))
                return LoadApplicationInfoByID(ApplicationID);
            return null;
        }

        public static int CreateApplication(clsApplication_DTO Model)
        {

            string Query = @"INSERT INTO Applications 
                            (
                                ApplicantPersonID, ApplicationDate, ApplicationTypeID, 
                                ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID
                            )
                            SELECT 
                                @ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, 
                                @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID
                            WHERE NOT EXISTS 
                            (
                                SELECT 1 
                                FROM Applications 
                                WHERE ApplicantPersonID = @ApplicantPersonID 
                                  AND ApplicationStatus = @ApplicationStatus_AddNew
                                  AND ApplicationTypeID = @ApplicationTypeID
                            )
                            ;
                            IF @@ROWCOUNT > 0
                                SELECT SCOPE_IDENTITY();
                            ELSE
                                SELECT -1;";

            return DbHelper.ExecuteScalar<int>(Query, (Action<SqlCommand>)(Command =>
            {
                DbHelper.SetValue<int>(Command, "@ApplicantPersonID", Model.ApplicantPersonID);
                DbHelper.SetValue<DateTime>(Command, "@ApplicationDate", Model.ApplicationDate);
                DbHelper.SetValue<int>(Command, "@ApplicationTypeID", Model.ApplicationTypeID);
                DbHelper.SetValue<int>(Command, "@ApplicationStatus", clsApplicationEnumConverter.ToByte(Model.ApplicationStatus));
                DbHelper.SetValue(Command, "@ApplicationStatus_AddNew", clsApplicationEnumConverter.ToByte(clsApplicationEnums.enApplicationStatus.New));
                DbHelper.SetValue<DateTime>(Command, "@LastStatusDate", Model.LastStatusDate);
                DbHelper.SetValue<decimal>(Command, "@PaidFees", Model.PaidFees);
                DbHelper.SetValue<int>(Command, "@CreatedByUserID", Model.CreatedByUserID);
            }));

        }

        public static bool UpdateApplication(clsApplication_DTO Model)
        {

            string Query = @"Update Applications Set
                              ApplicationTypeID = @ApplicationTypeID ,ApplicationStatus = @ApplicationStatus
                             , LastStatusDate = @LastStatusDate, PaidFees = @PaidFees 
                             Where ApplicationID = @ApplicationID";

            return DbHelper.ExecuteNonQuery(Query, (Action<SqlCommand>)(Command =>
            {
                DbHelper.SetValue<int>(Command, "@ApplicationID", Model.ApplicationID);
                DbHelper.SetValue<int>(Command, "@ApplicationTypeID", Model.ApplicationTypeID);
                DbHelper.SetValue<int>(Command, "@ApplicationStatus", clsApplicationEnumConverter.ToByte(Model.ApplicationStatus));
                DbHelper.SetValue<DateTime>(Command, "@LastStatusDate", Model.LastStatusDate);
                DbHelper.SetValue<decimal>(Command, "@PaidFees", Model.PaidFees);
            })) > 0;

        }


        public static bool DeleteApplicationByID(int ApplicationID)
        {
            int DeletedApplicationCount = 0;

            string QueryApplicationsTable = @"Delete From Applications Where ApplicationID = @ApplicationID;";


            bool TransactionSuccess = DbHelper.ExecuteTransaction(Command =>
            {

                DbHelper.SetValue<int>(Command, "@ApplicationID", ApplicationID);

                clsLicense_DAL.DeleteLicenseByApplicationID(ApplicationID);

                Command.CommandText = QueryApplicationsTable;
                DeletedApplicationCount = Command.ExecuteNonQuery();
            });


            return TransactionSuccess && (DeletedApplicationCount > 0);
        }

        public static bool DeleteApplicationByTypeID(int ApplicationTypeID)
        {
            string QueryApplicationsTable = @"Delete From Applications Where ApplicationTypeID = @ApplicationTypeID;";

            int RowsAffected = DbHelper.ExecuteNonQuery
                (QueryApplicationsTable, Command => DbHelper.SetValue<int>(Command, "@ApplicationTypeID", ApplicationTypeID));

            return (RowsAffected > 0);
        }

        public static bool DeleteByUserID(int CreatedByUserID)
        {
            int DeletedApplicationCount = 0;
            string QueryApplicationsTable = @"Delete From Applications Where CreatedByUserID = @CreatedByUserID;";


            bool TransactionSuccess = DbHelper.ExecuteTransaction(Command =>
            {

                DbHelper.SetValue<int>(Command, "@CreatedByUserID", CreatedByUserID);

                clsLicense_DAL.DeleteByUserID(CreatedByUserID);

                Command.CommandText = QueryApplicationsTable;
                DeletedApplicationCount = Command.ExecuteNonQuery();
            });


            return TransactionSuccess && (DeletedApplicationCount > 0);
        }
        public static List<clsApplication_DTO> LoadApplications()
        {

            string Query = "SELECT * FROM Applications;";

            return DbHelper.ReadList(Query, null,
                Reader => new clsApplication_DTO
                {
                    ApplicationID = DbHelper.GetValue<int>(Reader, "ApplicationID"),
                    ApplicationStatus = clsApplicationEnumConverter.ToStatus(DbHelper.GetValue<byte>(Reader, "ApplicationStatus")),
                    ApplicationDate = DbHelper.GetValue<DateTime>(Reader, "ApplicationDate"),
                    ApplicantPersonID = DbHelper.GetValue<int>(Reader, "ApplicantPersonID"),
                    ApplicationTypeID = DbHelper.GetValue<int>(Reader, "ApplicationTypeID"),
                    LastStatusDate = DbHelper.GetValue<DateTime>(Reader, "LastStatusDate"),
                    PaidFees = DbHelper.GetValue<decimal>(Reader, "PaidFees"),
                    CreatedByUserID = DbHelper.GetValue<int>(Reader, "CreatedByUserID")

                });
        }
        public static List<clsApplication_DTO> LoadAllBy(int Offset, int CountRows)
        {

            string Query = @"SELECT * FROM Applications
                             Order By ApplicationID
                             OFFSET @Offset ROWS 
                             FETCH NEXT @CountRows ROWS ONLY;";

            return DbHelper.ReadList(Query,
                Command =>
                {

                    DbHelper.SetValue<int>(Command, "@Offset", Offset);
                    DbHelper.SetValue<int>(Command, "@CountRows", CountRows);
                },
                Reader => _Reader(Reader) );
        }

        public static bool UpdateApplicationStatus(int ApplicationID, byte NewStatus, DateTime StatusDate)
        {
            string Query = @"Update Applications Set ApplicationStatus = @ApplicationStatus
                            ,LastStatusDate = @LastStatusDate Where ApplicationID = @ApplicationID ;";
            int RowsEffected = -1;
            RowsEffected = DbHelper.ExecuteNonQuery(Query, Command =>
            {
                DbHelper.SetValue<int>(Command, "@ApplicationID", ApplicationID);
                DbHelper.SetValue<DateTime>(Command, "@LastStatusDate", StatusDate);
                DbHelper.SetValue<byte>(Command, "@ApplicationStatus", NewStatus);
            });
            return RowsEffected > 0;

        }


        public static DateTime GetDateOfBirthByApplicationID(int ApplicationID)
        {
            string Query = @"Select P.DateOfBirth From People P 
                            Join Applications A ON A.ApplicantPersonID = P.PersonID
                            Where A.ApplicationID = @ApplicationID;";
            return DbHelper.ExecuteScalar<DateTime>(Query, Command => DbHelper.SetValue(Command, "@ApplicationID", ApplicationID));
        }
        public static List<clsApplication_DTO> LoadAllBy(int Offset, int CountRows ,clsApplicationQuery clsQuery)
        {

            string Query = $@"Select * From Applications Where 1 = 1 ";

            Query += clsQuery.SearchBy.HasValue ? $@" And {clsApplicationMapper.MapSearchBy(clsQuery.SearchBy.Value)} = @SearchValue" : "";
            ApplyApplicationFilter(clsQuery.Filter, ref Query);
            Query += $@" Order By {clsApplicationMapper.MapOrderBy(clsQuery.OrderBy)} 
                                 {clsOrderDirectionMapper.MapOrderDirection(clsQuery.OrderDirection)}";
            Query += " OFFSET @Offset ROWS FETCH NEXT @CountRows ROWS ONLY;";
            return DbHelper.ReadList<clsApplication_DTO>(Query, 
                Command =>
                {
                    DbHelper.SetValue(Command, "@ApplicationStatus", clsQuery.Filter.ApplicationStatus, IsHasValue: clsQuery.Filter.ApplicationStatus.HasValue);
                    DbHelper.SetValue(Command, "@ApplicationTypeID", clsQuery.Filter.ApplicationTypeID, IsHasValue: clsQuery.Filter.ApplicationTypeID.HasValue);
                    DbHelper.SetValue(Command, "@FromApplicationDate",
                    clsQuery.Filter.FromApplicationDate,
                    clsQuery.Filter.FromApplicationDate.HasValue);

                    DbHelper.SetValue(Command, "@ToApplicationDate",
                        clsQuery.Filter.ToApplicationDate,
                        clsQuery.Filter.ToApplicationDate.HasValue);

                    DbHelper.SetValue(Command, "@SearchValue", clsQuery.SearchValue, IsHasValue: clsQuery.SearchValue != null);

                    DbHelper.SetValue<int>(Command, "@Offset", Offset);
                    DbHelper.SetValue<int>(Command, "@CountRows", CountRows);
                },
                Reader => _Reader(Reader));
        }
        public static void ApplyApplicationFilter(clsApplicationFilter filter,ref string query)
        {
            if (filter == null) return;

            MappingHelper.AddCondition(filter.ApplicationStatus.HasValue,
                "ApplicationStatus = @ApplicationStatus",
                ref query);

            MappingHelper.AddCondition(
                filter.ApplicationTypeID.HasValue,
                "ApplicationTypeID = @ApplicationTypeID",
                ref query);

            MappingHelper.ApplyDateRange(
                filter.FromApplicationDate,
                filter.ToApplicationDate,
                "ApplicationDate",
                ref query);
        }


    }
}
