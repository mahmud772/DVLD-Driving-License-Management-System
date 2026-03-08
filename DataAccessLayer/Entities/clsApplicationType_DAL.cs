using Common.Filters;
using DVLD_DAL.Mappers;
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
    public class clsApplicationType_DAL
    {
        public static int LoadCount()
        {
            string Query = "Select Count (*) From ApplicationTypes;";
            return clsDbHelper.ExecuteScalar<int>(Query, null);
        }
        public static clsApplicationType_DTO LoadApplicationTypeByID(int ApplicationTypeID)
        {
            clsApplicationType_DTO ApplicationType = null;
            string Query = "SELECT ApplicationTypeTitle, ApplicationFees FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";
            bool IsFound = clsDbHelper.ExecuteReader
                (
                Query,
                Command =>
                clsDbHelper.SetValue<int>(Command, "@ApplicationTypeID", ApplicationTypeID),
                Reader => ApplicationType = new clsApplicationType_DTO
                {
                    ApplicationTypeTitle = clsDbHelper.GetValue<string>(Reader, "ApplicationTypeTitle"),
                    ApplicationFees = clsDbHelper.GetValue<decimal>(Reader, "ApplicationFees")
                }
                );
            return IsFound ? ApplicationType : null;
        }

        public static int AddNewApplicationType(clsApplicationType_DTO Model)
        {
            string Query = @"INSERT INTO ApplicationTypes (ApplicationTypeTitle, ApplicationFees)
                         VALUES (@ApplicationTypeTitle, @ApplicationFees);
                         SELECT SCOPE_IDENTITY();";

            return clsDbHelper.ExecuteNonQuery(Query, Command =>
            {
                clsDbHelper.SetValue<string>(Command, "@ApplicationTypeTitle", Model.ApplicationTypeTitle);
                clsDbHelper.SetValue<decimal>(Command, "@ApplicationFees", Model.ApplicationFees);
            });
        }
        public static bool UpdateApplicationType(clsApplicationType_DTO ApplicationType)
        {

            string Query = @"UPDATE ApplicationTypes SET ApplicationFees = @ApplicationFees ,
                            ApplicationTypeTitle = @ApplicationTypeTitle
                            WHERE ApplicationTypeID = @ApplicationTypeID;";

            return clsDbHelper.ExecuteNonQuery
                (
                Query,
                Command =>
                {
                    clsDbHelper.SetValue<int>(Command, "@ApplicationTypeID", ApplicationType.ApplicationTypeID);
                    clsDbHelper.SetValue<decimal>(Command, "@ApplicationFees", ApplicationType.ApplicationFees);
                    clsDbHelper.SetValue<string>(Command, "@ApplicationTypeTitle", ApplicationType.ApplicationTypeTitle);
                }
                ) > 0;

        }

        public static bool DeleteApplicationTypeByID(int ApplicationTypeID)
        {
            int DeletedApplicationTypeCount = 0;

            string QueryApplicationTypesTable = @"Delete From ApplicationTypes Where ApplicationTypeID = @ApplicationTypeID;";


            bool TransactionSuccess = clsDbHelper.ExecuteTransaction(Command =>
            {

                clsDbHelper.SetValue<int>(Command, "@ApplicationTypeID", ApplicationTypeID);


                clsApplication_DAL.DeleteApplicationByTypeID(ApplicationTypeID);

                Command.CommandText = QueryApplicationTypesTable;
                DeletedApplicationTypeCount = Command.ExecuteNonQuery();
            });


            return TransactionSuccess && (DeletedApplicationTypeCount > 0);
        }



        public static List<clsApplicationType_DTO> LoadAllApplicationTypes()
        {
            string Query = "SELECT * FROM ApplicationTypes;";
            return clsDbHelper.ReadList(Query, null,
                Reader => new clsApplicationType_DTO
                {
                    ApplicationTypeID = clsDbHelper.GetValue<int>(Reader, "ApplicationTypeID"),
                    ApplicationTypeTitle = clsDbHelper.GetValue<string>(Reader, "ApplicationTypeTitle"),
                    ApplicationFees = clsDbHelper.GetValue<decimal>(Reader, "ApplicationFees")
                }
                );


        }

        //public static decimal LoadApplicationFees(int ApplicationTypeID)
        //{
        //    string Query = "Select ApplicationFees From ApplicationTypes Where ApplicationTypeID = @ApplicationTypeID;";
        //    return DbHelper.ExecuteScalar<decimal>(Query, Command => DbHelper.SetValue<int>(Command, "@ApplicationTypeID", ApplicationTypeID));
        //}
        

    }
}
