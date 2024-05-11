using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ParallelSP.DAO;
using ParallelSP.Common;

namespace ParallelSP.Database
{
    public class PSPExecuter
    {

        private DAOProc Procedure = null;


        public PSPExecuter(string proc_id)
        {
            Procedure = new DAOProc(proc_id);
        }

        public void RunSqlCommand(List<string> sql_comm, string info, string mail)
        {

            string batch_id = Guid.NewGuid().ToString();
            int thread_id = 0;
            Email email = new Email();

            bool is_retry = false;


            Parallel.ForEach(sql_comm, (comm) =>
            {
                SQLCommandInfo sql_info = new SQLCommandInfo(comm);
                DAOLog log = new DAOLog();
                

                string thread_sid = (++thread_id).ToString("000");

                log.InsertLog(Procedure, batch_id, thread_sid, sql_info.RUNNING_TIME, 
                        sql_info.STRING_NO1, sql_info.STRING_NO2, "START", LogLevel.INFO);

                using (SqlConnection connection = new SqlConnection(Procedure.CONN_STR))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.Connection = connection;
                            command.CommandType = CommandType.Text;
                            command.CommandText = sql_info.SQL_COMMAND;
                            command.CommandTimeout = 0;

                            command.ExecuteNonQuery();

                            is_retry = false;

                            //if (mail == "1") email.Send(Procedure.ID);

                            log.InsertLog(Procedure, batch_id, thread_sid, sql_info.RUNNING_TIME,
                                sql_info.STRING_NO1, sql_info.STRING_NO2, "END", LogLevel.INFO);
                        }
                    }
                    catch (Exception ex)
                    {
                        is_retry = true;

                        log.InsertLog(Procedure, batch_id, thread_sid, sql_info.RUNNING_TIME,
                            sql_info.STRING_NO1, sql_info.STRING_NO2, ex.Message, LogLevel.ERROR);

                        //log.PushAlarmNoti(sql_info.RUNNING_TIME, sql_info.SQL_COMMAND, "執行錯誤",
                        //    sql_info.STRING_NO1 + "~" + sql_info.STRING_NO2 + Environment.NewLine + ex.Message);
                    }
                    finally
                    {                      
                        connection.Close();
                        connection.Dispose();
                    }
                }
               
                if (is_retry == true)
                {
                    log.InsertLog(Procedure, batch_id, thread_sid, sql_info.RUNNING_TIME,
                        sql_info.STRING_NO1, sql_info.STRING_NO2, "60秒後重新執行", LogLevel.RETRY);

                    //失敗後10秒重新執行
                    Thread.Sleep(60000);

                    using (SqlConnection retry_conn = new SqlConnection(Procedure.CONN_STR))
                    {
                        try
                        {
                            retry_conn.Open();
                            using (SqlCommand retry_comm = new SqlCommand())
                            {
                                retry_comm.Connection = retry_conn;
                                retry_comm.CommandType = CommandType.Text;
                                retry_comm.CommandText = sql_info.SQL_COMMAND;
                                retry_comm.CommandTimeout = 0;

                                retry_comm.ExecuteNonQuery();

                                //if (mail == "1") email.Send(Procedure.ID);

                                log.InsertLog(Procedure, batch_id, thread_sid, sql_info.RUNNING_TIME,
                                    sql_info.STRING_NO1, sql_info.STRING_NO2, "重新執行成功", LogLevel.RETRY);
                            }
                        }
                        catch (Exception ex)
                        {
                            log.InsertLog(Procedure, batch_id, thread_sid, sql_info.RUNNING_TIME,
                                sql_info.STRING_NO1, sql_info.STRING_NO2, "重新執行失敗：" + ex.Message, LogLevel.RETRY_FAIL);

                            if (info == "1")
                            {
                                log.PushAlarmNoti(sql_info.RUNNING_TIME, sql_info.SQL_COMMAND, "重新執行失敗",
                                    "重新執行失敗：" + sql_info.STRING_NO1 + "~" + sql_info.STRING_NO2 + Environment.NewLine + ex.Message);
                            }
                        }
                        finally
                        {
                            retry_conn.Close();
                            retry_conn.Dispose();
                        }
                    }
                }            
            });

            if (mail == "1") email.Send(Procedure.ID);
        }

    }
}
