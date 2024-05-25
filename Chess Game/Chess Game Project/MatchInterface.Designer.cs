using System.Drawing;
using System.Windows.Forms;

namespace Chess_Game_Project
{
    partial class MatchInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchInterface));
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlContainChessBoard = new System.Windows.Forms.Panel();
            this.pnlChatClientFrame = new Guna.UI2.WinForms.Guna2Panel();
            this.listChat = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlContainsIcon = new System.Windows.Forms.Panel();
            this.txtMessage = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCountTime = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSendData = new Guna.UI2.WinForms.Guna2Button();
            this.btnOutRoom = new Guna.UI2.WinForms.Guna2Button();
            this.btnSendIcon = new Guna.UI2.WinForms.Guna2Button();
            this.lbDifPlayer = new System.Windows.Forms.Label();
            this.lbCurrentPlayer = new System.Windows.Forms.Label();
            this.avtDifPlayer = new System.Windows.Forms.PictureBox();
            this.avtCurrentPlayer = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTurnUser = new System.Windows.Forms.TextBox();
            this.pnlContainPieces = new System.Windows.Forms.Panel();
            this.pnlContent.SuspendLayout();
            this.pnlChatClientFrame.SuspendLayout();
            this.listChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avtDifPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.avtCurrentPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pnlContent.Controls.Add(this.pnlContainChessBoard);
            this.pnlContent.Controls.Add(this.pnlChatClientFrame);
            this.pnlContent.Controls.Add(this.txtMessage);
            this.pnlContent.Controls.Add(this.txtCountTime);
            this.pnlContent.Controls.Add(this.btnSendData);
            this.pnlContent.Controls.Add(this.btnOutRoom);
            this.pnlContent.Controls.Add(this.btnSendIcon);
            this.pnlContent.Controls.Add(this.lbDifPlayer);
            this.pnlContent.Controls.Add(this.lbCurrentPlayer);
            this.pnlContent.Controls.Add(this.avtDifPlayer);
            this.pnlContent.Controls.Add(this.avtCurrentPlayer);
            this.pnlContent.Controls.Add(this.label3);
            this.pnlContent.Controls.Add(this.txtTurnUser);
            this.pnlContent.Controls.Add(this.pnlContainPieces);
            this.pnlContent.Location = new System.Drawing.Point(12, 12);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1471, 739);
            this.pnlContent.TabIndex = 1;
            // 
            // pnlContainChessBoard
            // 
            this.pnlContainChessBoard.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pnlContainChessBoard.Location = new System.Drawing.Point(305, 185);
            this.pnlContainChessBoard.Name = "pnlContainChessBoard";
            this.pnlContainChessBoard.Size = new System.Drawing.Size(755, 566);
            this.pnlContainChessBoard.TabIndex = 40;
            // 
            // pnlChatClientFrame
            // 
            this.pnlChatClientFrame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pnlChatClientFrame.Controls.Add(this.listChat);
            this.pnlChatClientFrame.Location = new System.Drawing.Point(1066, 207);
            this.pnlChatClientFrame.Name = "pnlChatClientFrame";
            this.pnlChatClientFrame.Size = new System.Drawing.Size(381, 446);
            this.pnlChatClientFrame.TabIndex = 39;
            // 
            // listChat
            // 
            this.listChat.BackColor = System.Drawing.Color.LightYellow;
            this.listChat.Controls.Add(this.pnlContainsIcon);
            this.listChat.Location = new System.Drawing.Point(0, 0);
            this.listChat.Name = "listChat";
            this.listChat.Size = new System.Drawing.Size(381, 446);
            this.listChat.TabIndex = 0;
            // 
            // pnlContainsIcon
            // 
            this.pnlContainsIcon.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlContainsIcon.Location = new System.Drawing.Point(0, 123);
            this.pnlContainsIcon.Name = "pnlContainsIcon";
            this.pnlContainsIcon.Size = new System.Drawing.Size(381, 323);
            this.pnlContainsIcon.TabIndex = 22;
            // 
            // txtMessage
            // 
            this.txtMessage.BorderColor = System.Drawing.Color.Black;
            this.txtMessage.BorderRadius = 5;
            this.txtMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMessage.DefaultText = "";
            this.txtMessage.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMessage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMessage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMessage.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMessage.FillColor = System.Drawing.Color.LemonChiffon;
            this.txtMessage.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMessage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMessage.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMessage.Location = new System.Drawing.Point(1066, 660);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.PasswordChar = '\0';
            this.txtMessage.PlaceholderText = "";
            this.txtMessage.SelectedText = "";
            this.txtMessage.Size = new System.Drawing.Size(259, 55);
            this.txtMessage.TabIndex = 38;
            // 
            // txtCountTime
            // 
            this.txtCountTime.BorderColor = System.Drawing.Color.DarkSeaGreen;
            this.txtCountTime.BorderRadius = 5;
            this.txtCountTime.BorderThickness = 0;
            this.txtCountTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCountTime.DefaultText = "60";
            this.txtCountTime.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCountTime.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCountTime.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCountTime.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCountTime.FillColor = System.Drawing.Color.DarkSeaGreen;
            this.txtCountTime.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCountTime.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCountTime.ForeColor = System.Drawing.Color.Black;
            this.txtCountTime.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCountTime.Location = new System.Drawing.Point(615, 49);
            this.txtCountTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCountTime.Name = "txtCountTime";
            this.txtCountTime.PasswordChar = '\0';
            this.txtCountTime.PlaceholderForeColor = System.Drawing.Color.DarkSeaGreen;
            this.txtCountTime.PlaceholderText = "";
            this.txtCountTime.SelectedText = "";
            this.txtCountTime.Size = new System.Drawing.Size(178, 48);
            this.txtCountTime.TabIndex = 37;
            this.txtCountTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSendData
            // 
            this.btnSendData.BorderColor = System.Drawing.Color.Red;
            this.btnSendData.BorderRadius = 5;
            this.btnSendData.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSendData.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSendData.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendData.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSendData.FillColor = System.Drawing.Color.Red;
            this.btnSendData.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSendData.ForeColor = System.Drawing.Color.White;
            this.btnSendData.Image = ((System.Drawing.Image)(resources.GetObject("btnSendData.Image")));
            this.btnSendData.Location = new System.Drawing.Point(1386, 660);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(62, 55);
            this.btnSendData.TabIndex = 36;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // btnOutRoom
            // 
            this.btnOutRoom.BorderRadius = 15;
            this.btnOutRoom.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOutRoom.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOutRoom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOutRoom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOutRoom.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnOutRoom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnOutRoom.ForeColor = System.Drawing.Color.Black;
            this.btnOutRoom.Location = new System.Drawing.Point(1281, 29);
            this.btnOutRoom.Name = "btnOutRoom";
            this.btnOutRoom.Size = new System.Drawing.Size(166, 56);
            this.btnOutRoom.TabIndex = 34;
            this.btnOutRoom.Text = "Thoát phòng";
            this.btnOutRoom.Click += new System.EventHandler(this.btnOutRoom_Click);
            // 
            // btnSendIcon
            // 
            this.btnSendIcon.BorderRadius = 5;
            this.btnSendIcon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSendIcon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSendIcon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendIcon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSendIcon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSendIcon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSendIcon.ForeColor = System.Drawing.Color.White;
            this.btnSendIcon.Image = ((System.Drawing.Image)(resources.GetObject("btnSendIcon.Image")));
            this.btnSendIcon.Location = new System.Drawing.Point(1325, 660);
            this.btnSendIcon.Name = "btnSendIcon";
            this.btnSendIcon.Size = new System.Drawing.Size(61, 55);
            this.btnSendIcon.TabIndex = 35;
            this.btnSendIcon.Click += new System.EventHandler(this.btnSendIcon_Click);
            // 
            // lbDifPlayer
            // 
            this.lbDifPlayer.AutoSize = true;
            this.lbDifPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDifPlayer.Location = new System.Drawing.Point(910, 10);
            this.lbDifPlayer.Name = "lbDifPlayer";
            this.lbDifPlayer.Size = new System.Drawing.Size(0, 20);
            this.lbDifPlayer.TabIndex = 29;
            this.lbDifPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCurrentPlayer
            // 
            this.lbCurrentPlayer.AutoSize = true;
            this.lbCurrentPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.lbCurrentPlayer.Location = new System.Drawing.Point(386, 11);
            this.lbCurrentPlayer.Name = "lbCurrentPlayer";
            this.lbCurrentPlayer.Size = new System.Drawing.Size(0, 20);
            this.lbCurrentPlayer.TabIndex = 28;
            this.lbCurrentPlayer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // avtDifPlayer
            // 
            this.avtDifPlayer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.avtDifPlayer.Location = new System.Drawing.Point(905, 34);
            this.avtDifPlayer.Name = "avtDifPlayer";
            this.avtDifPlayer.Size = new System.Drawing.Size(85, 71);
            this.avtDifPlayer.TabIndex = 27;
            this.avtDifPlayer.TabStop = false;
            // 
            // avtCurrentPlayer
            // 
            this.avtCurrentPlayer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.avtCurrentPlayer.Location = new System.Drawing.Point(379, 34);
            this.avtCurrentPlayer.Name = "avtCurrentPlayer";
            this.avtCurrentPlayer.Size = new System.Drawing.Size(85, 71);
            this.avtCurrentPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.avtCurrentPlayer.TabIndex = 26;
            this.avtCurrentPlayer.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(82, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 38);
            this.label3.TabIndex = 24;
            this.label3.Text = "Lượt của";
            // 
            // txtTurnUser
            // 
            this.txtTurnUser.BackColor = System.Drawing.Color.White;
            this.txtTurnUser.Enabled = false;
            this.txtTurnUser.Location = new System.Drawing.Point(79, 59);
            this.txtTurnUser.Multiline = true;
            this.txtTurnUser.Name = "txtTurnUser";
            this.txtTurnUser.Size = new System.Drawing.Size(141, 94);
            this.txtTurnUser.TabIndex = 23;
            // 
            // pnlContainPieces
            // 
            this.pnlContainPieces.BackColor = System.Drawing.Color.LightYellow;
            this.pnlContainPieces.Location = new System.Drawing.Point(3, 207);
            this.pnlContainPieces.Name = "pnlContainPieces";
            this.pnlContainPieces.Size = new System.Drawing.Size(296, 508);
            this.pnlContainPieces.TabIndex = 17;
            // 
            // MatchInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1486, 751);
            this.Controls.Add(this.pnlContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MatchInterface";
            this.Text = "MatchInterface";
            this.Load += new System.EventHandler(this.MatchInterface_Load);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlChatClientFrame.ResumeLayout(false);
            this.listChat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.avtDifPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.avtCurrentPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lbDifPlayer;
        private System.Windows.Forms.Label lbCurrentPlayer;
        private System.Windows.Forms.PictureBox avtDifPlayer;
        private System.Windows.Forms.PictureBox avtCurrentPlayer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTurnUser;
        private System.Windows.Forms.Panel pnlContainPieces;
        private Guna.UI2.WinForms.Guna2Button btnOutRoom;
        private Guna.UI2.WinForms.Guna2TextBox txtCountTime;
        private Guna.UI2.WinForms.Guna2Button btnSendData;
        private Guna.UI2.WinForms.Guna2Button btnSendIcon;
        private Guna.UI2.WinForms.Guna2TextBox txtMessage;
        private Guna.UI2.WinForms.Guna2Panel pnlChatClientFrame;
        private Guna.UI2.WinForms.Guna2Panel listChat;
        private Panel pnlContainsIcon;
        private Panel pnlContainChessBoard;
    }
}