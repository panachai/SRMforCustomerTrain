using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRMforCustomer.Models;

namespace SRMforCustomer.Controllers
{
    public class SearchTicketController : Controller
    {
        // GET: SearchTicket
        public ActionResult SearchTicket()
        {
            var RequestsModel = new RequestsModel() { ReTopicName = "testSRMtopic" };
            return View(RequestsModel);
        }

        public ActionResult Index(int? ticketID) { //set Search to ?ticketID=_
            if (!ticketID.HasValue)
                ticketID = 0;

            return Content(String.Format("TicketID = {0}", ticketID));
        }
    }
}