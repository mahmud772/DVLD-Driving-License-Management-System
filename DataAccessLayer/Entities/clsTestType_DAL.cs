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
    public class clsTestType_DAL
    {

        public static int LoadCount()
        {
            string Query = "Select Count (*) From TestTypes;";
            return clsDbHelper.ExecuteScalar<int>(Query, null);
        }

        public static clsTestType_DTO LoadTestTypeByID(int TestTypeID)
        {
            clsTestType_DTO Model = null;
            string Query = "SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID";

            clsDbHelper.ExecuteReader(Query, Command => clsDbHelper.SetValue(Command, "@TestTypeID", TestTypeID),
                Reader =>
                {
                    Model = new clsTestType_DTO
                    {
                        TestTypeID = TestTypeID,
                        TestTypeTitle = clsDbHelper.GetValue<string>(Reader, "TestTypeTitle"),
                        TestTypeDescription = clsDbHelper.GetValue<string>(Reader, "TestTypeDescription"),
                        TestTypeFees = clsDbHelper.GetValue<int>(Reader, "TestTypeFees")
                    };
                });
            return Model;
        }

        // إضافة نوع اختبار جديد
        public static int AddNewTestType(clsTestType_DTO Model)
        {
            string Query = @"INSERT INTO TestTypes (TestTypeTitle, TestTypeDescription, TestTypeFees)
                         VALUES (@TestTypeTitle, @TestTypeDescription, @TestTypeFees);
                         SELECT SCOPE_IDENTITY();";

            return clsDbHelper.ExecuteNonQuery(Query, Command =>
            {
                clsDbHelper.SetValue(Command, "@TestTypeTitle", Model.TestTypeTitle);
                clsDbHelper.SetValue(Command, "@TestTypeDescription", Model.TestTypeDescription);
                clsDbHelper.SetValue(Command, "@TestTypeFees", Model.TestTypeFees);
            });
        }

        // تحديث نوع اختبار
        public static bool UpdateTestType(clsTestType_DTO Model)
        {
            string Query = @"UPDATE TestTypes SET
                         TestTypeTitle = @TestTypeTitle, TestTypeDescription = @TestTypeDescription,
                         TestTypeFees = @TestTypeFees
                         WHERE TestTypeID = @TestTypeID";

            int RowsAffected = clsDbHelper.ExecuteNonQuery(Query, Command =>
            {
                clsDbHelper.SetValue(Command, "@TestTypeID", Model.TestTypeID); // شرط التحديث
                clsDbHelper.SetValue(Command, "@TestTypeTitle", Model.TestTypeTitle);
                clsDbHelper.SetValue(Command, "@TestTypeDescription", Model.TestTypeDescription);
                clsDbHelper.SetValue(Command, "@TestTypeFees", Model.TestTypeFees);
            });
            return RowsAffected > 0;
        }

        // حذف نوع اختبار
        public static bool DeleteTestType(int TestTypeID)
        {
            int DeletedTestTypeCount = 0;

            string QueryTestTypesTable = "DELETE FROM TestTypes WHERE TestTypeID = @TestTypeID";

            bool TransactionSuccess = clsDbHelper.ExecuteTransaction(Command =>
            {
                clsDbHelper.SetValue(Command, "@TestTypeID", TestTypeID);

                clsTestAppointment_DAL.DeleteTestAppointmentByTestType(TestTypeID);

                Command.CommandText = QueryTestTypesTable;
                DeletedTestTypeCount = Command.ExecuteNonQuery();
            });


            return TransactionSuccess && (DeletedTestTypeCount > 0);
        }






        public static List<clsTestType_DTO> LoadAllTestTypes()
        {
            string Query = "SELECT * FROM TestTypes;";
            return clsDbHelper.ReadList<clsTestType_DTO>(Query, null,
                Reader => new clsTestType_DTO
                {
                    TestTypeID = clsDbHelper.GetValue<int>(Reader, "TestTypeID"),
                    TestTypeTitle = clsDbHelper.GetValue<string>(Reader, "TestTypeTitle"),
                    TestTypeFees = clsDbHelper.GetValue<decimal>(Reader, "TestTypeFees"),
                    TestTypeDescription = clsDbHelper.GetValue<string>(Reader, "TestTypeDescription")
                }
                );

        }
    }
}
