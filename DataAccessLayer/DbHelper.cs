using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DAL
{
    internal static class DbHelper
    {

        public static T GetValue<T>(SqlDataReader reader, string column)
        {
            return reader[column] != DBNull.Value ? (T)reader[column] : default(T);
        }


        public static void SetValue<T>(SqlCommand command, string paramName, T value , bool AllowNull = false)
        {
            object val = value;
            if (value == null || (val.Equals(default(T)) && AllowNull))
                command.Parameters.AddWithValue(paramName, DBNull.Value);
            else
                command.Parameters.AddWithValue(paramName, value);
        }

        public static void SetValue<T>(SqlCommand command, string paramName , T value, bool IsHasValue, bool AllowNull = false)
        {
            if(IsHasValue)
                SetValue<T>(command , paramName , value , AllowNull);
        }
        public static bool FindID<T>(string Query, string ParameterName, T ParameterValue, ref int ID)
        {
            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsContactsDataAccessLayer.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    SetValue<T>(Command, ParameterName, ParameterValue);

                    try
                    {
                        Connection.Open();
                        object Result = Command.ExecuteScalar();

                        if (Result != DBNull.Value && Result != null)
                        {
                            ID = Convert.ToInt32(Result);
                            IsFound = true;
                        }
                    }
                    catch
                    {
                        IsFound = false;
                        throw;
                    }
                    finally
                    {
                        Connection.Close();
                    }
                }
            }
            return IsFound;
        }

        public static T ExecuteScalar<T>(string Query, Action<SqlCommand> ParameterSetter)
        {
            T Value = default(T);
            using (SqlConnection Connection = new SqlConnection(clsContactsDataAccessLayer.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    ParameterSetter?.Invoke(Command);

                    try
                    {
                        Connection.Open();
                        object Result = Command.ExecuteScalar();

                        if (Result != null && Result != DBNull.Value)
                            Value = (T)Convert.ChangeType(Result, typeof(T));
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        Connection.Close();
                    }
                }
            }
            return Value;
        }

        public static int ExecuteNonQuery(string Query, Action<SqlCommand> ParameterSetter)
        {
            int RowsAffected = 0;
            using (SqlConnection Connection = new SqlConnection(clsContactsDataAccessLayer.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    ParameterSetter?.Invoke(Command);

                    try
                    {
                        Connection.Open();
                        RowsAffected = Command.ExecuteNonQuery();
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        Connection.Close();
                    }
                }
            }
            return RowsAffected;
        }



        public static bool ExecuteReader(string Query, Action<SqlCommand> ParameterSetter, Action<SqlDataReader> ReaderHandler)
        {
            bool IsFound = false;

            using(SqlConnection Connection = new SqlConnection(clsContactsDataAccessLayer.ConnectionString))
            {
                using(SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    ParameterSetter?.Invoke(Command);

                    try
                    {
                        Connection.Open();
                        SqlDataReader Reader = Command.ExecuteReader();

                        if (Reader.Read())
                        {
                            IsFound = true;
                            ReaderHandler(Reader);
                        }

                        Reader.Close();
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        Connection.Close();
                    }
                }
            }

            return IsFound;
        }


        public static bool Exists(string Query, Action<SqlCommand> ParameterSetter)
        {
            bool Exists = false;

            using (SqlConnection Connection = new SqlConnection(clsContactsDataAccessLayer.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    ParameterSetter?.Invoke(Command);

                    try
                    {
                        Connection.Open();
                        object Result = Command.ExecuteScalar();
                        Exists = (Result != null && Result != DBNull.Value);
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        Connection.Close();
                    }
                }
            }
            return Exists;
        }

        public static List<T> ReadList<T>(string Query, Action<SqlCommand> ParameterSetter, Func<SqlDataReader, T> Mapper)
        {
            List<T> List = new List<T>();

            using(SqlConnection Connection = new SqlConnection(clsContactsDataAccessLayer.ConnectionString))
            {
                using(SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    ParameterSetter?.Invoke(Command);

                    try
                    {
                        Connection.Open();
                        SqlDataReader Reader = Command.ExecuteReader();

                        while (Reader.Read())
                            List.Add(Mapper(Reader));

                        Reader.Close();
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        Connection.Close();
                    }
                }
            }

            return List;
        }

        public static DataTable ReadDataTable(string Query, Action<SqlCommand> ParamSetter)
        {
            DataTable Table = new DataTable();
            using(SqlConnection Connection = new SqlConnection(clsContactsDataAccessLayer.ConnectionString))
            {
                using(SqlCommand Command = new SqlCommand(Query, Connection))
                {  
                    ParamSetter?.Invoke(Command);

                    try
                    {
                        Connection.Open();
                        Table.Load(Command.ExecuteReader());
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        Connection.Close();
                    }
                }
            }

            return Table;
        }

        public static bool ExecuteTransaction(Action<SqlCommand> Work)
        {
            bool IsSuccess = false;

            using(SqlConnection Connection = new SqlConnection(clsContactsDataAccessLayer.ConnectionString))
            {
                Connection.Open();

                using( SqlTransaction Transaction = Connection.BeginTransaction())
                {

                    using(SqlCommand Command = new SqlCommand())
                    {  
                        Command.Connection = Connection;
                        Command.Transaction = Transaction;

                        try
                        {

                            Work(Command);

                            Transaction.Commit();
                            IsSuccess = true;
                        }
                        catch
                        {
                            try { Transaction.Rollback(); } catch { }
                            throw;
                        }
                        finally
                        {
                            Connection.Close();
                        }
                    }
                }
            }

            return IsSuccess;
        }



    }

}
