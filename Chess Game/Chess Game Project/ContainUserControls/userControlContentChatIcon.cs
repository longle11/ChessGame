using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Chess_Game_Project.ContainUserControls
{
    public partial class userControlContentChatIcon : UserControl
    {
        public userControlContentChatIcon()
        {
            InitializeComponent();
        }
        public void addUsernameAndImage(string linkAvt, string username, System.Drawing.Image img, userControlChatOne chat)
        {
            ptvAvatar.Image = System.Drawing.Image.FromFile(linkAvt);
            ptvAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbIcon.Image = img;
            ptbIcon.SizeMode = PictureBoxSizeMode.Zoom;
            lbUserName.Text = username;
            lbUserName.AutoSize = true;

            if (chat != null)
            {
                this.Width += 100;
                ptvAvatar.Size = new Size(38, 35);
                ptbIcon.Size = new Size(53, 49);
                ptbIcon.Location = new Point(ptbIcon.Location.X + 10, ptbIcon.Location.Y);
            }
        }
    }
}
