namespace Chess_Game_Project.ContainUserControls
{
    partial class userControlChatMsgRight
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
            this.txtContent = new Guna.UI2.WinForms.Guna2TextBox();
            this.ptvAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lbUserName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptvAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtContent
            // 
            this.txtContent.BorderRadius = 10;
            this.txtContent.BorderThickness = 3;
            this.txtContent.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContent.DefaultText = "";
            this.txtContent.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtContent.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtContent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtContent.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtContent.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtContent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtContent.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtContent.Location = new System.Drawing.Point(19, 20);
            this.txtContent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.PasswordChar = '\0';
            this.txtContent.PlaceholderText = "";
            this.txtContent.SelectedText = "";
            this.txtContent.Size = new System.Drawing.Size(10, 39);
            this.txtContent.TabIndex = 6;
            this.txtContent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ptvAvatar
            // 
            this.ptvAvatar.ImageRotate = 0F;
            this.ptvAvatar.Location = new System.Drawing.Point(35, 28);
            this.ptvAvatar.Name = "ptvAvatar";
            this.ptvAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.ptvAvatar.Size = new System.Drawing.Size(31, 31);
            this.ptvAvatar.TabIndex = 4;
            this.ptvAvatar.TabStop = false;
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.BackColor = System.Drawing.Color.Transparent;
            this.lbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.lbUserName.Location = new System.Drawing.Point(16, 9);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(50, 16);
            this.lbUserName.TabIndex = 7;
            this.lbUserName.Text = "label1";
            // 
            // userControlChatMsgRight
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.ptvAvatar);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "userControlChatMsgRight";
            this.Size = new System.Drawing.Size(75, 66);
            ((System.ComponentModel.ISupportInitialize)(this.ptvAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtContent;
        private Guna.UI2.WinForms.Guna2CirclePictureBox ptvAvatar;
        private System.Windows.Forms.Label lbUserName;
    }
}
