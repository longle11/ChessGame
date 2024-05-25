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
    public partial class userControlCreateRoom : UserControl
    {
        public userControlCreateRoom()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> btnCloseCreateRoom_click;
        public event EventHandler<EventArgs> btnAcceptCreateRoom_click;

        public string betpoint
        {
            get
            {
                return txtBetPoints.Text;
            }
        }
        public string name
        {
            get
            {
                return txtRoomName.Text;
            }
        }
        private void btnCloseCreateRoom_Click(object sender, EventArgs e)
        {
            btnCloseCreateRoom_click?.Invoke(this, e);
        }
        private void btnAcceptCreateRoom_Click(object sender, EventArgs e)
        {
            btnAcceptCreateRoom_click?.Invoke(this, e);
        }
    }
}
