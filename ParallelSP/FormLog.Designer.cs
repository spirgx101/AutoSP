namespace ParallelSP
{
    partial class FormLog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SplitLog = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CheckLogWarnUp = new System.Windows.Forms.CheckBox();
            this.BtnQueryLog = new System.Windows.Forms.Button();
            this.TxtProcID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DateEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.DateBegin = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.RadioLog = new System.Windows.Forms.RadioButton();
            this.RadioCheckLog = new System.Windows.Forms.RadioButton();
            this.DgvCheckLog = new System.Windows.Forms.DataGridView();
            this.ColChecklog_log_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChecklog_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChecklog_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChecklog_sp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChecklog_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChecklog_diff_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChecklog_begin_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChecklog_end_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColChecklog_crt_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvExecuteLog = new System.Windows.Forms.DataGridView();
            this.ColExec_log_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExec_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExec_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExec_sp_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExec_thread = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExec_batch_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExec_thread_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExec_sp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExec_store_begin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExec_store_end = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExec_log_level_s = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExec_memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExec_crt_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExec_crt_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.SplitLog)).BeginInit();
            this.SplitLog.Panel1.SuspendLayout();
            this.SplitLog.Panel2.SuspendLayout();
            this.SplitLog.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCheckLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvExecuteLog)).BeginInit();
            this.SuspendLayout();
            // 
            // SplitLog
            // 
            this.SplitLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitLog.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitLog.IsSplitterFixed = true;
            this.SplitLog.Location = new System.Drawing.Point(0, 0);
            this.SplitLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SplitLog.Name = "SplitLog";
            this.SplitLog.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitLog.Panel1
            // 
            this.SplitLog.Panel1.Controls.Add(this.panel1);
            this.SplitLog.Panel1MinSize = 162;
            // 
            // SplitLog.Panel2
            // 
            this.SplitLog.Panel2.Controls.Add(this.DgvCheckLog);
            this.SplitLog.Panel2.Controls.Add(this.DgvExecuteLog);
            this.SplitLog.Size = new System.Drawing.Size(1198, 698);
            this.SplitLog.SplitterDistance = 162;
            this.SplitLog.SplitterWidth = 5;
            this.SplitLog.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CheckLogWarnUp);
            this.panel1.Controls.Add(this.BtnQueryLog);
            this.panel1.Controls.Add(this.TxtProcID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.DateEnd);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.DateBegin);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.RadioLog);
            this.panel1.Controls.Add(this.RadioCheckLog);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1198, 162);
            this.panel1.TabIndex = 5;
            // 
            // CheckLogWarnUp
            // 
            this.CheckLogWarnUp.AutoSize = true;
            this.CheckLogWarnUp.Checked = true;
            this.CheckLogWarnUp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckLogWarnUp.Location = new System.Drawing.Point(310, 18);
            this.CheckLogWarnUp.Name = "CheckLogWarnUp";
            this.CheckLogWarnUp.Size = new System.Drawing.Size(147, 20);
            this.CheckLogWarnUp.TabIndex = 21;
            this.CheckLogWarnUp.Text = "只顯示警告及錯誤訊息";
            this.CheckLogWarnUp.UseVisualStyleBackColor = true;
            this.CheckLogWarnUp.Visible = false;
            // 
            // BtnQueryLog
            // 
            this.BtnQueryLog.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnQueryLog.Location = new System.Drawing.Point(20, 117);
            this.BtnQueryLog.Name = "BtnQueryLog";
            this.BtnQueryLog.Size = new System.Drawing.Size(129, 37);
            this.BtnQueryLog.TabIndex = 20;
            this.BtnQueryLog.Text = "查詢";
            this.BtnQueryLog.UseVisualStyleBackColor = true;
            this.BtnQueryLog.Click += new System.EventHandler(this.BtnQueryLog_Click);
            // 
            // TxtProcID
            // 
            this.TxtProcID.Location = new System.Drawing.Point(106, 84);
            this.TxtProcID.Name = "TxtProcID";
            this.TxtProcID.Size = new System.Drawing.Size(379, 23);
            this.TxtProcID.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "執行編號：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DateEnd
            // 
            this.DateEnd.Location = new System.Drawing.Point(310, 47);
            this.DateEnd.Name = "DateEnd";
            this.DateEnd.Size = new System.Drawing.Size(175, 23);
            this.DateEnd.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "~";
            // 
            // DateBegin
            // 
            this.DateBegin.Location = new System.Drawing.Point(106, 47);
            this.DateBegin.Name = "DateBegin";
            this.DateBegin.Size = new System.Drawing.Size(172, 23);
            this.DateBegin.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "時間區間：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RadioLog
            // 
            this.RadioLog.AutoSize = true;
            this.RadioLog.Location = new System.Drawing.Point(173, 18);
            this.RadioLog.Name = "RadioLog";
            this.RadioLog.Size = new System.Drawing.Size(72, 20);
            this.RadioLog.TabIndex = 13;
            this.RadioLog.Text = "查詢Log";
            this.RadioLog.UseVisualStyleBackColor = true;
            this.RadioLog.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // RadioCheckLog
            // 
            this.RadioCheckLog.AutoSize = true;
            this.RadioCheckLog.Checked = true;
            this.RadioCheckLog.Location = new System.Drawing.Point(20, 18);
            this.RadioCheckLog.Name = "RadioCheckLog";
            this.RadioCheckLog.Size = new System.Drawing.Size(106, 20);
            this.RadioCheckLog.TabIndex = 12;
            this.RadioCheckLog.TabStop = true;
            this.RadioCheckLog.Text = "查詢CheckLog";
            this.RadioCheckLog.UseVisualStyleBackColor = true;
            this.RadioCheckLog.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // DgvCheckLog
            // 
            this.DgvCheckLog.AllowUserToAddRows = false;
            this.DgvCheckLog.AllowUserToDeleteRows = false;
            this.DgvCheckLog.AllowUserToOrderColumns = true;
            this.DgvCheckLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvCheckLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCheckLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColChecklog_log_id,
            this.ColChecklog_id,
            this.ColChecklog_time,
            this.ColChecklog_sp,
            this.ColChecklog_status,
            this.ColChecklog_diff_time,
            this.ColChecklog_begin_date,
            this.ColChecklog_end_date,
            this.ColChecklog_crt_date});
            this.DgvCheckLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvCheckLog.Location = new System.Drawing.Point(0, 0);
            this.DgvCheckLog.Margin = new System.Windows.Forms.Padding(2);
            this.DgvCheckLog.Name = "DgvCheckLog";
            this.DgvCheckLog.RowTemplate.Height = 27;
            this.DgvCheckLog.Size = new System.Drawing.Size(1198, 531);
            this.DgvCheckLog.TabIndex = 3;
            // 
            // ColChecklog_log_id
            // 
            this.ColChecklog_log_id.DataPropertyName = "log_id";
            this.ColChecklog_log_id.HeaderText = "流水序號";
            this.ColChecklog_log_id.Name = "ColChecklog_log_id";
            this.ColChecklog_log_id.ReadOnly = true;
            // 
            // ColChecklog_id
            // 
            this.ColChecklog_id.DataPropertyName = "id";
            this.ColChecklog_id.HeaderText = "執行編號";
            this.ColChecklog_id.Name = "ColChecklog_id";
            this.ColChecklog_id.ReadOnly = true;
            // 
            // ColChecklog_time
            // 
            this.ColChecklog_time.DataPropertyName = "time";
            this.ColChecklog_time.HeaderText = "執行時間";
            this.ColChecklog_time.Name = "ColChecklog_time";
            this.ColChecklog_time.ReadOnly = true;
            // 
            // ColChecklog_sp
            // 
            this.ColChecklog_sp.DataPropertyName = "sp";
            this.ColChecklog_sp.HeaderText = "預存程序";
            this.ColChecklog_sp.Name = "ColChecklog_sp";
            this.ColChecklog_sp.ReadOnly = true;
            // 
            // ColChecklog_status
            // 
            this.ColChecklog_status.DataPropertyName = "status";
            this.ColChecklog_status.HeaderText = "執行狀態";
            this.ColChecklog_status.Name = "ColChecklog_status";
            this.ColChecklog_status.ReadOnly = true;
            // 
            // ColChecklog_diff_time
            // 
            this.ColChecklog_diff_time.DataPropertyName = "diff_time";
            this.ColChecklog_diff_time.HeaderText = "執行時間(s)";
            this.ColChecklog_diff_time.Name = "ColChecklog_diff_time";
            this.ColChecklog_diff_time.ReadOnly = true;
            // 
            // ColChecklog_begin_date
            // 
            this.ColChecklog_begin_date.DataPropertyName = "begin_date";
            this.ColChecklog_begin_date.HeaderText = "開始時間";
            this.ColChecklog_begin_date.Name = "ColChecklog_begin_date";
            this.ColChecklog_begin_date.ReadOnly = true;
            // 
            // ColChecklog_end_date
            // 
            this.ColChecklog_end_date.DataPropertyName = "end_date";
            this.ColChecklog_end_date.HeaderText = "結束時間";
            this.ColChecklog_end_date.Name = "ColChecklog_end_date";
            this.ColChecklog_end_date.ReadOnly = true;
            // 
            // ColChecklog_crt_date
            // 
            this.ColChecklog_crt_date.DataPropertyName = "crt_date";
            this.ColChecklog_crt_date.HeaderText = "建立日期";
            this.ColChecklog_crt_date.Name = "ColChecklog_crt_date";
            this.ColChecklog_crt_date.ReadOnly = true;
            this.ColChecklog_crt_date.Visible = false;
            // 
            // DgvExecuteLog
            // 
            this.DgvExecuteLog.AllowUserToAddRows = false;
            this.DgvExecuteLog.AllowUserToDeleteRows = false;
            this.DgvExecuteLog.AllowUserToOrderColumns = true;
            this.DgvExecuteLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvExecuteLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvExecuteLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColExec_log_id,
            this.ColExec_id,
            this.ColExec_time,
            this.ColExec_sp_type,
            this.ColExec_thread,
            this.ColExec_batch_id,
            this.ColExec_thread_id,
            this.ColExec_sp,
            this.ColExec_store_begin,
            this.ColExec_store_end,
            this.ColExec_log_level_s,
            this.ColExec_memo,
            this.ColExec_crt_date,
            this.ColExec_crt_by});
            this.DgvExecuteLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvExecuteLog.Location = new System.Drawing.Point(0, 0);
            this.DgvExecuteLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DgvExecuteLog.Name = "DgvExecuteLog";
            this.DgvExecuteLog.RowTemplate.Height = 27;
            this.DgvExecuteLog.Size = new System.Drawing.Size(1198, 531);
            this.DgvExecuteLog.TabIndex = 2;
            this.DgvExecuteLog.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DgvExecuteLog_CellPainting);
            // 
            // ColExec_log_id
            // 
            this.ColExec_log_id.DataPropertyName = "log_id";
            this.ColExec_log_id.HeaderText = "流水序號";
            this.ColExec_log_id.Name = "ColExec_log_id";
            this.ColExec_log_id.ReadOnly = true;
            // 
            // ColExec_id
            // 
            this.ColExec_id.DataPropertyName = "id";
            this.ColExec_id.HeaderText = "執行編號";
            this.ColExec_id.Name = "ColExec_id";
            this.ColExec_id.ReadOnly = true;
            // 
            // ColExec_time
            // 
            this.ColExec_time.DataPropertyName = "time";
            this.ColExec_time.HeaderText = "執行時間";
            this.ColExec_time.Name = "ColExec_time";
            this.ColExec_time.ReadOnly = true;
            // 
            // ColExec_sp_type
            // 
            this.ColExec_sp_type.DataPropertyName = "sp_type";
            this.ColExec_sp_type.HeaderText = "預存程序類別";
            this.ColExec_sp_type.Name = "ColExec_sp_type";
            this.ColExec_sp_type.ReadOnly = true;
            // 
            // ColExec_thread
            // 
            this.ColExec_thread.DataPropertyName = "thread";
            this.ColExec_thread.HeaderText = "執行緒數";
            this.ColExec_thread.Name = "ColExec_thread";
            this.ColExec_thread.ReadOnly = true;
            // 
            // ColExec_batch_id
            // 
            this.ColExec_batch_id.DataPropertyName = "batch_id";
            this.ColExec_batch_id.HeaderText = "批次編號";
            this.ColExec_batch_id.Name = "ColExec_batch_id";
            this.ColExec_batch_id.ReadOnly = true;
            // 
            // ColExec_thread_id
            // 
            this.ColExec_thread_id.DataPropertyName = "thread_id";
            this.ColExec_thread_id.HeaderText = "執行緒編號";
            this.ColExec_thread_id.Name = "ColExec_thread_id";
            this.ColExec_thread_id.ReadOnly = true;
            // 
            // ColExec_sp
            // 
            this.ColExec_sp.DataPropertyName = "sp";
            this.ColExec_sp.HeaderText = "預存程序";
            this.ColExec_sp.Name = "ColExec_sp";
            this.ColExec_sp.ReadOnly = true;
            // 
            // ColExec_store_begin
            // 
            this.ColExec_store_begin.DataPropertyName = "store_begin";
            this.ColExec_store_begin.HeaderText = "啟始門市代號";
            this.ColExec_store_begin.Name = "ColExec_store_begin";
            this.ColExec_store_begin.ReadOnly = true;
            // 
            // ColExec_store_end
            // 
            this.ColExec_store_end.DataPropertyName = "store_end";
            this.ColExec_store_end.HeaderText = "結束門市代號";
            this.ColExec_store_end.Name = "ColExec_store_end";
            this.ColExec_store_end.ReadOnly = true;
            // 
            // ColExec_log_level_s
            // 
            this.ColExec_log_level_s.DataPropertyName = "level";
            this.ColExec_log_level_s.HeaderText = "訊息層級";
            this.ColExec_log_level_s.Name = "ColExec_log_level_s";
            this.ColExec_log_level_s.ReadOnly = true;
            // 
            // ColExec_memo
            // 
            this.ColExec_memo.DataPropertyName = "memo";
            this.ColExec_memo.HeaderText = "執行訊息";
            this.ColExec_memo.Name = "ColExec_memo";
            this.ColExec_memo.ReadOnly = true;
            // 
            // ColExec_crt_date
            // 
            this.ColExec_crt_date.DataPropertyName = "crt_date";
            this.ColExec_crt_date.HeaderText = "建立日期";
            this.ColExec_crt_date.Name = "ColExec_crt_date";
            this.ColExec_crt_date.ReadOnly = true;
            // 
            // ColExec_crt_by
            // 
            this.ColExec_crt_by.DataPropertyName = "crt_by";
            this.ColExec_crt_by.HeaderText = "建立人員";
            this.ColExec_crt_by.Name = "ColExec_crt_by";
            this.ColExec_crt_by.ReadOnly = true;
            // 
            // FormLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 698);
            this.Controls.Add(this.SplitLog);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查詢Log";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormLog_Load);
            this.SplitLog.Panel1.ResumeLayout(false);
            this.SplitLog.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitLog)).EndInit();
            this.SplitLog.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCheckLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvExecuteLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitLog;
        private System.Windows.Forms.DataGridView DgvExecuteLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExec_log_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExec_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExec_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExec_sp_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExec_thread;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExec_batch_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExec_thread_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExec_sp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExec_store_begin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExec_store_end;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExec_log_level_s;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExec_memo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExec_crt_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExec_crt_by;
        private System.Windows.Forms.DataGridView DgvCheckLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChecklog_log_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChecklog_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChecklog_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChecklog_sp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChecklog_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChecklog_diff_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChecklog_begin_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChecklog_end_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChecklog_crt_date;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnQueryLog;
        private System.Windows.Forms.TextBox TxtProcID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DateEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DateBegin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton RadioLog;
        private System.Windows.Forms.RadioButton RadioCheckLog;
        private System.Windows.Forms.CheckBox CheckLogWarnUp;
    }
}