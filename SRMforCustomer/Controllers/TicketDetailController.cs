using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SRMforCustomer.Controllers {
    public class TicketDetailController : Controller {
        // GET: TicketDetail
        public ActionResult Index(int? ticket) {
            if (ticket != null) {

                //show model

                ViewBag.testTicket = ticket;
                return View();
            }
            ViewBag.Message = "Return to Search Page";
            

            return View();
        }
    }
}