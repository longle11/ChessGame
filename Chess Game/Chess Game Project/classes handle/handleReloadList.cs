using Chess_Game_Project.classes;
using Chess_Game_Project.ContainUserControls;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chess_Game_Project.manageUsers;

namespace Chess_Game_Project.classes_handle
{
    internal class handleReloadList
    {
        public async static Task reloadListFriends(string apiGetUserId, infoUser user, userControlLists lists, userControlChatOne chat)
        {
            JToken tkData = await manageApi.callApiUsingGetMethodID(apiGetUserId + user.id);
            if (!string.IsNullOrEmpty(tkData.ToString()))
            {
                user = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());
                List<infoUser> getFriends = await handleGetLists.getListUser("friend", user, apiGetUserId);
                hanleDataIntoDatagridview.displayListFriends(getFriends, lists);


                createChatOneFrame.listChats.Clear();
                await createChatOneFrame.createChatBetweenClientAndClient(apiGetUserId, user, chat);

                MessageBox.Show("Làm mới thành công");
            }
        }
        public async static Task reloadListAcceptFriends(string apiGetUserId, infoUser user, userControlLists lists)
        {
            JToken tkData = await manageApi.callApiUsingGetMethodID(apiGetUserId + user.id);
            if (!string.IsNullOrEmpty(tkData.ToString()))
            {
                user = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());
                List<infoUser> getFriends = await handleGetLists.getListUser("waiting", user, apiGetUserId);
                hanleDataIntoDatagridview.displayListWaitingAccept(getFriends, lists);

                MessageBox.Show("Làm mới thành công");
            }
        }
        public async static Task reloadListMatches(DataGridView dtGridContainListRooms, string apiGetListMatches)
        {
            await hanleDataIntoDatagridview.displayListMatches(dtGridContainListRooms, apiGetListMatches);

            MessageBox.Show("Làm mới thành công");
        }
        public async static Task reloadListAllUsers(string apiGetUserId, string apiGetAllUser, infoUser user, userControlLists lists)
        {
            JToken tkData = await manageApi.callApiUsingGetMethodID(apiGetUserId + user.id);
            if (!string.IsNullOrEmpty(tkData.ToString()))
            {
                user = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());
                await handleGetLists.getListAllUser(user.id, apiGetAllUser, lists, user);
                MessageBox.Show("Làm mới thành công");
            }
        }
        public async static Task reloadListRanks(string apiGetUserId, string apiGetAllUser, infoUser user, userControlRanks rank)
        {
            JToken tkData = await manageApi.callApiUsingGetMethodID(apiGetUserId + user.id);
            if (!string.IsNullOrEmpty(tkData.ToString()))
            {
                JToken tkData1 = await manageApi.callApiUsingMethodGet(apiGetAllUser);
                List<infoUser> users = JsonConvert.DeserializeObject<List<infoUser>>(tkData1.ToString());
                user = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());
                hanleDataIntoDatagridview.displayListRank(users, user, rank);

            }
        }
        public async static Task reloadListHistories(string apiGetUserId, infoUser user, userControlHistory history)
        {
            JToken tkData = await manageApi.callApiUsingGetMethodID(apiGetUserId + user.id);
            if (!string.IsNullOrEmpty(tkData.ToString()))
            {
                user = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());
                await hanleDataIntoDatagridview.displayListHistoryMatch(user, history, apiGetUserId);

            }
        }
    }
}
