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
        //ตัวอย่างกรณี ? [Route("Search/{reTicketID?}")] //public ActionResult Index(int? reTicketID) {

        public ActionResult TrainLiew(Requests model, List<string> searchs, HttpPostedFileBase image) {
            if (image != null) {
                //var imageFile = TKSLibrary.IOHelper.ReadToEnd(image.InputStream);

            }

            var requestsModel = new List<Requests>() {
                new Requests(){
                    ReTopicName = "testSRMtopic"
                },
                new Requests(){
                    ReTopicName = "testSRMtopic2"
                }
            };

            return View(requestsModel);
        }

        //[Route("{id}")]
        public ActionResult Index(int id) { //set Search to ?ticketID=_ or SearchTicket/{ticketID} with MapRoute
            //if (!id.HasValue)
            //    id = 0;

            //return Content(String.Format("TicketID2 = {0}", id));
            return View();
        }

        public ActionResult AjaxTest() {

            var requests = new Requests() { ReTopicName = "testSRMtopic" };

            return View();
        }

        //Models.RequestsModel db = new Models.RequestsModel();

        public PartialViewResult PartialViewAjax(string keyword) {
            // System.Threading.Thread.Sleep(2000);
            //var data = db.ReTopicName.Where(f => f.FirstName.Contains(keyword)).ToList();
            //var selected = db.ReTopicName.Where(t => t..Contains(keyword));
            //เก็บไว้ใช้ตอนระบบ comment เพราะตอนเซิท where ตอนยิงเซอวิส เลย

            if (keyword != "") {
                var selected = new Requests() {
                    ReTicketId = 1000000000,
                    TypeRequestsId = 1,
                    StaffId = 2,
                    ReTopicName = "testSRMtopic : key : " + keyword + " : endKey ",
                    ReCustomerName = "CustomerName Test",
                    ReCustomerTel = "0900000000",
                    ReEmail = "panachai.ny@gmail.com",
                    ReDetail = "adasdasd Detail it here",
                    ReDateIn = DateTime.Now,
                    ReDateOut = DateTime.Now,

                };
                return PartialView(selected);
            }

            return PartialView();
        }

    }
}