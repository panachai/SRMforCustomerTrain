using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SRMforCustomer.Controllers {
    public class TicketDetailController : Controller {
        // GET: TicketDetail
        public ActionResult Index(string ticket) {
            int ticketSearch;

            if (!string.IsNullOrEmpty(ticket) && ticket.Length == 7) {
                if (int.TryParse(ticket, out ticketSearch) && Helper.Util.IsValidOTP(ticket)) {

                    //ยิงเก็ทค่าจากเบส



                    //show model

                    ViewBag.testTicket = ticket;
                    return View();
                }
                ViewBag.Message = "URL ของท่านผิดพลาดกรุณากลับไปค้นหาที่หน้า Search";
                return View();
            }
            ViewBag.Message = "Return to Search Page";


            return View();
        }
    }
}