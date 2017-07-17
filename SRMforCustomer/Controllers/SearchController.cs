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
            if (!string.IsNullOrEmpty(keyword)) {
                if (Helper.Util.IsValidOTP(keyword) && keyword.Length == 7) {//checksum 9700156 (test)
                    //ยิงเซอร์วิสเอาข้อมูล 1model ยัดใส่ด้านล่าง

                    var selected = new Requests() {
                        ReTicketId = 1000000000,
                        StatusId = 0,
                        ReTopicName = "testSRMtopic : key : " + keyword + " : endKey ",
                        ReCustomerName = "CustomerName Test",
                        ReCustomerTel = "0900000000",
                        ReEmail = "panachai.ny@gmail.com",
                        ReDetail = "adasdasd Detail it here",
                        ReDateIn = DateTime.Now,
                        ReDateOut = DateTime.Now,

                    };
                    return PartialView(selected);
                } else {
                    ViewBag.ErrorChecksum = "Ticket ของท่านไม่ถูกต้อง";
                }


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