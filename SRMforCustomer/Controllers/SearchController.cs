using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRMforCustomer.Helper;
using SRMforCustomer.Models;

namespace SRMforCustomer.Controllers {
    public class SearchController : Controller {

        private readonly ServiceConnectDB service;

        public SearchController() {
            this.service = new ServiceConnectDB();
        }

        // GET: Search
        public ActionResult Index() {
            return View();
        }

        public PartialViewResult ResultSearchPartial(string keyword) {
            int ticketSearch;
            if (!string.IsNullOrEmpty(keyword)) {
                if (int.TryParse(keyword, out ticketSearch)) {
                    if (Helper.Util.IsValidOTP(keyword) && keyword.Length == 7) {//checksum 9700156 (test)

                        //check ในกรณีที่ search ไม่เจอด้วย
                        Requests modelRequests = service.RequestsModelALL(ticketSearch); //check ยิงเซอวิสว่าผ่านไหม mockdata ไว้ (3852671)

                        return PartialView(modelRequests);
                    } else {
                        ViewBag.ErrorChecksum = "Ticket ของท่านไม่ถูกต้อง";
                        return PartialView();
                    }
                } else {
                    ViewBag.ErrorChecksum = "โปรดป้อนเฉพาะตัวเลข";
                    return PartialView();
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