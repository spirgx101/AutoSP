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
    public partial class FormPara : Form
    {
        private BindingSource source_para = new BindingSource();
        private SqlDataAdapter adapter_para = new SqlDataAdapter();

        public FormPara()
        {
            InitializeComponent();
        }

        private string GetConnectString()
        {
            return ConfigurationManager.AppSettings["ParallelSP"].ToString();
        }

        private void FormPara_Load(object sender, EventArgs e)
        {
            DgvConfigPara.DataSource = source_para;
            GetConfigPara();
        }

        private void GetConfigPara()
        {
            try
            {
                string selectCommand =
                    @"SELECT [para_id] ,[para_desc] FROM [dbo].[tbparallel_para]; ";

                adapter_para = new SqlDataAdapter(selectCommand, GetConnectString());

                #region Insert Command
                adapter_para.InsertCommand = new SqlCommand(
                    @"INSERT INTO [dbo].[tbparallel_para]
                        ([para_id]
                        ,[para_desc])
                      VALUES
                        (@para_id
                        ,@para_desc); ",
                    new SqlConnection(GetConnectString()));

                adapter_para.InsertCommand.Parameters.Add("@para_id", SqlDbType.VarChar, 30, "para_id");
                adapter_para.InsertCommand.Parameters.Add("@para_desc", SqlDbType.VarChar, 200, "para_desc");
                #endregion

                #region Update Command
                adapter_para.UpdateCommand = new SqlCommand(
                        @"UPDATE [dbo].[tbparallel_para]
                             SET [para_desc] = @para_desc
                           WHERE para_id = @para_id;   ",
                        new SqlConnection(GetConnectString()));

                adapter_para.UpdateCommand.Parameters.Add("@para_desc", SqlDbType.VarChar, 200, "para_desc");

                SqlParameter parameter = adapter_para.UpdateCommand.Parameters.Add("@para_id", SqlDbType.VarChar, 30);
                parameter.SourceColumn = "para_id";
                parameter.SourceVersion = DataRowVersion.Original;
                #endregion

                #region Delete Command
                adapter_para.DeleteCommand = new SqlCommand(
                    @"DELETE FROM [dbo].[tbparallel_para] WHERE para_id = @para_id;  ",
                        new SqlConnection(GetConnectString()));

                adapter_para.DeleteCommand.Parameters.Add("@para_id", SqlDbType.VarChar, 30, "para_id");
                #endregion

                SqlCommandBuilder builder_list = new SqlCommandBuilder(adapter_para);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                adapter_para.Fill(table);
                source_para.DataSource = table;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnUpdatePara_Click(object sender, EventArgs e)
        {
            source_para.EndEdit();
            adapter_para.Update((DataTable)source_para.DataSource);
            GetConfigPara();
        }
    }
}
