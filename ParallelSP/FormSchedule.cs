using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallelSP
{
    public partial class FormSchedule : Form
    {
        private BindingSource source_list = new BindingSource();
        private BindingSource source_week = new BindingSource();
        private BindingSource source_time = new BindingSource();
        private SqlDataAdapter adapter_list = new SqlDataAdapter();
        private SqlDataAdapter adapter_week = new SqlDataAdapter();
        private SqlDataAdapter adapter_time = new SqlDataAdapter();

        public FormSchedule()
        {
            InitializeComponent();
        }

        private string GetConnectString()
        {
            return ConfigurationManager.AppSettings["ParallelSP"].ToString();
        }

        private void GetConfigList()
        {

            try
            {
                string selectCommand =
                    @"SELECT [id]
                        ,[sp_type]
                        ,[ip]
                        ,[db]
                        ,[user_id]
                        ,[password]
                        ,[sp]
                        ,[para]
                        ,[conn_str]
                        ,[cpu]
                        ,[thread]
                        ,[is_del]
                        ,[crt_date]
                        ,[crt_by]
                    FROM [dbo].[tbparallel_list]; ";

                adapter_list = new SqlDataAdapter(selectCommand, GetConnectString());

                #region Insert Command
                adapter_list.InsertCommand = new SqlCommand(
                    @"INSERT INTO [dbo].[tbparallel_list]
                        ([id]
                        ,[sp_type]
                        ,[ip]
                        ,[db]
                        ,[user_id]
                        ,[password]
                        ,[sp]
                        ,[para]
                        ,[cpu]
                        ,[thread]
                        ,[is_del]
                        ,[crt_date]
                        ,[crt_by])
                      VALUES
                        (@id
                        ,@sp_type
                        ,@ip
                        ,@db
                        ,@user_id
                        ,@password
                        ,@sp
                        ,@para
                        ,@cpu
                        ,@thread
                        ,@is_del
                        ,getdate()
                        ,@crt_by); 
                      
                      INSERT INTO [dbo].[tbparallel_setweek]
                        ([id]
                        ,[sun]
                        ,[mon]
                        ,[tue]
                        ,[wed]
                        ,[thu]
                        ,[fri]
                        ,[sat]
                        ,[crt_date]
                        ,[crt_by])
                      VALUES
                        (@id
                        ,'1'
                        ,'1'
                        ,'1'
                        ,'1'
                        ,'1'
                        ,'1'
                        ,'1'
                        ,getdate()
                        ,@crt_by); 
                       
                      INSERT INTO [dbo].[tbparallel_settime]
                        ([id]
                        ,[time]
                        ,[enabled]
                        ,[crt_date]
                        ,[crt_by])
                      VALUES
                        (@id
                        ,'12:00'
                        ,'1'
                        ,getdate()
                        ,@crt_by); ",
                    new SqlConnection(GetConnectString()));

                adapter_list.InsertCommand.Parameters.Add("@id", SqlDbType.VarChar, 50, "id");
                adapter_list.InsertCommand.Parameters.Add("@sp_type", SqlDbType.VarChar, 5, "sp_type");
                adapter_list.InsertCommand.Parameters.Add("@ip", SqlDbType.VarChar, 15, "ip");
                adapter_list.InsertCommand.Parameters.Add("@db", SqlDbType.VarChar, 30, "db");
                adapter_list.InsertCommand.Parameters.Add("@user_id", SqlDbType.VarChar, 50, "user_id");
                adapter_list.InsertCommand.Parameters.Add("@password", SqlDbType.VarChar, 30, "password");
                adapter_list.InsertCommand.Parameters.Add("@sp", SqlDbType.VarChar, 100, "sp");
                adapter_list.InsertCommand.Parameters.Add("@para", SqlDbType.VarChar, 1000, "para");
                adapter_list.InsertCommand.Parameters.Add("@cpu", SqlDbType.Int, 1, "cpu");
                adapter_list.InsertCommand.Parameters.Add("@thread", SqlDbType.Int, 1, "thread");
                adapter_list.InsertCommand.Parameters.Add("@is_del", SqlDbType.Char, 1, "is_del");
                adapter_list.InsertCommand.Parameters.Add("@crt_date", SqlDbType.DateTime, 1, "crt_date");
                adapter_list.InsertCommand.Parameters.Add("@crt_by", SqlDbType.VarChar, 20, "crt_by");
                #endregion

                #region Update Command
                adapter_list.UpdateCommand = new SqlCommand(
                        @"UPDATE [dbo].[tbparallel_list]
                             SET [sp_type] = @sp_type
                                ,[ip] = @ip
                                ,[db] = @db
                                ,[user_id] = @user_id
                                ,[password] = @password
                                ,[sp] = @sp
                                ,[para] = @para
                                ,[cpu] = @cpu
                                ,[thread] = @thread
                                ,[is_del] = @is_del
                                ,[crt_date] = getdate()
                                ,[crt_by] = @crt_by
                           WHERE id = @id;   ",
                        new SqlConnection(GetConnectString()));

                adapter_list.UpdateCommand.Parameters.Add("@sp_type", SqlDbType.VarChar, 5, "sp_type");
                adapter_list.UpdateCommand.Parameters.Add("@ip", SqlDbType.VarChar, 15, "ip");
                adapter_list.UpdateCommand.Parameters.Add("@db", SqlDbType.VarChar, 30, "db");
                adapter_list.UpdateCommand.Parameters.Add("@user_id", SqlDbType.VarChar, 50, "user_id");
                adapter_list.UpdateCommand.Parameters.Add("@password", SqlDbType.VarChar, 30, "password");
                adapter_list.UpdateCommand.Parameters.Add("@sp", SqlDbType.VarChar, 100, "sp");
                adapter_list.UpdateCommand.Parameters.Add("@para", SqlDbType.VarChar, 1000, "para");
                adapter_list.UpdateCommand.Parameters.Add("@cpu", SqlDbType.Int, 1, "cpu");
                adapter_list.UpdateCommand.Parameters.Add("@thread", SqlDbType.Int, 1, "thread");
                adapter_list.UpdateCommand.Parameters.Add("@is_del", SqlDbType.Char, 1, "is_del");
                adapter_list.UpdateCommand.Parameters.Add("@crt_date", SqlDbType.DateTime, 1, "crt_date");
                adapter_list.UpdateCommand.Parameters.Add("@crt_by", SqlDbType.VarChar, 20, "crt_by");

                SqlParameter parameter = adapter_list.UpdateCommand.Parameters.Add("@id", SqlDbType.VarChar, 50);
                parameter.SourceColumn = "id";
                parameter.SourceVersion = DataRowVersion.Original;
                #endregion

                #region Delete Command
                adapter_list.DeleteCommand = new SqlCommand(
                    @"DELETE FROM [dbo].[tbparallel_list] WHERE id = @id;  
                      DELETE FROM [dbo].[tbparallel_setweek] WHERE id = @id;
                      DELETE FROM [dbo].[tbparallel_settime] WHERE id = @id; ",
                        new SqlConnection(GetConnectString()));

                adapter_list.DeleteCommand.Parameters.Add("@id", SqlDbType.VarChar, 50, "id");
                #endregion

                SqlCommandBuilder builder_list = new SqlCommandBuilder(adapter_list);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                adapter_list.Fill(table);
                source_list.DataSource = table;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetConfigWeek()
        {
            try
            {
                string selectCommand = string.Format(
                    @"SELECT [id] ,[sun] ,[mon] ,[tue] ,[wed] ,[thu] ,[fri] ,[sat] ,[crt_date] ,[crt_by] 
                        FROM [dbo].[tbparallel_setweek] WHERE id = '{0}'; ", DgvConfigList.CurrentRow.Cells["ColPorc_id"].Value.ToString());

                adapter_week = new SqlDataAdapter(selectCommand, GetConnectString());

                #region Update Command
                adapter_week.UpdateCommand = new SqlCommand(
                        @"UPDATE [dbo].[tbparallel_setweek]
                             SET [sun] = @sun
                                ,[mon] = @mon
                                ,[tue] = @tue
                                ,[wed] = @wed
                                ,[thu] = @thu
                                ,[fri] = @fri
                                ,[sat] = @sat
                                ,[crt_date] = getdate()
                                ,[crt_by] = @crt_by
                           WHERE id = @id;   ",
                        new SqlConnection(GetConnectString()));

                adapter_week.UpdateCommand.Parameters.Add("@sun", SqlDbType.Char, 1, "sun");
                adapter_week.UpdateCommand.Parameters.Add("@mon", SqlDbType.Char, 1, "mon");
                adapter_week.UpdateCommand.Parameters.Add("@tue", SqlDbType.Char, 1, "tue");
                adapter_week.UpdateCommand.Parameters.Add("@wed", SqlDbType.Char, 1, "wed");
                adapter_week.UpdateCommand.Parameters.Add("@thu", SqlDbType.Char, 1, "thu");
                adapter_week.UpdateCommand.Parameters.Add("@fri", SqlDbType.Char, 1, "fri");
                adapter_week.UpdateCommand.Parameters.Add("@sat", SqlDbType.Char, 1, "sat");
                adapter_week.UpdateCommand.Parameters.Add("@crt_date", SqlDbType.DateTime, 1, "crt_date");
                adapter_week.UpdateCommand.Parameters.Add("@crt_by", SqlDbType.VarChar, 20, "crt_by");

                SqlParameter parameter = adapter_week.UpdateCommand.Parameters.Add("@id", SqlDbType.VarChar, 50);
                parameter.SourceColumn = "id";
                parameter.SourceVersion = DataRowVersion.Original;
                #endregion

                SqlCommandBuilder builder_week = new SqlCommandBuilder(adapter_week);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                adapter_week.Fill(table);
                source_week.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetConfigTime()
        {
            try
            {
                string selectCommand = string.Format(
                    @"SELECT  [id] ,[time] ,[enabled], [info] ,[crt_date] ,[crt_by] 
                        FROM [dbo].[tbparallel_settime] WHERE id = '{0}' ORDER BY [time]; ", DgvConfigList.CurrentRow.Cells["ColPorc_id"].Value.ToString());

                adapter_time = new SqlDataAdapter(selectCommand, GetConnectString());

                #region INSERT Command
                adapter_time.UpdateCommand = new SqlCommand(
                        @" INSERT INTO [dbo].[tbparallel_settime]
                            ([id]
                            ,[time]
                            ,[enabled]
                            ,[info]
                            ,[crt_date]
                            ,[crt_by])
                          VALUES
                            (@id
                            ,@time
                            ,@enabled
                            ,getdate()
                            ,@crt_by);   ",
                        new SqlConnection(GetConnectString()));

                adapter_time.UpdateCommand.Parameters.Add("@id", SqlDbType.Char, 5, "id");
                adapter_time.UpdateCommand.Parameters.Add("@time", SqlDbType.Char, 5, "time");
                adapter_time.UpdateCommand.Parameters.Add("@enabled", SqlDbType.Char, 1, "enabled");
                adapter_time.UpdateCommand.Parameters.Add("@info", SqlDbType.Char, 1, "info");
                adapter_time.UpdateCommand.Parameters.Add("@crt_date", SqlDbType.DateTime, 1, "crt_date");
                adapter_time.UpdateCommand.Parameters.Add("@crt_by", SqlDbType.VarChar, 20, "crt_by");
                #endregion

                #region Update Command
                adapter_time.UpdateCommand = new SqlCommand(
                        @"UPDATE [dbo].[tbparallel_settime]
                             SET [enabled] = @enabled
                                ,[info] = @info
                                ,[crt_date] = getdate()
                                ,[crt_by] = @crt_by
                           WHERE [id] = @id
                             AND [time] = @time;   ",
                        new SqlConnection(GetConnectString()));

                //adapter_time.UpdateCommand.Parameters.Add("@time", SqlDbType.Char, 5, "time");
                adapter_time.UpdateCommand.Parameters.Add("@enabled", SqlDbType.Char, 1, "enabled");
                adapter_time.UpdateCommand.Parameters.Add("@info", SqlDbType.Char, 1, "info");
                adapter_time.UpdateCommand.Parameters.Add("@crt_date", SqlDbType.DateTime, 1, "crt_date");
                adapter_time.UpdateCommand.Parameters.Add("@crt_by", SqlDbType.VarChar, 20, "crt_by");

                SqlParameter parameter1 = adapter_time.UpdateCommand.Parameters.Add("@id", SqlDbType.VarChar, 50);
                parameter1.SourceColumn = "id";
                parameter1.SourceVersion = DataRowVersion.Original;

                SqlParameter parameter2 = adapter_time.UpdateCommand.Parameters.Add("@time", SqlDbType.VarChar, 5);
                parameter2.SourceColumn = "time";
                parameter2.SourceVersion = DataRowVersion.Original;
                #endregion

                #region Delete Command
                adapter_time.DeleteCommand = new SqlCommand(
                    @"DELETE FROM [dbo].[tbparallel_settime] WHERE [id] = @id AND [time] = @time;   ",
                        new SqlConnection(GetConnectString()));

                adapter_time.DeleteCommand.Parameters.Add("@id", SqlDbType.VarChar, 50, "id");
                adapter_time.DeleteCommand.Parameters.Add("@time", SqlDbType.VarChar, 5, "time");
                #endregion


                SqlCommandBuilder builder_time = new SqlCommandBuilder(adapter_time);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                adapter_time.Fill(table);
                source_time.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormSchedule_Load(object sender, EventArgs e)
        {
            DgvConfigList.DataSource = source_list;
            GetConfigList();
            DgvConfigWeek.DataSource = source_week;
            GetConfigWeek();
            DgvConfigTime.DataSource = source_time;
            GetConfigTime();
        }

        private void BtnUpdateConfig_Click(object sender, EventArgs e)
        {
            source_time.EndEdit();
            adapter_time.Update((DataTable)source_time.DataSource);
            GetConfigTime();

            source_week.EndEdit();
            adapter_week.Update((DataTable)source_week.DataSource);
            GetConfigWeek();

            source_list.EndEdit();
            adapter_list.Update((DataTable)source_list.DataSource);
            GetConfigList();       
        }

        private void DgvConfigList_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["ColProc_is_del"].Value = '0';
            e.Row.Cells["ColProc_para"].Value = "  ";
        }

        private void DgvConfigWeek_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["ColWeek_sun"].Value = '1';
            e.Row.Cells["ColWeek_mon"].Value = '1';
            e.Row.Cells["ColWeek_tue"].Value = '1';
            e.Row.Cells["ColWeek_wed"].Value = '1';
            e.Row.Cells["ColWeek_thu"].Value = '1';
            e.Row.Cells["ColWeek_fri"].Value = '1';
            e.Row.Cells["ColWeek_sat"].Value = '1';
        }

        private void DgvConfigTime_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["ColTime_id"].Value = DgvConfigList.CurrentRow.Cells["ColPorc_id"].Value.ToString();
            e.Row.Cells["ColTime_enabled"].Value = '1';
            e.Row.Cells["ColTime_info"].Value = '1';
        }

        private void DgvConfigList_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvConfigList.CurrentRow != null &&
                   DgvConfigList.CurrentRow.Index >= 0
                       && DgvConfigList.CurrentRow.Index != DgvConfigList.Rows.Count - 1)
            {
                GetConfigWeek();
                GetConfigTime();
            }
        }
    }
}
