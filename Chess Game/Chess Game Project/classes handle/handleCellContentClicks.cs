using Chess_Game_Project.classes;
using Chess_Game_Project.ContainUserControls;
using Chess_Game_Project.manageUsers;
using Guna.UI2.WinForms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Game_Project.classes_handle
{
    internal class handleCellContentClicks
    {
        public async static Task cellClickContent_AcceptFriend(DataGridView sender, infoUser user, DataGridViewCellEventArgs e, string apiUpdaStatusFriend, TcpClient client, string apiGetUserId, userControlLists lists, userControlChatOne chat)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridView dataGridView = sender;
                    if (e.ColumnIndex == 2) // chấp nhận lời mời
                    {

                        //chấp nhận lời mời kết bạn nghĩa là kiếm trong danh sách bạn bè của mình 
                        List<listFriends> listFriends = user.lists;
                        string id1 = user.id;
                        string id2 = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();

                        string idPairOfFriends = "";
                        //Chấp nhận lời mời kêt bạn
                        if(user.lists != null)
                        {
                            foreach (listFriends item in user.lists)
                            {
                                if (item.listID.Contains(id1) && item.listID.Contains(id2))
                                {
                                    idPairOfFriends = item._id;
                                    break;
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(idPairOfFriends))
                        {
                            string apiPath = apiUpdaStatusFriend + idPairOfFriends;
                            var data = new { };
                            JToken tkData = await manageApi.callApiUsingMethodPut(data, apiPath);
                            if (tkData != null)
                            {
                                string difUser = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                                string difUserId = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                                string message = (int)manageChooseCases.setting.acceptFriend + "*" + difUser + "+" + user.id + "+" + user.userName;
                                handleChat.sendData(client, message);
                                //xóa dòng đó khỏi dữ liệu
                                dataGridView.Rows.RemoveAt(e.RowIndex);
                                //tiến hành cập nhật lại thông tin bên trong user

                                listFriends temp = null;
                                foreach (listFriends item in user.lists)
                                {
                                    if (item.listID.Contains(user.id) && item.listID.Contains(difUserId))
                                    {
                                        temp = item;
                                        break;
                                    }
                                }
                                if (temp != null)
                                {
                                    user.lists.Remove(temp);
                                    temp.status = "friend";
                                    user.lists.Add(temp);
                                }

                                //cập nhật lại danh sách bạn bè
                                List<infoUser> getFriends = await handleGetLists.getListUser("friend", user, apiGetUserId);
                                hanleDataIntoDatagridview.displayListFriends(getFriends, lists);

                                await createChatOneFrame.createChatBetweenClientAndClient(apiGetUserId, user, chat);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async static Task cellClickContent_AllUsers(DataGridView sender, infoUser user, DataGridViewCellEventArgs e, string apiGetUserId, Form form, TcpClient client, string apiMakeFriend)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridView dataGridView = (DataGridView)sender;
                    if (e.ColumnIndex == 2) //xem thông tin người chơi
                    {
                        string apiPath = apiGetUserId + dataGridView.Rows[e.RowIndex].Cells["id"].Value.ToString();
                        JToken tkData = await manageApi.callApiUsingGetMethodID(apiPath);
                        if (tkData != null)
                        {
                            infoUser user1 = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());

                            InfoUserInterface infoUser = new InfoUserInterface(user1, false, null);
                            infoUser.Show();

                            form.Hide();
                        }
                    }
                    else if (e.ColumnIndex == 3) // kết bạn
                    {
                        var data = new
                        {
                            id_user1 = user.id,
                            id_user2 = dataGridView.Rows[e.RowIndex].Cells["id"].Value.ToString()
                        };

                        JToken tkData = await manageApi.callApiUsingMethodPost(data, apiMakeFriend);
                        if (tkData != null)
                        {
                            listFriends lstFriend = JsonConvert.DeserializeObject<listFriends>(tkData.ToString());
                            user.lists.Add(lstFriend);
                            DataGridViewCell cell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                            cell.Style = new DataGridViewCellStyle { Padding = new Padding(500, 0, 0, 0) };
                            cell.ReadOnly = true;
                            dataGridView.Update();
                            //gửi sự kiện lên server để reload lại form
                            string message = (int)manageChooseCases.setting.makeFriend + "*" + dataGridView.Rows[e.RowIndex].Cells["userName"].Value.ToString() + "+" + user.userName + "+" + JsonConvert.SerializeObject(lstFriend);
                            handleChat.sendData(client, message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        public async static Task<userControlChatOne> cellClickContent_ListFriends(DataGridView sender, infoUser user, DataGridViewCellEventArgs e, string apiGetUserId, Form form, Panel pnlChatOne, userControlLists lists, Guna2Button btnListFriend, userControlChatOne chat, TcpClient client, string apiDeleteFriend)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridView dataGridView = (DataGridView)sender;
                    if (e.ColumnIndex == 3) //xem thông tin người chơi
                    {
                        string apiPath = apiGetUserId + dataGridView.Rows[e.RowIndex].Cells["id"].Value.ToString();
                        JToken tkData = await manageApi.callApiUsingGetMethodID(apiPath);
                        if (tkData != null)
                        {
                            infoUser user1 = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());

                            InfoUserInterface infoUser = new InfoUserInterface(user1, false, null);
                            infoUser.Show();

                            form.Hide();
                        }
                    }
                    else if (e.ColumnIndex == 4)    //Nhắn tin
                    {
                        pnlChatOne.Controls.Clear();

                        foreach (userControlChatOne userControl in createChatOneFrame.listChats)
                        {
                            if (userControl.Tag.ToString().Contains(user.userName) && userControl.Tag.ToString().Contains(dataGridView.Rows[e.RowIndex].Cells["userName"].Value.ToString()))
                            {
                                //khi bấm vào thì đổi về lại trạng thái cũ
                                lists.changeTextInButtonChat(dataGridView.Rows[e.RowIndex].Cells["userName"].Value.ToString(), true);
                                if (lists.checkReadMessageIntoChat())
                                    btnListFriend.Text = "Danh sách bạn bè";
                                foreach (System.Windows.Forms.UserControl userControl1 in createChatOneFrame.listChats)
                                    userControl1.Hide();
                                chat = userControl;
                                pnlChatOne.Controls.Add(chat);
                                chat.Show();
                                pnlChatOne.Show();
                                return chat;
                            }
                        }
                    }
                    else if (e.ColumnIndex == 5)    //Hủy lời mời kết bạn
                    {

                        string id1 = user.id;
                        string id2 = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                        string difUsername = dataGridView.Rows[e.RowIndex].Cells["userName"].Value.ToString();
                        string newId = "";
                        foreach (listFriends item in user.lists)
                        {
                            if (item.listID.Contains(id1) && item.listID.Contains(id2) && string.Equals(item.status.ToLower(), "friend"))
                            {
                                newId = item._id;
                                break;
                            }
                        }
                        if (!string.IsNullOrEmpty(newId))
                        {
                            string apiPath = apiDeleteFriend + newId;
                            //tiến hành lấy ra _id thỏa mãn
                            JToken tkData = await manageApi.callApiUsingDeleteMethod(apiPath);
                            if (tkData != null)
                            {
                                string message = (int)manageChooseCases.setting.unFriend + "*" + difUsername + ":" + user.userName + ":" + user.id;
                                handleChat.sendData(client, message);
                                MessageBox.Show("Đã hủy kết bạn với người chơi này");

                                //tiến hành xóa cặp người dùng này
                                listFriends item = JsonConvert.DeserializeObject<listFriends>(tkData.ToString());
                                user.lists.Remove(item);
                                //cập nhật lại danh sách tất cả người dùng
                                lists.showBtnMakeFriend(dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
                                dataGridView.Rows.RemoveAt(e.RowIndex);
                                //xóa bạn bè thì cũng coi như mất luồng chat 
                                foreach (userControlChatOne control in createChatOneFrame.listChats)
                                {
                                    if (control.Tag.ToString().Contains(user.userName) && control.Tag.ToString().Contains(difUsername))
                                    {
                                        createChatOneFrame.listChats.Remove(control);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async static Task cellClickContent_ListMatches(DataGridView sender, infoUser user, DataGridViewCellEventArgs e, string apiAddUserIntoMatch, string apiGetUserId, string myIpAddress, Form form, TcpClient client)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridView dataGridView = (DataGridView)sender;

                    if (e.ColumnIndex == 6)
                    {
                        if (dataGridView.Rows[e.RowIndex].Cells["Count"].Value.ToString() == "2/2")
                        {
                            MessageBox.Show("Phòng đã đầy, vui lòng chọn phòng khác");
                            return;
                        }
                        else
                        {
                            if (user.point < int.Parse(dataGridView.Rows[e.RowIndex].Cells["betPoint"].Value.ToString()))
                            {
                                MessageBox.Show("Điểm của bạn không đủ để tham gia phòng chơi này");
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Tham gia thành công");
                                //tạo và tham gia vào phòng
                                string idMatch = dataGridView.Rows[e.RowIndex].Cells["id"].Value.ToString();
                                //tiến hành lấy ra mã phòng khi click vào
                                JToken tkData = await manageApi.callApiUsingMethodPut(new { option = "adduser", id = user.id }, apiAddUserIntoMatch + idMatch);
                                if (tkData != null)
                                {
                                    matches match = JsonConvert.DeserializeObject<matches>(tkData.ToString());

                                    //lặp qua để kiếm ra id của chủ phòng
                                    string id = "";
                                    foreach (matchPlayer match1 in match.players)
                                    {
                                        if (match1.user != user.id)
                                        {
                                            id = match1.user;
                                            break;
                                        }
                                    }
                                    JToken userPlayer = await manageApi.callApiUsingGetMethodID(apiGetUserId + id);

                                    if (userPlayer != null)
                                    {
                                        infoUser difUser = JsonConvert.DeserializeObject<infoUser>(userPlayer.ToString());
                                        //gửi sự kiện tới server và cập nhật lại biến user.players lên 2 đơn vị
                                        string message = (int)manageChooseCases.setting.joinRoom + "*" + difUser.userName + "+" + idMatch;
                                        handleChat.sendData(client, message);

                                        string ipServer = hanleDataIntoDatagridview.columnData[e.RowIndex].ToString();
                                        MatchInterface player = new MatchInterface(myIpAddress, ipServer, idMatch, ipServer, false, false, 1, match.betPoints, difUser, user, client);  //chủ phòng sẽ là cờ trắng
                                        player.Show();

                                        form.Hide();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
