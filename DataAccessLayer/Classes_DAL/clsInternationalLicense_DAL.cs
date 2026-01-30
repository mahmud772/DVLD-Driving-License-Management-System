using Common;
using DVLD_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public class clsInternationalLicense_DAL
    {
        public static int LoadCount()
        {
            string Query = "Select Count (*) From InternationalLicenses;";
            return DbHelper.ExecuteScalar<int>(Query, null);
        }

        public static clsInternationalLicense_DTO LoadInternationalLicenseByID(int InternationalLicenseID)
        {
            clsInternationalLicense_DTO Model = null;


            string Query = @"SELECT * FROM InternationalLicenses 
                     WHERE InternationalLicenseID = @InternationalLicenseID";

            DbHelper.ExecuteReader(Query,
                Command => DbHelper.SetValue(Command, "@InternationalLicenseID", InternationalLicenseID),
                Reader =>
                {
                    Model = new clsInternationalLicense_DTO
                    {

                        InternationalLicenseID = InternationalLicenseID,
                        ApplicationID = DbHelper.GetValue<int>(Reader, "ApplicationID"),
                        DriverID = DbHelper.GetValue<int>(Reader, "DriverID"),
                        IssuedUsingLocalLicenseID = DbHelper.GetValue<int>(Reader, "IssuedUsingLocalLicenseID"),
                        IssueDate = DbHelper.GetValue<DateTime>(Reader, "IssueDate"),
                        ExpirationDate = DbHelper.GetValue<DateTime>(Reader, "ExpirationDate"),
                        IsActive = DbHelper.GetValue<bool>(Reader, "IsActive"),
                        CreatedByUserID = DbHelper.GetValue<int>(Reader, "CreatedByUserID")


                    };
                });

            return Model;
        }

        public static int AddNewInternationalLicense(clsInternationalLicense_DTO Model)
        {
            string Query = @"INSERT INTO InternationalLicenses (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedbyUserID)
                         Select @ApplicationID, @DriverID, @IssuedUsingLocalLicenselID, @IssueDate, @ExpirationDate, @IsActive, @CreatedbyUserID
                         Where Exists (Select 1 From Licenses Where LicenseID = @IssuedUsingLocalLicenseID And LicenseClassID = @LicenseClassID And IsActive = 1)
						 And Not Exists (Select 1 From InternationalLicenses Where
						 DriverID = @DriverID And IsActive = 1 And IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID);
                         IF @@ROWCOUNT > 0
							SELECT SCOPE_IDENTITY();
						ELSE
							SELECT -1
                         ;";

            return DbHelper.ExecuteScalar<int>(Query, Command =>
            {
                DbHelper.SetValue(Command, "@ApplicationID", Model.ApplicationID);
                DbHelper.SetValue(Command, "@DriverID", Model.DriverID);
                DbHelper.SetValue(Command, "@IssuedUsingLocalLicenseID", Model.IssuedUsingLocalLicenseID);
                DbHelper.SetValue(Command, "@IssueDate", Model.IssueDate);
                DbHelper.SetValue(Command, "@ExpirationDate", Model.ExpirationDate);
                DbHelper.SetValue(Command, "@IsActive", Model.IsActive);
                DbHelper.SetValue(Command, "@CreatedByUserID", Model.CreatedByUserID);
                DbHelper.SetValue(Command, "@LicenseClassID", clsLicenseEnums.ConvertLicenseClassToInt(clsLicenseEnums.enLicenseClasses.OrdinaryDrivingLicense));
            });
        }


        public static bool UpdateInternationalLicense(clsInternationalLicense_DTO Model)
        {
            string Query = @"UPDATE InternationalLicenses SET
                         IsActive = @IsActive
                         WHERE InternationalLicenseID = @InternationalLicenseID";

            int RowsAffected = DbHelper.ExecuteNonQuery(Query, Command =>
            {
                DbHelper.SetValue(Command, "@InternationalLicenseID", Model.InternationalLicenseID); // شرط التحديث

                DbHelper.SetValue(Command, "@IsActive", Model.IsActive);

            });
            return RowsAffected > 0;
        }

        public static List<clsInternationalLicense_DTO> LoadInternationalLicenses()
        {
            string Query = "Select * From InternationalLicenses;";
            return DbHelper.ReadList<clsInternationalLicense_DTO>(Query, null,
                Reader => new clsInternationalLicense_DTO
                {
                    InternationalLicenseID = DbHelper.GetValue<int>(Reader, "InternationalLicenseID"),
                    ApplicationID = DbHelper.GetValue<int>(Reader, "ApplicationID"),
                    DriverID = DbHelper.GetValue<int>(Reader, "DriverID"),
                    IssuedUsingLocalLicenseID = DbHelper.GetValue<int>(Reader, "IssuedUsingLocalLicenseID"),
                    IssueDate = DbHelper.GetValue<DateTime>(Reader, "IssueDate"),
                    ExpirationDate = DbHelper.GetValue<DateTime>(Reader, "ExpirationDate"),
                    IsActive = DbHelper.GetValue<bool>(Reader, "IsActive"),
                    CreatedByUserID = DbHelper.GetValue<int>(Reader, "CreatedByUserID"),
                });
        }

        public static List<clsInternationalLicense_DTO> LoadInternationalLicenses(int Offset, int CountRows)
        {
            string Query = $@"SELECT * FROM InternationalLicenses 
                      ORDER BY InternationalLicenseID
                      OFFSET @Offset ROWS FETCH NEXT @CountRows ROWS ONLY;";

            return DbHelper.ReadList(Query,
                Command => {
                    DbHelper.SetValue(Command, "@Offset", Offset);
                    DbHelper.SetValue(Command, "@CountRows", CountRows);
                },
                Reader => new clsInternationalLicense_DTO
                {
                    InternationalLicenseID = DbHelper.GetValue<int>(Reader, "InternationalLicenseID"),
                    ApplicationID = DbHelper.GetValue<int>(Reader, "ApplicationID"),
                    DriverID = DbHelper.GetValue<int>(Reader, "DriverID"),
                    IssuedUsingLocalLicenseID = DbHelper.GetValue<int>(Reader, "IssuedUsingLocalLicenseID"),
                    IssueDate = DbHelper.GetValue<DateTime>(Reader, "IssueDate"),
                    ExpirationDate = DbHelper.GetValue<DateTime>(Reader, "ExpirationDate"),
                    IsActive = DbHelper.GetValue<bool>(Reader, "IsActive"),
                    CreatedByUserID = DbHelper.GetValue<int>(Reader, "CreatedByUserID"),

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
        public static bool DeleteInternationalLicenseByID(int InternationalLicenseID)
        {
            string Query = "DELETE FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";
            int RowsAffected = DbHelper.ExecuteNonQuery(Query, Command => DbHelper.SetValue(Command, "@InternationalLicenseID", InternationalLicenseID));
            return RowsAffected > 0;
        }

        public static bool DeleteByUserID(int CreatedByUserID)
        {
            int RowsAffected = 0;
            string QueryLicensesTable = @"Delete From InternationalLicenses Where CreatedByUserID = @CreatedByUserID;";

            RowsAffected = DbHelper.ExecuteNonQuery(QueryLicensesTable, Command =>
            {
                DbHelper.SetValue<int>(Command, "@CreatedByUserID", CreatedByUserID);
            });

            return RowsAffected > 0;
        }
    }
}
