namespace ParallelSP
{
    partial class FormPara
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPara));
            this.ToolBar = new System.Windows.Forms.ToolStrip();
            this.BtnUpdatePara = new System.Windows.Forms.ToolStripButton();
            this.DgvConfigPara = new System.Windows.Forms.DataGridView();
            this.ColPara_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPara_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvConfigPara)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            this.ToolBar.BackColor = System.Drawing.Color.Transparent;
            this.ToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnUpdatePara});
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ToolBar.Size = new System.Drawing.Size(751, 78);
            this.ToolBar.TabIndex = 14;
            // 
            // BtnUpdatePara
            // 
            this.BtnUpdatePara.AutoSize = false;
            this.BtnUpdatePara.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BtnUpdatePara.Image = ((System.Drawing.Image)(resources.GetObject("BtnUpdatePara.Image")));
            this.BtnUpdatePara.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BtnUpdatePara.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnUpdatePara.Name = "BtnUpdatePara";
            this.BtnUpdatePara.Size = new System.Drawing.Size(75, 75);
            this.BtnUpdatePara.Text = "更新";
            this.BtnUpdatePara.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnUpdatePara.Click += new System.EventHandler(this.BtnUpdatePara_Click);
            // 
            // DgvConfigPara
            // 
            this.DgvConfigPara.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvConfigPara.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColPara_id,
            this.ColPara_desc});
            this.DgvConfigPara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvConfigPara.Location = new System.Drawing.Point(0, 78);
            this.DgvConfigPara.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DgvConfigPara.Name = "DgvConfigPara";
            this.DgvConfigPara.RowTemplate.Height = 27;
            this.DgvConfigPara.Size = new System.Drawing.Size(751, 419);
            this.DgvConfigPara.TabIndex = 15;
            // 
            // ColPara_id
            // 
            this.ColPara_id.DataPropertyName = "para_id";
            this.ColPara_id.HeaderText = "參數代碼";
            this.ColPara_id.MaxInputLength = 30;
            this.ColPara_id.Name = "ColPara_id";
            this.ColPara_id.Width = 150;
            // 
            // ColPara_desc
            // 
            this.ColPara_desc.DataPropertyName = "para_desc";
            this.ColPara_desc.HeaderText = "參數描述";
            this.ColPara_desc.MaxInputLength = 200;
            this.ColPara_desc.Name = "ColPara_desc";
            this.ColPara_desc.Width = 500;
            // 
            // FormPara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 497);
            this.Controls.Add(this.DgvConfigPara);
            this.Controls.Add(this.ToolBar);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormPara";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "參數設定";
            this.Load += new System.EventHandler(this.FormPara_Load);
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvConfigPara)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolBar;
        private System.Windows.Forms.ToolStripButton BtnUpdatePara;
        private System.Windows.Forms.DataGridView DgvConfigPara;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPara_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPara_desc;
    }
}