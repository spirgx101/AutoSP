using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelSP.DAO
{
    public class DAOProc
    {
        private DAOLog log = new DAOLog();

        #region 讀取 Procedure 設定
        private string _id = string.Empty;
        private string _sp_type = string.Empty;
        private string _ip = string.Empty;
        private string _db = string.Empty;
        private string _sp = string.Empty;
        private string _para = string.Empty;
        private string _conn_str = string.Empty;
        private int _cpu = 0;
        private int _thread = 0;


        public string ID
        {
            get { return _id; }
            private set { _id = value; }
        }

        public string SP_TYPE
        {
            get { return _sp_type; }
            private set { _sp_type = value; }
        }
        public string IP
        {
            get { return _ip; }
            private set { _ip = value; }
        }
        public string DB
        {
            get { return _db; }
            private set { _db = value; }
        }
        public string SP
        {
            get { return _sp; }
            private set { _sp = value; }
        }
        public string PARA
        {
            get { return _para; }
            private set { _para = value; }
        }
        public string CONN_STR
        {
            get { return _conn_str; }
            private set { _conn_str = value; }
        }
        public int CPU
        {
            get { return _cpu; }
            private set { _cpu = value; }
        }
        public int THREAD
        {
            get { return _thread; }
            private set { _thread = value; }
        }

        #endregion

        public DAOProc(string proc_id)
        {
            ID = proc_id;
            GetProcedureSetting(proc_id);
        }

        private string GetConnectString()
        {
            return ConfigurationManager.AppSettings["ParallelSP"].ToString();
        }

        private void GetProcedureSetting(string id)
        {
            using (SqlConnection proc_conn = new SqlConnection(GetConnectString()))
            {
                try
                {
                    proc_conn.Open();
                    using (SqlCommand proc_comm = new SqlCommand())
                    {
                        proc_comm.Connection = proc_conn;
                        proc_comm.CommandType = CommandType.Text;
                        proc_comm.CommandText = @"
                                                SELECT [id]
                                                      ,[sp_type]
                                                      ,[ip]
                                                      ,[db]
                                                      ,[sp]
                                                      ,[para]
                                                      ,[conn_str]
                                                      ,[cpu]
                                                      ,[thread]
                                                      ,[is_del]
                                                      ,[crt_date]
                                                      ,[crt_by]
                                                  FROM [dbo].[tbparallel_list]
                                                 WHERE id = @id";
                        proc_comm.Parameters.Add("@id", SqlDbType.VarChar).Value = id;


                        using (IDataReader proc_dr = proc_comm.ExecuteReader())
                        {
                            var ordinals = new
                            {
                                SP_TYPE  = proc_dr.GetOrdinal("sp_type"),
                                IP       = proc_dr.GetOrdinal("ip"),
                                DB       = proc_dr.GetOrdinal("db"),
                                SP       = proc_dr.GetOrdinal("sp"),
                                PARA     = proc_dr.GetOrdinal("para"),
                                CONN_STR = proc_dr.GetOrdinal("conn_str"),
                                CPU      = proc_dr.GetOrdinal("cpu"),
                                THREAD   = proc_dr.GetOrdinal("thread")
                            };

                            if (proc_dr.Read())
                            {
                                SP_TYPE  = proc_dr.GetString(ordinals.SP_TYPE);
                                IP       = proc_dr.GetString(ordinals.IP);
                                DB       = proc_dr.GetString(ordinals.DB);
                                SP       = proc_dr.GetString(ordinals.SP);
                                PARA     = proc_dr.GetString(ordinals.PARA);
                                CONN_STR = proc_dr.GetString(ordinals.CONN_STR);
                                CPU      = proc_dr.GetInt32(ordinals.CPU);
                                THREAD   = proc_dr.GetInt32(ordinals.THREAD);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    proc_conn.Close();
                    //Console.WriteLine(ex.Message);
                    log.PushAlarmNoti("", "DAOProc.GetProcedureSetting()", "執行錯誤", ex.Message);
                } 
                finally
                {
                    proc_conn.Close();
                }
            }
        }
    }
}
