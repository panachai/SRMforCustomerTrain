using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRMforCustomer.Helper;
using SRMforCustomer.Models;

namespace SRMforCustomer.Controllers {
    public class TicketDetailController : Controller {
        // GET: TicketDetail
        public ActionResult Index(string ticket) {
            int ticketSearch;

            if (!string.IsNullOrEmpty(ticket) && ticket.Length == 7) {
                if (int.TryParse(ticket, out ticketSearch) && Helper.Util.IsValidOTP(ticket)) {

                    //ยิงเก็ทค่าจากเบส
                   Requests modelRequests = ServiceConnectDB.RequestsModelALL(3852671); //check ยิงเซอวิสว่าผ่านไหม mockdata ไว้ (3852671)

                    ViewBag.testTicket = ticket;

                    return View(modelRequests);
                }
                ViewBag.Message = "URL ของท่านผิดพลาดกรุณากลับไปค้นหาที่หน้า Search";
                return View();
            }
            ViewBag.Message = "Return to Search Page";


            return View();
        }
    }
}