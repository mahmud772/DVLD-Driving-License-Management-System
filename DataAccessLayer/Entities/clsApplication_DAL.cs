using Common;
using Common.Filters;
using Common.Helpers;
using Common.Queries;
using DVLD_DAL.Mappers;
using DVLD_DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace DVLD_DAL
{
    public class clsApplication_DAL
    {
        private static clsApplication_DTO _Reader(SqlDataReader Reader)
        {
            return new clsApplication_DTO
            {
                ApplicationID = clsDbHelper.GetValue<int>(Reader, "ApplicationID"),
                ApplicationStatus = clsApplicationEnumConverter.ToStatus(clsDbHelper.GetValue<byte>(Reader, "ApplicationStatus")),
                ApplicationDate = clsDbHelper.GetValue<DateTime>(Reader, "ApplicationDate"),
                ApplicantPersonID = clsDbHelper.GetValue<int>(Reader, "ApplicantPersonID"),
                ApplicationTypeID = clsDbHelper.GetValue<int>(Reader, "ApplicationTypeID"),
                LastStatusDate = clsDbHelper.GetValue<DateTime>(Reader, "LastStatusDate"),
                PaidFees = clsDbHelper.GetValue<decimal>(Reader, "PaidFees"),
                CreatedByUserID = clsDbHelper.GetValue<int>(Reader, "CreatedByUserID")
            };
        }
        
        public static int LoadCount(clsApplicationQuery clsQuery)
        {
            string Query = "Select Count (*) From Applications Where 1 = 1 ";
            Query += clsQuery.SearchBy.HasValue && clsQuery.SearchValue != null
               ? $" AND {clsApplicationMapper.MapSearchBy(clsQuery.SearchBy.Value)} = @SearchValue"
               : "";

            ApplyApplicationFilter(clsQuery.Filter, ref Query);

            return clsDbHelper.ExecuteScalar<int>(Query,
                Command =>
                {
                    clsDbHelper.SetValue(Command, "@ApplicationStatus", clsQuery.Filter.ApplicationStatus, IsHasValue: clsQuery.Filter.ApplicationStatus.HasValue);
                    clsDbHelper.SetValue(Command, "@ApplicationTypeID", clsQuery.Filter.ApplicationTypeID, IsHasValue: clsQuery.Filter.ApplicationTypeID.HasValue);
                    clsDbHelper.SetValue(Command, "@FromApplicationDate",
                    clsQuery.Filter.FromApplicationDate,
                    clsQuery.Filter.FromApplicationDate.HasValue);

                    clsDbHelper.SetValue(Command, "@ToApplicationDate",
                        clsQuery.Filter.ToApplicationDate,
                        clsQuery.Filter.ToApplicationDate.HasValue);

                    clsDbHelper.SetValue(Command, "@SearchValue", clsQuery.SearchValue, IsHasValue: clsQuery.SearchValue != null);


                });
        }
        public static clsApplication_DTO LoadApplicationInfoByID(int ApplicationID)
        {
            bool IsFound = false;
            clsApplication_DTO DTO = null;
            string Query = "Select * From Applications Where ApplicationID = @ApplicationID";
            IsFound = clsDbHelper.ExecuteReader(Query,
                Command => clsDbHelper.SetValue<int>(Command, "@ApplicationID", ApplicationID),
                Reader => { DTO = clsApplication_DAL._Reader(Reader); });
            return DTO ;
        }

        public static clsApplication_DTO LoadApplicationInfoByPersonID(int ApplicantPersonID)
        {
            int ApplicationID = -1;
            string Query = "Select ApplicationID From Applications Where ApplicantPersonID = @ApplicantPersonID";
            if (clsDbHelper.FindID<int>(Query, "@ApplicantPersonID", ApplicantPersonID, ref ApplicationID))
                return LoadApplicationInfoByID(ApplicationID);
            return null;
        }

        public static int CreateApplication(clsApplication_DTO DTO)
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

            return clsDbHelper.ExecuteScalar<int>(Query, (Command =>
            {
                clsDbHelper.SetValue<int>(Command, "@ApplicantPersonID", DTO.ApplicantPersonID);
                clsDbHelper.SetValue<DateTime>(Command, "@ApplicationDate", DTO.ApplicationDate);
                clsDbHelper.SetValue<int>(Command, "@ApplicationTypeID", DTO.ApplicationTypeID);
                clsDbHelper.SetValue<int>(Command, "@ApplicationStatus", clsApplicationEnumConverter.ToByte(DTO.ApplicationStatus));
                clsDbHelper.SetValue(Command, "@ApplicationStatus_AddNew", clsApplicationEnumConverter.ToByte(clsApplicationEnums.enApplicationStatus.New));
                clsDbHelper.SetValue<DateTime>(Command, "@LastStatusDate", DTO.LastStatusDate);
                clsDbHelper.SetValue<decimal>(Command, "@PaidFees", DTO.PaidFees);
                clsDbHelper.SetValue<int>(Command, "@CreatedByUserID", DTO.CreatedByUserID);
            }));

        }

        public static bool UpdateApplication(clsApplication_DTO Model)
        {

            string Query = @"Update Applications Set
                              ApplicationTypeID = @ApplicationTypeID ,ApplicationStatus = @ApplicationStatus
                             , LastStatusDate = @LastStatusDate, PaidFees = @PaidFees 
                             Where ApplicationID = @ApplicationID";

            return clsDbHelper.ExecuteNonQuery(Query, (Action<SqlCommand>)(Command =>
            {
                clsDbHelper.SetValue<int>(Command, "@ApplicationID", Model.ApplicationID);
                clsDbHelper.SetValue<int>(Command, "@ApplicationTypeID", Model.ApplicationTypeID);
                clsDbHelper.SetValue<int>(Command, "@ApplicationStatus", clsApplicationEnumConverter.ToByte(Model.ApplicationStatus));
                clsDbHelper.SetValue<DateTime>(Command, "@LastStatusDate", Model.LastStatusDate);
                clsDbHelper.SetValue<decimal>(Command, "@PaidFees", Model.PaidFees);
            })) > 0;

        }


        public static bool DeleteApplicationByID(int ApplicationID)
        {
            int DeletedApplicationCount = 0;

            string QueryApplicationsTable = @"Delete From Applications Where ApplicationID = @ApplicationID;";


            bool TransactionSuccess = clsDbHelper.ExecuteTransaction(Command =>
            {

                clsDbHelper.SetValue<int>(Command, "@ApplicationID", ApplicationID);

                clsLicense_DAL.DeleteLicenseByApplicationID(ApplicationID);

                Command.CommandText = QueryApplicationsTable;
                DeletedApplicationCount = Command.ExecuteNonQuery();
            });


            return TransactionSuccess && (DeletedApplicationCount > 0);
        }

        public static bool DeleteApplicationByTypeID(int ApplicationTypeID)
        {
            string QueryApplicationsTable = @"Delete From Applications Where ApplicationTypeID = @ApplicationTypeID;";

            int RowsAffected = clsDbHelper.ExecuteNonQuery
                (QueryApplicationsTable, Command => clsDbHelper.SetValue<int>(Command, "@ApplicationTypeID", ApplicationTypeID));

            return (RowsAffected > 0);
        }

        public static bool DeleteByUserID(int CreatedByUserID)
        {
            int DeletedApplicationCount = 0;
            string QueryApplicationsTable = @"Delete From Applications Where CreatedByUserID = @CreatedByUserID;";


            bool TransactionSuccess = clsDbHelper.ExecuteTransaction(Command =>
            {

                clsDbHelper.SetValue<int>(Command, "@CreatedByUserID", CreatedByUserID);

                clsLicense_DAL.DeleteByUserID(CreatedByUserID);

                Command.CommandText = QueryApplicationsTable;
                DeletedApplicationCount = Command.ExecuteNonQuery();
            });


            return TransactionSuccess && (DeletedApplicationCount > 0);
        }
        public static List<clsApplication_DTO> LoadApplications()
        {

            string Query = "SELECT * FROM Applications;";

            return clsDbHelper.ReadList(Query, null,
                Reader => new clsApplication_DTO
                {
                    ApplicationID = clsDbHelper.GetValue<int>(Reader, "ApplicationID"),
                    ApplicationStatus = clsApplicationEnumConverter.ToStatus(clsDbHelper.GetValue<byte>(Reader, "ApplicationStatus")),
                    ApplicationDate = clsDbHelper.GetValue<DateTime>(Reader, "ApplicationDate"),
                    ApplicantPersonID = clsDbHelper.GetValue<int>(Reader, "ApplicantPersonID"),
                    ApplicationTypeID = clsDbHelper.GetValue<int>(Reader, "ApplicationTypeID"),
                    LastStatusDate = clsDbHelper.GetValue<DateTime>(Reader, "LastStatusDate"),
                    PaidFees = clsDbHelper.GetValue<decimal>(Reader, "PaidFees"),
                    CreatedByUserID = clsDbHelper.GetValue<int>(Reader, "CreatedByUserID")

                });
        }
        public static List<clsApplication_DTO> LoadAllBy(int Offset, int CountRows)
        {

            string Query = @"SELECT * FROM Applications
                             Order By ApplicationID
                             OFFSET @Offset ROWS 
                             FETCH NEXT @CountRows ROWS ONLY;";

            return clsDbHelper.ReadList(Query,
                Command =>
                {

                    clsDbHelper.SetValue<int>(Command, "@Offset", Offset);
                    clsDbHelper.SetValue<int>(Command, "@CountRows", CountRows);
                },
                Reader => _Reader(Reader) );
        }

        public static bool UpdateApplicationStatus(int ApplicationID, byte NewStatus, DateTime StatusDate)
        {
            string Query = @"Update Applications Set ApplicationStatus = @ApplicationStatus
                            ,LastStatusDate = @LastStatusDate Where ApplicationID = @ApplicationID ;";
            int RowsEffected = -1;
            RowsEffected = clsDbHelper.ExecuteNonQuery(Query, Command =>
            {
                clsDbHelper.SetValue<int>(Command, "@ApplicationID", ApplicationID);
                clsDbHelper.SetValue<DateTime>(Command, "@LastStatusDate", StatusDate);
                clsDbHelper.SetValue<byte>(Command, "@ApplicationStatus", NewStatus);
            });
            return RowsEffected > 0;

        }


        public static DateTime GetDateOfBirthByApplicationID(int ApplicationID)
        {
            string Query = @"Select P.DateOfBirth From People P 
                            Join Applications A ON A.ApplicantPersonID = P.PersonID
                            Where A.ApplicationID = @ApplicationID;";
            return clsDbHelper.ExecuteScalar<DateTime>(Query, Command => clsDbHelper.SetValue(Command, "@ApplicationID", ApplicationID));
        }
        public static List<clsApplication_DTO> LoadAllBy(int Offset, int CountRows ,clsApplicationQuery clsQuery)
        {

            string Query = $@"Select * From Applications Where 1 = 1 ";

            Query += clsQuery.SearchBy.HasValue && clsQuery.SearchValue != null ? $@" And {clsApplicationMapper.MapSearchBy(clsQuery.SearchBy.Value)} = @SearchValue" : "";
            ApplyApplicationFilter(clsQuery.Filter, ref Query);
            Query += $@" Order By {clsApplicationMapper.MapOrderBy(clsQuery.OrderBy)} 
                                 {clsOrderDirectionMapper.MapOrderDirection(clsQuery.OrderDirection)}";
            Query += " OFFSET @Offset ROWS FETCH NEXT @CountRows ROWS ONLY;";
            return clsDbHelper.ReadList<clsApplication_DTO>(Query, 
                Command =>
                {
                    clsDbHelper.SetValue(Command, "@ApplicationStatus", clsQuery.Filter.ApplicationStatus, IsHasValue: clsQuery.Filter.ApplicationStatus.HasValue);
                    clsDbHelper.SetValue(Command, "@ApplicationTypeID", clsQuery.Filter.ApplicationTypeID, IsHasValue: clsQuery.Filter.ApplicationTypeID.HasValue);
                    clsDbHelper.SetValue(Command, "@FromApplicationDate",
                    clsQuery.Filter.FromApplicationDate,
                    clsQuery.Filter.FromApplicationDate.HasValue);

                    clsDbHelper.SetValue(Command, "@ToApplicationDate",
                        clsQuery.Filter.ToApplicationDate,
                        clsQuery.Filter.ToApplicationDate.HasValue);

                    clsDbHelper.SetValue(Command, "@SearchValue", clsQuery.SearchValue, IsHasValue: clsQuery.SearchValue != null);

                    clsDbHelper.SetValue<int>(Command, "@Offset", Offset);
                    clsDbHelper.SetValue<int>(Command, "@CountRows", CountRows);
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
