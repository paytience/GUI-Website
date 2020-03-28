using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net.Security;
using System.ServiceModel;
using System.Net.Mail;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Logging;
using MongoDB.Bson.Serialization.Attributes;
using System.Threading;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace CyborgWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = "mongodb+srv://cyborg:hmPHK#4.iunGKD2@cyborg-gui-mg1nk.azure.mongodb.net/test?retryWrites=true&w=majority";
            MongoClient MongodbClient = new MongoClient(connectionString);
            IMongoDatabase Mongodb = MongodbClient.GetDatabase("cyborg_data");
            IMongoCollection<BsonDocument> battery_status = Mongodb.GetCollection<BsonDocument>("__rosarnl_node__battery_status");
            IMongoCollection<BsonDocument> rosarnl_motorsstate = Mongodb.GetCollection<BsonDocument>("__rosarnl_node__motors_state");

            MongoDB newDB = new MongoDB(battery_status, rosarnl_motorsstate);

            Thread T1 = new Thread(new ThreadStart(newDB.WatchCollection));
            T1.Start();

            Thread T2 = new Thread(new ThreadStart(newDB.WatchCollection2));
            T2.Start();
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
