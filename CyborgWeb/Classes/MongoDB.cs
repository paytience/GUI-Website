using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace CyborgWeb
{
    public class MongoDB
    {
        private IMongoCollection<BsonDocument> batterystatus;
        private IMongoCollection<BsonDocument> motorsstate;
        public static string batterystatusString { get; set; }
        public static string motorsStateString { get; set; }
        public static DateTime batterystatusDateTime { get; set; }
        public static DateTime motorsStateDateTime { get; set; }

        public MongoDB(IMongoCollection<BsonDocument> BatteryStatus, IMongoCollection<BsonDocument> MotorsState)
        {
            batterystatus = BatteryStatus;
            motorsstate = MotorsState;
        }

        public MongoDB()
        {

        }

        public void WatchCollection()
        {
            // --- Old changestream lookup with filter that does not work: ---

            // var pipeline = new EmptyPipelineDefinition<ChangeStreamDocument<BsonDocument>>().Match(Builders<ChangeStreamDocument<BsonDocument>>.Filter.Gte("FullDocument.charge_percent", 0));
            // var options = new ChangeStreamOptions { FullDocument = ChangeStreamFullDocumentOption.UpdateLookup };

            // var cursor = batterystatus.Watch(pipeline, options);
            // foreach (var change in cursor.ToEnumerable())
            // {
            //     dynamic data = JObject.Parse(JsonConvert.SerializeObject(BsonTypeMapper.MapToDotNetValue(change.FullDocument)));
            //     batterystatusDateTime = Convert.ToDateTime(data.Date);
            //     batterystatusString = data.charge_percent.ToString();
            // }
            
            using (var cursor = batterystatus.Watch()) 
            {
                foreach (var change in cursor.ToEnumerable())
                {
                    dynamic data = JObject.Parse(JsonConvert.SerializeObject(BsonTypeMapper.MapToDotNetValue(change.FullDocument)));
                    
                    batterystatusString = (string)data.SelectToken("charge_percent");

                    // data.date is set in UTC time in 'topic_transmitter' -> ROS system's 'commander' package. 
                    batterystatusDateTime = (DateTime)data.SelectToken("date");
                }
            }
        }

        public void WatchCollection2()
        {
            using (var cursor = motorsstate.Watch()) 
            {
                foreach (var change in cursor.ToEnumerable())
                {
                    dynamic data = JObject.Parse(JsonConvert.SerializeObject(BsonTypeMapper.MapToDotNetValue(change.FullDocument)));

                    motorsStateString = (string)data.SelectToken("data");

                    // data.date is set in UTC time in 'topic_transmitter' -> ROS system's 'commander' package. 
                    motorsStateDateTime = (DateTime)data.SelectToken("date");
                }
            }
        }

        public string GetBatteryPercentage()
        {
            // Norway is in UTC+1 
            // Make threshold for 1 minute ago, changes made earlier than a minute ago are ignored.
            DateTime threshold = DateTime.UtcNow.AddMinutes(-1);
            DateTime packageReceived = batterystatusDateTime;
            
            if (packageReceived >= threshold)
            {
                return batterystatusString;
            }
            else
            {
                return "-";
            }
        }

        public string GetMotorsState()
        {
            DateTime threshold = DateTime.UtcNow.AddMinutes(-1);
            DateTime packageReceived = motorsStateDateTime;
            
            if (packageReceived >= threshold)
            {
                return motorsStateString;
            }
            else
            {
                return "-";
            }
        }
    }
}