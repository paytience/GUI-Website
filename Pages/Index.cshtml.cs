using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;


namespace CyborgWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            string connectionString = "mongodb+srv://cyborg:hmPHK#4.iunGKD2@cyborg-gui-mg1nk.azure.mongodb.net/test?retryWrites=true&w=majority";
            MongoClient MongodbClient = new MongoClient(connectionString);
            IMongoDatabase Mongodb = MongodbClient.GetDatabase("cyborg_data");
            IMongoCollection<BsonDocument> battery_status = Mongodb.GetCollection<BsonDocument>("__rosarnl_node__battery_status");
            IMongoCollection<BsonDocument> rosarnl_motorsstate = Mongodb.GetCollection<BsonDocument>("__rosarnl_node__motorsstate");

            MongoDB newDB = new MongoDB(battery_status, rosarnl_motorsstate);

            Thread T1 = new Thread(new ThreadStart(newDB.WatchCollection));
            T1.Start();

            Thread T2 = new Thread(new ThreadStart(newDB.WatchCollection2));
            T2.Start();
            //Thread T2 = new Thread(WatchCollection(rosarnl_motorsstate));
            //Thread T1 = new Thread(watchCollection1);

            //T1.Start(rosarnl_motorsstate);
            //T2.Start();
        }

        public JsonResult OnGetTestMethod()
        {
            MongoDB db = new MongoDB();
            string batterystatus = db.GetBatteryPercentage();
            return new JsonResult(batterystatus);
        }
    }
}
