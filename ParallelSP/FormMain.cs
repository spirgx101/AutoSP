using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using ParallelSP.Interface;
using ParallelSP.DAO;
using ParallelSP.Database;


namespace ParallelSP
{
    public partial class FormMain : Form
    {
        DAOLog log = new DAOLog();

        public FormMain()
        {
            InitializeComponent(); 
        }

        private void GetWorkingList()
        {
            while (true)
            {
                try
                {
                    //MethodInvoker check_method = new MethodInvoker(this.UpdateCheckList);
                    //this.BeginInvoke(check_method);
                    BeginInvoke(new Action(UpdateCheckList));
                    Thread.Sleep(5000);

                    //MethodInvoker log_method = new MethodInvoker(this.UpdateLogList);
                    //this.BeginInvoke(log_method);
                    BeginInvoke(new Action(UpdateLogList));
                    Thread.Sleep(2000);

                    //MethodInvoker cheklog_method = new MethodInvoker(this.UpdateCheckLogList);
                    //this.BeginInvoke(cheklog_method);
                    BeginInvoke(new Action(UpdateCheckLogList));
                    Thread.Sleep(2000);
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                    log.PushAlarmNoti("", "FromMain.GetWorkingList()", "執行錯誤", ex.Message);
                }
            }
        }

        private void UpdateCheckList()
        {
            try
            {
                DAOCheck check = new DAOCheck();
                DgvExecuteCheck.DataSource = check.GetRunningProc();
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                log.PushAlarmNoti("", "FromMain.UpdateCheckList()", "執行錯誤", ex.Message);
            }
        }

        private void UpdateCheckLogList()
        {
            try
            {
                DAOCheck check = new DAOCheck();
                DgvCheckLog.DataSource = check.GetCheckLog();
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                log.PushAlarmNoti("", "FromMain.UpdateCheckLogList()", "執行錯誤", ex.Message);
            }
        }

        private void UpdateLogList()
        {
            try
            {
                DAOLog log = new DAOLog();
                DgvExecuteLog.DataSource = log.GetLog(2);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                log.PushAlarmNoti("", "FromMain.UpdateLogList()", "執行錯誤", ex.Message);
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
                this.ShowInTaskbar = false;
                NotifyIcon.Visible = true;
                NotifyIcon.Tag = string.Empty;
                NotifyIcon.ShowBalloonTip(3000, this.Text, "ParallelSP Running!", ToolTipIcon.Info);
            }
        }

        private void TimerNow_Tick(object sender, EventArgs e)
        {
            this.Text = "ParallelSP [" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "]";
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
                        e.CellStyle.BackColor = Color.Blue;
                        e.CellStyle.ForeColor = Color.White;
                        break;
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            AutoExecuteSP auto_exec = new AutoExecuteSP();
            TimerNow.Start();

            Thread update_thread = new Thread(GetWorkingList);
            update_thread.Start();

            DgvExecuteCheck.Columns["ColCheck_begin_date"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss.fff";
            DgvExecuteCheck.Columns["ColCheck_end_date"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss.fff";
            DgvExecuteLog.Columns["ColExec_crt_date"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss.fff";
            DgvCheckLog.Columns["ColChecklog_begin_date"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss.fff";
            DgvCheckLog.Columns["ColChecklog_end_date"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss.fff";
            NotifyIcon.Visible = false;

        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            TimerNow.Stop();
            Environment.Exit(0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void ContextMenuItemExit_Click(object sender, EventArgs e)
        {
            MenuItemExit_Click(sender, e);
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Maximized;
                this.ShowInTaskbar = true;
            }
        }

        
        private void MenuItemSchedule_Click(object sender, EventArgs e)
        {
            FormSchedule frmSchedule = new FormSchedule();
            frmSchedule.ShowDialog();
        }

        private void MenuItemPara_Click(object sender, EventArgs e)
        {
            FormPara frmPara = new FormPara();
            frmPara.ShowDialog();
        }

        private void MenuItemLog_Click(object sender, EventArgs e)
        {
            FormLog frmLog = new FormLog();
            frmLog.ShowDialog();
        }
    }
}
