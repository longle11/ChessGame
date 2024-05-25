namespace Chess_Game_Project.ContainUserControls
{
    partial class userControlRanks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(userControlRanks));
            this.pnlRanker = new System.Windows.Forms.Panel();
            this.dtGridRank = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnCloseRank = new Guna.UI2.WinForms.Guna2Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbCurrentRank = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbYourRank = new System.Windows.Forms.Label();
            this.pnlYourLevel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLoadListRank = new Guna.UI2.WinForms.Guna2Button();
            this.pnlRanker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridRank)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRanker
            // 
            this.pnlRanker.Controls.Add(this.btnLoadListRank);
            this.pnlRanker.Controls.Add(this.dtGridRank);
            this.pnlRanker.Controls.Add(this.btnCloseRank);
            this.pnlRanker.Controls.Add(this.panel2);
            this.pnlRanker.Controls.Add(this.panel1);
            this.pnlRanker.Controls.Add(this.pnlYourLevel);
            this.pnlRanker.Location = new System.Drawing.Point(0, 0);
            this.pnlRanker.Name = "pnlRanker";
            this.pnlRanker.Size = new System.Drawing.Size(572, 546);
            this.pnlRanker.TabIndex = 4;
            // 
            // dtGridRank
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dtGridRank.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGridRank.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtGridRank.ColumnHeadersHeight = 35;
            this.dtGridRank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGridRank.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtGridRank.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtGridRank.Location = new System.Drawing.Point(0, 50);
            this.dtGridRank.Name = "dtGridRank";
            this.dtGridRank.RowHeadersVisible = false;
            this.dtGridRank.RowHeadersWidth = 51;
            this.dtGridRank.RowTemplate.Height = 24;
            this.dtGridRank.Size = new System.Drawing.Size(572, 434);
            this.dtGridRank.TabIndex = 89;
            this.dtGridRank.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtGridRank.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtGridRank.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtGridRank.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtGridRank.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtGridRank.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtGridRank.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtGridRank.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtGridRank.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtGridRank.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtGridRank.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtGridRank.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtGridRank.ThemeStyle.HeaderStyle.Height = 35;
            this.dtGridRank.ThemeStyle.ReadOnly = false;
            this.dtGridRank.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtGridRank.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtGridRank.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtGridRank.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtGridRank.ThemeStyle.RowsStyle.Height = 24;
            this.dtGridRank.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtGridRank.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btnCloseRank
            // 
            this.btnCloseRank.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCloseRank.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCloseRank.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCloseRank.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCloseRank.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseRank.ForeColor = System.Drawing.Color.White;
            this.btnCloseRank.Location = new System.Drawing.Point(518, 0);
            this.btnCloseRank.Name = "btnCloseRank";
            this.btnCloseRank.Size = new System.Drawing.Size(56, 48);
            this.btnCloseRank.TabIndex = 11;
            this.btnCloseRank.Text = "X";
            this.btnCloseRank.Click += new System.EventHandler(this.btnCloseRank_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.IndianRed;
            this.panel2.Controls.Add(this.lbCurrentRank);
            this.panel2.Location = new System.Drawing.Point(292, 490);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 59);
            this.panel2.TabIndex = 4;
            // 
            // lbCurrentRank
            // 
            this.lbCurrentRank.AutoSize = true;
            this.lbCurrentRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentRank.Location = new System.Drawing.Point(128, 10);
            this.lbCurrentRank.Name = "lbCurrentRank";
            this.lbCurrentRank.Size = new System.Drawing.Size(36, 38);
            this.lbCurrentRank.TabIndex = 0;
            this.lbCurrentRank.Text = "1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lbYourRank);
            this.panel1.Location = new System.Drawing.Point(0, 490);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 59);
            this.panel1.TabIndex = 3;
            // 
            // lbYourRank
            // 
            this.lbYourRank.AutoSize = true;
            this.lbYourRank.Font = new System.Drawing.Font("Consolas", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbYourRank.Location = new System.Drawing.Point(17, 10);
            this.lbYourRank.Name = "lbYourRank";
            this.lbYourRank.Size = new System.Drawing.Size(233, 38);
            this.lbYourRank.TabIndex = 4;
            this.lbYourRank.Text = "Hạng của bạn";
            // 
            // pnlYourLevel
            // 
            this.pnlYourLevel.Location = new System.Drawing.Point(3, 490);
            this.pnlYourLevel.Name = "pnlYourLevel";
            this.pnlYourLevel.Size = new System.Drawing.Size(573, 59);
            this.pnlYourLevel.TabIndex = 2;
            // 
            // btnLoadListRank
            // 
            this.btnLoadListRank.BackColor = System.Drawing.Color.Transparent;
            this.btnLoadListRank.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLoadListRank.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLoadListRank.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLoadListRank.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLoadListRank.FillColor = System.Drawing.Color.Transparent;
            this.btnLoadListRank.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLoadListRank.ForeColor = System.Drawing.Color.White;
            this.btnLoadListRank.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadListRank.Image")));
            this.btnLoadListRank.Location = new System.Drawing.Point(0, 3);
            this.btnLoadListRank.Name = "btnLoadListRank";
            this.btnLoadListRank.Size = new System.Drawing.Size(31, 41);
            this.btnLoadListRank.TabIndex = 93;
            this.btnLoadListRank.Click += new System.EventHandler(this.btnLoadListRank_Click);
            // 
            // userControlRanks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlRanker);
            this.Name = "userControlRanks";
            this.Size = new System.Drawing.Size(572, 547);
            this.pnlRanker.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridRank)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRanker;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbCurrentRank;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbYourRank;
        private System.Windows.Forms.FlowLayoutPanel pnlYourLevel;
        private Guna.UI2.WinForms.Guna2Button btnCloseRank;
        private Guna.UI2.WinForms.Guna2DataGridView dtGridRank;
        private Guna.UI2.WinForms.Guna2Button btnLoadListRank;
    }
}
