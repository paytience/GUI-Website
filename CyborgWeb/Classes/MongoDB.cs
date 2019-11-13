﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CyborgWeb
{
    public class MongoDB
    {
        public void Create() {
            try
            {
                string connectionString = "mongodb+srv://cyborg:hmPHK#4.iunGKD2@cyborg-gui-mg1nk.azure.mongodb.net/test?retryWrites=true&w=majority";
                MongoClient MongodbClient = new MongoClient(connectionString);
                // Get Database and Collection
                IMongoDatabase Mongodb = MongodbClient.GetDatabase("cyborg_data");
                var MongodbcollList = Mongodb.ListCollections().ToList();
                //Console.WriteLine("The MongoDB list of collections are: ");
                //foreach (var item in MongodbcollList)
                //{
                //    Console.WriteLine(item);
                //}
                IMongoCollection<BsonDocument> mydocument = Mongodb.GetCollection<BsonDocument>("mydocument");
                
                BsonElement employeename = new BsonElement("employeename", "Tapas Pal");
                BsonDocument empployee = new BsonDocument();
                empployee.Add(employeename);
                empployee.Add(new BsonElement("employeenumber", 123));
                mydocument.InsertOne(empployee);

                //create(Mongodb, mydocument);
                //update(Mongodb, mydocument);
                //delete(Mongodb, mydocument);

                var myresultDoc = mydocument.Find(new BsonDocument()).ToList();
                foreach (var myitem in myresultDoc)
                {
                    Console.WriteLine(myitem.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

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

        static void update(IMongoDatabase Mongodb, IMongoCollection<BsonDocument> mydocument)
        {
            // UPDATE
            BsonElement updateemployee = new BsonElement("employeename", "Tapas1 Pal1");

            BsonDocument updateemployeedoc = new BsonDocument();
            updateemployeedoc.Add(updateemployee);
            updateemployeedoc.Add(new BsonElement("employeenumber",
               1234));

            BsonDocument findemployeeDoc = new BsonDocument(new BsonElement("employeename", "Tapas Pal"));

            var updateDoc = mydocument.FindOneAndReplace(findemployeeDoc, updateemployeedoc);

            Console.WriteLine(updateDoc);

        }
        static void delete(IMongoDatabase Mongodb, IMongoCollection<BsonDocument> mydocument)
        {
            // DELETE
            BsonDocument findAnotheremployee = new BsonDocument(new BsonElement("employeename", "Tapas1 Pal1"));

            mydocument.FindOneAndDelete(findAnotheremployee);
        }
    }
}