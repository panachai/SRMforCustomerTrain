using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRMforCustomer.Models;

namespace SRMforCustomer.Controllers {
    //[RoutePrefix("Ticket")]
    public class TrainLiewController : Controller {
        // GET: SearchTicket
        //[Route("Search")]

        public ActionResult TrainLiew(RequestsModel model, List<string> searchs, HttpPostedFileBase image) {
            if (image != null) {
                //var imageFile = TKSLibrary.IOHelper.ReadToEnd(image.InputStream);

            }

            var requestsModel = new List<RequestsModel>() {
                new RequestsModel(){
                    ReTopicName = "testSRMtopic"
                },
                new RequestsModel(){
                    ReTopicName = "testSRMtopic2"
                }
            };
            
            return View(requestsModel);
        }

        //[Route("{id}")]
        public ActionResult Index(int id) { //set Search to ?ticketID=_ or SearchTicket/{ticketID} with MapRoute
            //if (!id.HasValue)
            //    id = 0;

            return Content(String.Format("TicketID2 = {0}", id));
        }
    }
}