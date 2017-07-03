using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace OneSignalPushNotification
{
    public class OneSignal
    {
        public string AddDevice(string apiId, int type)
        {
            // connecting one signal API 
            HttpWebRequest httpWebRequest = WebRequest.Create("https://onesignal.com/api/v1/players") as HttpWebRequest;
            httpWebRequest.KeepAlive = true;
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Headers.Add("authorization", "Basic XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX(This is REST API KEY)");

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            var obj = new
            {
                app_id = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX(This is OneSignal App ID)",
                identifier = apiId,
                language = "en",
                device_type = type
            };
            string s = javaScriptSerializer.Serialize(obj);
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            string input = null;
            try
            {
                using (Stream requestStream = httpWebRequest.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                }
                using (HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        input = streamReader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
            }
            Result result = javaScriptSerializer.Deserialize<Result>(input);
            return result.id;
        }

        public List<PlayerID> createNotification(PushContent content)
        {
            List<PlayerID> list = new List<PlayerID>();
            List<Clients> clients = content.clients;
            for (int i = 0; i < clients.Count; i++)
            {
                HttpWebRequest httpWebRequest = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;
                httpWebRequest.KeepAlive = true;
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Headers.Add("authorization", "Basic XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX(This is REST API KEY)");
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                string[] array = new string[1];
                string mobileTokens = clients[i].mobileTokens;
                int mobileType = clients[i].mobileType;
                array[0] = (clients[i].isPlayerIdExists ? clients[i].mobileTokens : this.AddDevice(mobileTokens, mobileType));
                bool playerIDExist = !clients[i].isPlayerIdExists;
                if (playerIDExist)
                {
                    PlayerID item = new PlayerID(clients[i].clientID, clients[i].mobileTokens, array[0]);
                    list.Add(item);
                }
                bool type = mobileType == 0;
                byte[] bytes;
                if (type) // IOS
                {
                    var obj = new
                    {
                        app_id = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX(This is OneSignal App ID)",
                        contents = new
                        {
                            en = "English Message for IOS",
                            tr = "English Message for IOS"
                        },
                        headings = new
                        {
                            en = "Headings",
                            tr = "English Message for IOS"
                        },
                        include_player_ids = array,
                        content_available = true,
                        ios_badgeType = "SetTo",
                        ios_badgeCount = 1,
                        data = content
                    };
                    string s = javaScriptSerializer.Serialize(obj);
                    bytes = Encoding.UTF8.GetBytes(s);
                }
                else
                {
                    var obj = new
                    {
                        app_id = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX(This is OneSignal App ID)",
                        contents = new
                        {
                            en = "English Message"
                        },
                        include_player_ids = array,
                        data = content
                    };
                    string s = javaScriptSerializer.Serialize(obj);
                    bytes = Encoding.UTF8.GetBytes(s);
                }
                string message = null;
                try
                {
                    using (Stream requestStream = httpWebRequest.GetRequestStream())
                    {
                        requestStream.Write(bytes, 0, bytes.Length);
                    }
                    using (HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                    {
                        using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                        {
                            message = streamReader.ReadToEnd();
                        }
                    }
                }
                catch (WebException ex)
                {
                    Debug.WriteLine(ex.Message);
                    Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
                }
                Debug.WriteLine(message);
            }
            return list;
        }
    }
}
}
