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

        public PartialViewResult ResultSearchPartial(string keyword) {
            if (keyword != "") {

                //checksum

                //ยิงเซอร์วิสเอาข้อมูล 1model ยัดใส่ด้านล่าง

                var selected = new RequestsModel() {
                    ReTicketID = 1000000000,
                    StatusID = 0,
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


        //void CheckTicket(int? reTicketID) {
        //    if (reTicketID != null) {
        //        var requestsModel = new List<RequestsModel>() {
        //            new RequestsModel(){
        //                ReTopicName = "testSRMtopic"
        //            },
        //            new RequestsModel(){
        //                ReTopicName = "testSRMtopic2"
        //            }
        //        };

        //        //return View(requestsModel);

        //    }
        //}
    }
}