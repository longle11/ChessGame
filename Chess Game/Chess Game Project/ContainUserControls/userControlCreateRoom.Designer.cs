namespace Chess_Game_Project.ContainUserControls
{
    partial class userControlCreateRoom
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
            this.pnlCreateRoom = new System.Windows.Forms.Panel();
            this.btnAcceptCreateRoom = new Guna.UI2.WinForms.Guna2Button();
            this.txtBetPoints = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtRoomName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCloseCreateRoom = new Guna.UI2.WinForms.Guna2Button();
            this.pnlCreateRoom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCreateRoom
            // 
            this.pnlCreateRoom.BackColor = System.Drawing.Color.NavajoWhite;
            this.pnlCreateRoom.Controls.Add(this.btnAcceptCreateRoom);
            this.pnlCreateRoom.Controls.Add(this.txtBetPoints);
            this.pnlCreateRoom.Controls.Add(this.txtRoomName);
            this.pnlCreateRoom.Controls.Add(this.label3);
            this.pnlCreateRoom.Controls.Add(this.label1);
            this.pnlCreateRoom.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.pnlCreateRoom.Location = new System.Drawing.Point(34, 80);
            this.pnlCreateRoom.Name = "pnlCreateRoom";
            this.pnlCreateRoom.Size = new System.Drawing.Size(621, 417);
            this.pnlCreateRoom.TabIndex = 5;
            // 
            // btnAcceptCreateRoom
            // 
            this.btnAcceptCreateRoom.Animated = true;
            this.btnAcceptCreateRoom.AutoRoundedCorners = true;
            this.btnAcceptCreateRoom.BorderRadius = 21;
            this.btnAcceptCreateRoom.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAcceptCreateRoom.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAcceptCreateRoom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAcceptCreateRoom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAcceptCreateRoom.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(121)))), ((int)(((byte)(94)))));
            this.btnAcceptCreateRoom.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAcceptCreateRoom.ForeColor = System.Drawing.Color.White;
            this.btnAcceptCreateRoom.Location = new System.Drawing.Point(426, 21);
            this.btnAcceptCreateRoom.Name = "btnAcceptCreateRoom";
            this.btnAcceptCreateRoom.Size = new System.Drawing.Size(180, 45);
            this.btnAcceptCreateRoom.TabIndex = 12;
            this.btnAcceptCreateRoom.Text = "Tạo phòng";
            this.btnAcceptCreateRoom.Click += new System.EventHandler(this.btnAcceptCreateRoom_Click);
            // 
            // txtBetPoints
            // 
            this.txtBetPoints.Animated = true;
            this.txtBetPoints.BorderColor = System.Drawing.Color.Black;
            this.txtBetPoints.BorderRadius = 10;
            this.txtBetPoints.BorderThickness = 2;
            this.txtBetPoints.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBetPoints.DefaultText = "";
            this.txtBetPoints.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBetPoints.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBetPoints.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBetPoints.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBetPoints.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBetPoints.Font = new System.Drawing.Font("Consolas", 10.8F);
            this.txtBetPoints.ForeColor = System.Drawing.Color.Gray;
            this.txtBetPoints.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBetPoints.Location = new System.Drawing.Point(40, 263);
            this.txtBetPoints.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBetPoints.Name = "txtBetPoints";
            this.txtBetPoints.PasswordChar = '\0';
            this.txtBetPoints.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtBetPoints.PlaceholderText = "Nhập điểm cược";
            this.txtBetPoints.SelectedText = "";
            this.txtBetPoints.Size = new System.Drawing.Size(286, 53);
            this.txtBetPoints.TabIndex = 11;
            // 
            // txtRoomName
            // 
            this.txtRoomName.Animated = true;
            this.txtRoomName.BorderColor = System.Drawing.Color.Black;
            this.txtRoomName.BorderRadius = 10;
            this.txtRoomName.BorderThickness = 2;
            this.txtRoomName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRoomName.DefaultText = "";
            this.txtRoomName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRoomName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRoomName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRoomName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRoomName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRoomName.Font = new System.Drawing.Font("Consolas", 10.8F);
            this.txtRoomName.ForeColor = System.Drawing.Color.Gray;
            this.txtRoomName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRoomName.Location = new System.Drawing.Point(40, 79);
            this.txtRoomName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.PasswordChar = '\0';
            this.txtRoomName.PlaceholderText = "Nhập tên phòng";
            this.txtRoomName.SelectedText = "";
            this.txtRoomName.Size = new System.Drawing.Size(286, 53);
            this.txtRoomName.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cooper Black", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 32);
            this.label3.TabIndex = 8;
            this.label3.Text = "Điểm cược :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tên phòng :";
            // 
            // btnCloseCreateRoom
            // 
            this.btnCloseCreateRoom.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCloseCreateRoom.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCloseCreateRoom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCloseCreateRoom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCloseCreateRoom.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseCreateRoom.ForeColor = System.Drawing.Color.White;
            this.btnCloseCreateRoom.Location = new System.Drawing.Point(632, 0);
            this.btnCloseCreateRoom.Name = "btnCloseCreateRoom";
            this.btnCloseCreateRoom.Size = new System.Drawing.Size(62, 52);
            this.btnCloseCreateRoom.TabIndex = 13;
            this.btnCloseCreateRoom.Text = "X";
            this.btnCloseCreateRoom.Click += new System.EventHandler(this.btnCloseCreateRoom_Click);
            // 
            // userControlCreateRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCloseCreateRoom);
            this.Controls.Add(this.pnlCreateRoom);
            this.Name = "userControlCreateRoom";
            this.Size = new System.Drawing.Size(694, 537);
            this.pnlCreateRoom.ResumeLayout(false);
            this.pnlCreateRoom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCreateRoom;
        private Guna.UI2.WinForms.Guna2Button btnAcceptCreateRoom;
        private Guna.UI2.WinForms.Guna2TextBox txtBetPoints;
        private Guna.UI2.WinForms.Guna2TextBox txtRoomName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnCloseCreateRoom;
    }
}
