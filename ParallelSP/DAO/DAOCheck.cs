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
    public class DAOCheck
    {
        private string PROCEDURE_ID = string.Empty;
        private string RUNNING_TIME = string.Empty;
        private DAOLog log = new DAOLog();

        public DAOCheck(string proc_id="", string run_time = "")
        {
            PROCEDURE_ID = proc_id;
            RUNNING_TIME = run_time;
        }

        private string GetConnectString()
        {
            return ConfigurationManager.AppSettings["ParallelSP"].ToString();
        }

        public bool StartProc()
        {
            bool is_success = false;

            using (SqlConnection proc_conn = new SqlConnection(GetConnectString()))
            {
                try
                {
                    proc_conn.Open();
                    using (SqlCommand log_comm = new SqlCommand())
                    {
                        log_comm.Connection = proc_conn;
                        log_comm.CommandType = CommandType.Text;
                        log_comm.CommandText = @"
                                                INSERT INTO [dbo].[tbparallel_check]
                                                           ([id]
                                                           ,[time]
                                                           ,[sp]
                                                           ,[status]
                                                           ,[begin_date]
                                                           ,[end_date])
                                                SELECT [id], @time, [sp], '1', GETDATE(), NULL
                                                  FROM [dbo].[tbparallel_list]
                                                 WHERE [id] = @id; ";

                        log_comm.Parameters.Add("@id", SqlDbType.VarChar).Value = PROCEDURE_ID;
                        log_comm.Parameters.Add("@time", SqlDbType.VarChar).Value = RUNNING_TIME;

                        log_comm.ExecuteNonQuery();
                        is_success = true;
                    }

                }
                catch (Exception ex)
                {
                    is_success = false;
                    proc_conn.Close();
                    //Console.WriteLine(ex.Message);
                    log.PushAlarmNoti("", "DAOCheck.StartProc()", "執行錯誤", ex.Message);
                }
                finally
                {
                    proc_conn.Close();
                }
            }
            return is_success;  
        }

        public bool StopProc()
        {
            bool is_success = false;

            using (SqlConnection proc_conn = new SqlConnection(GetConnectString()))
            {
                try
                {
                    proc_conn.Open();
                    using (SqlCommand log_comm = new SqlCommand())
                    {
                        log_comm.Connection = proc_conn;
                        log_comm.CommandType = CommandType.Text;
                        log_comm.CommandText = @"
                                                --BEGIN TRY
                                                --    BEGIN TRANSACTION;

                                                    UPDATE [dbo].[tbparallel_check]
                                                       SET [status] = '2' 
                                                          ,[end_date] = GETDATE()
                                                     WHERE id = @id
                                                       AND time = @time;

                                                    INSERT INTO [dbo].[tbparallel_checklog]
                                                        (id, time, sp, status, begin_date, end_date, crt_date)
                                                    SELECT [id]
                                                          ,[time]
                                                          ,[sp]
                                                          ,[status]
                                                          ,[begin_date]
                                                          ,[end_date]
                                                          ,getdate()
                                                      FROM [dbo].[tbparallel_check]
                                                     WHERE id = @id
                                                       AND time = @time;

                                                    DELETE [dbo].[tbparallel_check]
                                                     WHERE id = @id
                                                       AND time = @time;  

                                                --    COMMIT TRANSACTION;  
                                                --END TRY
                                                --BEGIN CATCH
                                                --    ROLLBACK TRANSACTION;  
                                                --END CATCH";

                        log_comm.Parameters.Add("@id", SqlDbType.VarChar).Value = PROCEDURE_ID;
                        log_comm.Parameters.Add("@time", SqlDbType.VarChar).Value = RUNNING_TIME;

                        log_comm.ExecuteNonQuery();
                        is_success = true;
                    }

                }
                catch (Exception ex)
                {
                    is_success = false;
                    proc_conn.Close();
                    //Console.WriteLine(ex.Message);
                    log.PushAlarmNoti("", "DAOCheck.StopProc()", "執行錯誤", ex.Message);
                }
                finally
                {
                    proc_conn.Close();
                }
            }
            return is_success;

        }

        public bool CheckProc()
        {
            bool is_running = false;

            using (SqlConnection proc_conn = new SqlConnection(GetConnectString()))
            {              
                try
                {
                    proc_conn.Open();
                    using (SqlCommand proc_comm = new SqlCommand())
                    {
                        proc_comm.Connection = proc_conn;
                        proc_comm.CommandType = CommandType.Text;
                        proc_comm.CommandText = @"SELECT *
                                                    FROM [dbo].[tbparallel_check] WITH (NOLOCK)
                                                   WHERE id = @id
                                                     AND time = @time
                                                     AND status = '1'; ";

                        proc_comm.Parameters.Add("@id", SqlDbType.VarChar).Value = PROCEDURE_ID;
                        proc_comm.Parameters.Add("@time", SqlDbType.VarChar).Value = RUNNING_TIME;

                        SqlDataReader site_reader = proc_comm.ExecuteReader();

                        if (site_reader.HasRows)
                        {
                            is_running = true;
                        }
                        site_reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    proc_conn.Close();
                    //Console.WriteLine(ex.Message);
                    log.PushAlarmNoti("", "DAOCheck.CheckProc()", "執行錯誤", ex.Message);
                }
                finally
                {
                    proc_conn.Close();
                }
             }

             return is_running;
        }

        public DataTable GetRunningProc()
        {
            DataTable proc_tbl = new DataTable();

            using (SqlConnection proc_conn = new SqlConnection(GetConnectString()))
            {
                try
                {
                    using (SqlCommand proc_comm = new SqlCommand())
                    {
                        proc_comm.Connection = proc_conn;
                        proc_comm.CommandType = CommandType.Text;
                        proc_comm.CommandText = @"SELECT id, time, sp, status, begin_date, end_date
                                                    FROM [dbo].[tbparallel_check] WITH (NOLOCK); ";

                        SqlDataAdapter proc_adpt = new SqlDataAdapter(proc_comm); 
                        DataSet proc_ds  = new DataSet();
                        proc_adpt.Fill(proc_ds, "check");
                        proc_tbl = proc_ds.Tables[0];
                    }
                }
                catch (Exception ex)
                {
                    proc_conn.Close();
                    //Console.WriteLine(ex.Message);
                    log.PushAlarmNoti("", "DAOCheck.GetRunningProc()", "執行錯誤", ex.Message);
                }
                finally
                {
                    proc_conn.Close();
                }
            }

            return proc_tbl;
            ;
        }

        public DataTable GetCheckLog()
        {
            DataTable proc_tbl = new DataTable();

            using (SqlConnection proc_conn = new SqlConnection(GetConnectString()))
            {
                try
                {
                    using (SqlCommand proc_comm = new SqlCommand())
                    {
                        proc_comm.Connection = proc_conn;
                        proc_comm.CommandType = CommandType.Text;
                        proc_comm.CommandText = @"SELECT log_id, id, time, sp, status, begin_date, end_date, diff_time, crt_date
                                                    FROM [dbo].[tbparallel_checklog] WITH (NOLOCK)
                                                   WHERE crt_date > CONVERT(VARCHAR, GETDATE()-1, 111)
                                                   ORDER BY crt_date desc";

                        SqlDataAdapter proc_adpt = new SqlDataAdapter(proc_comm);
                        DataSet proc_ds = new DataSet();
                        proc_adpt.Fill(proc_ds, "check");
                        proc_tbl = proc_ds.Tables[0];
                    }
                }
                catch (Exception ex)
                {
                    proc_conn.Close();
                    //Console.WriteLine(ex.Message);
                    log.PushAlarmNoti("", "DAOCheck.GetCheckLog()", "執行錯誤", ex.Message);
                }
                finally
                {
                    proc_conn.Close();
                }
            }

            return proc_tbl;
            ;
        }

        public DataTable GetCheckLog(string date_begin, string date_end, string proc_id = "")
        {
            DataTable proc_tbl = new DataTable();

            using (SqlConnection proc_conn = new SqlConnection(GetConnectString()))
            {
                try
                {
                    using (SqlCommand proc_comm = new SqlCommand())
                    {
                        proc_comm.Connection = proc_conn;
                        proc_comm.CommandType = CommandType.Text;
                        proc_comm.CommandText = @"SELECT log_id, id, time, sp, status, begin_date, end_date, diff_time, crt_date
                                                    FROM [dbo].[tbparallel_checklog] WITH (NOLOCK)
                                                   WHERE (crt_date >= @date_begin and crt_date <= @date_end)
                                                     AND (id = @proc_id OR @proc_id = '')
                                                   ORDER BY crt_date";


                        proc_comm.Parameters.Add("@date_begin", SqlDbType.VarChar).Value = date_begin ;
                        proc_comm.Parameters.Add("@date_end", SqlDbType.VarChar).Value = date_end;
                        proc_comm.Parameters.Add("@proc_id", SqlDbType.VarChar).Value = proc_id;

                        SqlDataAdapter proc_adpt = new SqlDataAdapter(proc_comm);
                        DataSet proc_ds = new DataSet();
                        proc_adpt.Fill(proc_ds, "check");
                        proc_tbl = proc_ds.Tables[0];
                    }
                }
                catch (Exception ex)
                {
                    proc_conn.Close();
                    //Console.WriteLine(ex.Message);
                    log.PushAlarmNoti("", "DAOCheck.GetCheckLog()", "執行錯誤", ex.Message);
                }
                finally
                {
                    proc_conn.Close();
                }
            }

            return proc_tbl;
            ;
        }

    }
}
