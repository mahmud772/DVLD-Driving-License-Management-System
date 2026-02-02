using DVLD_DTO;
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
            return DbHelper.ExecuteScalar<int>(Query, null);
        }

        public static clsTestType_DTO LoadTestTypeByID(int TestTypeID)
        {
            clsTestType_DTO Model = null;
            string Query = "SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID";

            DbHelper.ExecuteReader(Query, Command => DbHelper.SetValue(Command, "@TestTypeID", TestTypeID),
                Reader =>
                {
                    Model = new clsTestType_DTO
                    {
                        TestTypeID = TestTypeID,
                        TestTypeTitle = DbHelper.GetValue<string>(Reader, "TestTypeTitle"),
                        TestTypeDescription = DbHelper.GetValue<string>(Reader, "TestTypeDescription"),
                        TestTypeFees = DbHelper.GetValue<int>(Reader, "TestTypeFees")
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

            return DbHelper.ExecuteNonQuery(Query, Command =>
            {
                DbHelper.SetValue(Command, "@TestTypeTitle", Model.TestTypeTitle);
                DbHelper.SetValue(Command, "@TestTypeDescription", Model.TestTypeDescription);
                DbHelper.SetValue(Command, "@TestTypeFees", Model.TestTypeFees);
            });
        }

        // تحديث نوع اختبار
        public static bool UpdateTestType(clsTestType_DTO Model)
        {
            string Query = @"UPDATE TestTypes SET
                         TestTypeTitle = @TestTypeTitle, TestTypeDescription = @TestTypeDescription,
                         TestTypeFees = @TestTypeFees
                         WHERE TestTypeID = @TestTypeID";

            int RowsAffected = DbHelper.ExecuteNonQuery(Query, Command =>
            {
                DbHelper.SetValue(Command, "@TestTypeID", Model.TestTypeID); // شرط التحديث
                DbHelper.SetValue(Command, "@TestTypeTitle", Model.TestTypeTitle);
                DbHelper.SetValue(Command, "@TestTypeDescription", Model.TestTypeDescription);
                DbHelper.SetValue(Command, "@TestTypeFees", Model.TestTypeFees);
            });
            return RowsAffected > 0;
        }

        // حذف نوع اختبار
        public static bool DeleteTestType(int TestTypeID)
        {
            int DeletedTestTypeCount = 0;

            string QueryTestTypesTable = "DELETE FROM TestTypes WHERE TestTypeID = @TestTypeID";

            bool TransactionSuccess = DbHelper.ExecuteTransaction(Command =>
            {
                DbHelper.SetValue(Command, "@TestTypeID", TestTypeID);

                clsTestAppointment_DAL.DeleteTestAppointmentByTestType(TestTypeID);

                Command.CommandText = QueryTestTypesTable;
                DeletedTestTypeCount = Command.ExecuteNonQuery();
            });


            return TransactionSuccess && (DeletedTestTypeCount > 0);
        }






        public static List<clsTestType_DTO> LoadAllTestTypes()
        {
            string Query = "SELECT * FROM TestTypes;";
            return DbHelper.ReadList<clsTestType_DTO>(Query, null,
                Reader => new clsTestType_DTO
                {
                    TestTypeID = DbHelper.GetValue<int>(Reader, "TestTypeID"),
                    TestTypeTitle = DbHelper.GetValue<string>(Reader, "TestTypeTitle"),
                    TestTypeFees = DbHelper.GetValue<decimal>(Reader, "TestTypeFees"),
                    TestTypeDescription = DbHelper.GetValue<string>(Reader, "TestTypeDescription")
                }
                );

        }
    }
}
