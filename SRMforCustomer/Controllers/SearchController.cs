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
            int ticketSearch;
            if (!string.IsNullOrEmpty(keyword)) {
                if (int.TryParse(keyword, out ticketSearch)) {
                    if (Helper.Util.IsValidOTP(keyword) && keyword.Length == 7) {//checksum 9700156 (test)

                        //ยิงเซอร์วิสเอาข้อมูล 1model ยัดใส่ด้านล่าง

                        var selected = new Requests() {
                            TicketId = 1000000,
                            StatusId = 0,
                            TopicName = "testSRMtopic : key : " + keyword + " : endKey ",
                            CustomerName = "CustomerName Test",
                            TelephoneNumber = "0900000000",
                            Email = "panachai.ny@gmail.com",
                            Remark = "adasdasd Detail it here",
                            DateCreate = DateTime.Now,
                            DateFinish = DateTime.Now,

                        };
                        return PartialView(selected);
                    } else {
                        ViewBag.ErrorChecksum = "Ticket ของท่านไม่ถูกต้อง";
                        return PartialView();
                    }
                } else {
                    ViewBag.ErrorChecksum = "โปรดป้อนเฉพาะตัวเลข";
                    return PartialView();
                }
                ViewBag.ErrorChecksum = "โปรดป้อนข้อมูล";

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