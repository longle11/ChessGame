namespace Chess_Game_Project.ContainUserControls
{
    partial class userControlContentChatIcon
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
            this.lbUserName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.ptvAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.ptbIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptvAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lbUserName
            // 
            this.lbUserName.BackColor = System.Drawing.Color.Transparent;
            this.lbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbUserName.Location = new System.Drawing.Point(3, 4);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(63, 18);
            this.lbUserName.TabIndex = 5;
            this.lbUserName.Text = "LongLee";
            // 
            // ptvAvatar
            // 
            this.ptvAvatar.ImageRotate = 0F;
            this.ptvAvatar.Location = new System.Drawing.Point(3, 28);
            this.ptvAvatar.Name = "ptvAvatar";
            this.ptvAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.ptvAvatar.Size = new System.Drawing.Size(31, 31);
            this.ptvAvatar.TabIndex = 4;
            this.ptvAvatar.TabStop = false;
            // 
            // ptbIcon
            // 
            this.ptbIcon.ImageRotate = 0F;
            this.ptbIcon.Location = new System.Drawing.Point(40, 28);
            this.ptbIcon.Name = "ptbIcon";
            this.ptbIcon.Size = new System.Drawing.Size(53, 49);
            this.ptbIcon.TabIndex = 6;
            this.ptbIcon.TabStop = false;
            // 
            // userControlContentChatIcon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ptbIcon);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.ptvAvatar);
            this.Name = "userControlContentChatIcon";
            this.Size = new System.Drawing.Size(101, 84);
            ((System.ComponentModel.ISupportInitialize)(this.ptvAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel lbUserName;
        private Guna.UI2.WinForms.Guna2CirclePictureBox ptvAvatar;
        private Guna.UI2.WinForms.Guna2PictureBox ptbIcon;
    }
}
