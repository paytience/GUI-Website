using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Web.UI.HtmlControls;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using MongoDB.Bson;
namespace CyborgWeb
{
    public class MongoDB
    {
        private IMongoCollection<BsonDocument> batterystatus;
        private IMongoCollection<BsonDocument> motorsstate;
        private HtmlGenericControl batteryTextBox;
        private HtmlGenericControl motorsstateTextBox;
        public static string batterystatusString { get; set; }
        public static string motorsStateString { get; set; }
        public static DateTime batterystatusDateTime { get; set; }
        public static DateTime motorsStateDateTime { get; set; }

        public MongoDB(IMongoCollection<BsonDocument> BatteryStatus, HtmlGenericControl BatteryTextBox, IMongoCollection<BsonDocument> MotorsState, HtmlGenericControl MotorsstateTextBox)
        {
            batterystatus = BatteryStatus;
            batteryTextBox = BatteryTextBox;
            motorsstate = MotorsState;
            motorsstateTextBox = MotorsstateTextBox;
        }

        public MongoDB()
        {

        }

        public void WatchCollection()
        {
            var pipeline = new EmptyPipelineDefinition<ChangeStreamDocument<BsonDocument>>().Match(Builders<ChangeStreamDocument<BsonDocument>>.Filter.Gte("FullDocument.charge_percent", 0));
            var options = new ChangeStreamOptions { FullDocument = ChangeStreamFullDocumentOption.UpdateLookup };

            var cursor = batterystatus.Watch(pipeline, options);
            foreach (var change in cursor.ToEnumerable())
            {
                dynamic data = JObject.Parse(JsonConvert.SerializeObject(BsonTypeMapper.MapToDotNetValue(change.FullDocument)));
                batterystatusDateTime = Convert.ToDateTime(data.Date);
                batterystatusString = data.charge_percent.ToString();
            }
        }

        public void WatchCollection2()
        {
            var pipeline = new EmptyPipelineDefinition<ChangeStreamDocument<BsonDocument>>().Match(Builders<ChangeStreamDocument<BsonDocument>>.Filter.Empty);
            var options = new ChangeStreamOptions { FullDocument = ChangeStreamFullDocumentOption.UpdateLookup };

            var cursor = motorsstate.Watch(pipeline, options);
            foreach (var change in cursor.ToEnumerable())
            {
                dynamic data = JObject.Parse(JsonConvert.SerializeObject(BsonTypeMapper.MapToDotNetValue(change.FullDocument)));
                motorsStateDateTime = Convert.ToDateTime(data.Date);
                motorsStateString = data.data.ToString();
            }
        }

        public string GetBatteryPercentage()
        {
            DateTime now = DateTime.UtcNow.AddMinutes(55);
            if (batterystatusDateTime < now)
            {
                return "-";
            }
            else
            {
                return batterystatusString;
            }
                
        }

        public string GetMotorsState()
        {
            DateTime now = DateTime.UtcNow.AddMinutes(55);
            if (motorsStateDateTime < now)
            {
                return "-";
            }
            else
            {
                return motorsStateString;
            }
        }

        //public void Create() {
        //    try
        //    {
        //        string connectionString = "mongodb+srv://cyborg:hmPHK#4.iunGKD2@cyborg-gui-mg1nk.azure.mongodb.net/test?retryWrites=true&w=majority";
        //        MongoClient MongodbClient = new MongoClient(connectionString);
        //        // Get Database and Collection
        //        IMongoDatabase Mongodb = MongodbClient.GetDatabase("cyborg_data");
        //        var MongodbcollList = Mongodb.ListCollections().ToList();
        //        Console.WriteLine("The MongoDB list of collections are: ");
        //        foreach (var item in MongodbcollList)
        //        {
        //            Console.WriteLine(item);
        //        }
        //        IMongoCollection<BsonDocument> mydocument = Mongodb.GetCollection<BsonDocument>("mydocument");

        //        BsonElement employeename = new BsonElement("employeename", "Tapas Pal");
        //        BsonDocument empployee = new BsonDocument();
        //        empployee.Add(employeename);
        //        empployee.Add(new BsonElement("employeenumber", 123));
        //        mydocument.InsertOne(empployee);

        //        create(Mongodb, mydocument);
        //        update(Mongodb, mydocument);
        //        delete(Mongodb, mydocument);

        //        var myresultDoc = mydocument.Find(new BsonDocument()).ToList();
        //        foreach (var myitem in myresultDoc)
        //        {
        //            Console.WriteLine(myitem.ToString());
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    try
        //    {
        //        string connectionString = "mongodb+srv://cyborg:hmPHK#4.iunGKD2@cyborg-gui-mg1nk.azure.mongodb.net/test?retryWrites=true&w=majority";
        //        MongoClient MongodbClient = new MongoClient(connectionString);
        //        // Get Database and Collection
        //        IMongoDatabase Mongodb = MongodbClient.GetDatabase("cyborg_data");
        //        var MongodbcollList = Mongodb.ListCollections().ToList();
        //        Console.WriteLine("The MongoDB list of collections are: ");
        //        foreach (var item in MongodbcollList)
        //        {
        //            Console.WriteLine(item);
        //        }
        //        IMongoCollection<BsonDocument> mydocument = Mongodb.GetCollection<BsonDocument>("mydocument");

        //        create(Mongodb, mydocument);
        //        //update(Mongodb, mydocument);
        //        //delete(Mongodb, mydocument);

        //        var myresultDoc = mydocument.Find(new BsonDocument()).ToList();
        //        foreach (var myitem in myresultDoc)
        //        {
        //            Console.WriteLine(myitem.ToString());
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //    Console.ReadLine();
        //}

        //static void create(IMongoDatabase Mongodb, IMongoCollection<BsonDocument> mydocument)
        //{
        //    BsonElement employeename = new BsonElement("employeename", "Tapas Pal");
        //    BsonDocument empployee = new BsonDocument();
        //    empployee.Add(employeename);
        //    empployee.Add(new BsonElement("employeenumber", 123));
        //    mydocument.InsertOne(empployee);

        //}

        //static void update(IMongoDatabase Mongodb, IMongoCollection<BsonDocument> mydocument)
        //{
        //    // UPDATE
        //    BsonElement updateemployee = new BsonElement("employeename", "Tapas1 Pal1");

        //    BsonDocument updateemployeedoc = new BsonDocument();
        //    updateemployeedoc.Add(updateemployee);
        //    updateemployeedoc.Add(new BsonElement("employeenumber",
        //       1234));

        //    BsonDocument findemployeeDoc = new BsonDocument(new BsonElement("employeename", "Tapas Pal"));

        //    var updateDoc = mydocument.FindOneAndReplace(findemployeeDoc, updateemployeedoc);

        //    Console.WriteLine(updateDoc);

        //}
        //static void delete(IMongoDatabase Mongodb, IMongoCollection<BsonDocument> mydocument)
        //{
        //    // DELETE
        //    BsonDocument findAnotheremployee = new BsonDocument(new BsonElement("employeename", "Tapas1 Pal1"));

        //    mydocument.FindOneAndDelete(findAnotheremployee);
        //}
    }
}