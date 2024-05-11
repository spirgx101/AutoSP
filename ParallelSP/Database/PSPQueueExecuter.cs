using ParallelSP.Common;
using ParallelSP.DAO;
using ParallelSP.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelSP.Database
{
    public class PSPQueueExecuter
    {
        private DAOProc Procedure = null;
        private string Run_Time = string.Empty;
        private string Info = string.Empty;
        private string Mail = string.Empty;

        public PSPQueueExecuter(string proc_id, string run_time, string info, string mail)
        {
            Procedure = new DAOProc(proc_id);
            Run_Time = run_time;
            Info = info;
            Mail = mail;
        }

        public void RunSqlCommand()
        {
            Object locker = new Object();
            string batch_id = Guid.NewGuid().ToString();
            int thread_id = 0;
            Email email = new Email();

            List<string> sites = new DAOSite().ListAllSites();


            Parallel.For(0, Procedure.THREAD, i =>
            {
                //SQLCommandInfo sql_info = new SQLCommandInfo(comm);

                ParameterParser Parser = new ParameterParser(Procedure);
                DAOLog log = new DAOLog();
                

                string thread_sid = (++thread_id).ToString("000");
                string site_id = string.Empty;
                string sql_command = string.Empty;
                bool is_retry = false;
          
                while (true)
                {
                    lock (locker)
                    {
                        if (sites.Any())
                        {
                            site_id = sites.First();
                            sites.Remove(sites.First());
                        }
                        else
                        {
                            break;
                        }
                    }


                    log.InsertLog(Procedure, batch_id, thread_sid, Run_Time,
                    site_id, site_id, "START", LogLevel.INFO);

                    using (SqlConnection connection = new SqlConnection(Procedure.CONN_STR))
                    {
                        try
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand())
                            {
                                sql_command = "EXEC " + Procedure.SP + " " + Parser.Parse_Store_No(site_id);

                                command.Connection = connection;
                                command.CommandType = CommandType.Text;
                                command.CommandText = sql_command;
                                command.CommandTimeout = 0;
                               
                                command.ExecuteNonQuery();

                                is_retry = false;

                                //if (Mail == "1") email.Send(Procedure.ID);

                                log.InsertLog(Procedure, batch_id, thread_sid, Run_Time,
                                        site_id, site_id, "END", LogLevel.INFO);
                            }
                        }
                        catch (Exception ex)
                        {
                            is_retry = true;

                            log.InsertLog(Procedure, batch_id, thread_sid, Run_Time,
                                site_id, site_id, ex.Message, LogLevel.ERROR);

                            //log.PushAlarmNoti(Run_Time, Procedure.SP, "執行錯誤", site_id + Environment.NewLine + ex.Message);
                        }
                        finally
                        {
                            connection.Close();
                            connection.Dispose();
                        }
                    }

                    if (is_retry == true)
                    {
                        log.InsertLog(Procedure, batch_id, thread_sid, Run_Time,
                            site_id, site_id, "60秒後重新執行", LogLevel.RETRY);

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
                                    retry_comm.CommandText = sql_command;
                                    retry_comm.CommandTimeout = 0;

                                    retry_comm.ExecuteNonQuery();

                                    //if (Mail == "1") email.Send(Procedure.ID);

                                    log.InsertLog(Procedure, batch_id, thread_sid, Run_Time,
                                        site_id, site_id, "重新執行成功", LogLevel.RETRY);
                                }
                            }
                            catch (Exception ex)
                            {
                                log.InsertLog(Procedure, batch_id, thread_sid, Run_Time,
                                    site_id, site_id, "重新執行失敗：" + ex.Message, LogLevel.RETRY_FAIL);

                                if (Info == "1")
                                {
                                    log.PushAlarmNoti(Run_Time, sql_command, "重新執行失敗",
                                        "重新執行失敗：" + site_id + Environment.NewLine + ex.Message);
                                }
                            }
                            finally
                            {
                                retry_conn.Close();
                                retry_conn.Dispose();
                            }
                        }

                    }
                }

            });

            if (Mail == "1") email.Send(Procedure.ID);
        }

        /*
        private string GetSiteId(Dictionary<string, int> sites)
        {
            string site_id = string.Empty;

            var entry = sites.Where(e => e.Value == 0)
                    .Select(e => (KeyValuePair<string, int>?)e)
                    .FirstOrDefault();

            if (entry != null)
            {
                site_id = entry.Value.Key;
            }

            return site_id;
        }
        */


        /*
        while (sites.Any())
        {                   
            site_id = sites.First();
            sites.Remove(sites.First());

            log.InsertLog(Procedure, batch_id, thread_sid, Run_Time,
            site_id, site_id, "START", LogLevel.INFO);

            SqlConnection connection = new SqlConnection(Procedure.CONN_STR);

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "EXEC " + Procedure.SP + " " + Parser.Parser(site_id);
            command.CommandType = CommandType.Text;
            command.CommandTimeout = 0;

            try
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                isSuccess = false;
                command.Cancel();
                command.Dispose();
                connection.Close();
                connection.Dispose();

                log.InsertLog(Procedure, batch_id, thread_sid, Run_Time,
                        site_id, site_id, ex.Message, LogLevel.ERROR);

                //throw new Exception(ex.Message);
            }
            finally
            {
                command.Connection.Close();
                command.Dispose();
                connection.Dispose();

                log.InsertLog(Procedure, batch_id, thread_sid, Run_Time,
                        site_id, site_id, "END", LogLevel.INFO);

            }    
        }
        */

}
}
