using DVLD_DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    public class clsLicenseClass_DAL
    {

        public static int LoadCount()
        {
            string Query = "Select Count (*) From LicenseClasses;";
            return clsDbHelper.ExecuteScalar<int>(Query, null);
        }


        public static clsLicenseClass_DTO LoadLicenseClassByID(int LicenseClassID)
        {
            clsLicenseClass_DTO Model = null;
            string Query = "SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            clsDbHelper.ExecuteReader(Query, Command => clsDbHelper.SetValue(Command, "@LicenseClassID", LicenseClassID),
                Reader =>
                {
                    Model = new clsLicenseClass_DTO
                    {
                        LicenseClassID = LicenseClassID,
                        ClassName = clsDbHelper.GetValue<string>(Reader, "ClassName"),
                        ClassDescription = clsDbHelper.GetValue<string>(Reader, "ClassDescription"),
                        MinimumAllowedAge = clsDbHelper.GetValue<byte>(Reader, "MinimumAllowedAge"),
                        DefaultValidityLength = clsDbHelper.GetValue<byte>(Reader, "DefaultValidityLength"),
                        ClassFees = clsDbHelper.GetValue<decimal>(Reader, "ClassFees")
                    };
                });
            return Model;
        }

        // إضافة فئة رخصة جديدة
        public static int AddNewLicenseClass(clsLicenseClass_DTO Model)
        {
            string Query = @"INSERT INTO LicenseClasses (ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees)
                         VALUES (@ClassName, @ClassDescription, @MinimumAllowedAge, @DefaultValidityLength, @ClassFees);
                         SELECT SCOPE_IDENTITY();";

            return clsDbHelper.ExecuteNonQuery(Query, Command =>
            {
                clsDbHelper.SetValue(Command, "@ClassName", Model.ClassName);
                clsDbHelper.SetValue(Command, "@ClassDescription", Model.ClassDescription);
                clsDbHelper.SetValue(Command, "@MinimumAllowedAge", Model.MinimumAllowedAge);
                clsDbHelper.SetValue(Command, "@DefaultValidityLength", Model.DefaultValidityLength);
                clsDbHelper.SetValue(Command, "@ClassFees", Model.ClassFees);
            });
        }

        // تحديث فئة رخصة
        public static bool UpdateLicenseClass(clsLicenseClass_DTO Model)
        {
            string Query = @"UPDATE LicenseClasses SET
                         ClassName = @ClassName, ClassDescription = @ClassDescription,
                         MinimumAllowedAge = @MinimumAllowedAge, DefaultValidityLength = @DefaultValidityLength,
                         ClassFees = @ClassFees
                         WHERE LicenseClassID = @LicenseClassID";

            int RowsAffected = clsDbHelper.ExecuteNonQuery(Query, Command =>
            {
                clsDbHelper.SetValue(Command, "@LicenseClassID", Model.LicenseClassID); // شرط التحديث
                clsDbHelper.SetValue(Command, "@ClassName", Model.ClassName);
                clsDbHelper.SetValue(Command, "@ClassDescription", Model.ClassDescription);
                clsDbHelper.SetValue(Command, "@MinimumAllowedAge", Model.MinimumAllowedAge);
                clsDbHelper.SetValue(Command, "@DefaultValidityLength", Model.DefaultValidityLength);
                clsDbHelper.SetValue(Command, "@ClassFees", Model.ClassFees);
            });
            return RowsAffected > 0;
        }

        // حذف فئة رخصة
        public static bool DeleteLicenseClass(int LicenseClassID)
        {
            int DeletedLicenseCount = 0;
            string Query = "DELETE FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            bool TransactionSuccess = clsDbHelper.ExecuteTransaction(Command =>
            {
                clsDbHelper.SetValue(Command, "@LicenseClassID", LicenseClassID);

                clsLicense_DAL.DeleteLicenseByLicenseClassID(LicenseClassID);

                Command.CommandText = Query;
                DeletedLicenseCount = Command.ExecuteNonQuery();
            });

            return TransactionSuccess && (DeletedLicenseCount > 0);
        }

        public static List<clsLicenseClass_DTO> LoadAllLicenseClasses()
        {
            string Query = "Select * From LicenseClasses;";
            return clsDbHelper.ReadList(Query, null,
                Reader => new clsLicenseClass_DTO
                {
                    LicenseClassID = clsDbHelper.GetValue<int>(Reader, "LicenseClassID"),
                    ClassName = clsDbHelper.GetValue<string>(Reader, "ClassName"),
                    MinimumAllowedAge = clsDbHelper.GetValue<byte>(Reader, "MinimumAllowedAge"),
                    DefaultValidityLength = clsDbHelper.GetValue<byte>(Reader, "DefaultValidityLength"),
                    ClassFees = clsDbHelper.GetValue<decimal>(Reader, "ClassFees"),
                    ClassDescription = clsDbHelper.GetValue<string>(Reader, "ClassDescription")
                }
                );
        }
    }
}
