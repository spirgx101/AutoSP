using ParallelSP.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallelSP
{
    public partial class FormLog : Form
    {
        //private RadioButton RADIO_BUTTON;

        public FormLog()
        {
            InitializeComponent();
        }

        void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == null)
            {
                MessageBox.Show("請選擇一種log讀取");
                return;
            }

            // Ensure that the RadioButton.Checked property
            // changed to true.
            if (rb.Checked)
            {
                // Keep track of the selected RadioButton by saving a reference
                // to it.
                if (rb.Text == "查詢CheckLog")
                {
                    DgvCheckLog.Visible = true;
                    DgvExecuteLog.Visible = false;
                    CheckLogWarnUp.Visible = false;
                    CheckLogWarnUp.Checked = false;
                }
                else
                {
                    DgvCheckLog.Visible = false;
                    DgvExecuteLog.Visible = true;
                    CheckLogWarnUp.Visible = true;
                    CheckLogWarnUp.Checked = true;
                }

            }
        }

        private void FormLog_Load(object sender, EventArgs e)
        {
            DgvCheckLog.Visible = true;
            DgvExecuteLog.Visible = false;

            DgvExecuteLog.Columns["ColExec_crt_date"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss.fff";
            DgvCheckLog.Columns["ColChecklog_begin_date"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss.fff";
            DgvCheckLog.Columns["ColChecklog_end_date"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss.fff";
        }

        private void BtnQueryLog_Click(object sender, EventArgs e)
        {
            string date_begin = DateBegin.Value.ToString("yyyy/MM/dd 00:00:00");
            string date_end = DateEnd.Value.ToString("yyyy/MM/dd 23:59:59");
            string proc_id = TxtProcID.Text.Trim();
            int log_level = (CheckLogWarnUp.Checked == true) ? 2: 0;

            if (RadioCheckLog.Checked == true)
            {
                DAOCheck check_log = new DAOCheck();
                DataTable table = check_log.GetCheckLog(date_begin, date_end, proc_id);
                DgvCheckLog.DataSource = table;

            }

            if (RadioLog.Checked == true)
            {
                DAOLog log = new DAOLog();
                DataTable table = log.GetLog(date_begin, date_end, proc_id, log_level);
                DgvExecuteLog.DataSource = table;
            }

        }

        private void DgvExecuteLog_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string level = ((DataGridView)sender).Rows[e.RowIndex].Cells["ColExec_log_level_s"].Value.ToString();
                switch (level)
                {
                    case "測試":
                        e.CellStyle.BackColor = Color.Gray;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                    case "訊息":
                        e.CellStyle.BackColor = Color.White;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                    case "警告":
                        e.CellStyle.BackColor = Color.Yellow;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                    case "錯誤":
                        e.CellStyle.BackColor = Color.Red;
                        e.CellStyle.ForeColor = Color.White;
                        break;
                    case "重試":
                        e.CellStyle.BackColor = Color.Green;
                        e.CellStyle.ForeColor = Color.White;
                        break;
                    case "重試失敗":
                        e.CellStyle.BackColor = Color.Orange;
                        e.CellStyle.ForeColor = Color.White;
                        break;
                    default:
                        e.CellStyle.BackColor = Color.Green;
                        e.CellStyle.ForeColor = Color.White;
                        break;
                }
            }
        }
    }
}
