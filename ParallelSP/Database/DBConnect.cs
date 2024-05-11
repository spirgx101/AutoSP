using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelSP.Database
{
    public class DBConnect
    {
        private string ConnectionString = string.Empty;

        public DBConnect(string conneString)
        {
            ConnectionString = conneString;
        }

        public DBConnect(string dataSource, string initialCatalog, string userId, string password)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();

            scsb.DataSource = dataSource;
            scsb.InitialCatalog = initialCatalog;
            scsb.UserID = userId;
            scsb.Password = password;
            scsb.IntegratedSecurity = false;

            ConnectionString = scsb.ConnectionString;
        }

        public SqlConnection CreateConnection()
        {         
            return new SqlConnection(ConnectionString);
        }

    }
}
