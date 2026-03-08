using Common;
using Common.Filters;
using Common.Helpers;
using Common.Queries;
using DVLD_DAL.Mappers;
using DVLD_DTOs;
using DVLD_DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public class clsDetainedLicense_DAL
    {
        private static clsDetainedLicense_DTO _Reader(SqlDataReader Reader)
        {
            return new clsDetainedLicense_DTO
            {
                DetainID = clsDbHelper.GetValue<int>(Reader, "DetainID"),
                LicenseID = clsDbHelper.GetValue<int>(Reader, "LicenseID"),
                ReleaseDate = clsDbHelper.GetValue<DateTime>(Reader, "ReleaseDate"),
                IsReleased = clsDbHelper.GetValue<bool>(Reader, "IsReleased"),
                PaidFees = clsDbHelper.GetValue<decimal>(Reader, "PaidFees"),
                DetainDate = clsDbHelper.GetValue<DateTime>(Reader, "DetainDate"),
                CreatedByUserID = clsDbHelper.GetValue<int>(Reader, "CreatedByUserID"),
                ReleaseApplicationID = clsDbHelper.GetValue<int>(Reader, "ReleaseApplicationID"),
                ReleasedByUserID = clsDbHelper.GetValue<int>(Reader, "ReleasedByUserID"),
            };
        }
        private static clsLicenseCardInfo_DTO _CardReader(SqlDataReader Reader)
        {
            return new clsLicenseCardInfo_DTO
            {
                LicenseID = clsDbHelper.GetValue<int>(Reader, "LicenseID"),
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
                DriverID = clsDbHelper.GetValue<int>(Reader, "DriverID")
            };
        }
        public static int LoadCount(clsDetainedLicenseQuery clsQuery)
        {
            string Query = "Select Count (*) From DetainedLicenses Where 1 = 1  ";
            Query += clsQuery.SearchBy.HasValue && clsQuery.SearchValue != null
                ? $" AND {clsDetainedLicenseMapper.MapSearchBy(clsQuery.SearchBy.Value)} = @SearchValue"
                : "";

            _ApplyDetainedLicenseFilter(clsQuery.Filter, ref Query);


            return clsDbHelper.ExecuteScalar<int>(Query,
                Command =>
                {
                    clsDbHelper.SetValue(Command, "@SearchValue", clsQuery.SearchValue,
                        IsHasValue: clsQuery.SearchValue != null);

                    clsDbHelper.SetValue(Command, "@FromDetainDate",
                        clsQuery.Filter.FromDetainDate,
                        clsQuery.Filter.FromDetainDate.HasValue);

                    clsDbHelper.SetValue(Command, "@ToDetainDate",
                        clsQuery.Filter.ToDetainDate,
                        clsQuery.Filter.ToDetainDate.HasValue);

                    clsDbHelper.SetValue(Command, "@FromReleaseDate",
                        clsQuery.Filter.FromReleaseDate,
                        clsQuery.Filter.FromReleaseDate.HasValue);

                    clsDbHelper.SetValue(Command, "@ToReleaseDate",
                        clsQuery.Filter.ToReleaseDate,
                        clsQuery.Filter.ToReleaseDate.HasValue);

                    clsDbHelper.SetValue(Command, "@IsReleased",
                        clsQuery.Filter.IsReleased,
                        clsQuery.Filter.IsReleased.HasValue);

                });
        }

        public static clsDetainedLicense_DTO LoadDetainedLicenseByID(int DetainID)
        {
            clsDetainedLicense_DTO Model = null;
            string Query = "SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID";

            clsDbHelper.ExecuteReader(Query, Command => clsDbHelper.SetValue(Command, "@DetainID", DetainID),
                Reader =>
                {
                    Model = _Reader(Reader);
                });
            return Model;
        }
        public static clsDetainedLicense_DTO LoadDetainedLicenseByLicenseID(int LicenseID)
        {
            clsDetainedLicense_DTO Model = null;
            string Query = "SELECT * FROM DetainedLicenses WHERE LicenseID = @LicenseID And IsReleased = 0";

            clsDbHelper.ExecuteReader(Query, Command => clsDbHelper.SetValue(Command, "@LicenseID", LicenseID),
                Reader =>
                {
                    Model = _Reader(Reader);
                });
            return Model;
        }

        // إضافة احتجاز رخصة جديدة
        public static int AddNewDetainedLicense(clsDetainedLicense_DTO Model)
        {
            string Query = @"INSERT INTO DetainedLicenses (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased)
                         Select @LicenseID, @DetainDate, @FineFees, @CreatedByUserID, 0
                         WHERE NOT EXISTS 
                         (
                            SELECT 1 FROM DetainedLicenses 
                            WHERE LicenseID = @LicenseID AND IsReleased = 0
                         );
                         IF @@ROWCOUNT > 0
                            SELECT SCOPE_IDENTITY();
                         ELSE
                            SELECT -1;";

            return clsDbHelper.ExecuteScalar<int>(Query, Command =>
            {
                clsDbHelper.SetValue(Command, "@LicenseID", Model.LicenseID);
                clsDbHelper.SetValue(Command, "@DetainDate", Model.DetainDate);
                clsDbHelper.SetValue(Command, "@FineFees", Model.PaidFees);
                clsDbHelper.SetValue(Command, "@CreatedByUserID", Model.CreatedByUserID);

            });
        }


        public static bool UpdateDetainedLicense(clsDetainedLicense_DTO Model)
        {
            string Query = @"UPDATE DetainedLicenses SET FineFees = @FineFees,
                         CreatedByUserID = @CreatedByUserID
                         WHERE DetainID = @DetainID;";

            int RowsAffected = clsDbHelper.ExecuteNonQuery(Query, Command =>
            {
                clsDbHelper.SetValue(Command, "@DetainID", Model.DetainID); // شرط التحديث
                clsDbHelper.SetValue(Command, "@FineFees", Model.PaidFees);
                clsDbHelper.SetValue(Command, "@CreatedByUserID", Model.CreatedByUserID);
            });
            return RowsAffected > 0;
        }

        public static bool IsReleaseLicenseByLicenseID(int LicenseID)
        {
            string Query = "Select IsReleased From DetainedLicenses Where LicenseID = @LicenseID;";
            return clsDbHelper.Exists(Query, Command => clsDbHelper.SetValue(Command, "@LicenseID", LicenseID));
        }

        public static bool IsReleaseLicense(int DetainID)
        {
            string Query = "Select IsReleased From DetainedLicenses Where DetainID = @DetainID;";
            return clsDbHelper.Exists(Query, Command => clsDbHelper.SetValue(Command, "@DetainID", DetainID));
        }
        public static bool ReleaseLicense(clsDetainedLicense_DTO Model)
        {
            string Query = @"UPDATE DetainedLicenses 
                             SET IsReleased = 1, 
                                 ReleaseDate = @ReleaseDate, 
                                 ReleaseApplicationID = @ReleaseApplicationID, 
                                 ReleasedByUserID = @ReleasedByUserID
                             WHERE LicenseID = @LicenseID AND IsReleased = 0;";
            int RowsAffected = clsDbHelper.ExecuteNonQuery(Query, Command =>
            {

                clsDbHelper.SetValue(Command, "@LicenseID", Model.LicenseID);
                clsDbHelper.SetValue(Command, "@ReleaseDate", Model.ReleaseDate);
                clsDbHelper.SetValue(Command, "@ReleasedByUserID", Model.ReleasedByUserID);
                clsDbHelper.SetValue(Command, "@ReleaseApplicationID", Model.ReleaseApplicationID);
            });
            return RowsAffected > 0;
        }

        // حذف احتجاز رخصة
        public static bool DeleteDetainedLicenseByID(int DetainID)
        {
            string Query = "DELETE FROM DetainedLicenses WHERE DetainID = @DetainID";
            int RowsAffected = clsDbHelper.ExecuteNonQuery(Query, Command => clsDbHelper.SetValue(Command, "@DetainID", DetainID));
            return RowsAffected > 0;
        }



        public static bool DeleteByUserID(int CreatedByUserID)
        {
            int RowsAffected = 0;
            string QueryLicensesTable = @"Delete From DetainedLicenses Where CreatedByUserID = @CreatedByUserID OR ReleasedByUserID = @CreatedByUserID;";

            RowsAffected = clsDbHelper.ExecuteNonQuery(QueryLicensesTable, Command =>
            {
                clsDbHelper.SetValue<int>(Command, "@CreatedByUserID", CreatedByUserID);
            });

            return RowsAffected > 0;
        }

        public static List<clsDetainedLicense_DTO> LoadDetainedLicenses()
        {
            string Query = "Select * From DetainedLicenses ;";
            return clsDbHelper.ReadList(Query, null,
                Reader => _Reader(Reader));
        }
        public static List<clsDetainedLicense_DTO> LoadDetainedLicenses(int Offset, int CountRows)
        {
            string Query = $@"SELECT * FROM DetainedLicenses 
                      ORDER BY DetainID
                      OFFSET @Offset ROWS FETCH NEXT @CountRows ROWS ONLY;";

            return clsDbHelper.ReadList(Query,
                Command => {
                    clsDbHelper.SetValue(Command, "@Offset", Offset);
                    clsDbHelper.SetValue(Command, "@CountRows", CountRows);
                },
                Reader => _Reader(Reader));
        }
        public static List<clsLicenseCardInfo_DTO> LoadDetainedLicensesCardsInfo(int Offset, int CountRows)
        {
            string Query = @"Select P.FirstName , P.SecondName , P.ThirdName , P.LastName,
                        P.ImagePath ,P.NationalNo , P.DateOfBirth , P.Gendor ,
                        L.LicenseClassID , L.IsActive , 
                        L.IssueReason , L.IssueDate , L.ExpirationDate ,
                        L.Notes , L.DriverID From Licenses L
                        Join Drivers D ON L.DriverID = D.DriverID
                        Join People P ON D.PersonID = P.PersonID
                        Join DetainedLicenses DL ON DL.LicenseID = L.LicenseID
                        ORDER BY L.LicenseID
                        OFFSET @Offset ROWS FETCH NEXT @CountRows ROWS ONLY;";

            return clsDbHelper.ReadList(Query,
                Command => {
                    clsDbHelper.SetValue(Command, "@Offset", Offset);
                    clsDbHelper.SetValue(Command, "@CountRows", CountRows);
                },
                Reader => _CardReader(Reader));
        }
        public static List<clsLicenseCardInfo_DTO> LoadDetainedLicensesCardsInfo(int Offset, int CountRows, clsDetainedLicenseQuery clsQuery)
        {
            string Query = @"SELECT 
                                    P.FirstName , P.SecondName , P.ThirdName , P.LastName,
                                    P.ImagePath ,P.NationalNo , P.DateOfBirth , P.Gendor ,
                                    L.LicenseClassID , L.IsActive , 
                                    L.IssueReason , L.IssueDate , L.ExpirationDate ,
                                    L.Notes , L.DriverID , L.LicenseID
                                    FROM Licenses L
                                    JOIN Drivers D ON L.DriverID = D.DriverID
                                    JOIN People P ON D.PersonID = P.PersonID
                                    JOIN DetainedLicenses DL ON DL.LicenseID = L.LicenseID
                                    WHERE 1 = 1 ";

            Query += clsQuery.SearchBy.HasValue && clsQuery.SearchValue != null
                ? $" AND {clsDetainedLicenseMapper.MapSearchBy(clsQuery.SearchBy.Value)} = @SearchValue"
                : "";

            _ApplyDetainedLicenseFilter(clsQuery.Filter, ref Query);

            Query += $@" ORDER BY {clsDetainedLicenseMapper.MapOrderBy(clsQuery.OrderBy)}
                 {clsOrderDirectionMapper.MapOrderDirection(clsQuery.OrderDirection)}
                 OFFSET @Offset ROWS FETCH NEXT @CountRows ROWS ONLY;";

            return clsDbHelper.ReadList(Query,
                Command =>
                {
                    clsDbHelper.SetValue(Command, "@SearchValue", clsQuery.SearchValue,
                        IsHasValue: clsQuery.SearchValue != null);

                    clsDbHelper.SetValue(Command, "@FromDetainDate",
                        clsQuery.Filter.FromDetainDate,
                        clsQuery.Filter.FromDetainDate.HasValue);

                    clsDbHelper.SetValue(Command, "@ToDetainDate",
                        clsQuery.Filter.ToDetainDate,
                        clsQuery.Filter.ToDetainDate.HasValue);

                    clsDbHelper.SetValue(Command, "@FromReleaseDate",
                        clsQuery.Filter.FromReleaseDate,
                        clsQuery.Filter.FromReleaseDate.HasValue);

                    clsDbHelper.SetValue(Command, "@ToReleaseDate",
                        clsQuery.Filter.ToReleaseDate,
                        clsQuery.Filter.ToReleaseDate.HasValue);

                    clsDbHelper.SetValue(Command, "@IsReleased",
                        clsQuery.Filter.IsReleased,
                        clsQuery.Filter.IsReleased.HasValue);

                    clsDbHelper.SetValue(Command, "@Offset", Offset);
                    clsDbHelper.SetValue(Command, "@CountRows", CountRows);
                },
                Reader => _CardReader(Reader));
        }

        private static void _ApplyDetainedLicenseFilter(clsDetainedLicenseFilter filter,ref string query)
        {
            if (filter == null)return;

            MappingHelper.ApplyDateRange(
                filter.FromDetainDate,
                filter.ToDetainDate,
                "DetainDate",
                ref query);

            MappingHelper.AddCondition(
                filter.IsReleased.HasValue,
                "IsReleased = @IsReleased",
                ref query);

            MappingHelper.ApplyDateRange(
                filter.FromReleaseDate,
                filter.ToReleaseDate,
                "ReleaseDate",
                ref query);
        }
        public static int LoadPersonIDByDetainID(int DetainID)
        {
            string Query = @"Select D.PersonID From DetainedLicenses DL
                        Join Licenses L ON L.LicenseID = DL.LicenseID
                        Join Drivers D ON L.DriverID = D.DriverID
                        Where DetainID = @DetainID;";
            return clsDbHelper.ExecuteScalar<int>(Query, Command => clsDbHelper.SetValue(Command, "@DetainID", DetainID));
        }
    }
}

