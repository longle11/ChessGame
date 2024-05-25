namespace Chess_Game_Project.ContainUserControls
{
    partial class userControlHistory
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(userControlHistory));
            this.pnlChildContainHistory = new System.Windows.Forms.Panel();
            this.dtGridViewHistory = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnCloseHistory = new Guna.UI2.WinForms.Guna2Button();
            this.btnLoadListHistory = new Guna.UI2.WinForms.Guna2Button();
            this.pnlChildContainHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridViewHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlChildContainHistory
            // 
            this.pnlChildContainHistory.Controls.Add(this.btnLoadListHistory);
            this.pnlChildContainHistory.Controls.Add(this.dtGridViewHistory);
            this.pnlChildContainHistory.Controls.Add(this.btnCloseHistory);
            this.pnlChildContainHistory.Location = new System.Drawing.Point(0, 0);
            this.pnlChildContainHistory.Name = "pnlChildContainHistory";
            this.pnlChildContainHistory.Size = new System.Drawing.Size(866, 552);
            this.pnlChildContainHistory.TabIndex = 6;
            // 
            // dtGridViewHistory
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dtGridViewHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGridViewHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtGridViewHistory.ColumnHeadersHeight = 35;
            this.dtGridViewHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGridViewHistory.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtGridViewHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtGridViewHistory.Location = new System.Drawing.Point(0, 65);
            this.dtGridViewHistory.Name = "dtGridViewHistory";
            this.dtGridViewHistory.RowHeadersVisible = false;
            this.dtGridViewHistory.RowHeadersWidth = 51;
            this.dtGridViewHistory.RowTemplate.Height = 24;
            this.dtGridViewHistory.Size = new System.Drawing.Size(863, 484);
            this.dtGridViewHistory.TabIndex = 89;
            this.dtGridViewHistory.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtGridViewHistory.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtGridViewHistory.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtGridViewHistory.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtGridViewHistory.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtGridViewHistory.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtGridViewHistory.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtGridViewHistory.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtGridViewHistory.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtGridViewHistory.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtGridViewHistory.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtGridViewHistory.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtGridViewHistory.ThemeStyle.HeaderStyle.Height = 35;
            this.dtGridViewHistory.ThemeStyle.ReadOnly = false;
            this.dtGridViewHistory.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtGridViewHistory.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtGridViewHistory.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtGridViewHistory.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtGridViewHistory.ThemeStyle.RowsStyle.Height = 24;
            this.dtGridViewHistory.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtGridViewHistory.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btnCloseHistory
            // 
            this.btnCloseHistory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCloseHistory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCloseHistory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCloseHistory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCloseHistory.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseHistory.ForeColor = System.Drawing.Color.White;
            this.btnCloseHistory.Location = new System.Drawing.Point(804, 0);
            this.btnCloseHistory.Name = "btnCloseHistory";
            this.btnCloseHistory.Size = new System.Drawing.Size(62, 59);
            this.btnCloseHistory.TabIndex = 3;
            this.btnCloseHistory.Text = "X";
            this.btnCloseHistory.Click += new System.EventHandler(this.btnCloseHistory_Click);
            // 
            // btnLoadListHistory
            // 
            this.btnLoadListHistory.BackColor = System.Drawing.Color.Transparent;
            this.btnLoadListHistory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLoadListHistory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLoadListHistory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLoadListHistory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLoadListHistory.FillColor = System.Drawing.Color.Transparent;
            this.btnLoadListHistory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLoadListHistory.ForeColor = System.Drawing.Color.White;
            this.btnLoadListHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadListHistory.Image")));
            this.btnLoadListHistory.Location = new System.Drawing.Point(0, 25);
            this.btnLoadListHistory.Name = "btnLoadListHistory";
            this.btnLoadListHistory.Size = new System.Drawing.Size(31, 24);
            this.btnLoadListHistory.TabIndex = 93;
            this.btnLoadListHistory.Click += new System.EventHandler(this.btnLoadListHistory_Click);
            // 
            // userControlHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlChildContainHistory);
            this.Name = "userControlHistory";
            this.Size = new System.Drawing.Size(866, 553);
            this.pnlChildContainHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridViewHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlChildContainHistory;
        private Guna.UI2.WinForms.Guna2Button btnCloseHistory;
        private Guna.UI2.WinForms.Guna2DataGridView dtGridViewHistory;
        private Guna.UI2.WinForms.Guna2Button btnLoadListHistory;
    }
}
