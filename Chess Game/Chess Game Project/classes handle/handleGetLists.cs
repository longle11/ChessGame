using Chess_Game_Project.classes;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chess_Game_Project.ContainUserControls;

namespace Chess_Game_Project.classes_handle
{
    internal class handleGetLists
    {
        //============================================  HÀM DÙNG ĐỂ LẤY RA DANH SÁCH NGƯỜI DÙNG ============================================
        public static async Task getListAllUser(string userId, string apiGetAllUser, userControlLists lists, infoUser user)
        {
            try
            {
                JToken tokenData = await manageApi.callApiUsingMethodGet(apiGetAllUser);
                if (tokenData != null)
                {
                    List<infoUser> userLists = JsonConvert.DeserializeObject<List<infoUser>>(tokenData.ToString());
                    foreach (infoUser item in userLists)
                    {
                        if (item.id == userId)
                        {
                            userLists.Remove(item);
                            break;
                        }
                    }
                    //hiển thị danh sách tất cả user lên datagridView
                    hanleDataIntoDatagridview.displayListUsers(userLists, lists, user);
                }
            }
            catch (Exception ex)
            {
            }
        }
        public static async Task<List<infoUser>> getListUser(string status, infoUser user, string apiGetUserId)
        {
            try
            {
                List<infoUser> lists = new List<infoUser>();
                if(user.lists != null)
                {
                    foreach (listFriends item in user.lists)
                    {
                        //tiến hành lấy ra listID
                        List<string> listid = item.listID;
                        string apiPath = null;
                        if (string.Equals(item.status.ToLower(), "waiting") && string.Equals(status.ToLower(), "waiting"))
                        {
                            if (listid[0] != user.id)
                                apiPath = apiGetUserId + listid[0];
                            else
                                continue;
                        }
                        else if (string.Equals(item.status.ToLower(), "friend") && string.Equals(status.ToLower(), "friend"))
                        {
                            string id = "";
                            foreach (string item1 in listid)
                                if (item1 != user.id) id = item1;
                            apiPath = apiGetUserId + id;
                        }
                        if (!string.IsNullOrEmpty(apiPath))
                        {
                            JToken tkData = await manageApi.callApiUsingGetMethodID(apiPath);
                            if (tkData != null)
                            {
                                infoUser friend = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());
                                if (friend != null)
                                {
                                    if (item.status.ToLower() == status)
                                        lists.Add(friend);
                                }
                            }
                        }
                    }
                }
                return lists;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static async Task<List<string>> getListFriends(string apiGetUserId, infoUser user)
        {
            try
            {
                JToken tkData = await manageApi.callApiUsingGetMethodID(apiGetUserId + user.id);
                if (tkData != null)
                {
                    infoUser info = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());
                    List<string> arraysUserName = new List<string>();
                    foreach (listFriends lists in info.lists)
                    {
                        if (lists.status == "friend")
                        {
                            List<string> listIds = lists.listID;
                            string id = listIds[0] == user.id ? listIds[1] : listIds[0];
                            JToken tkInfo = await manageApi.callApiUsingGetMethodID(apiGetUserId + id);
                            if (tkInfo != null)
                            {
                                infoUser difUser = JsonConvert.DeserializeObject<infoUser>(tkInfo.ToString());
                                if(difUser != null )
                                {
                                    if (difUser.statusActive == "online")
                                        arraysUserName.Add(difUser.userName);
                                }
                            }
                        }
                    }
                    return arraysUserName;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //==================================================================================================================================
    }
}
