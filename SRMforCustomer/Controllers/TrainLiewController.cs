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
                    TopicName = "testSRMtopic"
                },
                new Requests(){
                    TopicName = "testSRMtopic2"
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

            var requests = new Requests() { TopicName = "testSRMtopic" };

            return View();
        }

        //Models.RequestsModel db = new Models.RequestsModel();

        public PartialViewResult PartialViewAjax(string keyword) {
            // System.Threading.Thread.Sleep(2000);
            //var data = db.ReTopicName.Where(f => f.FirstName.Contains(keyword)).ToList();
            //var selected = db.ReTopicName.Where(t => t..Contains(keyword));
            //เก็บไว้ใช้ตอนระบบ comment เพราะตอนเซิท where ตอนยิงเซอวิส เลย

            //if (keyword != "") {
            //    var selected = new Requests() {
            //        TicketId = 1000000000,
            //        RequestTypeId = 1,
            //        StaffId = 2,
            //        TopicName = "testSRMtopic : key : " + keyword + " : endKey ",
            //        CustomerName = "CustomerName Test",
            //        TelephoneNumber = "0900000000",
            //        Email = "panachai.ny@gmail.com",
            //        Remark = "adasdasd Detail it here",
            //        DateCreate = DateTime.Now,
            //        DateFinish = DateTime.Now,

            //    };
                //return PartialView(selected);
            //}

            return PartialView();
        }

    }
}