using Common;
using DVLD_DTO;
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

        public static int LoadCount()
        {
            string Query = "Select Count (*) From Licenses;";
            return DbHelper.ExecuteScalar<int>(Query, null);
        }
        public static clsLicense_DTO LoadLicenseInfoByID(int LicenseID)
        {
            clsLicense_DTO Model = null;
            string Query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID";


            bool IsFound = DbHelper.ExecuteReader(Query, Command => DbHelper.SetValue<int>(Command, "@LicenseID", LicenseID),
                Reader =>
                {
                    Model = new clsLicense_DTO
                    {
                        LicenseID = LicenseID,
                        ApplicationID = DbHelper.GetValue<int>(Reader, "ApplicationID"),
                        DriverID = DbHelper.GetValue<int>(Reader, "DriverID"),
                        LicenseClass = clsLicenseEnums.ConvertLicenseClassToEnum(DbHelper.GetValue<int>(Reader, "LicenseClassID")),
                        IssueDate = DbHelper.GetValue<DateTime>(Reader, "IssueDate"),
                        ExpirationDate = DbHelper.GetValue<DateTime>(Reader, "ExpirationDate"),
                        Notes = DbHelper.GetValue<string>(Reader, "Notes"),
                        PaidFees = DbHelper.GetValue<decimal>(Reader, "PaidFees"),
                        IsActive = DbHelper.GetValue<bool>(Reader, "IsActive"),
                        IssueReason = clsLicenseEnums.ConvertIssueReasonToEnum(DbHelper.GetValue<byte>(Reader, "IssueReason")),
                        CreatedByUserID = DbHelper.GetValue<int>(Reader, "CreatedByUserID")
                    };
                });

            return IsFound ? Model : null;
        }


        public static clsLicense_DTO LoadLicenseInfoByDriverID(int DriverID)
        {
            string Query = "SELECT LicenseID FROM Licenses WHERE DriverID = @DriverID";
            int LicenseID = -1;

            if (DbHelper.FindID<int>(Query, "@DriverID", DriverID, ref LicenseID))
            {
                return LoadLicenseInfoByID(LicenseID);
            }

            return null;
        }

        public static int LoadDriverIDByLicenseID(int LicenseID)
        {
            string Query = "Select DriverID From Licenses Where LicenseID = @LicenseID ;";
            return DbHelper.ExecuteScalar<int>(Query, Command => DbHelper.SetValue(Command, "@LicenseID", LicenseID));
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
            bool IsFound = DbHelper.ExecuteReader(Query, Command => DbHelper.SetValue(Command, "@LicenseID", LicenseID),
                Reader =>
                {
                    Card = new clsLicenseCardInfo_DTO
                    {
                        LicenseID = LicenseID,
                        FirstName = DbHelper.GetValue<string>(Reader, "FirstName"),
                        SecondName = DbHelper.GetValue<string>(Reader, "SecondName"),
                        ThirdName = DbHelper.GetValue<string>(Reader, "ThirdName"),
                        LastName = DbHelper.GetValue<string>(Reader, "LastName"),
                        ImagePath = DbHelper.GetValue<string>(Reader, "ImagePath"),
                        NationalNo = DbHelper.GetValue<string>(Reader, "NationalNo"),
                        DateOfBirth = DbHelper.GetValue<DateTime>(Reader, "DateOfBirth"),
                        LicenseClass = clsLicenseEnums.ConvertLicenseClassToEnum(DbHelper.GetValue<int>(Reader, "LicenseClassID")),
                        IsActive = DbHelper.GetValue<bool>(Reader, "IsActive"),
                        IssueReason = clsLicenseEnums.ConvertIssueReasonToEnum(DbHelper.GetValue<byte>(Reader, "IssueReason")),
                        IssueDate = DbHelper.GetValue<DateTime>(Reader, "IssueDate"),
                        ExpirationDate = DbHelper.GetValue<DateTime>(Reader, "ExpirationDate"),
                        Notes = DbHelper.GetValue<string>(Reader, "Notes"),
                        DriverID = DbHelper.GetValue<int>(Reader, "DriverID")


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


            NewLicenseID = DbHelper.ExecuteScalar<int>(Query, Command =>
            {

                DbHelper.SetValue<int>(Command, "@ApplicationID", Model.ApplicationID);
                DbHelper.SetValue<int>(Command, "@DriverID", Model.DriverID);
                DbHelper.SetValue<int>(Command, "@LicenseClassID", clsLicenseEnums.ConvertLicenseClassToInt(Model.LicenseClass));
                DbHelper.SetValue<DateTime>(Command, "@IssueDate", Model.IssueDate);
                DbHelper.SetValue<DateTime>(Command, "@ExpirationDate", Model.ExpirationDate);
                DbHelper.SetValue<string>(Command, "@Notes", Model.Notes, ValidNull: true);
                DbHelper.SetValue<decimal>(Command, "@PaidFees", Model.PaidFees);
                DbHelper.SetValue<bool>(Command, "@IsActive", Model.IsActive);
                DbHelper.SetValue<byte>(Command, "@IssueReason", clsLicenseEnums.ConvertIssueReasonToByte(Model.IssueReason));
                DbHelper.SetValue<int>(Command, "@CreatedByUserID", Model.CreatedByUserID);
            });

            return NewLicenseID;
        }


        public static bool UpdateLicense(clsLicense_DTO Model)
        {
            string Query = @"
                        UPDATE Licenses SET Notes = @Notes,
                            PaidFees = @PaidFees, IsActive = @IsActive,
                        WHERE LicenseID = @LicenseID";


            int RowsAffected = DbHelper.ExecuteNonQuery(Query, Command =>
            {

                DbHelper.SetValue<int>(Command, "@LicenseID", Model.LicenseID);

                DbHelper.SetValue<string>(Command, "@Notes", Model.Notes, ValidNull: true);
                DbHelper.SetValue<decimal>(Command, "@PaidFees", Model.PaidFees);
                DbHelper.SetValue<bool>(Command, "@IsActive", Model.IsActive);
                DbHelper.SetValue<int>(Command, "@CreatedByUserID", Model.CreatedByUserID);
            });

            return RowsAffected > 0;
        }


        public static bool DeleteLicenseByID(int LicenseID)
        {

            int RowsAffected = 0;
            string Query = "DELETE FROM Licenses WHERE LicenseID = @LicenseID";

            RowsAffected = DbHelper.ExecuteNonQuery(Query, Command =>
            {
                DbHelper.SetValue<int>(Command, "@LicenseID", LicenseID);
            });

            return RowsAffected > 0;
        }

        public static bool DeleteLicenseByLicenseClassID(int LicenseClassID)
        {

            int RowsAffected = 0;
            string Query = "DELETE FROM Licenses WHERE LicenseClassID = @LicenseClassID";

            RowsAffected = DbHelper.ExecuteNonQuery(Query, Command =>
            {
                DbHelper.SetValue<int>(Command, "@LicenseClassID", LicenseClassID);
            });

            return RowsAffected > 0;
        }

        public static bool DeleteLicenseByApplicationID(int ApplicationID)
        {

            int RowsAffected = 0;
            string Query = "DELETE FROM Licenses WHERE ApplicationID = @ApplicationID";

            RowsAffected = DbHelper.ExecuteNonQuery(Query, Command =>
            {
                DbHelper.SetValue<int>(Command, "@ApplicationID", ApplicationID);
            });

            return RowsAffected > 0;
        }


        public static bool DeleteByUserID(int CreatedByUserID)
        {
            int RowsAffected = 0;
            string QueryLicensesTable = @"Delete From Licenses Where CreatedByUserID = @CreatedByUserID;";

            RowsAffected = DbHelper.ExecuteNonQuery(QueryLicensesTable, Command =>
            {
                DbHelper.SetValue<int>(Command, "@CreatedByUserID", CreatedByUserID);
            });

            return RowsAffected > 0;
        }



        public static List<clsLicense_DTO> LoadLicenses()
        {
            string Query = "SELECT * FROM Licenses;";

            return DbHelper.ReadList(Query, null,
                Reader => new clsLicense_DTO
                {
                    LicenseID = DbHelper.GetValue<int>(Reader, "LicenseID"),
                    ApplicationID = DbHelper.GetValue<int>(Reader, "ApplicationID"),
                    DriverID = DbHelper.GetValue<int>(Reader, "DriverID"),
                    LicenseClass = clsLicenseEnums.ConvertLicenseClassToEnum(DbHelper.GetValue<int>(Reader, "LicenseClassID")),
                    IssueDate = DbHelper.GetValue<DateTime>(Reader, "IssueDate"),
                    ExpirationDate = DbHelper.GetValue<DateTime>(Reader, "ExpirationDate"),
                    Notes = DbHelper.GetValue<string>(Reader, "Notes"),
                    PaidFees = DbHelper.GetValue<decimal>(Reader, "PaidFees"),
                    IsActive = DbHelper.GetValue<bool>(Reader, "IsActive"),
                    IssueReason = clsLicenseEnums.ConvertIssueReasonToEnum(DbHelper.GetValue<byte>(Reader, "IssueReason")),
                    CreatedByUserID = DbHelper.GetValue<int>(Reader, "CreatedByUserID")
                });
        }
        public static List<clsLicense_DTO> LoadLicenses(int Offset, int CountRows)
        {
            string Query = $@"SELECT * FROM Licenses
                      ORDER BY LicenseID
                      OFFSET @Offset ROWS FETCH NEXT @CountRows ROWS ONLY;";

            return DbHelper.ReadList(Query,
                Command => {
                    DbHelper.SetValue(Command, "@Offset", Offset);
                    DbHelper.SetValue(Command, "@CountRows", CountRows);
                },
                Reader => new clsLicense_DTO
                {
                    LicenseID = DbHelper.GetValue<int>(Reader, "LicenseID"),
                    ApplicationID = DbHelper.GetValue<int>(Reader, "ApplicationID"),
                    DriverID = DbHelper.GetValue<int>(Reader, "DriverID"),
                    LicenseClass = clsLicenseEnums.ConvertLicenseClassToEnum(DbHelper.GetValue<int>(Reader, "LicenseClassID")),
                    IssueDate = DbHelper.GetValue<DateTime>(Reader, "IssueDate"),
                    ExpirationDate = DbHelper.GetValue<DateTime>(Reader, "ExpirationDate"),
                    Notes = DbHelper.GetValue<string>(Reader, "Notes"),
                    PaidFees = DbHelper.GetValue<decimal>(Reader, "PaidFees"),
                    IsActive = DbHelper.GetValue<bool>(Reader, "IsActive"),
                    IssueReason = clsLicenseEnums.ConvertIssueReasonToEnum(DbHelper.GetValue<byte>(Reader, "IssueReason")),
                    CreatedByUserID = DbHelper.GetValue<int>(Reader, "CreatedByUserID")

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
            return DbHelper.ReadList(Query, null,
                Reader => new clsLicenseCardInfo_DTO
                {
                    LicenseID = DbHelper.GetValue<int>(Reader, "LicenseID"),
                    FirstName = DbHelper.GetValue<string>(Reader, "FirstName"),
                    SecondName = DbHelper.GetValue<string>(Reader, "SecondName"),
                    ThirdName = DbHelper.GetValue<string>(Reader, "ThirdName"),
                    LastName = DbHelper.GetValue<string>(Reader, "LastName"),
                    ImagePath = DbHelper.GetValue<string>(Reader, "ImagePath"),
                    NationalNo = DbHelper.GetValue<string>(Reader, "NationalNo"),
                    DateOfBirth = DbHelper.GetValue<DateTime>(Reader, "DateOfBirth"),
                    LicenseClass = clsLicenseEnums.ConvertLicenseClassToEnum(DbHelper.GetValue<int>(Reader, "LicenseClassID")),
                    IsActive = DbHelper.GetValue<bool>(Reader, "IsActive"),
                    IssueReason = clsLicenseEnums.ConvertIssueReasonToEnum(DbHelper.GetValue<byte>(Reader, "IssueReason")),
                    IssueDate = DbHelper.GetValue<DateTime>(Reader, "IssueDate"),
                    ExpirationDate = DbHelper.GetValue<DateTime>(Reader, "ExpirationDate"),
                    Notes = DbHelper.GetValue<string>(Reader, "Notes"),
                    DriverID = DbHelper.GetValue<int>(Reader, "DriverID")
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
            return DbHelper.ReadList(Query,
                Command => {
                    DbHelper.SetValue(Command, "@Offset", Offset);
                    DbHelper.SetValue(Command, "@CountRows", CountRows);
                },
                Reader => new clsLicenseCardInfo_DTO
                {
                    LicenseID = DbHelper.GetValue<int>(Reader, "LicenseID"),
                    FirstName = DbHelper.GetValue<string>(Reader, "FirstName"),
                    SecondName = DbHelper.GetValue<string>(Reader, "SecondName"),
                    ThirdName = DbHelper.GetValue<string>(Reader, "ThirdName"),
                    LastName = DbHelper.GetValue<string>(Reader, "LastName"),
                    ImagePath = DbHelper.GetValue<string>(Reader, "ImagePath"),
                    NationalNo = DbHelper.GetValue<string>(Reader, "NationalNo"),
                    DateOfBirth = DbHelper.GetValue<DateTime>(Reader, "DateOfBirth"),
                    LicenseClass = clsLicenseEnums.ConvertLicenseClassToEnum(DbHelper.GetValue<int>(Reader, "LicenseClassID")),
                    IsActive = DbHelper.GetValue<bool>(Reader, "IsActive"),
                    IssueReason = clsLicenseEnums.ConvertIssueReasonToEnum(DbHelper.GetValue<byte>(Reader, "IssueReason")),
                    IssueDate = DbHelper.GetValue<DateTime>(Reader, "IssueDate"),
                    ExpirationDate = DbHelper.GetValue<DateTime>(Reader, "ExpirationDate"),
                    Notes = DbHelper.GetValue<string>(Reader, "Notes"),
                    DriverID = DbHelper.GetValue<int>(Reader, "DriverID")
                });
        }
        public static int LoadLicenseClassIDByLicenseID(int LicenseID)
        {
            string Query = "Select LicenseClassID From Licenses Where LicenseID = @LicenseID;";
            return DbHelper.ExecuteScalar<int>(Query, Command => DbHelper.SetValue<int>(Command, "@LicenseID", LicenseID));
        }

    }
}
