using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace SRMforCustomer.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {

            return View();
        }


        public ActionResult About() {
            ViewBag.Message = "Your application description page.";
            //อาจจะไม่ทำ
            return View();
        }


     
    }
}