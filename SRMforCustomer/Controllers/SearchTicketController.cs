using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRMforCustomer.Models;

namespace SRMforCustomer.Controllers {
    public class SearchTicketController : Controller {
        // GET: SearchTicket
        public ActionResult SearchTicket() {
            var requestsModel = new RequestsModel() { ReTopicName = "testSRMtopic" };
            //ViewData["requestsModel"] = requestsModel;
            

            return View(requestsModel);
        }

        [Route("SearchTicket/{ticketID}")]
        public ActionResult Index(int? ticketID) { //set Search to ?ticketID=_ or SearchTicket/{ticketID} with MapRoute
            if (!ticketID.HasValue)
                ticketID = 0;

            return Content(String.Format("TicketID2 = {0}", ticketID));
        }
    }
}