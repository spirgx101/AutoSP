namespace ParallelSP
{
    partial class FormMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.SplitExecute = new System.Windows.Forms.SplitContainer();
            this.DgvExecuteCheck = new System.Windows.Forms.DataGridView();
            this.ColCheck_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCheck_sp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCheck_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCheck_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCheck_begin_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCheck_end_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuMain = new System.Windows.Forms.MenuStrip();
            this.MenuItemSchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemPara = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemLog = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.TabExecute = new System.Windows.Forms.TabControl();
            this.TpgExecuteLog = new System.Windows.Forms.TabPage();
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
            this.TpgCheckLog = new System.Windows.Forms.TabPage();
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
            this.TimerNow = new System.Windows.Forms.Timer(this.components);
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.SplitExecute)).BeginInit();
            this.SplitExecute.Panel1.SuspendLayout();
            this.SplitExecute.Panel2.SuspendLayout();
            this.SplitExecute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvExecuteCheck)).BeginInit();
            this.MenuMain.SuspendLayout();
            this.TabExecute.SuspendLayout();
            this.TpgExecuteLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvExecuteLog)).BeginInit();
            this.TpgCheckLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCheckLog)).BeginInit();
            this.ContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitExecute
            // 
            this.SplitExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitExecute.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitExecute.IsSplitterFixed = true;
            this.SplitExecute.Location = new System.Drawing.Point(0, 0);
            this.SplitExecute.Margin = new System.Windows.Forms.Padding(2);
            this.SplitExecute.Name = "SplitExecute";
            this.SplitExecute.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitExecute.Panel1
            // 
            this.SplitExecute.Panel1.Controls.Add(this.DgvExecuteCheck);
            this.SplitExecute.Panel1.Controls.Add(this.MenuMain);
            this.SplitExecute.Panel1MinSize = 200;
            // 
            // SplitExecute.Panel2
            // 
            this.SplitExecute.Panel2.Controls.Add(this.TabExecute);
            this.SplitExecute.Size = new System.Drawing.Size(998, 537);
            this.SplitExecute.SplitterDistance = 200;
            this.SplitExecute.SplitterWidth = 3;
            this.SplitExecute.TabIndex = 0;
            // 
            // DgvExecuteCheck
            // 
            this.DgvExecuteCheck.AllowUserToAddRows = false;
            this.DgvExecuteCheck.AllowUserToDeleteRows = false;
            this.DgvExecuteCheck.AllowUserToOrderColumns = true;
            this.DgvExecuteCheck.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvExecuteCheck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvExecuteCheck.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCheck_id,
            this.ColCheck_sp,
            this.ColCheck_time,
            this.ColCheck_status,
            this.ColCheck_begin_date,
            this.ColCheck_end_date});
            this.DgvExecuteCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvExecuteCheck.Location = new System.Drawing.Point(0, 24);
            this.DgvExecuteCheck.Margin = new System.Windows.Forms.Padding(2);
            this.DgvExecuteCheck.Name = "DgvExecuteCheck";
            this.DgvExecuteCheck.RowTemplate.Height = 27;
            this.DgvExecuteCheck.Size = new System.Drawing.Size(998, 176);
            this.DgvExecuteCheck.TabIndex = 0;
            // 
            // ColCheck_id
            // 
            this.ColCheck_id.DataPropertyName = "id";
            this.ColCheck_id.HeaderText = "執行編號";
            this.ColCheck_id.Name = "ColCheck_id";
            this.ColCheck_id.ReadOnly = true;
            // 
            // ColCheck_sp
            // 
            this.ColCheck_sp.DataPropertyName = "sp";
            this.ColCheck_sp.HeaderText = "預存程序";
            this.ColCheck_sp.Name = "ColCheck_sp";
            this.ColCheck_sp.ReadOnly = true;
            // 
            // ColCheck_time
            // 
            this.ColCheck_time.DataPropertyName = "time";
            this.ColCheck_time.HeaderText = "執行時間";
            this.ColCheck_time.Name = "ColCheck_time";
            this.ColCheck_time.ReadOnly = true;
            // 
            // ColCheck_status
            // 
            this.ColCheck_status.DataPropertyName = "status";
            this.ColCheck_status.HeaderText = "執行狀態";
            this.ColCheck_status.Name = "ColCheck_status";
            this.ColCheck_status.ReadOnly = true;
            // 
            // ColCheck_begin_date
            // 
            this.ColCheck_begin_date.DataPropertyName = "begin_date";
            this.ColCheck_begin_date.HeaderText = "開始時間";
            this.ColCheck_begin_date.Name = "ColCheck_begin_date";
            this.ColCheck_begin_date.ReadOnly = true;
            // 
            // ColCheck_end_date
            // 
            this.ColCheck_end_date.DataPropertyName = "end_date";
            this.ColCheck_end_date.HeaderText = "結束時間";
            this.ColCheck_end_date.Name = "ColCheck_end_date";
            this.ColCheck_end_date.ReadOnly = true;
            // 
            // MenuMain
            // 
            this.MenuMain.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MenuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemSchedule,
            this.MenuItemPara,
            this.MenuItemLog,
            this.MenuItemExit});
            this.MenuMain.Location = new System.Drawing.Point(0, 0);
            this.MenuMain.Name = "MenuMain";
            this.MenuMain.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MenuMain.Size = new System.Drawing.Size(998, 24);
            this.MenuMain.TabIndex = 1;
            this.MenuMain.Text = "menuStrip1";
            // 
            // MenuItemSchedule
            // 
            this.MenuItemSchedule.Name = "MenuItemSchedule";
            this.MenuItemSchedule.Size = new System.Drawing.Size(83, 20);
            this.MenuItemSchedule.Text = "排程設定(&S)";
            this.MenuItemSchedule.Visible = false;
            this.MenuItemSchedule.Click += new System.EventHandler(this.MenuItemSchedule_Click);
            // 
            // MenuItemPara
            // 
            this.MenuItemPara.Name = "MenuItemPara";
            this.MenuItemPara.Size = new System.Drawing.Size(83, 20);
            this.MenuItemPara.Text = "參數設定(&P)";
            this.MenuItemPara.Visible = false;
            this.MenuItemPara.Click += new System.EventHandler(this.MenuItemPara_Click);
            // 
            // MenuItemLog
            // 
            this.MenuItemLog.Name = "MenuItemLog";
            this.MenuItemLog.Size = new System.Drawing.Size(83, 20);
            this.MenuItemLog.Text = "LOG查詢(&L)";
            this.MenuItemLog.Visible = false;
            this.MenuItemLog.Click += new System.EventHandler(this.MenuItemLog_Click);
            // 
            // MenuItemExit
            // 
            this.MenuItemExit.Name = "MenuItemExit";
            this.MenuItemExit.Size = new System.Drawing.Size(59, 20);
            this.MenuItemExit.Text = "離開(&E)";
            this.MenuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);
            // 
            // TabExecute
            // 
            this.TabExecute.Controls.Add(this.TpgExecuteLog);
            this.TabExecute.Controls.Add(this.TpgCheckLog);
            this.TabExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabExecute.Location = new System.Drawing.Point(0, 0);
            this.TabExecute.Margin = new System.Windows.Forms.Padding(2);
            this.TabExecute.Name = "TabExecute";
            this.TabExecute.SelectedIndex = 0;
            this.TabExecute.Size = new System.Drawing.Size(998, 334);
            this.TabExecute.TabIndex = 1;
            // 
            // TpgExecuteLog
            // 
            this.TpgExecuteLog.Controls.Add(this.DgvExecuteLog);
            this.TpgExecuteLog.Location = new System.Drawing.Point(4, 25);
            this.TpgExecuteLog.Margin = new System.Windows.Forms.Padding(2);
            this.TpgExecuteLog.Name = "TpgExecuteLog";
            this.TpgExecuteLog.Padding = new System.Windows.Forms.Padding(2);
            this.TpgExecuteLog.Size = new System.Drawing.Size(990, 305);
            this.TpgExecuteLog.TabIndex = 0;
            this.TpgExecuteLog.Text = "Execute Log";
            this.TpgExecuteLog.UseVisualStyleBackColor = true;
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
            this.DgvExecuteLog.Location = new System.Drawing.Point(2, 2);
            this.DgvExecuteLog.Margin = new System.Windows.Forms.Padding(2);
            this.DgvExecuteLog.Name = "DgvExecuteLog";
            this.DgvExecuteLog.RowTemplate.Height = 27;
            this.DgvExecuteLog.Size = new System.Drawing.Size(986, 301);
            this.DgvExecuteLog.TabIndex = 1;
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
            // TpgCheckLog
            // 
            this.TpgCheckLog.Controls.Add(this.DgvCheckLog);
            this.TpgCheckLog.Location = new System.Drawing.Point(4, 22);
            this.TpgCheckLog.Margin = new System.Windows.Forms.Padding(2);
            this.TpgCheckLog.Name = "TpgCheckLog";
            this.TpgCheckLog.Padding = new System.Windows.Forms.Padding(2);
            this.TpgCheckLog.Size = new System.Drawing.Size(990, 308);
            this.TpgCheckLog.TabIndex = 1;
            this.TpgCheckLog.Text = "Check Log";
            this.TpgCheckLog.UseVisualStyleBackColor = true;
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
            this.DgvCheckLog.Location = new System.Drawing.Point(2, 2);
            this.DgvCheckLog.Margin = new System.Windows.Forms.Padding(2);
            this.DgvCheckLog.Name = "DgvCheckLog";
            this.DgvCheckLog.RowTemplate.Height = 27;
            this.DgvCheckLog.Size = new System.Drawing.Size(986, 304);
            this.DgvCheckLog.TabIndex = 1;
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
            // TimerNow
            // 
            this.TimerNow.Interval = 1000;
            this.TimerNow.Tick += new System.EventHandler(this.TimerNow_Tick);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.ContextMenuStrip = this.ContextMenu;
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "ParallelSP";
            this.NotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // ContextMenu
            // 
            this.ContextMenu.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuItemExit});
            this.ContextMenu.Name = "ContextMenu";
            this.ContextMenu.Size = new System.Drawing.Size(111, 28);
            // 
            // ContextMenuItemExit
            // 
            this.ContextMenuItemExit.Name = "ContextMenuItemExit";
            this.ContextMenuItemExit.Size = new System.Drawing.Size(110, 24);
            this.ContextMenuItemExit.Text = "離開";
            this.ContextMenuItemExit.Click += new System.EventHandler(this.ContextMenuItemExit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 537);
            this.Controls.Add(this.SplitExecute);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuMain;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMain";
            this.Text = "ParallelSP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.SplitExecute.Panel1.ResumeLayout(false);
            this.SplitExecute.Panel1.PerformLayout();
            this.SplitExecute.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitExecute)).EndInit();
            this.SplitExecute.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvExecuteCheck)).EndInit();
            this.MenuMain.ResumeLayout(false);
            this.MenuMain.PerformLayout();
            this.TabExecute.ResumeLayout(false);
            this.TpgExecuteLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvExecuteLog)).EndInit();
            this.TpgCheckLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCheckLog)).EndInit();
            this.ContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitExecute;
        private System.Windows.Forms.DataGridView DgvExecuteCheck;
        private System.Windows.Forms.TabControl TabExecute;
        private System.Windows.Forms.TabPage TpgExecuteLog;
        private System.Windows.Forms.TabPage TpgCheckLog;
        private System.Windows.Forms.Timer TimerNow;
        private System.Windows.Forms.DataGridView DgvExecuteLog;
        private System.Windows.Forms.DataGridView DgvCheckLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCheck_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCheck_sp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCheck_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCheck_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCheck_begin_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCheck_end_date;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChecklog_log_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChecklog_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChecklog_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChecklog_sp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChecklog_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChecklog_diff_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChecklog_begin_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChecklog_end_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColChecklog_crt_date;
        private System.Windows.Forms.MenuStrip MenuMain;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSchedule;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private new System.Windows.Forms.ContextMenuStrip ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemPara;
        private System.Windows.Forms.ToolStripMenuItem MenuItemLog;
    }
}

