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
    public class clsInternationalLicense_DAL
    {
        private static clsLicenseCardInfo_DTO _CardReader(SqlDataReader Reader)
        {
            return new clsLicenseCardInfo_DTO
            {
                LicenseID = clsDbHelper.GetValue<int>(Reader, "InternationalLicenseID"),
                FirstName = clsDbHelper.GetValue<string>(Reader, "FirstName"),
                SecondName = clsDbHelper.GetValue<string>(Reader, "SecondName"),
                ThirdName = clsDbHelper.GetValue<string>(Reader, "ThirdName"),
                LastName = clsDbHelper.GetValue<string>(Reader, "LastName"),
                ImagePath = clsDbHelper.GetValue<string>(Reader, "ImagePath"),
                NationalNo = clsDbHelper.GetValue<string>(Reader, "NationalNo"),
                DateOfBirth = clsDbHelper.GetValue<DateTime>(Reader, "DateOfBirth"),
                LicenseClass = clsLicenseEnumConverter.ToClass(clsDbHelper.GetValue<int>(Reader, "LicenseClassID")),
                IsActive = clsDbHelper.GetValue<bool>(Reader, "IsActive"),
                IssueReason = clsLicenseEnumConverter.ToIssueReason(clsDbHelper.GetValue<byte>(Reader, "IssueReason")),
                IssueDate = clsDbHelper.GetValue<DateTime>(Reader, "IssueDate"),
                ExpirationDate = clsDbHelper.GetValue<DateTime>(Reader, "ExpirationDate"),
                Notes = clsDbHelper.GetValue<string>(Reader, "Notes"),
                DriverID = clsDbHelper.GetValue<int>(Reader, "DriverID"),
                Gendor = clsPersonEnumConverter.ToGendor(clsDbHelper.GetValue<byte>(Reader, "Gendor"))
            };
        }
        public static int LoadCount(clsLicenseQuery clsQuery)
        {
            string Query = "Select Count (*) From InternationalLicenses Where 1 = 1 ";
            Query += clsQuery.SearchBy.HasValue && clsQuery.SearchValue != null
                ? $" AND {clsLicenseMapper.MapSearchBy(clsQuery.SearchBy.Value)} = @SearchValue"
                : "";

            _ApplyLicenseFilter(clsQuery.Filter, ref Query);
            return clsDbHelper.ExecuteScalar<int>(Query,
                Command =>
                {
                    clsDbHelper.SetValue(Command, "@SearchValue", clsQuery.SearchValue,
                        IsHasValue: clsQuery.SearchValue != null);

                    clsDbHelper.SetValue(Command, "@FromIssueDate",
                        clsQuery.Filter.FromIssueDate,
                        clsQuery.Filter.FromIssueDate.HasValue);

                    clsDbHelper.SetValue(Command, "@ToIssueDate",
                        clsQuery.Filter.ToIssueDate,
                        clsQuery.Filter.ToIssueDate.HasValue);

                    clsDbHelper.SetValue(Command, "@IsActive",
                        clsQuery.Filter.IsActive,
                        clsQuery.Filter.IsActive.HasValue);

                    clsDbHelper.SetValue(Command, "@FromExpirationDate",
                        clsQuery.Filter.FromExpirationDate,
                        clsQuery.Filter.FromExpirationDate.HasValue);

                    clsDbHelper.SetValue(Command, "@ToExpirationDate",
                        clsQuery.Filter.ToExpirationDate,
                        clsQuery.Filter.ToExpirationDate.HasValue);

                    clsDbHelper.SetValue(Command, "@LicenseClassID",
                        clsQuery.Filter.LicenseClassID,
                        clsQuery.Filter.LicenseClassID.HasValue);

                    clsDbHelper.SetValue(Command, "@IssueReason",
                        clsQuery.Filter.IssueReason,
                        clsQuery.Filter.IssueReason.HasValue);
                });
            
        }

        public static clsInternationalLicense_DTO LoadInternationalLicenseByID(int InternationalLicenseID)
        {
            clsInternationalLicense_DTO Model = null;


            string Query = @"SELECT * FROM InternationalLicenses 
                     WHERE InternationalLicenseID = @InternationalLicenseID";

            clsDbHelper.ExecuteReader(Query,
                Command => clsDbHelper.SetValue(Command, "@InternationalLicenseID", InternationalLicenseID),
                Reader =>
                {
                    Model = new clsInternationalLicense_DTO
                    {

                        InternationalLicenseID = InternationalLicenseID,
                        ApplicationID = clsDbHelper.GetValue<int>(Reader, "ApplicationID"),
                        DriverID = clsDbHelper.GetValue<int>(Reader, "DriverID"),
                        IssuedUsingLocalLicenseID = clsDbHelper.GetValue<int>(Reader, "IssuedUsingLocalLicenseID"),
                        IssueDate = clsDbHelper.GetValue<DateTime>(Reader, "IssueDate"),
                        ExpirationDate = clsDbHelper.GetValue<DateTime>(Reader, "ExpirationDate"),
                        IsActive = clsDbHelper.GetValue<bool>(Reader, "IsActive"),
                        CreatedByUserID = clsDbHelper.GetValue<int>(Reader, "CreatedByUserID")


                    };
                });

            return Model;
        }

        public static int AddNewInternationalLicense(clsInternationalLicense_DTO Model)
        {
            string Query = @"INSERT INTO InternationalLicenses (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedbyUserID)
                         Select @ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @IssueDate, @ExpirationDate, @IsActive, @CreatedbyUserID
                         Where Exists (Select 1 From Licenses Where LicenseID = @IssuedUsingLocalLicenseID And LicenseClassID = @LicenseClassID And IsActive = 1)
						 And Not Exists (Select 1 From InternationalLicenses Where
						 DriverID = @DriverID And IsActive = 1 And IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID);
                         IF @@ROWCOUNT > 0
							SELECT SCOPE_IDENTITY();
						ELSE
							SELECT -1
                         ;";

            return clsDbHelper.ExecuteScalar<int>(Query, Command =>
            {
                clsDbHelper.SetValue(Command, "@ApplicationID", Model.ApplicationID);
                clsDbHelper.SetValue(Command, "@DriverID", Model.DriverID);
                clsDbHelper.SetValue(Command, "@IssuedUsingLocalLicenseID", Model.IssuedUsingLocalLicenseID);
                clsDbHelper.SetValue(Command, "@IssueDate", Model.IssueDate);
                clsDbHelper.SetValue(Command, "@ExpirationDate", Model.ExpirationDate);
                clsDbHelper.SetValue(Command, "@IsActive", Model.IsActive);
                clsDbHelper.SetValue(Command, "@CreatedByUserID", Model.CreatedByUserID);
                clsDbHelper.SetValue(Command, "@LicenseClassID", clsLicenseEnumConverter.ToInt(clsLicenseEnums.enLicenseClasses.OrdinaryDrivingLicense));
            });
        }


        public static bool UpdateInternationalLicense(clsInternationalLicense_DTO Model)
        {
            string Query = @"UPDATE InternationalLicenses SET
                         IsActive = @IsActive
                         WHERE InternationalLicenseID = @InternationalLicenseID";

            int RowsAffected = clsDbHelper.ExecuteNonQuery(Query, Command =>
            {
                clsDbHelper.SetValue(Command, "@InternationalLicenseID", Model.InternationalLicenseID); 

                clsDbHelper.SetValue(Command, "@IsActive", Model.IsActive);

            });
            return RowsAffected > 0;
        }

        public static List<clsInternationalLicense_DTO> LoadInternationalLicenses()
        {
            string Query = "Select * From InternationalLicenses;";
            return clsDbHelper.ReadList<clsInternationalLicense_DTO>(Query, null,
                Reader => new clsInternationalLicense_DTO
                {
                    InternationalLicenseID = clsDbHelper.GetValue<int>(Reader, "InternationalLicenseID"),
                    ApplicationID = clsDbHelper.GetValue<int>(Reader, "ApplicationID"),
                    DriverID = clsDbHelper.GetValue<int>(Reader, "DriverID"),
                    IssuedUsingLocalLicenseID = clsDbHelper.GetValue<int>(Reader, "IssuedUsingLocalLicenseID"),
                    IssueDate = clsDbHelper.GetValue<DateTime>(Reader, "IssueDate"),
                    ExpirationDate = clsDbHelper.GetValue<DateTime>(Reader, "ExpirationDate"),
                    IsActive = clsDbHelper.GetValue<bool>(Reader, "IsActive"),
                    CreatedByUserID = clsDbHelper.GetValue<int>(Reader, "CreatedByUserID"),
                });
        }

        public static List<clsInternationalLicense_DTO> LoadInternationalLicenses(int Offset, int CountRows)
        {
            string Query = $@"SELECT * FROM InternationalLicenses 
                      ORDER BY InternationalLicenseID
                      OFFSET @Offset ROWS FETCH NEXT @CountRows ROWS ONLY;";

            return clsDbHelper.ReadList(Query,
                Command => {
                    clsDbHelper.SetValue(Command, "@Offset", Offset);
                    clsDbHelper.SetValue(Command, "@CountRows", CountRows);
                },
                Reader => new clsInternationalLicense_DTO
                {
                    InternationalLicenseID = clsDbHelper.GetValue<int>(Reader, "InternationalLicenseID"),
                    ApplicationID = clsDbHelper.GetValue<int>(Reader, "ApplicationID"),
                    DriverID = clsDbHelper.GetValue<int>(Reader, "DriverID"),
                    IssuedUsingLocalLicenseID = clsDbHelper.GetValue<int>(Reader, "IssuedUsingLocalLicenseID"),
                    IssueDate = clsDbHelper.GetValue<DateTime>(Reader, "IssueDate"),
                    ExpirationDate = clsDbHelper.GetValue<DateTime>(Reader, "ExpirationDate"),
                    IsActive = clsDbHelper.GetValue<bool>(Reader, "IsActive"),
                    CreatedByUserID = clsDbHelper.GetValue<int>(Reader, "CreatedByUserID"),

                });
        }
        public static List<clsLicenseCardInfo_DTO> LoadInternationalLicensesCardsInfo(int Offset, int CountRows)
        {
            string Query = @"Select P.FirstName , P.SecondName , P.ThirdName , P.LastName,
                        P.ImagePath ,P.NationalNo , P.DateOfBirth , P.Gendor ,
                        L.LicenseClassID , L.IsActive , 
                        L.IssueReason , L.IssueDate , L.ExpirationDate ,
                        L.Notes , L.DriverID From Licenses L
                        Join Drivers D ON L.DriverID = D.DriverID
                        Join People P ON D.PersonID = P.PersonID
                        Join InternationalLicenses IL ON IL.IssuedUsingLocalLicenseID = L.LicenseID
                        ORDER BY LicenseID
                        OFFSET @Offset ROWS FETCH NEXT @CountRows ROWS ONLY;"; ;

            return clsDbHelper.ReadList(Query,
                Command => {
                    clsDbHelper.SetValue(Command, "@Offset", Offset);
                    clsDbHelper.SetValue(Command, "@CountRows", CountRows);
                },
                Reader => _CardReader(Reader));
        }
        public static List<clsLicenseCardInfo_DTO> LoadInternationalLicensesCardsInfo(int Offset, int CountRows , clsLicenseQuery clsQuery)
        {
            string Query = @"Select IL.InternationalLicenseID, P.FirstName , P.SecondName , P.ThirdName , P.LastName,
                        P.ImagePath ,P.NationalNo , P.DateOfBirth , P.Gendor ,
                        L.LicenseClassID , L.IsActive , 
                        L.IssueReason , L.IssueDate , L.ExpirationDate ,
                        L.Notes , L.DriverID From Licenses L
                        Join Drivers D ON L.DriverID = D.DriverID
                        Join People P ON D.PersonID = P.PersonID
                        Join InternationalLicenses IL ON IL.IssuedUsingLocalLicenseID = L.LicenseID
                        Where 1 = 1  "; ;

            Query += clsQuery.SearchBy.HasValue && clsQuery.SearchValue != null
                ? $" AND {clsLicenseMapper.MapSearchBy(clsQuery.SearchBy.Value)} = @SearchValue"
                : "";

            _ApplyLicenseFilter(clsQuery.Filter, ref Query);

            Query += $@" ORDER BY {clsLicenseMapper.MapOrderBy(clsQuery.OrderBy)}
                 {clsOrderDirectionMapper.MapOrderDirection(clsQuery.OrderDirection)}
                 OFFSET @Offset ROWS FETCH NEXT @CountRows ROWS ONLY;";

            return clsDbHelper.ReadList(Query,
                Command =>
                {
                    clsDbHelper.SetValue(Command, "@SearchValue", clsQuery.SearchValue,
                        IsHasValue: clsQuery.SearchValue != null);

                    clsDbHelper.SetValue(Command, "@FromIssueDate",
                        clsQuery.Filter.FromIssueDate,
                        clsQuery.Filter.FromIssueDate.HasValue);

                    clsDbHelper.SetValue(Command, "@ToIssueDate",
                        clsQuery.Filter.ToIssueDate,
                        clsQuery.Filter.ToIssueDate.HasValue);

                    clsDbHelper.SetValue(Command, "@IsActive",
                        clsQuery.Filter.IsActive,
                        clsQuery.Filter.IsActive.HasValue);

                    clsDbHelper.SetValue(Command, "@FromExpirationDate",
                        clsQuery.Filter.FromExpirationDate,
                        clsQuery.Filter.FromExpirationDate.HasValue);

                    clsDbHelper.SetValue(Command, "@ToExpirationDate",
                        clsQuery.Filter.ToExpirationDate,
                        clsQuery.Filter.ToExpirationDate.HasValue);

                    clsDbHelper.SetValue(Command, "@LicenseClassID",
                        clsQuery.Filter.LicenseClassID,
                        clsQuery.Filter.LicenseClassID.HasValue);

                    clsDbHelper.SetValue(Command, "@IssueReason",
                        clsQuery.Filter.IssueReason,
                        clsQuery.Filter.IssueReason.HasValue);

                    clsDbHelper.SetValue(Command, "@Offset", Offset);
                    clsDbHelper.SetValue(Command, "@CountRows", CountRows);
                },
                Reader => _CardReader(Reader));
        }
        private static void _ApplyLicenseFilter(clsLicenseFilter filter, ref string query)
        {
            if (filter == null) return;

            MappingHelper.AddCondition(filter.LicenseClassID.HasValue,
                "LicenseClassID = @LicenseClassID",
                ref query);

            MappingHelper.AddCondition(filter.IsActive.HasValue,
                "IsActive = @IsActive",
                ref query);

            MappingHelper.AddCondition(filter.IssueReason.HasValue,
                "IssueReason = @IssueReason",
                ref query);

            MappingHelper.ApplyDateRange(filter.FromIssueDate, filter.ToIssueDate,
                "IssueDate",
                ref query);

            MappingHelper.ApplyDateRange(filter.FromExpirationDate, filter.ToExpirationDate,
                "ExpirationDate",
                ref query);
        }
        public static bool DeleteInternationalLicenseByID(int InternationalLicenseID)
        {
            string Query = "DELETE FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";
            int RowsAffected = clsDbHelper.ExecuteNonQuery(Query, Command => clsDbHelper.SetValue(Command, "@InternationalLicenseID", InternationalLicenseID));
            return RowsAffected > 0;
        }

        public static bool DeleteByUserID(int CreatedByUserID)
        {
            int RowsAffected = 0;
            string QueryLicensesTable = @"Delete From InternationalLicenses Where CreatedByUserID = @CreatedByUserID;";

            RowsAffected = clsDbHelper.ExecuteNonQuery(QueryLicensesTable, Command =>
            {
                clsDbHelper.SetValue<int>(Command, "@CreatedByUserID", CreatedByUserID);
            });

            return RowsAffected > 0;
        }
        public static int LoadPersonIDByInternationalLicenseID(int InternationalLicenseID)
        {
            string Query = @"Select D.PersonID From InternationalLicenses IL
                        Join Drivers D ON D.DriverID = IL.DriverID
                        Where InternationalLicenseID = @InternationalLicenseID;";
            return clsDbHelper.ExecuteScalar<int>(Query, Command => clsDbHelper.SetValue(Command, "@InternationalLicenseID", InternationalLicenseID));
        }
    }
}
