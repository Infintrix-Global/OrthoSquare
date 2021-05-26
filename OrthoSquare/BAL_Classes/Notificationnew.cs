using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace OrthoSquare.BAL_Classes
{
    public class Notificationnew
    {
        public string getExactPayload(string patientid, string Tokens, string Message,string Title, string typemsg)
        {
            string postData = "";
            postData = "{\"collapse_key\":\"score_update\",\"time_to_live\":108,\"delay_while_idle\":true,\"priority\":\"high\",\"data\": { \"patientid\": \"" + patientid + "\",\"Message\": \"" + Message + "\",\"Title\": \"" + Title + "\",\"Type\": \"" + typemsg + "\"}  ,\"registration_ids\":[\"" + Tokens + "\"] }";
            return postData;
        }

        public string SendMessage(string patientid, string Tokens, string Message, string Title, string typemsg)
        {
            FCMResponse response;

            string SERVER_API_KEY = "AAAA0WSR2uo:APA91bEdpTK20YoliaTJm5qGfMpBvrxsGh0CsnCWY1HPZ-DHnhnFfge2ws66tg4IDhFOOuYSk8IecC3f4CULoIFcd0UWmFsShlPmrb7MbDFY2eIqHhaqEAlYx_kIZW80RB9lTgoKwiId";

            var SENDER_ID = 899335445226;
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            tRequest.ContentType = "application/json";

            var objNotification = new
            {
                to = Tokens,
                data = new
                {
                    postData = getExactPayload(patientid, Tokens, Message,Title, typemsg)
                }

            };
            string jsonNotificationFormat = Newtonsoft.Json.JsonConvert.SerializeObject(objNotification);

            Byte[] byteArray = Encoding.UTF8.GetBytes(jsonNotificationFormat);
            tRequest.Headers.Add(string.Format("Authorization: key={0}", SERVER_API_KEY));
            tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
            tRequest.ContentLength = byteArray.Length;
            tRequest.ContentType = "application/json";
            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);

                using (WebResponse tResponse = tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        using (StreamReader tReader = new StreamReader(dataStreamResponse))
                        {
                            String responseFromFirebaseServer = tReader.ReadToEnd();
                            response = Newtonsoft.Json.JsonConvert.DeserializeObject<FCMResponse>(responseFromFirebaseServer);
                        }
                    }

                }
            }

            return response.ToString();
        }


    
        public class FCMResponse
        {
            public long multicast_id { get; set; }
            public int success { get; set; }
            public int failure { get; set; }
            public int canonical_ids { get; set; }
            public List<FCMResult> results { get; set; }
        }
        public class FCMResult
        {
            public string message_id { get; set; }
        }
    }
}