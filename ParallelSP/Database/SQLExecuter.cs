using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelSP.Database
{
    public class SQLExecuter
    {
        private SqlConnection Connection = null;
        private SqlCommand Command = null;
        private string CommandText = string.Empty;
        public string SPName { set { CommandText = value; } }
        private string ConnectionString = string.Empty;

        public SQLExecuter(string conn_string)
        {
            Connection = new SqlConnection(conn_string);
        }

        public bool ExecuteCommand(string sql_comm, CommandType sql_type, Dictionary<string, Tuple<SqlDbType, dynamic>> parameter, ref string error_msg)
        {
            bool is_success = false;
            Command = Connection.CreateCommand();
            Command.CommandText = sql_comm;
            Command.CommandType = sql_type;

            foreach(KeyValuePair<string, Tuple<SqlDbType, dynamic>> para in parameter)
            {
                Command.Parameters.Add(para.Key, para.Value.Item1).Value = para.Value.Item2;
            }

            try
            {
                Connection.Open();
                Command.ExecuteNonQuery();
                is_success = true;
            }
            catch(Exception ex)
            {
                error_msg = ex.Message;
                is_success = false;
            }
            finally
            {
                Command.Dispose();
                Connection.Close();
                Connection.Dispose();
            }

            return is_success;
        }


    }
}
