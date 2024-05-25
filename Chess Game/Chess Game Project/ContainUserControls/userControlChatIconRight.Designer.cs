namespace Chess_Game_Project.ContainUserControls
{
    partial class userControlChatIconRight
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
            this.ptbAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.ptbIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lbUserName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbAvatar
            // 
            this.ptbAvatar.ImageRotate = 0F;
            this.ptbAvatar.Location = new System.Drawing.Point(59, 28);
            this.ptbAvatar.Name = "ptbAvatar";
            this.ptbAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.ptbAvatar.Size = new System.Drawing.Size(31, 31);
            this.ptbAvatar.TabIndex = 7;
            this.ptbAvatar.TabStop = false;
            // 
            // ptbIcon
            // 
            this.ptbIcon.ImageRotate = 0F;
            this.ptbIcon.Location = new System.Drawing.Point(3, 24);
            this.ptbIcon.Name = "ptbIcon";
            this.ptbIcon.Size = new System.Drawing.Size(53, 49);
            this.ptbIcon.TabIndex = 10;
            this.ptbIcon.TabStop = false;
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.BackColor = System.Drawing.Color.Transparent;
            this.lbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.lbUserName.Location = new System.Drawing.Point(40, 5);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(50, 16);
            this.lbUserName.TabIndex = 11;
            this.lbUserName.Text = "label1";
            // 
            // userControlChatIconRight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.ptbIcon);
            this.Controls.Add(this.ptbAvatar);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "userControlChatIconRight";
            this.Size = new System.Drawing.Size(101, 84);
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2CirclePictureBox ptbAvatar;
        private Guna.UI2.WinForms.Guna2PictureBox ptbIcon;
        private System.Windows.Forms.Label lbUserName;
    }
}
