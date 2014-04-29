using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ExGrip.PromotionalCodesDotNet451;

namespace WebTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public async Task<JsonResult> RedeemPromocode(string promoCode)
        {
            var key = System.Configuration.ConfigurationManager.AppSettings["promocodeKey"];
            var secret = System.Configuration.ConfigurationManager.AppSettings["promocodeSecret"];

            var promocodeManager = new PromotionCodeManager(key, secret);

            var isValid = await promocodeManager.ValidatePromoCode(promoCode);
          
            
            if(isValid)
            {
               var redeemed = await promocodeManager.RedeemPromoCode(promoCode);
                
               if(redeemed)
               {
                   var data = new { Redeemed = true, isValid = true };

                   return   Json(data, JsonRequestBehavior.AllowGet);
               }
               else
               {
                   var data = new { Redeemed = false, isValid = true };
                   return Json(data, JsonRequestBehavior.AllowGet);
               }

            }
            else
            {
                var data = new { Redeemed = false, isValid = false };
                return Json(data, JsonRequestBehavior.AllowGet);
            }

            
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}