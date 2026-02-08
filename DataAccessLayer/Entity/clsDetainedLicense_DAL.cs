using Common;
using Common.Filters;
using Common.Helpers;
using Common.Queries;
using DVLD_DAL.Mappers;
using DVLD_DTO;
using DVLD_Models;
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
                DetainID = DbHelper.GetValue<int>(Reader, "DetainID"),
                LicenseID = DbHelper.GetValue<int>(Reader, "LicenseID"),
                ReleaseDate = DbHelper.GetValue<DateTime>(Reader, "ReleaseDate"),
                IsReleased = DbHelper.GetValue<bool>(Reader, "IsReleased"),
                PaidFees = DbHelper.GetValue<decimal>(Reader, "PaidFees"),
                DetainDate = DbHelper.GetValue<DateTime>(Reader, "DetainDate"),
                CreatedByUserID = DbHelper.GetValue<int>(Reader, "CreatedByUserID"),
                ReleaseApplicationID = DbHelper.GetValue<int>(Reader, "ReleaseApplicationID"),
                ReleasedByUserID = DbHelper.GetValue<int>(Reader, "ReleasedByUserID"),
            };
        }
        private static clsLicenseCardInfo_DTO _CardReader(SqlDataReader Reader)
        {
            return new clsLicenseCardInfo_DTO
            {
                LicenseID = DbHelper.GetValue<int>(Reader, "LicenseID"),
                FirstName = DbHelper.GetValue<string>(Reader, "FirstName"),
                SecondName = DbHelper.GetValue<string>(Reader, "SecondName"),
                ThirdName = DbHelper.GetValue<string>(Reader, "ThirdName"),
                LastName = DbHelper.GetValue<string>(Reader, "LastName"),
                ImagePath = DbHelper.GetValue<string>(Reader, "ImagePath"),
                NationalNo = DbHelper.GetValue<string>(Reader, "NationalNo"),
                DateOfBirth = DbHelper.GetValue<DateTime>(Reader, "DateOfBirth"),
                LicenseClass = clsLicenseEnumConverter.ToClass(DbHelper.GetValue<int>(Reader, "LicenseClassID")),
                IsActive = DbHelper.GetValue<bool>(Reader, "IsActive"),
                IssueReason = clsLicenseEnumConverter.ToIssueReason(DbHelper.GetValue<byte>(Reader, "IssueReason")),
                IssueDate = DbHelper.GetValue<DateTime>(Reader, "IssueDate"),
                ExpirationDate = DbHelper.GetValue<DateTime>(Reader, "ExpirationDate"),
                Notes = DbHelper.GetValue<string>(Reader, "Notes"),
                DriverID = DbHelper.GetValue<int>(Reader, "DriverID")
            };
        }
        public static int LoadCount()
        {
            string Query = "Select Count (*) From DetainedLicenses;";
            return DbHelper.ExecuteScalar<int>(Query, null);
        }

        public static clsDetainedLicense_DTO LoadDetainedLicenseByID(int DetainID)
        {
            clsDetainedLicense_DTO Model = null;
            string Query = "SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID";

            DbHelper.ExecuteReader(Query, Command => DbHelper.SetValue(Command, "@DetainID", DetainID),
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

            return DbHelper.ExecuteScalar<int>(Query, Command =>
            {
                DbHelper.SetValue(Command, "@LicenseID", Model.LicenseID);
                DbHelper.SetValue(Command, "@DetainDate", Model.DetainDate);
                DbHelper.SetValue(Command, "@FineFees", Model.PaidFees);
                DbHelper.SetValue(Command, "@CreatedByUserID", Model.CreatedByUserID);

            });
        }


        public static bool UpdateDetainedLicense(clsDetainedLicense_DTO Model)
        {
            string Query = @"UPDATE DetainedLicenses SET FineFees = @FineFees,
                         CreatedByUserID = @CreatedByUserID
                         WHERE DetainID = @DetainID;";

            int RowsAffected = DbHelper.ExecuteNonQuery(Query, Command =>
            {
                DbHelper.SetValue(Command, "@DetainID", Model.DetainID); // شرط التحديث
                DbHelper.SetValue(Command, "@FineFees", Model.PaidFees);
                DbHelper.SetValue(Command, "@CreatedByUserID", Model.CreatedByUserID);
            });
            return RowsAffected > 0;
        }

        public static bool IsReleaseLicenseByLicenseID(int LicenseID)
        {
            string Query = "Select IsReleased From DetainedLicenses Where LicenseID = @LicenseID;";
            return DbHelper.Exists(Query, Command => DbHelper.SetValue(Command, "@LicenseID", LicenseID));
        }

        public static bool IsReleaseLicense(int DetainID)
        {
            string Query = "Select IsReleased From DetainedLicenses Where DetainID = @DetainID;";
            return DbHelper.Exists(Query, Command => DbHelper.SetValue(Command, "@DetainID", DetainID));
        }
        public static bool ReleaseLicense(clsDetainedLicense_DTO Model)
        {
            string Query = @"UPDATE DetainedLicenses 
                             SET IsReleased = 1, 
                                 ReleaseDate = @ReleaseDate, 
                                 ReleaseApplicationID = @ReleaseApplicationID, 
                                 ReleasedByUserID = @ReleasedByUserID
                             WHERE LicenseID = @LicenseID AND IsReleased = 0;";
            int RowsAffected = DbHelper.ExecuteNonQuery(Query, Command =>
            {

                DbHelper.SetValue(Command, "@LicenseID", Model.LicenseID);
                DbHelper.SetValue(Command, "@ReleaseDate", Model.ReleaseDate);
                DbHelper.SetValue(Command, "@ReleasedByUserID", Model.ReleasedByUserID);
                DbHelper.SetValue(Command, "@ReleaseApplicationID", Model.ReleaseApplicationID);
            });
            return RowsAffected > 0;
        }

        // حذف احتجاز رخصة
        public static bool DeleteDetainedLicenseByID(int DetainID)
        {
            string Query = "DELETE FROM DetainedLicenses WHERE DetainID = @DetainID";
            int RowsAffected = DbHelper.ExecuteNonQuery(Query, Command => DbHelper.SetValue(Command, "@DetainID", DetainID));
            return RowsAffected > 0;
        }



        public static bool DeleteByUserID(int CreatedByUserID)
        {
            int RowsAffected = 0;
            string QueryLicensesTable = @"Delete From DetainedLicenses Where CreatedByUserID = @CreatedByUserID OR ReleasedByUserID = @CreatedByUserID;";

            RowsAffected = DbHelper.ExecuteNonQuery(QueryLicensesTable, Command =>
            {
                DbHelper.SetValue<int>(Command, "@CreatedByUserID", CreatedByUserID);
            });

            return RowsAffected > 0;
        }

        public static List<clsDetainedLicense_DTO> LoadDetainedLicenses()
        {
            string Query = "Select * From DetainedLicenses ;";
            return DbHelper.ReadList(Query, null,
                Reader => _Reader(Reader));
        }
        public static List<clsDetainedLicense_DTO> LoadDetainedLicenses(int Offset, int CountRows)
        {
            string Query = $@"SELECT * FROM DetainedLicenses 
                      ORDER BY DetainID
                      OFFSET @Offset ROWS FETCH NEXT @CountRows ROWS ONLY;";

            return DbHelper.ReadList(Query,
                Command => {
                    DbHelper.SetValue(Command, "@Offset", Offset);
                    DbHelper.SetValue(Command, "@CountRows", CountRows);
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

            return DbHelper.ReadList(Query,
                Command => {
                    DbHelper.SetValue(Command, "@Offset", Offset);
                    DbHelper.SetValue(Command, "@CountRows", CountRows);
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

            Query += clsQuery.SearchBy.HasValue
                ? $" AND {clsDetainedLicenseMapper.MapSearchBy(clsQuery.SearchBy.Value)} = @SearchValue"
                : "";

            _ApplyDetainedLicenseFilter(clsQuery.Filter, ref Query);

            Query += $@" ORDER BY {clsDetainedLicenseMapper.MapOrderBy(clsQuery.OrderBy)}
                 {clsOrderDirectionMapper.MapOrderDirection(clsQuery.OrderDirection)}
                 OFFSET @Offset ROWS FETCH NEXT @CountRows ROWS ONLY;";

            return DbHelper.ReadList(Query,
                Command =>
                {
                    DbHelper.SetValue(Command, "@SearchValue", clsQuery.SearchValue,
                        IsHasValue: clsQuery.SearchValue != null);

                    DbHelper.SetValue(Command, "@FromDetainDate",
                        clsQuery.Filter.FromDetainDate,
                        clsQuery.Filter.FromDetainDate.HasValue);

                    DbHelper.SetValue(Command, "@ToDetainDate",
                        clsQuery.Filter.ToDetainDate,
                        clsQuery.Filter.ToDetainDate.HasValue);

                    DbHelper.SetValue(Command, "@FromReleaseDate",
                        clsQuery.Filter.FromReleaseDate,
                        clsQuery.Filter.FromReleaseDate.HasValue);

                    DbHelper.SetValue(Command, "@ToReleaseDate",
                        clsQuery.Filter.ToReleaseDate,
                        clsQuery.Filter.ToReleaseDate.HasValue);

                    DbHelper.SetValue(Command, "@IsReleased",
                        clsQuery.Filter.IsReleased,
                        clsQuery.Filter.IsReleased.HasValue);

                    DbHelper.SetValue(Command, "@Offset", Offset);
                    DbHelper.SetValue(Command, "@CountRows", CountRows);
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

    }
}

