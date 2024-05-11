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
    public class DAOSite
    {
        //private int NumberOfThread = 0;
        private DAOLog log = new DAOLog();

        public DAOSite()
        {           
        }

        private string GetConnectString()
        {
            return ConfigurationManager.AppSettings["ParallelSP"].ToString();
        }

        public List<string>[] SplitAllSites(int number_thread = 10)
        {
            //NumberOfThread = number_thread;

            List<string>[] sites = new List<string>[number_thread];
            for (int i = 0; i < number_thread; i++) sites[i] = new List<string>();

            using (SqlConnection site_conn = new SqlConnection(GetConnectString()))
            {
                double row_count = 0;
                try
                {
                    site_conn.Open();
                    using (SqlCommand site_comm = new SqlCommand())
                    {
                        site_comm.Connection = site_conn;
                        site_comm.CommandType = CommandType.Text;
                        site_comm.CommandText = "SELECT COUNT(1) FROM [dbo].[tbparallel_setstore]; ";

                        SqlDataReader site_reader = site_comm.ExecuteReader();

                        if (site_reader.HasRows)
                        {
                            site_reader.Read();
                            row_count = site_reader.GetInt32(0);
                        }
                        site_reader.Close();
                    }

                    int count = (int)(Math.Ceiling(row_count / number_thread));

                    using (SqlCommand site_comm = new SqlCommand())
                    {
                        site_comm.Connection = site_conn;
                        site_comm.CommandType = CommandType.Text;
                        site_comm.CommandText = @"
                                                SELECT IDX, RTRIM(LTRIM(ID)) AS ID
                                                    FROM ( SELECT ROW_NUMBER() OVER(ORDER BY [store_no]) AS IDX, 
                                                                  [store_no] AS ID, 
                                                                  [store_name] AS NAME
                                                             FROM [dbo].[tbparallel_setstore] ) A; ";

                        SqlDataReader site_reader = site_comm.ExecuteReader();

                        if (site_reader.HasRows)
                        {
                            while (site_reader.Read())
                            {
                                sites[(site_reader.GetInt64(0) - 1) / count].Add(site_reader.GetString(1));
                            }
                        }
                        site_reader.Close();
                    }

                }
                catch (Exception ex)
                {
                    site_conn.Close();
                    //Console.WriteLine(ex.Message);
                    log.PushAlarmNoti("", "DAOSite.SplitAllSites()", "執行錯誤", ex.Message);
                }
                finally
                {
                    site_conn.Close();
                }
            }

            return sites;
        }

        public List<string> ListAllSites()
        {
            List<string> sites = new List<string>();

            using (SqlConnection site_conn = new SqlConnection(GetConnectString()))
            {
                try
                {
                    site_conn.Open();

                    using (SqlCommand site_comm = new SqlCommand())
                    {
                        site_comm.Connection = site_conn;
                        site_comm.CommandType = CommandType.Text;
                        site_comm.CommandText = @"SELECT [store_no] FROM [dbo].[tbparallel_setstore] with (nolock); ";

                        SqlDataReader site_reader = site_comm.ExecuteReader();

                        if (site_reader.HasRows)
                        {
                            while (site_reader.Read())
                            {
                                sites.Add(site_reader.GetString(0));
                            }
                        }
                        site_reader.Close();
                    }

                }
                catch (Exception ex)
                {
                    site_conn.Close();
                    //Console.WriteLine(ex.Message);
                    log.PushAlarmNoti("", "DAOSite.ListAllSites()", "執行錯誤", ex.Message);
                }
                finally
                {
                    site_conn.Close();
                }
            }

            return sites;
        }

        /*
        public Dictionary<string, int> ListAllSites()
        {
            Dictionary<string, int> sites = new Dictionary<string, int>();

            using (SqlConnection site_conn = new SqlConnection(GetConnectString()))
            {
                try
                {
                    site_conn.Open();

                    using (SqlCommand site_comm = new SqlCommand())
                    {
                        site_comm.Connection = site_conn;
                        site_comm.CommandType = CommandType.Text;
                        site_comm.CommandText = @"SELECT [store_no] FROM [dbo].[tbparallel_setstore] with (nolock); ";

                        SqlDataReader site_reader = site_comm.ExecuteReader();

                        if (site_reader.HasRows)
                        {
                            while (site_reader.Read())
                            {
                                sites.Add(site_reader.GetString(0), 0);
                            }
                        }
                        site_reader.Close();
                    }

                }
                catch (Exception ex)
                {
                    site_conn.Close();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    site_conn.Close();
                }
            }

            return sites;
        }
        */

    }
}
