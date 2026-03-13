using Common;
using Common.Filters;
using Common.Helpers;
using Common.Queries;
using DVLD_DAL.Mappers;
using DVLD_DTOs;
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
    public class clsLicense_DAL
    {
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
                DriverID = clsDbHelper.GetValue<int>(Reader, "DriverID"),
                Gendor = clsPersonEnumConverter.ToGendor(clsDbHelper.GetValue<byte>(Reader, "Gendor"))
            };
        }
        public static int LoadCount(clsLicenseQuery clsQuery)
        {
            string Query = "Select Count (*) From Licenses Where 1 = 1 ";
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
        public static clsLicense_DTO LoadLicenseInfoByID(int LicenseID)
        {
            clsLicense_DTO Model = null;
            string Query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID";


            bool IsFound = clsDbHelper.ExecuteReader(Query, Command => clsDbHelper.SetValue<int>(Command, "@LicenseID", LicenseID),
                Reader =>
                {
                    Model = new clsLicense_DTO
                    {
                        LicenseID = LicenseID,
                        ApplicationID = clsDbHelper.GetValue<int>(Reader, "ApplicationID"),
                        DriverID = clsDbHelper.GetValue<int>(Reader, "DriverID"),
                        LicenseClass = clsLicenseEnumConverter.ToClass(clsDbHelper.GetValue<int>(Reader, "LicenseClassID")),
                        IssueDate = clsDbHelper.GetValue<DateTime>(Reader, "IssueDate"),
                        ExpirationDate = clsDbHelper.GetValue<DateTime>(Reader, "ExpirationDate"),
                        Notes = clsDbHelper.GetValue<string>(Reader, "Notes"),
                        PaidFees = clsDbHelper.GetValue<decimal>(Reader, "PaidFees"),
                        IsActive = clsDbHelper.GetValue<bool>(Reader, "IsActive"),
                        IssueReason = clsLicenseEnumConverter.ToIssueReason(clsDbHelper.GetValue<byte>(Reader, "IssueReason")),
                        CreatedByUserID = clsDbHelper.GetValue<int>(Reader, "CreatedByUserID")
                    };
                });

            return IsFound ? Model : null;
        }


        public static clsLicense_DTO LoadLicenseInfoByDriverID(int DriverID)
        {
            string Query = "SELECT LicenseID FROM Licenses WHERE DriverID = @DriverID";
            int LicenseID = -1;

            if (clsDbHelper.FindID<int>(Query, "@DriverID", DriverID, ref LicenseID))
            {
                return LoadLicenseInfoByID(LicenseID);
            }

            return null;
        }

        public static int LoadDriverIDByLicenseID(int LicenseID)
        {
            string Query = "Select DriverID From Licenses Where LicenseID = @LicenseID ;";
            return clsDbHelper.ExecuteScalar<int>(Query, Command => clsDbHelper.SetValue(Command, "@LicenseID", LicenseID));
        }
        public static int LoadPersonIDByLicenseID(int LicenseID)
        {
            string Query = @"Select D.PersonID From Licenses L
                        Join Drivers D ON L.DriverID = D.DriverID
                        Where L.LicenseID = @LicenseID ;";
            return clsDbHelper.ExecuteScalar<int>(Query, Command => clsDbHelper.SetValue(Command, "@LicenseID", LicenseID));
        }

        public static clsLicenseCardInfo_DTO LoadLicenseCardInfo(int LicenseID)
        {
            clsLicenseCardInfo_DTO Card = null;
            string Query = @"Select P.FirstName , P.SecondName , P.ThirdName , P.LastName,
                        P.ImagePath ,P.NationalNo , P.DateOfBirth , P.Gendor ,
                        L.LicenseClassID , L.IsActive , 
                        L.IssueReason , L.IssueDate , L.ExpirationDate ,
                        L.Notes , L.DriverID From Licenses L
                        Join Drivers D ON L.DriverID = D.DriverID
                        Join People P ON D.PersonID = P.PersonID
                        Where L.LicenseID = @LicenseID;";
            bool IsFound = clsDbHelper.ExecuteReader(Query, Command => clsDbHelper.SetValue(Command, "@LicenseID", LicenseID),
                Reader =>
                {
                    Card = new clsLicenseCardInfo_DTO
                    {
                        LicenseID = LicenseID,
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
                );
            return IsFound ? Card : null;
        }
        public static int AddNewLicense(clsLicense_DTO Model)
        {
            int NewLicenseID = -1;

            string Query = @"
                        INSERT INTO Licenses (ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
                        Select @ApplicationID, @DriverID, @LicenseClassID, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID
                        Where Not Exists 
                        (
                            Select 1 From Licenses Where DriverID = @DriverID And LicenseClassID = @LicenseClassID And IsActive = 1
                        );
                        IF @@ROWCOUNT > 0
                            SELECT SCOPE_IDENTITY();
                        ELSE
                            SELECT -1;";


            NewLicenseID = clsDbHelper.ExecuteScalar<int>(Query, Command =>
            {

                clsDbHelper.SetValue<int>(Command, "@ApplicationID", Model.ApplicationID);
                clsDbHelper.SetValue<int>(Command, "@DriverID", Model.DriverID);
                clsDbHelper.SetValue<int>(Command, "@LicenseClassID", clsLicenseEnumConverter.ToInt(Model.LicenseClass));
                clsDbHelper.SetValue<DateTime>(Command, "@IssueDate", Model.IssueDate);
                clsDbHelper.SetValue<DateTime>(Command, "@ExpirationDate", Model.ExpirationDate);
                clsDbHelper.SetValue<string>(Command, "@Notes", Model.Notes, AllowNull: true);
                clsDbHelper.SetValue<decimal>(Command, "@PaidFees", Model.PaidFees);
                clsDbHelper.SetValue<bool>(Command, "@IsActive", Model.IsActive);
                clsDbHelper.SetValue<byte>(Command, "@IssueReason", clsLicenseEnumConverter.ToByte(Model.IssueReason));
                clsDbHelper.SetValue<int>(Command, "@CreatedByUserID", Model.CreatedByUserID);
            });

            return NewLicenseID;
        }


        public static bool UpdateLicense(clsLicense_DTO Model)
        {
            string Query = @"
                        UPDATE Licenses SET Notes = @Notes, IsActive = @IsActive
                        WHERE LicenseID = @LicenseID And Not Exists 
                        ( Select 1 From Licenses
                        Where DriverID = @DriverID 
                        And LicenseClassID = @LicenseClassID
                        And IsActive = 1
                        AND LicenseID <> @LicenseID)";
            int RowsAffected = clsDbHelper.ExecuteNonQuery(Query, Command =>
            {

                clsDbHelper.SetValue<int>(Command, "@LicenseID", Model.LicenseID);

                clsDbHelper.SetValue<string>(Command, "@Notes", Model.Notes, AllowNull: true);
                clsDbHelper.SetValue<bool>(Command, "@IsActive", Model.IsActive);
                clsDbHelper.SetValue<int>(Command, "@CreatedByUserID", Model.CreatedByUserID);
                clsDbHelper.SetValue<int>(Command, "@DriverID", Model.DriverID);
                clsDbHelper.SetValue<int>(Command, "@LicenseClassID", Model.LicenseClassID);
            });

            return RowsAffected > 0;
        }


        public static bool DeleteLicenseByID(int LicenseID)
        {

            int RowsAffected = 0;
            string Query = "DELETE FROM Licenses WHERE LicenseID = @LicenseID";

            RowsAffected = clsDbHelper.ExecuteNonQuery(Query, Command =>
            {
                clsDbHelper.SetValue<int>(Command, "@LicenseID", LicenseID);
            });

            return RowsAffected > 0;
        }

        public static bool DeleteLicenseByLicenseClassID(int LicenseClassID)
        {

            int RowsAffected = 0;
            string Query = "DELETE FROM Licenses WHERE LicenseClassID = @LicenseClassID";

            RowsAffected = clsDbHelper.ExecuteNonQuery(Query, Command =>
            {
                clsDbHelper.SetValue<int>(Command, "@LicenseClassID", LicenseClassID);
            });

            return RowsAffected > 0;
        }

        public static bool DeleteLicenseByApplicationID(int ApplicationID)
        {

            int RowsAffected = 0;
            string Query = "DELETE FROM Licenses WHERE ApplicationID = @ApplicationID";

            RowsAffected = clsDbHelper.ExecuteNonQuery(Query, Command =>
            {
                clsDbHelper.SetValue<int>(Command, "@ApplicationID", ApplicationID);
            });

            return RowsAffected > 0;
        }


        public static bool DeleteByUserID(int CreatedByUserID)
        {
            int RowsAffected = 0;
            string QueryLicensesTable = @"Delete From Licenses Where CreatedByUserID = @CreatedByUserID;";

            RowsAffected = clsDbHelper.ExecuteNonQuery(QueryLicensesTable, Command =>
            {
                clsDbHelper.SetValue<int>(Command, "@CreatedByUserID", CreatedByUserID);
            });

            return RowsAffected > 0;
        }



        public static List<clsLicense_DTO> LoadLicenses()
        {
            string Query = "SELECT * FROM Licenses;";

            return clsDbHelper.ReadList(Query, null,
                Reader => new clsLicense_DTO
                {
                    LicenseID = clsDbHelper.GetValue<int>(Reader, "LicenseID"),
                    ApplicationID = clsDbHelper.GetValue<int>(Reader, "ApplicationID"),
                    DriverID = clsDbHelper.GetValue<int>(Reader, "DriverID"),
                    LicenseClass = clsLicenseEnumConverter.ToClass(clsDbHelper.GetValue<int>(Reader, "LicenseClassID")),
                    IssueDate = clsDbHelper.GetValue<DateTime>(Reader, "IssueDate"),
                    ExpirationDate = clsDbHelper.GetValue<DateTime>(Reader, "ExpirationDate"),
                    Notes = clsDbHelper.GetValue<string>(Reader, "Notes"),
                    PaidFees = clsDbHelper.GetValue<decimal>(Reader, "PaidFees"),
                    IsActive = clsDbHelper.GetValue<bool>(Reader, "IsActive"),
                    IssueReason = clsLicenseEnumConverter.ToIssueReason(clsDbHelper.GetValue<byte>(Reader, "IssueReason")),
                    CreatedByUserID = clsDbHelper.GetValue<int>(Reader, "CreatedByUserID")
                });
        }
        public static List<clsLicense_DTO> LoadLicenses(int Offset, int CountRows)
        {
            string Query = $@"SELECT * FROM Licenses
                      ORDER BY LicenseID
                      OFFSET @Offset ROWS FETCH NEXT @CountRows ROWS ONLY;";

            return clsDbHelper.ReadList(Query,
                Command => {
                    clsDbHelper.SetValue(Command, "@Offset", Offset);
                    clsDbHelper.SetValue(Command, "@CountRows", CountRows);
                },
                Reader => new clsLicense_DTO
                {
                    LicenseID = clsDbHelper.GetValue<int>(Reader, "LicenseID"),
                    ApplicationID = clsDbHelper.GetValue<int>(Reader, "ApplicationID"),
                    DriverID = clsDbHelper.GetValue<int>(Reader, "DriverID"),
                    LicenseClass = clsLicenseEnumConverter.ToClass(clsDbHelper.GetValue<int>(Reader, "LicenseClassID")),
                    IssueDate = clsDbHelper.GetValue<DateTime>(Reader, "IssueDate"),
                    ExpirationDate = clsDbHelper.GetValue<DateTime>(Reader, "ExpirationDate"),
                    Notes = clsDbHelper.GetValue<string>(Reader, "Notes"),
                    PaidFees = clsDbHelper.GetValue<decimal>(Reader, "PaidFees"),
                    IsActive = clsDbHelper.GetValue<bool>(Reader, "IsActive"),
                    IssueReason = clsLicenseEnumConverter.ToIssueReason(clsDbHelper.GetValue<byte>(Reader, "IssueReason")),
                    CreatedByUserID = clsDbHelper.GetValue<int>(Reader, "CreatedByUserID")

                });
        }
        public static List<clsLicenseCardInfo_DTO> LoadLicensesCardsInfo()
        {
            string Query = @"Select P.FirstName , P.SecondName , P.ThirdName , P.LastName,
                        P.ImagePath ,P.NationalNo , P.DateOfBirth , P.Gendor ,
                        L.LicenseClassID , L.IsActive , 
                        L.IssueReason , L.IssueDate , L.ExpirationDate ,
                        L.Notes , L.DriverID From Licenses L
                        Join Drivers D ON L.DriverID = D.DriverID
                        Join People P ON D.PersonID = P.PersonID;";
            return clsDbHelper.ReadList(Query, null,
                Reader => new clsLicenseCardInfo_DTO
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
                });
        }
        public static List<clsLicenseCardInfo_DTO> LoadLicensesCardsInfo(int Offset, int CountRows)
        {

            string Query = @"Select L.LicenseID , P.FirstName , P.SecondName , P.ThirdName , P.LastName,
                        P.ImagePath ,P.NationalNo , P.DateOfBirth , P.Gendor ,
                        L.LicenseClassID , L.IsActive , 
                        L.IssueReason , L.IssueDate , L.ExpirationDate ,
                        L.Notes , L.DriverID From Licenses L
                        Join Drivers D ON L.DriverID = D.DriverID
                        Join People P ON D.PersonID = P.PersonID
                        ORDER BY LicenseID
                        OFFSET @Offset ROWS FETCH NEXT @CountRows ROWS ONLY;";
            return clsDbHelper.ReadList(Query,
                Command => {
                    clsDbHelper.SetValue(Command, "@Offset", Offset);
                    clsDbHelper.SetValue(Command, "@CountRows", CountRows);
                },
                Reader => new clsLicenseCardInfo_DTO
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
                });
        }
        public static int LoadLicenseClassIDByLicenseID(int LicenseID)
        {
            string Query = "Select LicenseClassID From Licenses Where LicenseID = @LicenseID;";
            return clsDbHelper.ExecuteScalar<int>(Query, Command => clsDbHelper.SetValue<int>(Command, "@LicenseID", LicenseID));
        }
        public static List<clsLicenseCardInfo_DTO> LoadLicensesCardsInfo(int Offset, int CountRows, clsLicenseQuery clsQuery)
        {
            string Query = @"Select L.LicenseID , P.FirstName , P.SecondName , P.ThirdName , P.LastName,
                        P.ImagePath ,P.NationalNo , P.DateOfBirth , P.Gendor ,
                        L.LicenseClassID , L.IsActive , 
                        L.IssueReason , L.IssueDate , L.ExpirationDate ,
                        L.Notes , L.DriverID From Licenses L
                        Join Drivers D ON L.DriverID = D.DriverID
                        Join People P ON D.PersonID = P.PersonID
                         Where 1 = 1 "; ;

            Query += clsQuery.SearchBy.HasValue && clsQuery.SearchValue != null
                ? $" AND L.{clsLicenseMapper.MapSearchBy(clsQuery.SearchBy.Value)} = @SearchValue"
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
        private static void _ApplyLicenseFilter(clsLicenseFilter filter,ref string query)
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

            MappingHelper.ApplyDateRange(filter.FromIssueDate,filter.ToIssueDate,
                "IssueDate",
                ref query);

            MappingHelper.ApplyDateRange(filter.FromExpirationDate,filter.ToExpirationDate,
                "ExpirationDate",
                ref query);
        }

    }
}
