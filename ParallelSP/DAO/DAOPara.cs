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
    public class DAOPara
    {
        private string PARAMETER_ID = string.Empty;
        private DAOLog log = new DAOLog();

        public DAOPara(string para_id)
        {
            PARAMETER_ID = para_id;
        }

        private string GetConnectString()
        {
            return ConfigurationManager.AppSettings["ParallelSP"].ToString();
        }

        public string GetParameterValue()
        {
            string para_value = string.Empty;

            using (SqlConnection para_conn = new SqlConnection(GetConnectString()))
            {
                try
                {
                    para_conn.Open();
                    using (SqlCommand para_comm = new SqlCommand())
                    {
                        para_comm.Connection = para_conn;
                        para_comm.CommandType = CommandType.Text;
                        para_comm.CommandText = @"
                                                SELECT [para_desc]
                                                  FROM [dbo].[tbparallel_para]
                                                 WHERE para_id = @para_id; ";

                        para_comm.Parameters.Add("@para_id", SqlDbType.VarChar).Value = PARAMETER_ID;

                        using (SqlDataReader para_reader = para_comm.ExecuteReader())
                        {
                            if (para_reader.HasRows)
                            {
                                while (para_reader.Read())
                                {
                                    if (para_reader.HasRows)
                                    {
                                        para_value = para_reader.GetString(0);
                                    }
                                }
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    para_conn.Close();
                    //Console.WriteLine(ex.Message);
                    log.PushAlarmNoti("", "DAOPara.GetParameterValue()", "執行錯誤", ex.Message);
                }
                finally
                {
                    para_conn.Close();
                }
            }

            return para_value;
        }

        public string GetParameterValueOfString(string connection, string command)
        {
            string para_value = string.Empty;

            using (SqlConnection para_conn = new SqlConnection(connection))
            {
                try
                {
                    para_conn.Open();
                    using (SqlCommand para_comm = new SqlCommand())
                    {
                        para_comm.Connection = para_conn;
                        para_comm.CommandType = CommandType.Text;
                        para_comm.CommandText = command;

                        using (SqlDataReader para_reader = para_comm.ExecuteReader())
                        {
                            if (para_reader.HasRows)
                            {
                                while (para_reader.Read())
                                {
                                    if (para_reader.HasRows)
                                    {
                                        para_value = para_reader.GetString(0);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    para_conn.Close();
                    //Console.WriteLine(ex.Message);
                    log.PushAlarmNoti("", "DAOPara.GetParameterValueOfString()", "執行錯誤", ex.Message);
                }
                finally
                {
                    para_conn.Close();
                }
            }

            return "'" + para_value + "'";
        }

        public DataTable GetParameterValueOfDatatable(string connection, string command)
        {
            DataTable para_table = new DataTable();

            using (SqlConnection para_conn = new SqlConnection(connection))
            {
                try
                {
                    para_conn.Open();
                    using (SqlCommand para_comm = new SqlCommand())
                    {
                        para_comm.Connection = para_conn;
                        para_comm.CommandType = CommandType.Text;
                        para_comm.CommandText = command;

                        SqlDataAdapter proc_adpt = new SqlDataAdapter(para_comm);
                        DataSet proc_ds = new DataSet();
                        proc_adpt.Fill(proc_ds, "para_table");
                        para_table = proc_ds.Tables[0];
                    }
                }
                catch (Exception ex)
                {
                    para_conn.Close();
                    //Console.WriteLine(ex.Message);
                    log.PushAlarmNoti("", "DAOPara.GetParameterValueOfDatatable", "執行錯誤", ex.Message);
                }
                finally
                {
                    para_conn.Close();
                }
            }


            return para_table;
        }
    }
}
