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
            return DbHelper.ExecuteScalar<int>(Query, null);
        }


        public static clsLicenseClass_DTO LoadLicenseClassByID(int LicenseClassID)
        {
            clsLicenseClass_DTO Model = null;
            string Query = "SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            DbHelper.ExecuteReader(Query, Command => DbHelper.SetValue(Command, "@LicenseClassID", LicenseClassID),
                Reader =>
                {
                    Model = new clsLicenseClass_DTO
                    {
                        LicenseClassID = LicenseClassID,
                        ClassName = DbHelper.GetValue<string>(Reader, "ClassName"),
                        ClassDescription = DbHelper.GetValue<string>(Reader, "ClassDescription"),
                        MinimumAllowedAge = DbHelper.GetValue<byte>(Reader, "MinimumAllowedAge"),
                        DefaultValidityLength = DbHelper.GetValue<byte>(Reader, "DefaultValidityLength"),
                        ClassFees = DbHelper.GetValue<decimal>(Reader, "ClassFees")
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

            return DbHelper.ExecuteNonQuery(Query, Command =>
            {
                DbHelper.SetValue(Command, "@ClassName", Model.ClassName);
                DbHelper.SetValue(Command, "@ClassDescription", Model.ClassDescription);
                DbHelper.SetValue(Command, "@MinimumAllowedAge", Model.MinimumAllowedAge);
                DbHelper.SetValue(Command, "@DefaultValidityLength", Model.DefaultValidityLength);
                DbHelper.SetValue(Command, "@ClassFees", Model.ClassFees);
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

            int RowsAffected = DbHelper.ExecuteNonQuery(Query, Command =>
            {
                DbHelper.SetValue(Command, "@LicenseClassID", Model.LicenseClassID); // شرط التحديث
                DbHelper.SetValue(Command, "@ClassName", Model.ClassName);
                DbHelper.SetValue(Command, "@ClassDescription", Model.ClassDescription);
                DbHelper.SetValue(Command, "@MinimumAllowedAge", Model.MinimumAllowedAge);
                DbHelper.SetValue(Command, "@DefaultValidityLength", Model.DefaultValidityLength);
                DbHelper.SetValue(Command, "@ClassFees", Model.ClassFees);
            });
            return RowsAffected > 0;
        }

        // حذف فئة رخصة
        public static bool DeleteLicenseClass(int LicenseClassID)
        {
            int DeletedLicenseCount = 0;
            string Query = "DELETE FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            bool TransactionSuccess = DbHelper.ExecuteTransaction(Command =>
            {
                DbHelper.SetValue(Command, "@LicenseClassID", LicenseClassID);

                clsLicense_DAL.DeleteLicenseByLicenseClassID(LicenseClassID);

                Command.CommandText = Query;
                DeletedLicenseCount = Command.ExecuteNonQuery();
            });

            return TransactionSuccess && (DeletedLicenseCount > 0);
        }

        public static List<clsLicenseClass_DTO> LoadAllLicenseClasses()
        {
            string Query = "Select * From LicenseClasses;";
            return DbHelper.ReadList(Query, null,
                Reader => new clsLicenseClass_DTO
                {
                    LicenseClassID = DbHelper.GetValue<int>(Reader, "LicenseClassID"),
                    ClassName = DbHelper.GetValue<string>(Reader, "ClassName"),
                    MinimumAllowedAge = DbHelper.GetValue<byte>(Reader, "MinimumAllowedAge"),
                    DefaultValidityLength = DbHelper.GetValue<byte>(Reader, "DefaultValidityLength"),
                    ClassFees = DbHelper.GetValue<decimal>(Reader, "ClassFees"),
                    ClassDescription = DbHelper.GetValue<string>(Reader, "ClassDescription")
                }
                );
        }
    }
}
