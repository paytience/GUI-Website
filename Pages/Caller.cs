using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CyborgWeb.Pages
{
    // Caller model takes in ajax calls from Custom'.js
    public class CallerModel : PageModel
    {

        public CallerModel()
        {
            
        }
        public JsonResult OnGetBatteryStatus()
        {
            MongoDB db = new MongoDB();
            string batterystatus = db.GetBatteryPercentage();
            return new JsonResult(batterystatus);
        }

        public JsonResult OnGetMotorsState()
        {
            MongoDB db = new MongoDB();
            string motorsstate = db.GetMotorsState();
            return new JsonResult(motorsstate);
        }
    }
}
