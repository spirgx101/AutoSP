using ParallelSP.DAO;
using ParallelSP.Database;
using ParallelSP.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelSP.DAO
{
    public class AutoExecuteSP
    {
        //private UltraHighAccurateTimer AutoExecuteTimer;

        private MicroLibrary.MicroTimer MICRO_TIMER = null;

        public AutoExecuteSP()
        {
            //TimerCallback callback = new TimerCallback(CheckRunTime);
            //System.Threading.Timer timer = new System.Threading.Timer(callback, null, 0, 60000);

            //this.AutoExecuteTimer = new UltraHighAccurateTimer();
            //this.AutoExecuteTimer.Interval = 60000;
            //this.AutoExecuteTimer.Tick += new UltraHighAccurateTimer.ManualTimerEventHandler(AutoExecuteTimer_Tick);
            //this.AutoExecuteTimer.Start();

            this.MICRO_TIMER = new MicroLibrary.MicroTimer();
            MICRO_TIMER.MicroTimerElapsed += new MicroLibrary.MicroTimer.MicroTimerElapsedEventHandler(OnTimedEvent);
            MICRO_TIMER.Interval = 60000000;
            MICRO_TIMER.Enabled = true;
        }

        private string GetConnectString()
        {
            return ConfigurationManager.AppSettings["ParallelSP"].ToString();
        }


        private void OnTimedEvent(object sender, MicroLibrary.MicroTimerEventArgs timerEventArgs)
        {
            string now_hhmm = DateTime.Now.ToString("HH:mm");
            //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
            DAOLog log = new DAOLog();

            using (SqlConnection time_conn = new SqlConnection(GetConnectString()))
            {
                try
                {
                    time_conn.Open();
                    using (SqlCommand repeat_check_com = new SqlCommand())
                    {
                        repeat_check_com.Connection = time_conn;
                        repeat_check_com.CommandType = CommandType.Text;
                        repeat_check_com.CommandText = @"
                                                SELECT a.[id], b.[time] 
                                                  FROM [dbo].[tbparallel_setweek] a
                                                 INNER JOIN [dbo].[tbparallel_settime] b
                                                    ON a.[id] = b.[id]
                                                       AND b.[time] = @time
	                                                   AND b.[enabled] = '1'
                                                 INNER JOIN [dbo].[tbparallel_list] c
	                                                ON a.id = b.id
	                                                   AND b.id = c.id
	                                                   AND c.is_del = '0'
                                                WHERE 
                                                EXISTS (
	                                                SELECT [id]
	                                                  FROM [dbo].[tbparallel_check]
	                                                 WHERE a.id = id
	                                                   AND [status] = '1'
                                                )
                                                AND (SELECT 
                                                        CASE DATEPART(dw, GETDATE())
			                                                WHEN 1 THEN sun
			                                                WHEN 2 THEN mon
			                                                WHEN 3 THEN tue
			                                                WHEN 4 THEN wed
			                                                WHEN 5 THEN thu
			                                                WHEN 6 THEN fri
			                                                WHEN 7 THEN sat 
			                                            END)  = '1'; ";

                        repeat_check_com.Parameters.Add("@time", SqlDbType.VarChar).Value = now_hhmm;


                        using (SqlDataReader repeat_check_reader = repeat_check_com.ExecuteReader())
                        {
                            if (repeat_check_reader.HasRows)
                            {
                                while (repeat_check_reader.Read())
                                {
                                    if ((repeat_check_reader.HasRows) && (!repeat_check_reader[0].Equals(DBNull.Value)))
                                    {
                                        string proc_id = repeat_check_reader.GetString(0);
                                        string run_time = repeat_check_reader.GetString(1);
                                        string proc_memo = "重覆執行 [" + proc_id + "]，時間 [" + run_time + "]";

                                        DAOProc proc = new DAOProc(proc_id);
                                        log.InsertLog(proc, Guid.NewGuid().ToString(), "999", now_hhmm, "", "", proc_memo, LogLevel.WARNING);
                                        log.PushAlarmNoti(now_hhmm, proc.SP, "執行錯誤", proc_memo);
                                    }
                                }
                            }
                        }
                    }


                    using (SqlCommand time_comm = new SqlCommand())
                    {
                        time_comm.Connection = time_conn;
                        time_comm.CommandType = CommandType.Text;
                        time_comm.CommandText = @"
                                                SELECT a.[id], b.[time], b.[info], b.[mail]
                                                  FROM [dbo].[tbparallel_setweek] a
                                                 INNER JOIN [dbo].[tbparallel_settime] b
                                                    ON a.[id] = b.[id]
                                                       AND b.[time] = @time
	                                                   AND b.[enabled] = '1'
                                                 INNER JOIN [dbo].[tbparallel_list] c
	                                                ON a.id = b.id
	                                                   AND b.id = c.id
	                                                   AND c.is_del = '0'
                                                WHERE 
                                                NOT EXISTS (
	                                                SELECT [id]
	                                                  FROM [dbo].[tbparallel_check]
	                                                 WHERE a.id = id
	                                                   AND [status] = '1'
                                                )
                                                AND (SELECT 
                                                        CASE DATEPART(dw, GETDATE())
			                                                WHEN 1 THEN sun
			                                                WHEN 2 THEN mon
			                                                WHEN 3 THEN tue
			                                                WHEN 4 THEN wed
			                                                WHEN 5 THEN thu
			                                                WHEN 6 THEN fri
			                                                WHEN 7 THEN sat 
			                                            END)  = '1'; ";

                        time_comm.Parameters.Add("@time", SqlDbType.VarChar).Value = now_hhmm;

                        using (SqlDataReader time_reader = time_comm.ExecuteReader())
                        {
                            if (time_reader.HasRows)
                            {
                                while (time_reader.Read())
                                {
                                    if ((time_reader.HasRows) && (!time_reader[0].Equals(DBNull.Value)))
                                    {
                                        string[] para_obj = new string[4] { time_reader.GetString(0), time_reader.GetString(1), time_reader.GetString(2), time_reader.GetString(3) };

                                        Thread proc_thread = new Thread(RunParallelProcedure);
                                        proc_thread.Start(para_obj);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    time_conn.Close();
                    //Console.WriteLine(ex.Message);
                    log.PushAlarmNoti("", "AutoExecuteSP.AutoExecuteTimer()", "執行錯誤", ex.Message);
                }
                finally
                {
                    time_conn.Close();
                }
            }
        }

        /*
        private void AutoExecuteTimer_Tick(object sender)
        {
            string now_hhmm = DateTime.Now.ToString("HH:mm");
            //Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
            DAOLog log = new DAOLog();

            using (SqlConnection time_conn = new SqlConnection(GetConnectString()))
            {
                try
                {
                    time_conn.Open();
                    using (SqlCommand repeat_check_com = new SqlCommand())
                    {
                        repeat_check_com.Connection = time_conn;
                        repeat_check_com.CommandType = CommandType.Text;
                        repeat_check_com.CommandText = @"
                                                SELECT a.[id], b.[time] 
                                                  FROM [dbo].[tbparallel_setweek] a
                                                 INNER JOIN [dbo].[tbparallel_settime] b
                                                    ON a.[id] = b.[id]
                                                       AND b.[time] = @time
	                                                   AND b.[enabled] = '1'
                                                 INNER JOIN [dbo].[tbparallel_list] c
	                                                ON a.id = b.id
	                                                   AND b.id = c.id
	                                                   AND c.is_del = '0'
                                                WHERE 
                                                EXISTS (
	                                                SELECT [id]
	                                                  FROM [dbo].[tbparallel_check]
	                                                 WHERE a.id = id
	                                                   AND [status] = '1'
                                                )
                                                AND (SELECT 
                                                        CASE DATEPART(dw, GETDATE())
			                                                WHEN 1 THEN sun
			                                                WHEN 2 THEN mon
			                                                WHEN 3 THEN tue
			                                                WHEN 4 THEN wed
			                                                WHEN 5 THEN thu
			                                                WHEN 6 THEN fri
			                                                WHEN 7 THEN sat 
			                                            END)  = '1'; ";

                        repeat_check_com.Parameters.Add("@time", SqlDbType.VarChar).Value = now_hhmm;


                        using (SqlDataReader repeat_check_reader = repeat_check_com.ExecuteReader())
                        {
                            if (repeat_check_reader.HasRows)
                            {
                                while (repeat_check_reader.Read())
                                {
                                    if ((repeat_check_reader.HasRows) && (!repeat_check_reader[0].Equals(DBNull.Value)))
                                    {
                                        string proc_id = repeat_check_reader.GetString(0);
                                        string run_time = repeat_check_reader.GetString(1);
                                        string proc_memo = "重覆執行 [" + proc_id + "]，時間 [" + run_time +"]";
                                        
                                        DAOProc proc = new DAOProc(proc_id);
                                        log.InsertLog(proc, Guid.NewGuid().ToString(), "999", now_hhmm, "", "", proc_memo, LogLevel.WARNING);
                                        log.PushAlarmNoti(now_hhmm, proc.SP, "執行錯誤", proc_memo);
                                    }
                                }
                            }                        
                        }
                    }


                    using (SqlCommand time_comm = new SqlCommand())
                    {
                        time_comm.Connection = time_conn;
                        time_comm.CommandType = CommandType.Text;
                        time_comm.CommandText = @"
                                                SELECT a.[id], b.[time] 
                                                  FROM [dbo].[tbparallel_setweek] a
                                                 INNER JOIN [dbo].[tbparallel_settime] b
                                                    ON a.[id] = b.[id]
                                                       AND b.[time] = @time
	                                                   AND b.[enabled] = '1'
                                                 INNER JOIN [dbo].[tbparallel_list] c
	                                                ON a.id = b.id
	                                                   AND b.id = c.id
	                                                   AND c.is_del = '0'
                                                WHERE 
                                                NOT EXISTS (
	                                                SELECT [id]
	                                                  FROM [dbo].[tbparallel_check]
	                                                 WHERE a.id = id
	                                                   AND [status] = '1'
                                                )
                                                AND (SELECT 
                                                        CASE DATEPART(dw, GETDATE())
			                                                WHEN 1 THEN sun
			                                                WHEN 2 THEN mon
			                                                WHEN 3 THEN tue
			                                                WHEN 4 THEN wed
			                                                WHEN 5 THEN thu
			                                                WHEN 6 THEN fri
			                                                WHEN 7 THEN sat 
			                                            END)  = '1'; ";

                        time_comm.Parameters.Add("@time", SqlDbType.VarChar).Value = now_hhmm;

                        using (SqlDataReader time_reader = time_comm.ExecuteReader())
                        {
                            if (time_reader.HasRows)
                            {
                                while (time_reader.Read())
                                {
                                    if ((time_reader.HasRows) && (!time_reader[0].Equals(DBNull.Value)))
                                    {
                                        string[] para_obj = new string[2] { time_reader.GetString(0), time_reader.GetString(1) };

                                        Thread proc_thread = new Thread(RunParallelProcedure);
                                        proc_thread.Start(para_obj);
                                    }
                                }
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    time_conn.Close();
                    //this.AutoExecuteTimer.Stop();
                    //Console.WriteLine(ex.Message);
                    log.PushAlarmNoti("", "AutoExecuteSP.AutoExecuteTimer()", "執行錯誤", ex.Message);
                }
                finally
                {
                    time_conn.Close();
                }
            }
        }
        */

        private void RunParallelProcedure(object para_obj)
        {
            string proc_id = ((string[])para_obj)[0];
            string run_time = ((string[])para_obj)[1];
            string info = ((string[])para_obj)[2];
            string mail = ((string[])para_obj)[3];
            List<string> sql_comm = new List<string>();

            DAOCheck proc_check = new DAOCheck(proc_id, run_time);
            proc_check.StartProc();

            DAOProc proc = new DAOProc(proc_id);
            PSPExecuter executer = new PSPExecuter(proc_id);
            

            switch (proc.SP_TYPE.Substring(0, 1))
            {
                case "A": //門市代號                
                    sql_comm = GenerateSqlCommandTypeA(proc, run_time);
                    executer.RunSqlCommand(sql_comm, info, mail);
                    break;
                case "B": //貨號
                    sql_comm = GenerateSqlCommandTypeB(proc, run_time);
                    executer.RunSqlCommand(sql_comm, info, mail);
                    break;
                case "N": //其他
                    sql_comm = GenerateSqlCommandTypeN(proc, run_time);
                    executer.RunSqlCommand(sql_comm, info, mail);
                    break;
                case "Q":
                    PSPQueueExecuter queue_executer = new PSPQueueExecuter(proc_id, run_time, info, mail);
                    queue_executer.RunSqlCommand();
                    break;
            }

            try
            {
                proc_check.StopProc();
            }
            catch(Exception ex)
            {
                DAOLog log = new DAOLog();
                log.InsertLog(proc, Guid.NewGuid().ToString(), "999", run_time, "", "", ex.Message, LogLevel.ERROR);
                log.PushAlarmNoti(run_time, proc.SP, "結束失敗", ex.Message);
            }
        }

        private List<string> GenerateSqlCommandTypeN(DAOProc proc, string run_time)
        {
            IProcedureTypeN iproc_type = new ProcedureTypeN();
            List<string> commandList = new List<string>();

            commandList = iproc_type.CreateProcedureList(proc, run_time);

            return commandList;
        }

        private List<string> GenerateSqlCommandTypeA(DAOProc proc, string run_time)
        {
            IProcedureTypeA iproc_type = null;
            List<string> commandList = new List<string>();

            switch (proc.SP_TYPE)
            {
                case "A1":
                    iproc_type = new ProcedureTypeA1();
                    break;
                case "A2":
                    iproc_type = new ProcedureTypeA2();
                    break;
            }

            commandList = iproc_type.CreateProcedureList(proc, run_time);

            return commandList;
        }

        private List<string> GenerateSqlCommandTypeB(DAOProc proc, string run_time)
        {          
            IProcedureTypeB iproc_type = new ProcedureTypeB();
            List<string> commandList = new List<string>();

            commandList = iproc_type.CreateProcedureList(proc, run_time);

            return commandList;
        }
    }
}
