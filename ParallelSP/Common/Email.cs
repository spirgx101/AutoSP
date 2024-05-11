using ParallelSP.DAO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ParallelSP.Common
{
    public class Email
    {
        private string subject = string.Empty;
        private string text = string.Empty;
        private string send_id = string.Empty;
        private string[] receive_id = new string[] { };
        private string[] cc_id = new string[] { };
        private string[] bcc_id = new string[] { };

        

        private DAOLog log = new DAOLog();

        private string GetConnectString()
        {
            return ConfigurationManager.AppSettings["ParallelSP"].ToString();
        }

        public Email()
        {
        }

        public void Send(string proc_id)
        {
            DataTable dt_before = new DataTable();
            DataTable dt_after = new DataTable();

            dt_before = Get_Mail_Data(proc_id);

            if (dt_before != null)
            {
                foreach (DataRow dr in dt_before.Rows)
                {
                    string sp = dr["update_sp"].ToString();
                    if (Exec_UpdateSP(sp) == "Y")
                    {
                        string mail_id = dr["mail_id"].ToString();
                        dt_after = Get_Mail_Data(proc_id, mail_id);
                        if (dt_after.Rows != null && dt_after.Rows.Count > 0)
                        {
                            Get_MailInfo_And_Send(dt_after);
                        }
                        else
                        {
                            throw new Exception("Email寄送失敗!!");
                        }
                    }
                }              
            }
            else
            {
                throw new Exception("Email寄送失敗!!");
            }
        }

        private void Get_MailInfo_And_Send(DataTable mail)
        {
            foreach(DataRow dr in mail.Rows)
            {
                string subject = dr["mail_subject"].ToString();
                string mail_html = dr["mail_html"].ToString();
                string sender = "WebManager@pxmart.com.tw";
                string[] receive = dr["mail_to"].ToString().Split(';');
                string[] cc = dr["mail_cc"].ToString().Split(';');
                string[] bcc = dr["mail_bcc"].ToString().Split(';');

                Send_Mail(subject, mail_html, sender, receive, cc, bcc);
            }
        }

        private DataTable Get_Mail_Data(string proc_id, string mail_id = "")
        {
            DataTable ret = new DataTable();

            using (SqlConnection mail_conn = new SqlConnection(GetConnectString()))
            {
                try
                {
                    mail_conn.Open();
                 
                    string sqlstr = @"
                                    SELECT [proc_id]
                                            ,[mail_id]
                                            ,[mail_seq]
                                            ,[mail_to]
                                            ,[mail_cc]
                                            ,[mail_bcc]
                                            ,[subject_org]
                                            ,[html_org]
                                            ,[update_sp]
                                            ,[mail_subject]
                                            ,[mail_html]
                                            ,[enabled]
                                        FROM [PLS].[dbo].[tbparallel_mail]
                                        WHERE proc_id = @proc_id
                                    ";

                    sqlstr += mail_id.Trim() != string.Empty ? " And mail_id = @mail_id ;" : ";";

                    ret.Clear();

                    using (SqlDataAdapter mail_da = new SqlDataAdapter())
                    {

                        mail_da.SelectCommand = new SqlCommand(sqlstr, mail_conn);
                        
                        mail_da.SelectCommand.Parameters.AddWithValue("@proc_id", proc_id);

                        if (mail_id.Trim() != string.Empty)
                        {
                            mail_da.SelectCommand.Parameters.AddWithValue("@mail_id", mail_id);
                        }

                        mail_da.Fill(ret);                                            
                    }
                }
                catch 
                {
                    ret = null;
                }
            }

            return ret;
        }

        private string Exec_UpdateSP(string sp)
        {
            string flag = "N";

            using (SqlConnection conn = new SqlConnection(GetConnectString()))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandType = CommandType.Text;
                        comm.CommandTimeout = 0;
                        comm.CommandText = sp;

                        flag = comm.ExecuteScalar().ToString().ToUpper().Trim();
                    }
                }
                catch 
                {
                    flag = "N";
                }                           
            }

            return flag;
        }

        private void Send_Mail(String Subject, String Text, String SenderId, String[] AddresseeId, String[] CCIds, String[] bCCIds)
        {
            //MailMessage message = new MailMessage(SenderId, AddresseeId); // MailMessage(寄信者, 收信者)
            MailMessage message = new MailMessage();
            message.From = new MailAddress(SenderId);

            foreach (string mailto in AddresseeId) message.To.Add(mailto);


            message.IsBodyHtml = true;

            message.BodyEncoding = System.Text.Encoding.UTF8; // E-mail編碼

            message.Subject = Subject; // E-mail主旨

            message.Body = Text; // E-mail內容

            foreach (String ccid in CCIds)
            {
                if (ccid == "") { break; }

                message.CC.Add(ccid);
            }

            foreach (String bccid in bCCIds)
            {
                if (bccid == "") { break; }

                message.Bcc.Add(bccid);
            }

            SmtpClient smtpClient = new SmtpClient("mail.pxmart.com.tw", 25); //設定E-mail Server 和 port

            smtpClient.Timeout = 30 * 1000; // 30s. 預設值100s. 

            smtpClient.Send(message);

            smtpClient.Dispose();
        }
    }
}
