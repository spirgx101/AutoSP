namespace ParallelSP
{
    partial class FormSchedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSchedule));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ToolBar = new System.Windows.Forms.ToolStrip();
            this.BtnUpdateConfig = new System.Windows.Forms.ToolStripButton();
            this.SplitProcedure = new System.Windows.Forms.SplitContainer();
            this.DgvConfigList = new System.Windows.Forms.DataGridView();
            this.ColPorc_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProc_sp_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProc_ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProc_db = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProc_user_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProc_password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProc_sp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProc_para = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProc_conn_str = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProc_cpu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProc_thread = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProc_is_del = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColProc_crt_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProc_crt_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SplitSchedule = new System.Windows.Forms.SplitContainer();
            this.DgvConfigWeek = new System.Windows.Forms.DataGridView();
            this.ColWeek_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWeek_sun = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColWeek_mon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColWeek_tue = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColWeek_wed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColWeek_thu = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColWeek_fri = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColWeek_sat = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColWeek_crt_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWeek_crt_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvConfigTime = new System.Windows.Forms.DataGridView();
            this.ColTime_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTime_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTime_enabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColTime_info = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColTime_crt_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTime_crt_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitProcedure)).BeginInit();
            this.SplitProcedure.Panel1.SuspendLayout();
            this.SplitProcedure.Panel2.SuspendLayout();
            this.SplitProcedure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvConfigList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitSchedule)).BeginInit();
            this.SplitSchedule.Panel1.SuspendLayout();
            this.SplitSchedule.Panel2.SuspendLayout();
            this.SplitSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvConfigWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvConfigTime)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            this.ToolBar.BackColor = System.Drawing.Color.Transparent;
            this.ToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnUpdateConfig});
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ToolBar.Size = new System.Drawing.Size(1192, 78);
            this.ToolBar.TabIndex = 13;
            // 
            // BtnUpdateConfig
            // 
            this.BtnUpdateConfig.AutoSize = false;
            this.BtnUpdateConfig.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnUpdateConfig.Image = ((System.Drawing.Image)(resources.GetObject("BtnUpdateConfig.Image")));
            this.BtnUpdateConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnUpdateConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnUpdateConfig.Name = "BtnUpdateConfig";
            this.BtnUpdateConfig.Size = new System.Drawing.Size(75, 75);
            this.BtnUpdateConfig.Text = "更新";
            this.BtnUpdateConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnUpdateConfig.Click += new System.EventHandler(this.BtnUpdateConfig_Click);
            // 
            // SplitProcedure
            // 
            this.SplitProcedure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitProcedure.Location = new System.Drawing.Point(0, 78);
            this.SplitProcedure.Margin = new System.Windows.Forms.Padding(2);
            this.SplitProcedure.Name = "SplitProcedure";
            this.SplitProcedure.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitProcedure.Panel1
            // 
            this.SplitProcedure.Panel1.Controls.Add(this.DgvConfigList);
            // 
            // SplitProcedure.Panel2
            // 
            this.SplitProcedure.Panel2.Controls.Add(this.SplitSchedule);
            this.SplitProcedure.Size = new System.Drawing.Size(1192, 447);
            this.SplitProcedure.SplitterDistance = 231;
            this.SplitProcedure.SplitterWidth = 3;
            this.SplitProcedure.TabIndex = 14;
            // 
            // DgvConfigList
            // 
            this.DgvConfigList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvConfigList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvConfigList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColPorc_id,
            this.ColProc_sp_type,
            this.ColProc_ip,
            this.ColProc_db,
            this.ColProc_user_id,
            this.ColProc_password,
            this.ColProc_sp,
            this.ColProc_para,
            this.ColProc_conn_str,
            this.ColProc_cpu,
            this.ColProc_thread,
            this.ColProc_is_del,
            this.ColProc_crt_date,
            this.ColProc_crt_by});
            this.DgvConfigList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvConfigList.Location = new System.Drawing.Point(0, 0);
            this.DgvConfigList.Margin = new System.Windows.Forms.Padding(2);
            this.DgvConfigList.Name = "DgvConfigList";
            this.DgvConfigList.RowTemplate.Height = 27;
            this.DgvConfigList.Size = new System.Drawing.Size(1192, 231);
            this.DgvConfigList.TabIndex = 0;
            this.DgvConfigList.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.DgvConfigList_DefaultValuesNeeded);
            this.DgvConfigList.SelectionChanged += new System.EventHandler(this.DgvConfigList_SelectionChanged);
            // 
            // ColPorc_id
            // 
            this.ColPorc_id.DataPropertyName = "id";
            this.ColPorc_id.HeaderText = "執行編號";
            this.ColPorc_id.MaxInputLength = 50;
            this.ColPorc_id.Name = "ColPorc_id";
            // 
            // ColProc_sp_type
            // 
            this.ColProc_sp_type.DataPropertyName = "sp_type";
            this.ColProc_sp_type.HeaderText = "預存程序類別";
            this.ColProc_sp_type.MaxInputLength = 5;
            this.ColProc_sp_type.Name = "ColProc_sp_type";
            // 
            // ColProc_ip
            // 
            this.ColProc_ip.DataPropertyName = "ip";
            this.ColProc_ip.HeaderText = "電腦位址";
            this.ColProc_ip.MaxInputLength = 15;
            this.ColProc_ip.Name = "ColProc_ip";
            // 
            // ColProc_db
            // 
            this.ColProc_db.DataPropertyName = "db";
            this.ColProc_db.HeaderText = "資料庫";
            this.ColProc_db.MaxInputLength = 30;
            this.ColProc_db.Name = "ColProc_db";
            // 
            // ColProc_user_id
            // 
            this.ColProc_user_id.DataPropertyName = "user_id";
            this.ColProc_user_id.HeaderText = "帳號";
            this.ColProc_user_id.MaxInputLength = 50;
            this.ColProc_user_id.Name = "ColProc_user_id";
            // 
            // ColProc_password
            // 
            this.ColProc_password.DataPropertyName = "password";
            this.ColProc_password.HeaderText = "密碼";
            this.ColProc_password.MaxInputLength = 30;
            this.ColProc_password.Name = "ColProc_password";
            // 
            // ColProc_sp
            // 
            this.ColProc_sp.DataPropertyName = "sp";
            this.ColProc_sp.HeaderText = "預存程序";
            this.ColProc_sp.MaxInputLength = 100;
            this.ColProc_sp.Name = "ColProc_sp";
            // 
            // ColProc_para
            // 
            this.ColProc_para.DataPropertyName = "para";
            this.ColProc_para.HeaderText = "參數";
            this.ColProc_para.MaxInputLength = 1000;
            this.ColProc_para.Name = "ColProc_para";
            // 
            // ColProc_conn_str
            // 
            this.ColProc_conn_str.DataPropertyName = "conn_str";
            this.ColProc_conn_str.HeaderText = "連接字串";
            this.ColProc_conn_str.Name = "ColProc_conn_str";
            this.ColProc_conn_str.Visible = false;
            // 
            // ColProc_cpu
            // 
            this.ColProc_cpu.DataPropertyName = "cpu";
            dataGridViewCellStyle1.Format = "N0";
            this.ColProc_cpu.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColProc_cpu.HeaderText = "CPU";
            this.ColProc_cpu.MaxInputLength = 2;
            this.ColProc_cpu.Name = "ColProc_cpu";
            // 
            // ColProc_thread
            // 
            this.ColProc_thread.DataPropertyName = "thread";
            dataGridViewCellStyle2.Format = "N0";
            this.ColProc_thread.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColProc_thread.HeaderText = "執行緒數";
            this.ColProc_thread.MaxInputLength = 2;
            this.ColProc_thread.Name = "ColProc_thread";
            // 
            // ColProc_is_del
            // 
            this.ColProc_is_del.DataPropertyName = "is_del";
            this.ColProc_is_del.FalseValue = "0";
            this.ColProc_is_del.HeaderText = "刪除";
            this.ColProc_is_del.IndeterminateValue = "1";
            this.ColProc_is_del.Name = "ColProc_is_del";
            this.ColProc_is_del.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColProc_is_del.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColProc_is_del.TrueValue = "1";
            // 
            // ColProc_crt_date
            // 
            this.ColProc_crt_date.DataPropertyName = "crt_date";
            this.ColProc_crt_date.HeaderText = "建立日期";
            this.ColProc_crt_date.Name = "ColProc_crt_date";
            this.ColProc_crt_date.Visible = false;
            // 
            // ColProc_crt_by
            // 
            this.ColProc_crt_by.DataPropertyName = "crt_by";
            this.ColProc_crt_by.HeaderText = "建立人員";
            this.ColProc_crt_by.MaxInputLength = 20;
            this.ColProc_crt_by.Name = "ColProc_crt_by";
            // 
            // SplitSchedule
            // 
            this.SplitSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitSchedule.IsSplitterFixed = true;
            this.SplitSchedule.Location = new System.Drawing.Point(0, 0);
            this.SplitSchedule.Margin = new System.Windows.Forms.Padding(2);
            this.SplitSchedule.Name = "SplitSchedule";
            this.SplitSchedule.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitSchedule.Panel1
            // 
            this.SplitSchedule.Panel1.Controls.Add(this.DgvConfigWeek);
            // 
            // SplitSchedule.Panel2
            // 
            this.SplitSchedule.Panel2.Controls.Add(this.DgvConfigTime);
            this.SplitSchedule.Size = new System.Drawing.Size(1192, 213);
            this.SplitSchedule.SplitterDistance = 45;
            this.SplitSchedule.SplitterWidth = 3;
            this.SplitSchedule.TabIndex = 0;
            // 
            // DgvConfigWeek
            // 
            this.DgvConfigWeek.AllowUserToAddRows = false;
            this.DgvConfigWeek.AllowUserToDeleteRows = false;
            this.DgvConfigWeek.AllowUserToResizeColumns = false;
            this.DgvConfigWeek.AllowUserToResizeRows = false;
            this.DgvConfigWeek.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvConfigWeek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvConfigWeek.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColWeek_id,
            this.ColWeek_sun,
            this.ColWeek_mon,
            this.ColWeek_tue,
            this.ColWeek_wed,
            this.ColWeek_thu,
            this.ColWeek_fri,
            this.ColWeek_sat,
            this.ColWeek_crt_date,
            this.ColWeek_crt_by});
            this.DgvConfigWeek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvConfigWeek.Location = new System.Drawing.Point(0, 0);
            this.DgvConfigWeek.Margin = new System.Windows.Forms.Padding(2);
            this.DgvConfigWeek.Name = "DgvConfigWeek";
            this.DgvConfigWeek.RowTemplate.Height = 27;
            this.DgvConfigWeek.Size = new System.Drawing.Size(1192, 45);
            this.DgvConfigWeek.TabIndex = 0;
            this.DgvConfigWeek.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.DgvConfigWeek_DefaultValuesNeeded);
            // 
            // ColWeek_id
            // 
            this.ColWeek_id.DataPropertyName = "id";
            this.ColWeek_id.HeaderText = "執行編號";
            this.ColWeek_id.MaxInputLength = 50;
            this.ColWeek_id.Name = "ColWeek_id";
            this.ColWeek_id.ReadOnly = true;
            this.ColWeek_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColWeek_sun
            // 
            this.ColWeek_sun.DataPropertyName = "sun";
            this.ColWeek_sun.FalseValue = "0";
            this.ColWeek_sun.HeaderText = "星期日";
            this.ColWeek_sun.Name = "ColWeek_sun";
            this.ColWeek_sun.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColWeek_sun.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColWeek_sun.TrueValue = "1";
            // 
            // ColWeek_mon
            // 
            this.ColWeek_mon.DataPropertyName = "mon";
            this.ColWeek_mon.FalseValue = "0";
            this.ColWeek_mon.HeaderText = "星期一";
            this.ColWeek_mon.Name = "ColWeek_mon";
            this.ColWeek_mon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColWeek_mon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColWeek_mon.TrueValue = "1";
            // 
            // ColWeek_tue
            // 
            this.ColWeek_tue.DataPropertyName = "tue";
            this.ColWeek_tue.FalseValue = "0";
            this.ColWeek_tue.HeaderText = "星期二";
            this.ColWeek_tue.Name = "ColWeek_tue";
            this.ColWeek_tue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColWeek_tue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColWeek_tue.TrueValue = "1";
            // 
            // ColWeek_wed
            // 
            this.ColWeek_wed.DataPropertyName = "wed";
            this.ColWeek_wed.FalseValue = "0";
            this.ColWeek_wed.HeaderText = "星期三";
            this.ColWeek_wed.Name = "ColWeek_wed";
            this.ColWeek_wed.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColWeek_wed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColWeek_wed.TrueValue = "1";
            // 
            // ColWeek_thu
            // 
            this.ColWeek_thu.DataPropertyName = "thu";
            this.ColWeek_thu.FalseValue = "0";
            this.ColWeek_thu.HeaderText = "星期四";
            this.ColWeek_thu.Name = "ColWeek_thu";
            this.ColWeek_thu.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColWeek_thu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColWeek_thu.TrueValue = "1";
            // 
            // ColWeek_fri
            // 
            this.ColWeek_fri.DataPropertyName = "fri";
            this.ColWeek_fri.FalseValue = "0";
            this.ColWeek_fri.HeaderText = "星期五";
            this.ColWeek_fri.Name = "ColWeek_fri";
            this.ColWeek_fri.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColWeek_fri.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColWeek_fri.TrueValue = "1";
            // 
            // ColWeek_sat
            // 
            this.ColWeek_sat.DataPropertyName = "sat";
            this.ColWeek_sat.FalseValue = "0";
            this.ColWeek_sat.HeaderText = "星期六";
            this.ColWeek_sat.Name = "ColWeek_sat";
            this.ColWeek_sat.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColWeek_sat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColWeek_sat.TrueValue = "1";
            // 
            // ColWeek_crt_date
            // 
            this.ColWeek_crt_date.DataPropertyName = "crt_date";
            this.ColWeek_crt_date.HeaderText = "建立日期";
            this.ColWeek_crt_date.Name = "ColWeek_crt_date";
            this.ColWeek_crt_date.Visible = false;
            // 
            // ColWeek_crt_by
            // 
            this.ColWeek_crt_by.DataPropertyName = "crt_by";
            this.ColWeek_crt_by.HeaderText = "建立人員";
            this.ColWeek_crt_by.MaxInputLength = 20;
            this.ColWeek_crt_by.Name = "ColWeek_crt_by";
            // 
            // DgvConfigTime
            // 
            this.DgvConfigTime.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvConfigTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvConfigTime.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColTime_id,
            this.ColTime_time,
            this.ColTime_enabled,
            this.ColTime_info,
            this.ColTime_crt_date,
            this.ColTime_crt_by});
            this.DgvConfigTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvConfigTime.Location = new System.Drawing.Point(0, 0);
            this.DgvConfigTime.Margin = new System.Windows.Forms.Padding(2);
            this.DgvConfigTime.Name = "DgvConfigTime";
            this.DgvConfigTime.RowTemplate.Height = 27;
            this.DgvConfigTime.Size = new System.Drawing.Size(1192, 165);
            this.DgvConfigTime.TabIndex = 0;
            this.DgvConfigTime.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.DgvConfigTime_DefaultValuesNeeded);
            // 
            // ColTime_id
            // 
            this.ColTime_id.DataPropertyName = "id";
            this.ColTime_id.HeaderText = "執行編號";
            this.ColTime_id.MaxInputLength = 50;
            this.ColTime_id.Name = "ColTime_id";
            // 
            // ColTime_time
            // 
            this.ColTime_time.DataPropertyName = "time";
            this.ColTime_time.HeaderText = "執行時間";
            this.ColTime_time.MaxInputLength = 5;
            this.ColTime_time.Name = "ColTime_time";
            // 
            // ColTime_enabled
            // 
            this.ColTime_enabled.DataPropertyName = "enabled";
            this.ColTime_enabled.FalseValue = "0";
            this.ColTime_enabled.HeaderText = "啟用/停用";
            this.ColTime_enabled.Name = "ColTime_enabled";
            this.ColTime_enabled.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColTime_enabled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColTime_enabled.TrueValue = "1";
            // 
            // ColTime_info
            // 
            this.ColTime_info.DataPropertyName = "info";
            this.ColTime_info.FalseValue = "0";
            this.ColTime_info.HeaderText = "智慧通報";
            this.ColTime_info.Name = "ColTime_info";
            this.ColTime_info.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColTime_info.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColTime_info.TrueValue = "1";
            // 
            // ColTime_crt_date
            // 
            this.ColTime_crt_date.DataPropertyName = "crt_date";
            this.ColTime_crt_date.HeaderText = "建立日期";
            this.ColTime_crt_date.Name = "ColTime_crt_date";
            this.ColTime_crt_date.Visible = false;
            // 
            // ColTime_crt_by
            // 
            this.ColTime_crt_by.DataPropertyName = "crt_by";
            this.ColTime_crt_by.HeaderText = "建立人員";
            this.ColTime_crt_by.MaxInputLength = 20;
            this.ColTime_crt_by.Name = "ColTime_crt_by";
            // 
            // FormSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 525);
            this.Controls.Add(this.SplitProcedure);
            this.Controls.Add(this.ToolBar);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "排程設定";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormSchedule_Load);
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            this.SplitProcedure.Panel1.ResumeLayout(false);
            this.SplitProcedure.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitProcedure)).EndInit();
            this.SplitProcedure.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvConfigList)).EndInit();
            this.SplitSchedule.Panel1.ResumeLayout(false);
            this.SplitSchedule.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitSchedule)).EndInit();
            this.SplitSchedule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvConfigWeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvConfigTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolBar;
        private System.Windows.Forms.ToolStripButton BtnUpdateConfig;
        private System.Windows.Forms.SplitContainer SplitProcedure;
        private System.Windows.Forms.DataGridView DgvConfigList;
        private System.Windows.Forms.SplitContainer SplitSchedule;
        private System.Windows.Forms.DataGridView DgvConfigWeek;
        private System.Windows.Forms.DataGridView DgvConfigTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWeek_id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColWeek_sun;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColWeek_mon;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColWeek_tue;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColWeek_wed;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColWeek_thu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColWeek_fri;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColWeek_sat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWeek_crt_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWeek_crt_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPorc_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProc_sp_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProc_ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProc_db;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProc_user_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProc_password;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProc_sp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProc_para;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProc_conn_str;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProc_cpu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProc_thread;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColProc_is_del;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProc_crt_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProc_crt_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTime_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTime_time;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColTime_enabled;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColTime_info;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTime_crt_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTime_crt_by;
    }
}