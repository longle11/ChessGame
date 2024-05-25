using Chess_Game_Project.classes;
using Chess_Game_Project.classes_handle;
using Chess_Game_Project.ContainUserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Game_Project.manageUsers
{
    internal class createChatOneFrame
    {
        public static List<userControlChatOne> listChats = new List<userControlChatOne>();

        public static async Task createChatBetweenClientAndClient(string apiGetUserId, infoUser user, userControlChatOne chat)
        {
            //thêm tập hợp các bạn bè vào để chat
            List<string> listFriends = await handleGetLists.getListFriends(apiGetUserId, user);
            foreach (string userName in listFriends)
            {
                bool check = false;
                if (userName != user.userName)
                {
                    for (int index = 0; index < listChats.Count; index++)
                    {
                        if (listChats[index].Tag.ToString().Contains(user.userName) && listChats[index].Tag.ToString().Contains(userName))
                        {
                            check = true;
                            break;
                        }
                    }
                    if (!check)
                    {
                        chat = new userControlChatOne();
                        chat.Hide();
                        chat.Tag = $"{user.userName},{userName}";
                        chat.Dock = DockStyle.Bottom;
                        listChats.Add(chat);
                    }
                }
                check = false;
            }
            chat = null;
        }
        public static event EventHandler<EventArgs> chat_btnCloseForm_click;
        public static event EventHandler<EventArgs> chat_btnSendIconChatOne_click;
        public static event EventHandler<EventArgs> chat_btnSendMsgChatOne_click;
        public static void Chat_btnCloseForm_click(object sender, EventArgs e)
        {
            chat_btnCloseForm_click?.Invoke(sender, e);
        }

        public static void Chat_btnSendIconChatOne_click(object sender, EventArgs e)
        {
            chat_btnSendIconChatOne_click?.Invoke(sender, e);
        }

        public static void Chat_btnSendMsgChatOne_click(object sender, EventArgs e)
        {
            chat_btnSendMsgChatOne_click?.Invoke(sender, e);
        }
    }
}
