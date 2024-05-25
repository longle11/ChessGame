namespace Chess_Game_Project
{
    partial class InputTokenForm1
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.txtAuth = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNext = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnSendTokenAgain = new Guna.UI2.WinForms.Guna2GradientButton();
            this.authLabel = new System.Windows.Forms.Label();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.NavajoWhite;
            this.pnlContent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlContent.Controls.Add(this.txtAuth);
            this.pnlContent.Controls.Add(this.label1);
            this.pnlContent.Controls.Add(this.btnNext);
            this.pnlContent.Controls.Add(this.btnSendTokenAgain);
            this.pnlContent.Controls.Add(this.authLabel);
            this.pnlContent.Location = new System.Drawing.Point(105, 25);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(591, 400);
            this.pnlContent.TabIndex = 15;
            // 
            // txtAuth
            // 
            this.txtAuth.BorderColor = System.Drawing.Color.Black;
            this.txtAuth.BorderRadius = 5;
            this.txtAuth.BorderThickness = 2;
            this.txtAuth.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAuth.DefaultText = "";
            this.txtAuth.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAuth.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAuth.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAuth.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAuth.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAuth.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtAuth.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAuth.Location = new System.Drawing.Point(158, 141);
            this.txtAuth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAuth.Name = "txtAuth";
            this.txtAuth.PasswordChar = '\0';
            this.txtAuth.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtAuth.PlaceholderText = "Nhập mã";
            this.txtAuth.SelectedText = "";
            this.txtAuth.Size = new System.Drawing.Size(292, 48);
            this.txtAuth.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(160, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 2);
            this.label1.TabIndex = 4;
            this.label1.Text = "-----------------------";
            // 
            // btnNext
            // 
            this.btnNext.BorderRadius = 20;
            this.btnNext.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNext.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(121)))), ((int)(((byte)(94)))));
            this.btnNext.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(121)))), ((int)(((byte)(94)))));
            this.btnNext.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(214, 267);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(180, 45);
            this.btnNext.TabIndex = 15;
            this.btnNext.Text = "Xác nhận";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnSendTokenAgain
            // 
            this.btnSendTokenAgain.BorderRadius = 10;
            this.btnSendTokenAgain.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSendTokenAgain.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSendTokenAgain.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendTokenAgain.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendTokenAgain.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSendTokenAgain.FillColor = System.Drawing.Color.NavajoWhite;
            this.btnSendTokenAgain.FillColor2 = System.Drawing.Color.NavajoWhite;
            this.btnSendTokenAgain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSendTokenAgain.ForeColor = System.Drawing.Color.Black;
            this.btnSendTokenAgain.Location = new System.Drawing.Point(132, 211);
            this.btnSendTokenAgain.Name = "btnSendTokenAgain";
            this.btnSendTokenAgain.Size = new System.Drawing.Size(123, 27);
            this.btnSendTokenAgain.TabIndex = 14;
            this.btnSendTokenAgain.Text = "Gửi lại mã";
            this.btnSendTokenAgain.Click += new System.EventHandler(this.btnSendTokenAgain_Click);
            // 
            // authLabel
            // 
            this.authLabel.AutoSize = true;
            this.authLabel.BackColor = System.Drawing.Color.NavajoWhite;
            this.authLabel.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.authLabel.ForeColor = System.Drawing.Color.Black;
            this.authLabel.Location = new System.Drawing.Point(154, 117);
            this.authLabel.Name = "authLabel";
            this.authLabel.Size = new System.Drawing.Size(153, 20);
            this.authLabel.TabIndex = 10;
            this.authLabel.Text = "Nhập mã xác thực";
            // 
            // InputTokenForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 465);
            this.Controls.Add(this.pnlContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InputTokenForm1";
            this.Text = "InputTokenForm1";
            this.Load += new System.EventHandler(this.InputTokenForm1_Load);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label authLabel;
        private Guna.UI2.WinForms.Guna2GradientButton btnSendTokenAgain;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GradientButton btnNext;
        private Guna.UI2.WinForms.Guna2TextBox txtAuth;
    }
}