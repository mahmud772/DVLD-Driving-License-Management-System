using Common;
using Common.Filters;
using Common.Helpers;
using Common.Queries;
using DVLD_DAL.Mappers;
using DVLD_DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public class clsLocalDrivingLicenseApplication_DAL
    {
        private static clsLocalDrivingLicenseApplication_DTO _Reader(SqlDataReader Reader)
        {
            return new clsLocalDrivingLicenseApplication_DTO
            {
                LocalDrivingLicenseApplicationID = DbHelper.GetValue<int>(Reader, "LocalDrivingLicenseApplicationID"),
                ApplicationID = DbHelper.GetValue<int>(Reader, "ApplicationID"),
                LicenseClassID = DbHelper.GetValue<int>(Reader, "LicenseClassID"),

                ApplicationStatus = clsApplicationEnumConverter.ToStatus(DbHelper.GetValue<byte>(Reader, "ApplicationStatus")),
                ApplicationDate = DbHelper.GetValue<DateTime>(Reader, "ApplicationDate"),
                ApplicantPersonID = DbHelper.GetValue<int>(Reader, "ApplicantPersonID"),
                ApplicationTypeID = DbHelper.GetValue<int>(Reader, "ApplicationTypeID"),
                LastStatusDate = DbHelper.GetValue<DateTime>(Reader, "LastStatusDate"),
                PaidFees = DbHelper.GetValue<decimal>(Reader, "PaidFees"),
                CreatedByUserID = DbHelper.GetValue<int>(Reader, "CreatedByUserID")
            };
        }
        public static int LoadCount(clsLocalDrivingLicenseApplicationQuery clsQuery)
        {
            string Query = "Select Count (*) From LocalDrivingLicenseApplications Where 1 = 1 ";

            Query += clsQuery.SearchBy.HasValue && clsQuery.SearchValue != null ?
                $@" And {clsApplicationMapper.MapSearchBy(clsQuery.SearchBy.Value)} = @SearchValue" : "";

            _ApplyLocalDrivingLicenseApplicationFilter(clsQuery.Filter, ref Query);
            return DbHelper.ExecuteScalar<int>(Query,
                Command =>
                {
                    DbHelper.SetValue(Command, "@ApplicationStatus", clsQuery.Filter.ApplicationStatus,
                        IsHasValue: clsQuery.Filter.ApplicationStatus.HasValue);

                    DbHelper.SetValue(Command, "@ApplicationTypeID", clsQuery.Filter.ApplicationTypeID,
                        IsHasValue: clsQuery.Filter.ApplicationTypeID.HasValue);

                    DbHelper.SetValue(Command, "@FromApplicationDate",
                    clsQuery.Filter.FromApplicationDate,
                    clsQuery.Filter.FromApplicationDate.HasValue);

                    DbHelper.SetValue(Command, "@ToApplicationDate",
                        clsQuery.Filter.ToApplicationDate,
                        clsQuery.Filter.ToApplicationDate.HasValue);

                    DbHelper.SetValue(Command, "@LicenseClassID",
                        clsQuery.Filter.LicenseClassID,
                        clsQuery.Filter.LicenseClassID.HasValue);

                    DbHelper.SetValue(Command, "@SearchValue", clsQuery.SearchValue,
                        IsHasValue: clsQuery.SearchValue != null);

                });
            
        }

        public static clsLocalDrivingLicenseApplication_DTO LoadLocalDrivingLicenseApplicationByID(int LocalDrivingLicenseApplicationID)
        {
            clsLocalDrivingLicenseApplication_DTO Model = null;
            string Query = @"SELECT 
                    LDLLA.LocalDrivingLicenseApplicationID, 
                    LDLLA.ApplicationID, 
                    LDLLA.LicenseClassID, 
                    A.ApplicantPersonID, 
                    A.ApplicationDate, 
                    A.ApplicationTypeID, 
                    A.ApplicationStatus, 
                    A.LastStatusDate, 
                    A.PaidFees, 
                    A.CreatedByUserID
                 FROM LocalDrivingLicenseApplications LDLLA
                 JOIN Applications A ON LDLLA.ApplicationID = A.ApplicationID 
                 WHERE LDLLA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            DbHelper.ExecuteReader(Query, Command => DbHelper.SetValue(Command, "@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID),
                Reader =>
                {
                    Model = _Reader(Reader);
                });
            return Model;
        }

        // إضافة طلب رخصة قيادة محلي جديد
        public static int AddNewLocalDrivingLicenseApplication(clsLocalDrivingLicenseApplication_DTO Model)
        {
            string Query = @"INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID)
                         Select @ApplicationID, @LicenseClassID
                         Where Not Exists
                        (
                            Select 1 From LocalDrivingLicenseApplications LDLA
                            Join Applications A ON LDLA.ApplicationID = A.ApplicationID
                            Where A.ApplicantPersonID = @ApplicantPersonID
                            And( A.ApplicationStatus = @ApplicationStatus_New 
                            OR A.ApplicationStatus = @ApplicationStatus_Completed )
                            And LDLA.LicenseClassID = @LicenseClassID
                        );
                         IF @@ROWCOUNT > 0
                                SELECT SCOPE_IDENTITY();
                            ELSE
                                SELECT -1;";

            return DbHelper.ExecuteScalar<int>(Query, (Action<System.Data.SqlClient.SqlCommand>)(Command =>
            {
                DbHelper.SetValue(Command, "@ApplicationID", Model.ApplicationID);
                DbHelper.SetValue(Command, "@LicenseClassID", Model.LicenseClassID);
                DbHelper.SetValue(Command, "@ApplicantPersonID", Model.ApplicantPersonID);
                DbHelper.SetValue(Command, "@ApplicationStatus_New", clsApplicationEnumConverter.ToByte(clsApplicationEnums.enApplicationStatus.New));
                DbHelper.SetValue(Command, "@ApplicationStatus_Completed", clsApplicationEnumConverter.ToByte(clsApplicationEnums.enApplicationStatus.Completed));

            }));
        }


        public static bool UpdateLocalDrivingLicenseApplication(clsLocalDrivingLicenseApplication_DTO Model)
        {
            string Query = @"UPDATE LocalDrivingLicenseApplications SET
                         ApplicationID = @ApplicationID, LicenseClassID = @LicenseClassID
                         WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            int RowsAffected = DbHelper.ExecuteNonQuery(Query, Command =>
            {
                DbHelper.SetValue(Command, "@LocalDrivingLicenseApplicationID", Model.LocalDrivingLicenseApplicationID); // شرط التحديث
                DbHelper.SetValue(Command, "@ApplicationID", Model.ApplicationID);
                DbHelper.SetValue(Command, "@LicenseClassID", Model.LicenseClassID);
            });
            return RowsAffected > 0;
        }


        public static bool DeleteLocalDrivingLicenseApplicationByApplicationID(int ApplicationID)
        {
            return clsApplication_DAL.DeleteApplicationByID(ApplicationID);
        }

        public static int GetPersonIDByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            string Query = @"Select A.ApplicantPersonID From Applications A
                            Join LocalDrivingLicenseApplications LD ON LD.ApplicationID = A.ApplicationID
                            Where LD.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";
            return DbHelper.ExecuteScalar<int>(Query, Command => DbHelper.SetValue(Command, "@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID));
        }

        public static List<clsLocalDrivingLicenseApplication_DTO> LoadLocalDrivingLicenseApplications()
        {
            string Query = @"SELECT 
                    LDLLA.LocalDrivingLicenseApplicationID, 
                    LDLLA.ApplicationID, 
                    LDLLA.LicenseClassID, 
                    A.ApplicantPersonID, 
                    A.ApplicationDate, 
                    A.ApplicationTypeID, 
                    A.ApplicationStatus, 
                    A.LastStatusDate, 
                    A.PaidFees, 
                    A.CreatedByUserID
                 FROM LocalDrivingLicenseApplications LDLLA
                 JOIN Applications A ON LDLLA.ApplicationID = A.ApplicationID ;";
            return DbHelper.ReadList(Query, null,
                Reader => _Reader(Reader)
                );
        }

        public static List<clsLocalDrivingLicenseApplication_DTO> LoadLocalDrivingLicenseApplications(int Offset, int CountRows)
        {
            string Query = $@"SELECT 
                    LDLLA.LocalDrivingLicenseApplicationID, 
                    LDLLA.ApplicationID, 
                    LDLLA.LicenseClassID, 
                    A.ApplicantPersonID, 
                    A.ApplicationDate, 
                    A.ApplicationTypeID, 
                    A.ApplicationStatus, 
                    A.LastStatusDate, 
                    A.PaidFees, 
                    A.CreatedByUserID
                 FROM LocalDrivingLicenseApplications LDLLA
                      ORDER BY LDLLA.LocalDrivingLicenseApplicationID
                      OFFSET @Offset ROWS FETCH NEXT @CountRows ROWS ONLY;";

            return DbHelper.ReadList(Query,
                Command => {
                    DbHelper.SetValue(Command, "@Offset", Offset);
                    DbHelper.SetValue(Command, "@CountRows", CountRows);
                },
                Reader => _Reader(Reader));
        }
        public static List<clsLocalDrivingLicenseApplication_DTO> LoadLocalDrivingLicenseApplications(int Offset, int CountRows , clsLocalDrivingLicenseApplicationQuery clsQuery)
        {
            string Query = $@"SELECT 
                    LDLLA.LocalDrivingLicenseApplicationID, 
                    LDLLA.ApplicationID, 
                    LDLLA.LicenseClassID, 
                    A.ApplicantPersonID, 
                    A.ApplicationDate, 
                    A.ApplicationTypeID, 
                    A.ApplicationStatus, 
                    A.LastStatusDate, 
                    A.PaidFees, 
                    A.CreatedByUserID
                 FROM LocalDrivingLicenseApplications LDLLA
                    Where 1 = 1 ";

            Query += clsQuery.SearchBy.HasValue && clsQuery.SearchValue != null ? 
                $@" And {clsApplicationMapper.MapSearchBy(clsQuery.SearchBy.Value)} = @SearchValue" : "";
            _ApplyLocalDrivingLicenseApplicationFilter(clsQuery.Filter, ref Query);

            Query += $@" Order By {clsApplicationMapper.MapOrderBy(clsQuery.OrderBy)} 
                                 {clsOrderDirectionMapper.MapOrderDirection(clsQuery.OrderDirection)}";

            Query += " OFFSET @Offset ROWS FETCH NEXT @CountRows ROWS ONLY;";
            return DbHelper.ReadList<clsLocalDrivingLicenseApplication_DTO>(Query,
                Command =>
                {
                    DbHelper.SetValue(Command, "@ApplicationStatus", clsQuery.Filter.ApplicationStatus,
                        IsHasValue: clsQuery.Filter.ApplicationStatus.HasValue);

                    DbHelper.SetValue(Command, "@ApplicationTypeID", clsQuery.Filter.ApplicationTypeID,
                        IsHasValue: clsQuery.Filter.ApplicationTypeID.HasValue);

                    DbHelper.SetValue(Command, "@FromApplicationDate",
                    clsQuery.Filter.FromApplicationDate,
                    clsQuery.Filter.FromApplicationDate.HasValue);

                    DbHelper.SetValue(Command, "@ToApplicationDate",
                        clsQuery.Filter.ToApplicationDate,
                        clsQuery.Filter.ToApplicationDate.HasValue);

                    DbHelper.SetValue(Command, "@LicenseClassID",
                        clsQuery.Filter.LicenseClassID,
                        clsQuery.Filter.LicenseClassID.HasValue);

                    DbHelper.SetValue(Command, "@SearchValue", clsQuery.SearchValue,
                        IsHasValue: clsQuery.SearchValue != null);

                    DbHelper.SetValue<int>(Command, "@Offset", Offset);
                    DbHelper.SetValue<int>(Command, "@CountRows", CountRows);
                },
                Reader => _Reader(Reader));
        }
        private static void _ApplyLocalDrivingLicenseApplicationFilter(clsLocalDrivingLicenseApplicationFilter filter,
                    ref string query)
        {
            if (filter == null)
                return;

            // Application الأساسية
            clsApplication_DAL.ApplyApplicationFilter(filter, ref query);

            MappingHelper.AddCondition(
                filter.LicenseClassID.HasValue,
                "LicenseClassID = @LicenseClassID",
                ref query);
        }
        public static int LoadLicenseClassIDByLocalDrivingLicenseApplicationID(int LocalLicenseAppID)
        {
            string Query = @"SELECT 
                    LicenseClassID
                    From LocalDrivingLicenseApplications
                    Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID ;";
            return DbHelper.ExecuteScalar<int>(Query, Command => DbHelper.SetValue(Command, "@LocalDrivingLicenseApplicationID", LocalLicenseAppID));
        }
    }
}
