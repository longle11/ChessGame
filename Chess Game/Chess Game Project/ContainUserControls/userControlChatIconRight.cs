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
    public partial class userControlChatIconRight : UserControl
    {
        public userControlChatIconRight()
        {
            InitializeComponent();
        }
        public void addUsernameAndImage(string linkAvt, string username, System.Drawing.Image img, userControlChatOne chat)
        {
            ptbAvatar.Image = Image.FromFile(linkAvt);
            ptbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbIcon.Image = img;
            ptbIcon.SizeMode = PictureBoxSizeMode.Zoom;
            lbUserName.Text = username;
            
            if(chat != null)
            {
                this.Width += 100;
                ptbAvatar.Size = new Size(38, 35);
                ptbIcon.Size = new Size(53, 49);
                ptbIcon.Location = new Point(ptbIcon.Location.X + 40, ptbIcon.Location.Y);
                ptbAvatar.Location = new Point(ptbAvatar.Location.X + 60, ptbAvatar.Location.Y);
                lbUserName.Location = new Point(lbUserName.Location.X + 60, lbUserName.Location.Y);
            }
            else
            {
                lbUserName.Location = new Point(lbUserName.Location.X + 20, lbUserName.Location.Y);
                ptbAvatar.Location = new Point(ptbAvatar.Location.X + 15, ptbAvatar.Location.Y);
                ptbIcon.Location = new Point(ptbIcon.Location.X + 15, ptbIcon.Location.Y);
            }
        }
    }
}
