using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace RoadStatusDotNet
{
    public class ConsumeRoadStatus
    {
        const string APP_ID = "";//removed app id value before sharing in email
        const string APP_KEY = "";//removed app_key value before sharing in email
        Uri URI = new Uri("https://api.tfl.gov.uk/Road/A233?app_id=" + APP_ID + "&&app_key=" + APP_KEY);
        public void GetValidRoad(string roadId)
        {
            using (var client = new WebClient()) //WebClient  
            {
                try
                {
                    if (roadId.ToUpper() == "A2")
                    {
                        URI = new Uri("https://api.tfl.gov.uk/Road/A2?app_id=" + APP_ID + "&&app_key=" + APP_KEY);
                    }
                    client.Headers.Add("Content-Type:application/json"); //Content-Type  
                    client.Headers.Add("Accept:application/json");
                    // DownloadStringCompleted Method gets Called   
                    // when an asynchronous resource-download operation completes.  
                    client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadString_EventByID_Callback);
                    client.DownloadStringAsync(URI); //URI  
                    Console.ReadLine();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(roadId.ToUpper()+" is not a valid road");
                    Console.ReadLine();
                }
            }
            void DownloadString_EventByID_Callback(object sender, DownloadStringCompletedEventArgs e)
            {
                try
                {

                    List<StatusInfo> statusInfo = JsonConvert.DeserializeObject<List<StatusInfo>>(e.Result);
                    if (statusInfo.Count > 0)
                    {
                        StatusInfo status = statusInfo[0];
                        if (status.exceptionType == null || status.exceptionType.Length <= 0)
                        {
                            Console.WriteLine(string.Format("The status of the {0} is as follows", status.displayName));
                            Console.WriteLine(string.Format("Road Status is {0}", status.statusSeverity));
                            Console.WriteLine(string.Format("Road Status Description is {0}", status.statusSeverityDescription));
                        }
                        else if (status.message != null && status.message.Length > 0)
                        {
                            Console.WriteLine(status.message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(roadId.ToUpper() + " is not a valid road");
                    Console.ReadLine();
                }
            }

        }

        
        public class StatusInfo
        {
           
            [JsonProperty("id")]
            public string id;
            
            [JsonProperty("displayName")]
            public string displayName;

            
            [JsonProperty("statusSeverity")]
            public string statusSeverity;

            
            [JsonProperty("statusSeverityDescription")]
            public string statusSeverityDescription;

            
            [JsonProperty("exceptionType")]
            public string exceptionType;

            
            [JsonProperty("message")]
            public string message;

        }

    }
}
