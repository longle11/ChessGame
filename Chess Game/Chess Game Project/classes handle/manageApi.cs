using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Game_Project.classes_handle
{
    internal class manageApi
    {
        public static async Task<JToken> callApiUsingGetMethodID(string apiPath)
        {
            //làm mới lại danh sách khi có phần tử mới được thêm vào
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(apiPath);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string jsonData = await response.Content.ReadAsStringAsync();
                JObject objData = JObject.Parse(jsonData);
                JToken tkData = objData["data"];

                return tkData;
            }

            return null;
        }
        public static async Task<JToken> callApiUsingDeleteMethod(string apiPath)
        {
            //làm mới lại danh sách khi có phần tử mới được thêm vào
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(apiPath);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string jsonData = await response.Content.ReadAsStringAsync();
                JObject objData = JObject.Parse(jsonData);
                JToken tkData = objData["data"];

                return tkData;
            }

            return null;
        }
        public static async Task<JToken> callApiUsingMethodGet(string apiPath)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(apiPath);
            JToken dataToken = null;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                JObject jsonData = JObject.Parse(responseData);
                // Lấy giá trị của thuộc tính "data"
                dataToken = jsonData["data"];
                return dataToken;
            }
            return null;
        }
        public static async Task<JToken> callApiUsingMethodPost(object data, string apiPath)
        {
            //gọi tới API 
            HttpClient client = new HttpClient();
            var objData = JsonConvert.SerializeObject(data);
            HttpResponseMessage response = await client.PostAsync(apiPath, new StringContent(objData, Encoding.UTF8, "application/json"));
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                JObject jsonData = JObject.Parse(responseData);
                // Lấy giá trị của thuộc tính "data"
                JToken dataToken = jsonData["data"];
                if(dataToken == null)
                {
                    dataToken = jsonData["notify"];
                }
                return dataToken;
            }
            return null;
        }
        public static async Task<JToken> callApiUsingMethodPut(object data, string apiPath)
        {
            //gọi tới API 
            HttpClient client = new HttpClient();
            string dataJson = JsonConvert.SerializeObject(data);
            //tiến hành lấy ra _id thỏa mãn
            HttpResponseMessage response = await client.PutAsync(apiPath, new StringContent(dataJson, Encoding.UTF8, "application/json"));
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JObject.Parse(await response.Content.ReadAsStringAsync())["data"];
            }
            return null;
        }
    }
}
