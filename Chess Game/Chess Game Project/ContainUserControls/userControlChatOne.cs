using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Game_Project.ContainUserControls
{
    public partial class userControlChatOne : UserControl
    {
        //userControlChatOne, userControlContentChatIcon, userControlContentChatMessage, userControlHistory, userControlRanks
        public userControlChatOne()
        {
            InitializeComponent();
            pnlContainIconsChatOne.Hide();

            pnlContentChatOne.Parent = pnlChatOneFrame;
            pnlContainIconsChatOne.Parent = pnlChatOneFrame;
            pnlContainIconsChatOne.BringToFront();
        }
        int posY = 0;
        public int pos
        {
            get
            {
                return posY;
            }
            set
            {
                posY = value;
            }
        }
        public bool eventActive = false;
        List<Button> buttonListIcons = new List<Button>();
        public Guna2TextBox TextBox
        {
            get { return txtSendMsgChatOne; }
        }
        public Guna2Panel pnlChatOne
        {
            get { return pnlContentChatOne; }
        }
        public Panel containsIcon
        {
            get { return pnlContainIconsChatOne; }
        }
        public List<Button> listIcons
        {
            get { return buttonListIcons; }
            set { buttonListIcons = value; }
        }
        public event EventHandler<EventArgs> btnCloseForm_click;
        public event EventHandler<EventArgs> btnSendIconChatOne_click;
        public event EventHandler<EventArgs> btnSendMsgChatOne_click;
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            btnCloseForm_click?.Invoke(this, e);
        }

        private void btnSendIconChatOne_Click(object sender, EventArgs e)
        {
            btnSendIconChatOne_click?.Invoke(this, e);
        }

        private void btnSendMsgChatOne_Click(object sender, EventArgs e)
        {
            btnSendMsgChatOne_click?.Invoke(this, e);
        }
    }
}