using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Linq;
using System.Web;
using System.Net.Mail;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using System.Threading;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CyborgWeb
{
    //string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;

    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            string connectionString = "mongodb+srv://cyborg:hmPHK#4.iunGKD2@cyborg-gui-mg1nk.azure.mongodb.net/test?retryWrites=true&w=majority";
            MongoClient MongodbClient = new MongoClient(connectionString);
            IMongoDatabase Mongodb = MongodbClient.GetDatabase("cyborg_data");
            IMongoCollection<BsonDocument> battery_status = Mongodb.GetCollection<BsonDocument>("__rosarnl_node__battery_status");
            IMongoCollection<BsonDocument> rosarnl_motorsstate = Mongodb.GetCollection<BsonDocument>("__rosarnl_node__motorsstate");
            HtmlGenericControl batteryTextBox = txtBattery;
            HtmlGenericControl motorsstateTextBox = txtMotorsstate;

            MongoDB newDB = new MongoDB(battery_status, batteryTextBox, rosarnl_motorsstate, motorsstateTextBox);

            Thread T1 = new Thread(new ThreadStart(newDB.WatchCollection));
            T1.Start();

            //Thread T2 = new Thread(WatchCollection(rosarnl_motorsstate));
            //Thread T1 = new Thread(watchCollection1);

            //T1.Start(rosarnl_motorsstate);
            //T2.Start();
        }

        [WebMethod]
        public static string GetBatteryStatus() //Webmethod ran from js method in Custom'.js, returns Quizes gathered from database in page_prerender event
        {
            MongoDB db = new MongoDB();
            string batteryStatus = db.GetBatteryPercentage();
            return batteryStatus;
        }

        //        //FilterDefinition<BsonDocument> filter = "{ 'charge_percent': 80}";
        //        txtMotorstate.InnerHtml = rosarnl_motorsstate.Find(filter, null).ToString();

        //class Battery_status
        //{
        //    [BsonElement("_id")]
        //    public ObjectId id { get; set; }

        //    [BsonElement("date")]
        //    public string date { get; set; }

        //    [BsonElement("charging_state")]
        //    public Int32 charging_state { get; set; }

        //    [BsonElement("charge_percent")]
        //    public Double charge_percent { get; set; }
        //}

        //class rosarnl_motorsstate
        //{
        //    [BsonElement("_id")]
        //    public ObjectId id { get; set; }

        //    [BsonElement("date")]
        //    public string date { get; set; }

        //    [BsonElement("data")]
        //    public bool data { get; set; }
        //}



        //[WebMethod]
        //public static void AddName(string name) //Webmethod ran from js method in Custom'.js, returns Quizes gathered from database in page_prerender event
        //{
        //    Data Data = new Data();
        //    Data.AddName(name);
        //}

        //[WebMethod]
        //public static void AddResult(string quizIndex, string correct, string incorrect) //Webmethod ran from js method in Custom'.js, returns Quizes gathered from database in page_prerender event
        //{
        //    Data Data = new Data();
        //    Data.AddResult(quizIndex, correct, incorrect);
        //}

        //[WebMethod]
        //public static List<Result> GetScores(string quizIndex) //Webmethod ran from js method in Custom'.js, returns Quizes gathered from database in page_prerender event
        //{
        //    List<string> lstResultId = new List<string>();
        //    List<string> lstCorrect = new List<string>();
        //    List<string> lstIncorrect = new List<string>();
        //    List<string> lstQuizId = new List<string>();
        //    List<string> lstUserId = new List<string>();
        //    List<string> lstName = new List<string>();

        //    Data resultData = new Data();
        //    resultData.GetScores(quizIndex, out lstResultId, out lstCorrect, out lstIncorrect, out lstQuizId, out lstUserId, out lstName);
        //    List<Result> Results = new List<Result>();
        //    for (int i = 0; i < lstResultId.Count(); i++)
        //    {
        //        Results.Add(new Result(lstResultId[i], lstCorrect[i], lstIncorrect[i], lstQuizId[i], lstUserId[i], lstName[i]));
        //    }
        //    return Results;
        //}

        protected void sendMessageButton_Click(object sender, EventArgs e)
        {
            string name = String.Format("{0}", Request.Form["name"]);
            string email = String.Format("{0}", Request.Form["email"]);
            string phone = String.Format("{0}", Request.Form["phone"]);
            string message = String.Format("{0}", Request.Form["message"]);
            SmtpClient smtpClient = new SmtpClient("smtp.live.com", 25)
            {
                Credentials = new System.Net.NetworkCredential("praktisktest@hotmail.com", "Nyemailinfotest5"),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true
            };
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

            //Setting From , To and CC
            mail.Subject = "CyborgWeb test website contact";
            mail.Body = "Thank you for contacting us " + name + ", your message has been received! \n \n You wrote: " + message + "\n\n ";
            mail.From = new MailAddress("praktisktest@hotmail.com", "CyborgWeb Website");
            mail.To.Add(new MailAddress(email));

            System.Net.Mail.MailMessage mail2 = new System.Net.Mail.MailMessage();

            //Setting From , To and CC
            mail2.Subject = "CyborgWeb test website contact";
            mail2.Body = name + " skrev: " + message;
            mail2.From = new MailAddress("praktisktest@hotmail.com", "CyborgWeb Website");
            mail2.To.Add(new MailAddress("casperknilsen@gmail.com"));

            smtpClient.Send(mail);
            smtpClient.Send(mail2);
        }

        protected void BtnGetData_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "done async GET" + "');", true);
            //await FillTxtBoxesAsync();
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "done async GET" + "');", true);
        }
    }
}