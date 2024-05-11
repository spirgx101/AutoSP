
namespace ManualSP
{
    partial class FormMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbxServerList = new System.Windows.Forms.ComboBox();
            this.txtSqlCommand = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "連接伺服器：";
            // 
            // cbxServerList
            // 
            this.cbxServerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServerList.FormattingEnabled = true;
            this.cbxServerList.Location = new System.Drawing.Point(100, 8);
            this.cbxServerList.Name = "cbxServerList";
            this.cbxServerList.Size = new System.Drawing.Size(366, 24);
            this.cbxServerList.TabIndex = 1;
            // 
            // txtSqlCommand
            // 
            this.txtSqlCommand.Location = new System.Drawing.Point(16, 46);
            this.txtSqlCommand.Multiline = true;
            this.txtSqlCommand.Name = "txtSqlCommand";
            this.txtSqlCommand.Size = new System.Drawing.Size(450, 150);
            this.txtSqlCommand.TabIndex = 2;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(391, 202);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 3;
            this.btnExecute.Text = "執行SP";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 235);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.txtSqlCommand);
            this.Controls.Add(this.cbxServerList);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "手動執行SP小工具";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxServerList;
        private System.Windows.Forms.TextBox txtSqlCommand;
        private System.Windows.Forms.Button btnExecute;
    }
}

