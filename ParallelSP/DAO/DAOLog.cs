using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallelSP.DAO
{
    public enum LogLevel : int
    {
        DEBUG = 0,
        INFO = 1,
        WARNING = 2,
        ERROR = 3,
        RETRY = 4,
        RETRY_FAIL = 5
    }



    public class DAOLog
    {
        private System.Object lockThis = new System.Object();

        public DAOLog()
        {
        }

        private string GetConnectString()
        {
            return ConfigurationManager.AppSettings["ParallelSP"].ToString();
        }

        public bool InsertLog(DAOProc proc, string batch_id, string thread_id, string run_time, string store_begin,  string store_end, string memo, LogLevel level=0)
        {
            bool is_success = false;

            using (SqlConnection log_conn = new SqlConnection(GetConnectString()))
            {
                try
                {
                    log_conn.Open();
                    using (SqlCommand log_comm = new SqlCommand())
                    {
                        log_comm.Connection = log_conn;
                        log_comm.CommandType = CommandType.Text;
                        log_comm.CommandText = @"EXEC [sp_parallel_log] @id, @time, @sp_type, @thread, @batch_id, @thread_id, @sp, @store_begin, @store_end, @log_level, @memo; ";

                        log_comm.Parameters.Add("@id", SqlDbType.VarChar).Value = proc.ID;
                        log_comm.Parameters.Add("@time", SqlDbType.VarChar).Value = run_time;
                        log_comm.Parameters.Add("@sp_type", SqlDbType.VarChar).Value = proc.SP_TYPE;
                        log_comm.Parameters.Add("@thread", SqlDbType.VarChar).Value = proc.THREAD.ToString().Trim();
                        log_comm.Parameters.Add("@batch_id", SqlDbType.VarChar).Value = batch_id;
                        log_comm.Parameters.Add("@thread_id", SqlDbType.VarChar).Value = thread_id;
                        log_comm.Parameters.Add("@sp", SqlDbType.VarChar).Value = proc.SP;
                        log_comm.Parameters.Add("@store_begin", SqlDbType.VarChar).Value = store_begin;
                        log_comm.Parameters.Add("@store_end", SqlDbType.VarChar).Value = store_end;
                        log_comm.Parameters.Add("@log_level", SqlDbType.Int).Value = level;
                        log_comm.Parameters.Add("@memo", SqlDbType.VarChar).Value = memo;

                        log_comm.ExecuteNonQuery();
                        is_success = true;
                    }

                }
                catch(Exception ex)
                {                 
                    is_success = false;
                    log_conn.Close();
                    //Console.WriteLine(ex.Message);

                    PushAlarmNoti("", "DAOLog.InsertLog()", "執行錯誤", ex.Message);
                }
                finally
                {
                    log_conn.Close();
                }

                return is_success;
            }
        }

        public DataTable GetLog()
        {
            DataTable proc_table = new DataTable();

            using (SqlConnection proc_conn = new SqlConnection(GetConnectString()))
            {
                try
                {
                    using (SqlCommand proc_comm = new SqlCommand())
                    {
                        proc_comm.Connection = proc_conn;
                        proc_comm.CommandType = CommandType.Text;
                        proc_comm.CommandText = @"SELECT log_id, id, time, sp_type, thread, batch_id, thread_id, sp, store_begin, store_end,
                                                         CASE log_level
	                                                        WHEN 0 THEN '測試'
	                                                        WHEN 1 THEN '訊息'
	                                                        WHEN 2 THEN '警告'
                                                            WHEN 3 THEN '錯誤'
                                                            WHEN 4 THEN '重試'
                                                            WHEN 5 THEN '重試失敗'
	                                                        ELSE '未定義' 
	                                                     END AS level,
                                                         memo, crt_date, crt_by
                                                    FROM [dbo].[tbparallel_log] WITH (NOLOCK)
                                                   WHERE crt_date > CONVERT(varchar, GETDATE()-1, 111)
                                                   ORDER BY log_id desc";

                        SqlDataAdapter proc_adpt = new SqlDataAdapter(proc_comm);
                        DataSet proc_ds = new DataSet();
                        proc_adpt.Fill(proc_ds, "log");
                        proc_table = proc_ds.Tables[0];
                    }
                }
                catch (Exception ex)
                {
                    proc_conn.Close();
                    //Console.WriteLine(ex.Message);
                    PushAlarmNoti("", "DAOLog.GetLog()", "執行錯誤", ex.Message);
                }
                finally
                {
                    proc_conn.Close();
                }
            }

            return proc_table;
        }

        public DataTable GetLog(int log_level)
        {
            DataTable proc_table = new DataTable();

            using (SqlConnection proc_conn = new SqlConnection(GetConnectString()))
            {
                try
                {
                    using (SqlCommand proc_comm = new SqlCommand())
                    {
                        proc_comm.Connection = proc_conn;
                        proc_comm.CommandType = CommandType.Text;
                        proc_comm.CommandText = @"SELECT log_id, id, time, sp_type, thread, batch_id, thread_id, sp, store_begin, store_end,
                                                         CASE log_level
	                                                        WHEN 0 THEN '測試'
	                                                        WHEN 1 THEN '訊息'
	                                                        WHEN 2 THEN '警告'
                                                            WHEN 3 THEN '錯誤'
                                                            WHEN 4 THEN '重試'
                                                            WHEN 5 THEN '重試失敗'
	                                                        ELSE '未定義' 
	                                                     END AS level,
                                                         memo, crt_date, crt_by
                                                    FROM [dbo].[tbparallel_log] WITH (NOLOCK)
                                                   WHERE crt_date > CONVERT(varchar, GETDATE()-7, 111)
                                                     AND log_level  >= @level
                                                   ORDER BY log_id desc";

                        proc_comm.Parameters.Add("@level", SqlDbType.Int).Value = log_level;

                        SqlDataAdapter proc_adpt = new SqlDataAdapter(proc_comm);
                        DataSet proc_ds = new DataSet();
                        proc_adpt.Fill(proc_ds, "log");
                        proc_table = proc_ds.Tables[0];
                    }
                }
                catch (Exception ex)
                {
                    proc_conn.Close();
                    //Console.WriteLine(ex.Message);
                    PushAlarmNoti("", "DAOLog.GetLog()", "執行錯誤", ex.Message);
                }
                finally
                {
                    proc_conn.Close();
                }
            }

            return proc_table;
        }

        public DataTable GetLog(string date_begin, string date_end, string proc_id = "", int log_level = 2)
        {
            DataTable proc_table = new DataTable();

            using (SqlConnection proc_conn = new SqlConnection(GetConnectString()))
            {
                try
                {
                    using (SqlCommand proc_comm = new SqlCommand())
                    {
                        proc_comm.Connection = proc_conn;
                        proc_comm.CommandType = CommandType.Text;
                        proc_comm.CommandText = @"SELECT log_id, id, time, sp_type, thread, batch_id, thread_id, sp, store_begin, store_end,
                                                         CASE log_level
	                                                        WHEN 0 THEN '測試'
	                                                        WHEN 1 THEN '訊息'
	                                                        WHEN 2 THEN '警告'
                                                            WHEN 3 THEN '錯誤'
                                                            WHEN 4 THEN '重試'
                                                            WHEN 5 THEN '重試失敗'
	                                                        ELSE '未定義' 
	                                                     END AS level,
                                                         memo, crt_date, crt_by
                                                    FROM [dbo].[tbparallel_log] WITH (NOLOCK)
                                                   WHERE (crt_date >= @date_begin and crt_date <= @date_end)
                                                     AND (id = @proc_id OR @proc_id = '')
                                                     AND log_level >= @level
                                                   ORDER BY log_id ";

                        proc_comm.Parameters.Add("@date_begin", SqlDbType.VarChar).Value = date_begin;
                        proc_comm.Parameters.Add("@date_end", SqlDbType.VarChar).Value = date_end;
                        proc_comm.Parameters.Add("@proc_id", SqlDbType.VarChar).Value = proc_id;
                        proc_comm.Parameters.Add("@level", SqlDbType.Int).Value = log_level;

                        SqlDataAdapter proc_adpt = new SqlDataAdapter(proc_comm);
                        DataSet proc_ds = new DataSet();
                        proc_adpt.Fill(proc_ds, "log");
                        proc_table = proc_ds.Tables[0];
                    }
                }
                catch (Exception ex)
                {
                    proc_conn.Close();
                    //Console.WriteLine(ex.Message);
                    PushAlarmNoti("", "DAOLog.GetLog()", "執行錯誤", ex.Message);
                }
                finally
                {
                    proc_conn.Close();
                }
            }

            return proc_table;
        }

        public bool PushAlarmNoti(string time, string operation, string status, string content)
        {
            bool is_success = false;

            using (SqlConnection alarm_conn = new SqlConnection(GetConnectString()))
            {
                try
                {
                    alarm_conn.Open();
                    using (SqlCommand alarm_comm = new SqlCommand())
                    {
                        alarm_comm.Connection = alarm_conn;
                        alarm_comm.CommandType = CommandType.Text;
                        alarm_comm.CommandText = @"EXEC [sp_parallel_status]  @time, @operation, @status, @content; ";

                        alarm_comm.Parameters.Add("@time", SqlDbType.VarChar).Value = time;
                        alarm_comm.Parameters.Add("@operation", SqlDbType.VarChar).Value = operation;
                        alarm_comm.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
                        alarm_comm.Parameters.Add("@content", SqlDbType.VarChar).Value = content;

                        alarm_comm.ExecuteNonQuery();
                        is_success = true;
                    }
                }
                catch (Exception ex)
                {
                    is_success = false;
                    alarm_conn.Close();
                    //Console.WriteLine(ex.Message);
                    //PushAlarmNoti("", "DAOLog.PushAlarmNoti()", "執行錯誤", ex.Message);
                    //MessageBox.Show(ex.Message);
                    WriteLog(time, "DAOLog.PushAlarmNoti()", "執行錯誤", ex.Message);
                }
                finally
                {
                    alarm_conn.Close();
                }

                return is_success;
            }

        }

        public void WriteLog(string time, string operation, string status, string content)
        {
            try
            {
                lock (lockThis)
                {
                    string FilePath = Application.StartupPath;

                    string filename = FilePath +
                            string.Format("\\Log\\{0}_{1:yyyy-MM-dd}.txt", "ParallelSP", DateTime.Now);
                    FileInfo finfo = new FileInfo(filename);

                    if (finfo.Directory.Exists == false)
                    {
                        finfo.Directory.Create();
                    }

                    string writeString = string.Format("{0:yyyy/MM/dd HH:mm:ss} {1} {2} {3} {4}",
                        DateTime.Now, time, operation, status, content) + Environment.NewLine;

                    File.AppendAllText(filename, writeString, Encoding.Unicode);
                }
            }
            catch
            {
            }
        }

        /*
        public void WriteLog(string batch_id, string thread_id, string run_time, string store_begin, string store_end, string memo, LogLevel level = 0)
        {
            try
            {
                lock (lockThis)
                {
                    string FilePath = Application.StartupPath;

                    string filename = FilePath +
                            string.Format("\\Log\\{0}_{1:yyyy-MM-dd}.txt", "ParallelSP", DateTime.Now);
                    FileInfo finfo = new FileInfo(filename);

                    if (finfo.Directory.Exists == false)
                    {
                        finfo.Directory.Create();
                    }
                    string writeString = string.Format("{0:yyyy/MM/dd HH:mm:ss} {1} {2} {3} {4}-{5} {6,-8} {7}",
                            DateTime.Now, batch_id, thread_id, run_time, store_begin, store_end, level, memo) + Environment.NewLine;

                    File.AppendAllText(filename, writeString, Encoding.Unicode);
                }
            }
            catch
            { }
        }
        */

    }
}
