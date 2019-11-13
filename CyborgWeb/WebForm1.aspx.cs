using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Linq;
using System.Web;
using System.Net.Mail;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace CyborgWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
            
        //}
        //static void Main(string[] args)
        //{
        //    MainAsync().Wait();

        //    Console.ReadLine();
        //}
        //static async Task MainAsync()
        //{
        //    string connectionString = "mongodb+srv://cyborg:hmPHK#4.iunGKD2@cyborg-gui-mg1nk.azure.mongodb.net/test?retryWrites=true&w=majority";
        //    MongoClient client = new MongoClient(connectionString);

        //    var db = client.GetDatabase("cyborg_data");

        //    var collection = db.GetCollection<BsonDocument>("__rosarnl_node__battery_status");

        //    var MongodbcollList = db.ListCollections().ToList();

        //    foreach (var item in MongodbcollList)
        //    {
        //        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "The MongoDB list of collections are: " + "');", true);
        //        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + item + "');", true);
        //    }

        //    using (IAsyncCursor<BsonDocument> cursor = await collection.FindAsync(new BsonDocument()))
        //    {
        //        while (await cursor.MoveNextAsync())
        //        {
        //            IEnumerable<BsonDocument> batch = cursor.Current;
        //            foreach (BsonDocument document in batch)
        //            {
        //                Console.WriteLine(document);
        //                Console.WriteLine();
        //            }
        //        }
        //    }
        //}

        protected void Page_PreRender(object sender, EventArgs e)
        {
            MongoDB newDB = new MongoDB();
            newDB.Create();
            //string connectionString = "mongodb+srv://cyborg:hmPHK#4.iunGKD2@cyborg-gui-mg1nk.azure.mongodb.net/test?retryWrites=true&w=majority";
            //MongoClient client = new MongoClient(connectionString);

            //var db = client.GetDatabase("cyborg_data");

            //var collection = db.GetCollection<BsonDocument>("__rosarnl_node__battery_status");

            //var MongodbcollList = db.ListCollections().ToList();

            //foreach (var item in MongodbcollList)
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "The MongoDB list of collections are: " + "');", true);
            //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + item + "');", true);
            //}

            //string connectionString = "mongodb+srv://cyborg:hmPHK#4.iunGKD2@cyborg-gui-mg1nk.azure.mongodb.net/test?retryWrites=true&w=majority";
            //MongoClient client = new MongoClient(connectionString);
            //var db = client.GetDatabase("cyborg_data");
            //var collection = db.GetCollection<BsonDocument>("__rosarnl_node__battery_status");



            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + collection + "');", true);

        }

        [WebMethod]
        public static List<Quiz> GetQuizes() //Webmethod ran from js method in Custom'.js, returns Quizes gathered from database in page_prerender event
        {
            List<Quiz> quizData = (List<Quiz>)HttpContext.Current.Session["quizData"];
            return quizData;
        }

        [WebMethod]
        public static void AddName(string name) //Webmethod ran from js method in Custom'.js, returns Quizes gathered from database in page_prerender event
        {
            Data Data = new Data();
            Data.AddName(name);
        }

        [WebMethod]
        public static void AddResult(string quizIndex, string correct, string incorrect) //Webmethod ran from js method in Custom'.js, returns Quizes gathered from database in page_prerender event
        {
            Data Data = new Data();
            Data.AddResult(quizIndex, correct, incorrect);
        }

        [WebMethod]
        public static List<Result> GetScores(string quizIndex) //Webmethod ran from js method in Custom'.js, returns Quizes gathered from database in page_prerender event
        {
            List<string> lstResultId = new List<string>();
            List<string> lstCorrect = new List<string>();
            List<string> lstIncorrect = new List<string>();
            List<string> lstQuizId = new List<string>();
            List<string> lstUserId = new List<string>();
            List<string> lstName = new List<string>();

            Data resultData = new Data();
            resultData.GetScores(quizIndex, out lstResultId, out lstCorrect, out lstIncorrect, out lstQuizId, out lstUserId, out lstName);
            List<Result> Results = new List<Result>();
            for (int i = 0; i < lstResultId.Count(); i++)
            {
                Results.Add(new Result(lstResultId[i], lstCorrect[i], lstIncorrect[i], lstQuizId[i], lstUserId[i], lstName[i]));
            }
            return Results;
        }

        protected void sendMessageButton_Click(object sender, EventArgs e)
        {
            string name = String.Format("{0}", Request.Form["name"]);
            string email = String.Format("{0}", Request.Form["email"]);
            string phone = String.Format("{0}", Request.Form["phone"]);
            string message = String.Format("{0}", Request.Form["message"]);
            SmtpClient smtpClient = new SmtpClient("smtp.live.com", 25)
            {
                Credentials = new System.Net.NetworkCredential("CyborgWebtest@hotmail.com", "Nyemailinfotest5"),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true
            };
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

            //Setting From , To and CC
            mail.Subject = "CyborgWeb test website contact";
            mail.Body = "Thank you for contacting us " + name + ", your message has been received! \n \n You wrote: " + message + "\n\n ";
            mail.From = new MailAddress("CyborgWebtest@hotmail.com", "CyborgWeb Website");
            mail.To.Add(new MailAddress(email));

            System.Net.Mail.MailMessage mail2 = new System.Net.Mail.MailMessage();

            //Setting From , To and CC
            mail2.Subject = "CyborgWeb test website contact";
            mail2.Body = name + " skrev: " + message;
            mail2.From = new MailAddress("CyborgWebtest@hotmail.com", "CyborgWeb Website");
            mail2.To.Add(new MailAddress("casperknilsen@gmail.com"));

            smtpClient.Send(mail);
            smtpClient.Send(mail2);
        }
    }
}