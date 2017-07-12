using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRMforCustomer.Models;

namespace SRMforCustomer.Controllers {
    public class SearchController : Controller {
        // GET: Search
        public ActionResult Index() {
        

            return View();
        }

        void CheckTicket(int? reTicketID) {
            if (reTicketID != null) {
                var requestsModel = new List<RequestsModel>() {
                    new RequestsModel(){
                        ReTopicName = "testSRMtopic"
                    },
                    new RequestsModel(){
                        ReTopicName = "testSRMtopic2"
                    }
                };

                //return View(requestsModel);

            }
        }
    }
}