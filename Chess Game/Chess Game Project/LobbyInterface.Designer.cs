namespace Chess_Game_Project
{
    partial class LobbyInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LobbyInterface));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlCoverPage = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtScore = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnRefreshListMatches = new Guna.UI2.WinForms.Guna2Button();
            this.btnListAllUsers = new Guna.UI2.WinForms.Guna2Button();
            this.btnAcceptFriend = new Guna.UI2.WinForms.Guna2Button();
            this.txtSendMessage = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSendMessage = new Guna.UI2.WinForms.Guna2Button();
            this.btnSendIcon = new Guna.UI2.WinForms.Guna2Button();
            this.pnlMultiChats = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlMultiChatFrame = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlContainsIcon = new System.Windows.Forms.Panel();
            this.pnlContainsChild = new System.Windows.Forms.Panel();
            this.pnlChatOne = new System.Windows.Forms.Panel();
            this.dtGridContainListRooms = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnRandomRoom = new Guna.UI2.WinForms.Guna2Button();
            this.btnCreateRoom = new Guna.UI2.WinForms.Guna2Button();
            this.btnHistory = new Guna.UI2.WinForms.Guna2Button();
            this.btnRank = new Guna.UI2.WinForms.Guna2Button();
            this.btnListFriend = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.btnContainInfoUser = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ptboxAvatar = new System.Windows.Forms.PictureBox();
            this.ptbAvatarPage = new System.Windows.Forms.PictureBox();
            this.userControlChatOne1 = new Chess_Game_Project.ContainUserControls.userControlChatOne();
            this.userControlChatOne2 = new Chess_Game_Project.ContainUserControls.userControlChatOne();
            this.userControlChatOne3 = new Chess_Game_Project.ContainUserControls.userControlChatOne();
            this.userControlChatOne4 = new Chess_Game_Project.ContainUserControls.userControlChatOne();
            this.pnlCoverPage.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlMultiChats.SuspendLayout();
            this.pnlMultiChatFrame.SuspendLayout();
            this.pnlContainsChild.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridContainListRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptboxAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatarPage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCoverPage
            // 
            this.pnlCoverPage.BackColor = System.Drawing.Color.LightCoral;
            this.pnlCoverPage.Controls.Add(this.pnlContent);
            this.pnlCoverPage.Controls.Add(this.ptbAvatarPage);
            this.pnlCoverPage.Location = new System.Drawing.Point(0, -3);
            this.pnlCoverPage.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCoverPage.Name = "pnlCoverPage";
            this.pnlCoverPage.Size = new System.Drawing.Size(1447, 751);
            this.pnlCoverPage.TabIndex = 1;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.OldLace;
            this.pnlContent.Controls.Add(this.label1);
            this.pnlContent.Controls.Add(this.txtScore);
            this.pnlContent.Controls.Add(this.txtUserName);
            this.pnlContent.Controls.Add(this.btnRefreshListMatches);
            this.pnlContent.Controls.Add(this.btnListAllUsers);
            this.pnlContent.Controls.Add(this.btnAcceptFriend);
            this.pnlContent.Controls.Add(this.txtSendMessage);
            this.pnlContent.Controls.Add(this.btnSendMessage);
            this.pnlContent.Controls.Add(this.btnSendIcon);
            this.pnlContent.Controls.Add(this.pnlMultiChats);
            this.pnlContent.Controls.Add(this.pnlContainsChild);
            this.pnlContent.Controls.Add(this.dtGridContainListRooms);
            this.pnlContent.Controls.Add(this.btnRandomRoom);
            this.pnlContent.Controls.Add(this.btnCreateRoom);
            this.pnlContent.Controls.Add(this.btnHistory);
            this.pnlContent.Controls.Add(this.btnRank);
            this.pnlContent.Controls.Add(this.btnListFriend);
            this.pnlContent.Controls.Add(this.btnLogout);
            this.pnlContent.Controls.Add(this.btnContainInfoUser);
            this.pnlContent.Controls.Add(this.label2);
            this.pnlContent.Controls.Add(this.ptboxAvatar);
            this.pnlContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.pnlContent.Location = new System.Drawing.Point(83, 2);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1349, 763);
            this.pnlContent.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(514, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 22);
            this.label1.TabIndex = 95;
            this.label1.Text = "Người chơi";
            // 
            // txtScore
            // 
            this.txtScore.BorderRadius = 10;
            this.txtScore.BorderThickness = 3;
            this.txtScore.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtScore.DefaultText = "";
            this.txtScore.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtScore.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtScore.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtScore.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtScore.FillColor = System.Drawing.Color.OldLace;
            this.txtScore.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtScore.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.txtScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtScore.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtScore.Location = new System.Drawing.Point(666, 31);
            this.txtScore.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtScore.Name = "txtScore";
            this.txtScore.PasswordChar = '\0';
            this.txtScore.PlaceholderText = "";
            this.txtScore.ReadOnly = true;
            this.txtScore.SelectedText = "";
            this.txtScore.Size = new System.Drawing.Size(79, 47);
            this.txtScore.TabIndex = 93;
            this.txtScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUserName
            // 
            this.txtUserName.BorderRadius = 10;
            this.txtUserName.BorderThickness = 3;
            this.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserName.DefaultText = "";
            this.txtUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserName.FillColor = System.Drawing.Color.OldLace;
            this.txtUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserName.Location = new System.Drawing.Point(467, 31);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PasswordChar = '\0';
            this.txtUserName.PlaceholderText = "";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.SelectedText = "";
            this.txtUserName.Size = new System.Drawing.Size(191, 47);
            this.txtUserName.TabIndex = 92;
            this.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnRefreshListMatches
            // 
            this.btnRefreshListMatches.BackColor = System.Drawing.Color.Transparent;
            this.btnRefreshListMatches.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefreshListMatches.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRefreshListMatches.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRefreshListMatches.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRefreshListMatches.FillColor = System.Drawing.Color.Transparent;
            this.btnRefreshListMatches.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefreshListMatches.ForeColor = System.Drawing.Color.White;
            this.btnRefreshListMatches.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshListMatches.Image")));
            this.btnRefreshListMatches.Location = new System.Drawing.Point(467, 270);
            this.btnRefreshListMatches.Name = "btnRefreshListMatches";
            this.btnRefreshListMatches.Size = new System.Drawing.Size(31, 24);
            this.btnRefreshListMatches.TabIndex = 91;
            this.btnRefreshListMatches.Click += new System.EventHandler(this.btnRefreshListMatches_Click);
            // 
            // btnListAllUsers
            // 
            this.btnListAllUsers.Animated = true;
            this.btnListAllUsers.AutoRoundedCorners = true;
            this.btnListAllUsers.BorderRadius = 24;
            this.btnListAllUsers.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnListAllUsers.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnListAllUsers.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnListAllUsers.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnListAllUsers.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(121)))), ((int)(((byte)(94)))));
            this.btnListAllUsers.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnListAllUsers.ForeColor = System.Drawing.Color.White;
            this.btnListAllUsers.Location = new System.Drawing.Point(780, 227);
            this.btnListAllUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnListAllUsers.Name = "btnListAllUsers";
            this.btnListAllUsers.Size = new System.Drawing.Size(180, 50);
            this.btnListAllUsers.TabIndex = 90;
            this.btnListAllUsers.Text = "Danh sách người chơi";
            this.btnListAllUsers.Click += new System.EventHandler(this.btnListAllUsers_Click);
            // 
            // btnAcceptFriend
            // 
            this.btnAcceptFriend.Animated = true;
            this.btnAcceptFriend.AutoRoundedCorners = true;
            this.btnAcceptFriend.BorderRadius = 24;
            this.btnAcceptFriend.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAcceptFriend.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAcceptFriend.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAcceptFriend.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAcceptFriend.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(121)))), ((int)(((byte)(94)))));
            this.btnAcceptFriend.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnAcceptFriend.ForeColor = System.Drawing.Color.White;
            this.btnAcceptFriend.Location = new System.Drawing.Point(1152, 227);
            this.btnAcceptFriend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAcceptFriend.Name = "btnAcceptFriend";
            this.btnAcceptFriend.Size = new System.Drawing.Size(180, 50);
            this.btnAcceptFriend.TabIndex = 89;
            this.btnAcceptFriend.Text = "Lời mời kết bạn";
            this.btnAcceptFriend.Click += new System.EventHandler(this.btnAcceptFriend_Click);
            // 
            // txtSendMessage
            // 
            this.txtSendMessage.BorderColor = System.Drawing.Color.Black;
            this.txtSendMessage.BorderRadius = 10;
            this.txtSendMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSendMessage.DefaultText = "";
            this.txtSendMessage.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSendMessage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSendMessage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSendMessage.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSendMessage.FillColor = System.Drawing.Color.LemonChiffon;
            this.txtSendMessage.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSendMessage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSendMessage.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSendMessage.Location = new System.Drawing.Point(19, 700);
            this.txtSendMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSendMessage.Name = "txtSendMessage";
            this.txtSendMessage.PasswordChar = '\0';
            this.txtSendMessage.PlaceholderText = "";
            this.txtSendMessage.SelectedText = "";
            this.txtSendMessage.Size = new System.Drawing.Size(284, 53);
            this.txtSendMessage.TabIndex = 85;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.BorderColor = System.Drawing.Color.Red;
            this.btnSendMessage.BorderRadius = 10;
            this.btnSendMessage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSendMessage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSendMessage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendMessage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSendMessage.FillColor = System.Drawing.Color.Plum;
            this.btnSendMessage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSendMessage.ForeColor = System.Drawing.Color.White;
            this.btnSendMessage.Image = ((System.Drawing.Image)(resources.GetObject("btnSendMessage.Image")));
            this.btnSendMessage.Location = new System.Drawing.Point(382, 698);
            this.btnSendMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(71, 57);
            this.btnSendMessage.TabIndex = 84;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // btnSendIcon
            // 
            this.btnSendIcon.BorderRadius = 10;
            this.btnSendIcon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSendIcon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSendIcon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendIcon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSendIcon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSendIcon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSendIcon.ForeColor = System.Drawing.Color.White;
            this.btnSendIcon.Image = ((System.Drawing.Image)(resources.GetObject("btnSendIcon.Image")));
            this.btnSendIcon.Location = new System.Drawing.Point(309, 700);
            this.btnSendIcon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSendIcon.Name = "btnSendIcon";
            this.btnSendIcon.Size = new System.Drawing.Size(67, 55);
            this.btnSendIcon.TabIndex = 83;
            this.btnSendIcon.Click += new System.EventHandler(this.btnSendIcon_Click);
            // 
            // pnlMultiChats
            // 
            this.pnlMultiChats.BackColor = System.Drawing.Color.NavajoWhite;
            this.pnlMultiChats.Controls.Add(this.pnlMultiChatFrame);
            this.pnlMultiChats.Location = new System.Drawing.Point(19, 214);
            this.pnlMultiChats.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMultiChats.Name = "pnlMultiChats";
            this.pnlMultiChats.Size = new System.Drawing.Size(434, 478);
            this.pnlMultiChats.TabIndex = 88;
            // 
            // pnlMultiChatFrame
            // 
            this.pnlMultiChatFrame.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlMultiChatFrame.Controls.Add(this.pnlContainsIcon);
            this.pnlMultiChatFrame.Location = new System.Drawing.Point(0, 0);
            this.pnlMultiChatFrame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMultiChatFrame.Name = "pnlMultiChatFrame";
            this.pnlMultiChatFrame.Size = new System.Drawing.Size(434, 478);
            this.pnlMultiChatFrame.TabIndex = 72;
            // 
            // pnlContainsIcon
            // 
            this.pnlContainsIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlContainsIcon.Location = new System.Drawing.Point(0, 194);
            this.pnlContainsIcon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlContainsIcon.Name = "pnlContainsIcon";
            this.pnlContainsIcon.Size = new System.Drawing.Size(434, 284);
            this.pnlContainsIcon.TabIndex = 65;
            // 
            // pnlContainsChild
            // 
            this.pnlContainsChild.AutoSize = true;
            this.pnlContainsChild.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnlContainsChild.Controls.Add(this.pnlChatOne);
            this.pnlContainsChild.Location = new System.Drawing.Point(288, 757);
            this.pnlContainsChild.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlContainsChild.Name = "pnlContainsChild";
            this.pnlContainsChild.Size = new System.Drawing.Size(1346, 642);
            this.pnlContainsChild.TabIndex = 70;
            // 
            // pnlChatOne
            // 
            this.pnlChatOne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pnlChatOne.Location = new System.Drawing.Point(179, 16);
            this.pnlChatOne.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlChatOne.Name = "pnlChatOne";
            this.pnlChatOne.Size = new System.Drawing.Size(803, 570);
            this.pnlChatOne.TabIndex = 6;
            // 
            // dtGridContainListRooms
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dtGridContainListRooms.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGridContainListRooms.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtGridContainListRooms.ColumnHeadersHeight = 35;
            this.dtGridContainListRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGridContainListRooms.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtGridContainListRooms.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtGridContainListRooms.Location = new System.Drawing.Point(467, 299);
            this.dtGridContainListRooms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtGridContainListRooms.Name = "dtGridContainListRooms";
            this.dtGridContainListRooms.RowHeadersVisible = false;
            this.dtGridContainListRooms.RowHeadersWidth = 51;
            this.dtGridContainListRooms.RowTemplate.Height = 24;
            this.dtGridContainListRooms.Size = new System.Drawing.Size(865, 393);
            this.dtGridContainListRooms.TabIndex = 87;
            this.dtGridContainListRooms.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtGridContainListRooms.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtGridContainListRooms.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtGridContainListRooms.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtGridContainListRooms.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtGridContainListRooms.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtGridContainListRooms.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtGridContainListRooms.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtGridContainListRooms.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtGridContainListRooms.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtGridContainListRooms.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtGridContainListRooms.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtGridContainListRooms.ThemeStyle.HeaderStyle.Height = 35;
            this.dtGridContainListRooms.ThemeStyle.ReadOnly = false;
            this.dtGridContainListRooms.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtGridContainListRooms.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtGridContainListRooms.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtGridContainListRooms.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtGridContainListRooms.ThemeStyle.RowsStyle.Height = 24;
            this.dtGridContainListRooms.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtGridContainListRooms.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtGridContainListRooms.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridContainListRooms_CellContentClick);
            // 
            // btnRandomRoom
            // 
            this.btnRandomRoom.BorderRadius = 15;
            this.btnRandomRoom.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRandomRoom.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRandomRoom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRandomRoom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRandomRoom.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(121)))), ((int)(((byte)(94)))));
            this.btnRandomRoom.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandomRoom.ForeColor = System.Drawing.Color.White;
            this.btnRandomRoom.Location = new System.Drawing.Point(991, 698);
            this.btnRandomRoom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRandomRoom.Name = "btnRandomRoom";
            this.btnRandomRoom.Size = new System.Drawing.Size(155, 57);
            this.btnRandomRoom.TabIndex = 82;
            this.btnRandomRoom.Text = "Ngẫu nhiên";
            this.btnRandomRoom.Click += new System.EventHandler(this.btnRandomRoom_Click);
            // 
            // btnCreateRoom
            // 
            this.btnCreateRoom.BorderRadius = 15;
            this.btnCreateRoom.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCreateRoom.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCreateRoom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCreateRoom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCreateRoom.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(121)))), ((int)(((byte)(94)))));
            this.btnCreateRoom.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateRoom.ForeColor = System.Drawing.Color.White;
            this.btnCreateRoom.Location = new System.Drawing.Point(1177, 698);
            this.btnCreateRoom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCreateRoom.Name = "btnCreateRoom";
            this.btnCreateRoom.Size = new System.Drawing.Size(155, 57);
            this.btnCreateRoom.TabIndex = 81;
            this.btnCreateRoom.Text = "Tạo phòng";
            this.btnCreateRoom.Click += new System.EventHandler(this.btnCreateRoom_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Animated = true;
            this.btnHistory.AutoRoundedCorners = true;
            this.btnHistory.BorderRadius = 26;
            this.btnHistory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHistory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHistory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHistory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHistory.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(121)))), ((int)(((byte)(94)))));
            this.btnHistory.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnHistory.ForeColor = System.Drawing.Color.White;
            this.btnHistory.Location = new System.Drawing.Point(19, 143);
            this.btnHistory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(172, 54);
            this.btnHistory.TabIndex = 80;
            this.btnHistory.Text = "Lịch sử đấu";
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnRank
            // 
            this.btnRank.Animated = true;
            this.btnRank.AutoRoundedCorners = true;
            this.btnRank.BorderRadius = 24;
            this.btnRank.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRank.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRank.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRank.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRank.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(121)))), ((int)(((byte)(94)))));
            this.btnRank.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnRank.ForeColor = System.Drawing.Color.White;
            this.btnRank.Location = new System.Drawing.Point(209, 147);
            this.btnRank.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRank.Name = "btnRank";
            this.btnRank.Size = new System.Drawing.Size(167, 50);
            this.btnRank.TabIndex = 79;
            this.btnRank.Text = "Bảng xếp hạng";
            this.btnRank.Click += new System.EventHandler(this.btnRank_Click);
            // 
            // btnListFriend
            // 
            this.btnListFriend.Animated = true;
            this.btnListFriend.AutoRoundedCorners = true;
            this.btnListFriend.BorderRadius = 24;
            this.btnListFriend.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnListFriend.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnListFriend.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnListFriend.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnListFriend.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(121)))), ((int)(((byte)(94)))));
            this.btnListFriend.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnListFriend.ForeColor = System.Drawing.Color.White;
            this.btnListFriend.Location = new System.Drawing.Point(966, 227);
            this.btnListFriend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnListFriend.Name = "btnListFriend";
            this.btnListFriend.Size = new System.Drawing.Size(180, 50);
            this.btnListFriend.TabIndex = 78;
            this.btnListFriend.Text = "Danh sách bạn bè";
            this.btnListFriend.Click += new System.EventHandler(this.btnListFriend_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Animated = true;
            this.btnLogout.AutoRoundedCorners = true;
            this.btnLogout.BorderRadius = 24;
            this.btnLogout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(121)))), ((int)(((byte)(94)))));
            this.btnLogout.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1152, 16);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(180, 50);
            this.btnLogout.TabIndex = 77;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnContainInfoUser
            // 
            this.btnContainInfoUser.Animated = true;
            this.btnContainInfoUser.AutoRoundedCorners = true;
            this.btnContainInfoUser.BorderRadius = 24;
            this.btnContainInfoUser.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnContainInfoUser.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnContainInfoUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnContainInfoUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnContainInfoUser.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(121)))), ((int)(((byte)(94)))));
            this.btnContainInfoUser.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnContainInfoUser.ForeColor = System.Drawing.Color.White;
            this.btnContainInfoUser.Location = new System.Drawing.Point(957, 16);
            this.btnContainInfoUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnContainInfoUser.Name = "btnContainInfoUser";
            this.btnContainInfoUser.Size = new System.Drawing.Size(180, 50);
            this.btnContainInfoUser.TabIndex = 76;
            this.btnContainInfoUser.Text = "Thông tin";
            this.btnContainInfoUser.Click += new System.EventHandler(this.btnContainInfoUser_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Indigo;
            this.label2.Location = new System.Drawing.Point(678, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 22);
            this.label2.TabIndex = 63;
            this.label2.Text = "Điểm";
            // 
            // ptboxAvatar
            // 
            this.ptboxAvatar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ptboxAvatar.Location = new System.Drawing.Point(34, 16);
            this.ptboxAvatar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ptboxAvatar.Name = "ptboxAvatar";
            this.ptboxAvatar.Size = new System.Drawing.Size(157, 123);
            this.ptboxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptboxAvatar.TabIndex = 50;
            this.ptboxAvatar.TabStop = false;
            // 
            // ptbAvatarPage
            // 
            this.ptbAvatarPage.BackColor = System.Drawing.Color.Sienna;
            this.ptbAvatarPage.Location = new System.Drawing.Point(0, 2);
            this.ptbAvatarPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ptbAvatarPage.Name = "ptbAvatarPage";
            this.ptbAvatarPage.Size = new System.Drawing.Size(1121, 656);
            this.ptbAvatarPage.TabIndex = 0;
            this.ptbAvatarPage.TabStop = false;
            // 
            // userControlChatOne1
            // 
            this.userControlChatOne1.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.userControlChatOne1.Location = new System.Drawing.Point(0, 0);
            this.userControlChatOne1.Name = "userControlChatOne1";
            this.userControlChatOne1.pos = 0;
            this.userControlChatOne1.Size = new System.Drawing.Size(598, 442);
            this.userControlChatOne1.TabIndex = 0;
            // 
            // userControlChatOne2
            // 
            this.userControlChatOne2.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.userControlChatOne2.Location = new System.Drawing.Point(0, 0);
            this.userControlChatOne2.Name = "userControlChatOne2";
            this.userControlChatOne2.pos = 0;
            this.userControlChatOne2.Size = new System.Drawing.Size(598, 442);
            this.userControlChatOne2.TabIndex = 0;
            // 
            // userControlChatOne3
            // 
            this.userControlChatOne3.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.userControlChatOne3.Location = new System.Drawing.Point(0, 0);
            this.userControlChatOne3.Name = "userControlChatOne3";
            this.userControlChatOne3.pos = 0;
            this.userControlChatOne3.Size = new System.Drawing.Size(598, 442);
            this.userControlChatOne3.TabIndex = 0;
            // 
            // userControlChatOne4
            // 
            this.userControlChatOne4.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.userControlChatOne4.Location = new System.Drawing.Point(0, 0);
            this.userControlChatOne4.Name = "userControlChatOne4";
            this.userControlChatOne4.pos = 0;
            this.userControlChatOne4.Size = new System.Drawing.Size(598, 442);
            this.userControlChatOne4.TabIndex = 0;
            // 
            // LobbyInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1444, 770);
            this.Controls.Add(this.pnlCoverPage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LobbyInterface";
            this.Text = "LobbyInterface";
            this.Load += new System.EventHandler(this.LobbyInterface_Load);
            this.pnlCoverPage.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlMultiChats.ResumeLayout(false);
            this.pnlMultiChatFrame.ResumeLayout(false);
            this.pnlContainsChild.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridContainListRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptboxAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatarPage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCoverPage;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox ptboxAvatar;
        private System.Windows.Forms.PictureBox ptbAvatarPage;
        private System.Windows.Forms.Panel pnlContainsChild;
        private Guna.UI2.WinForms.Guna2Button btnRank;
        private Guna.UI2.WinForms.Guna2Button btnListFriend;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2Button btnContainInfoUser;
        private Guna.UI2.WinForms.Guna2Button btnHistory;
        private Guna.UI2.WinForms.Guna2Button btnRandomRoom;
        private Guna.UI2.WinForms.Guna2Button btnCreateRoom;
        private Guna.UI2.WinForms.Guna2DataGridView dtGridContainListRooms;
        private Guna.UI2.WinForms.Guna2Panel pnlMultiChats;
        private Guna.UI2.WinForms.Guna2Panel pnlMultiChatFrame;
        private System.Windows.Forms.Panel pnlContainsIcon;
        private System.Windows.Forms.Panel pnlChatOne;
        private Guna.UI2.WinForms.Guna2TextBox txtSendMessage;
        private Guna.UI2.WinForms.Guna2Button btnSendMessage;
        private Guna.UI2.WinForms.Guna2Button btnSendIcon;
        private Guna.UI2.WinForms.Guna2Button btnRefreshListMatches;
        private Guna.UI2.WinForms.Guna2Button btnListAllUsers;
        private Guna.UI2.WinForms.Guna2Button btnAcceptFriend;
        private Guna.UI2.WinForms.Guna2TextBox txtScore;
        private Guna.UI2.WinForms.Guna2TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private ContainUserControls.userControlChatOne userControlChatOne1;
        private ContainUserControls.userControlChatOne userControlChatOne2;
        private ContainUserControls.userControlChatOne userControlChatOne3;
        private ContainUserControls.userControlChatOne userControlChatOne4;
    }
}