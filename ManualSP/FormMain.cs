using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ManualSP
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> server = new Dictionary<string, string>();

            // Get the configuration file.
            System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Get the appSettings section.
            System.Configuration.AppSettingsSection appSettings =
                (System.Configuration.AppSettingsSection)config.GetSection("appSettings");

            if (appSettings.Settings.Count != 0)
            {
                foreach (string key in appSettings.Settings.AllKeys)
                {
                    string value = appSettings.Settings[key].Value;
                    server.Add(key, value);
                }
            }
  
            cbxServerList.DataSource = new BindingSource(server, null);
            cbxServerList.DisplayMember = "key";
            cbxServerList.ValueMember = "value";
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection(cbxServerList.SelectedValue.ToString()))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandType = CommandType.Text;
                        comm.CommandText = txtSqlCommand.Text;


                        comm.ExecuteNonQuery();

                        MessageBox.Show("執行完成。");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
    }


 
}
