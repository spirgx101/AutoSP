using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelSP.Database
{
    public class SQLCommandInfo
    {
        private string _running_time = string.Empty;
        private string _string_no1 = string.Empty;
        private string _string_no2 = string.Empty;
        private string _sql_command = string.Empty;

        public string RUNNING_TIME
        {
            get { return _running_time; }
        }
        public string STRING_NO1
        {
            get { return _string_no1; }
        }
        public string STRING_NO2
        {
            get { return _string_no2; }
        }
        public string SQL_COMMAND
        {
            get { return _sql_command; }
        }

        public SQLCommandInfo(string sql_comm)
        {
            string[] s = sql_comm.Split('^');
            string[] p = s[0].Split(';');

            _running_time = p[0];
            _string_no1 = p[1];
            _string_no2 = p[2];
            _sql_command = s[1];
        }
    }
}
