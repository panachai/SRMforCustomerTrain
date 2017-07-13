using SRMforCustomer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace SRMforCustomer.Controllers {
    public class RequestsController : Controller {
        // GET: Requests
        public ActionResult Index() {
            return View();
        }

        public PartialViewResult RequestsPartial(string keyword) {

            if (string.IsNullOrEmpty(keyword)) {

                return PartialView();
            } else {

                Random generator = new Random();
                int random;
                do {
                    random = generator.Next(0, 1000000);
                } while (random < 100000);

                //checksum
                int checksumDigit = Helper.Util.CalculateCheckDigi(random.ToString());
                string randomString = random +""+ checksumDigit;

                //call service insert data to SQL_database
                //------

                var requestsModel = new RequestsModel() {
                    ReTicketID = Int32.Parse(randomString),
                    TypeRequestsID = 1,
                    StaffID = 0,
                    StatusID = 0,
                    ReTopicName = "testSRMtopic : key : " + keyword + " : endKey ",
                    ReCustomerName = "CustomerName Test",
                    ReCustomerTel = "0900000000",
                    ReEmail = "panachai.ny@gmail.com",
                    ReDetail = "adasdasd Detail it here",
                    ReDateIn = DateTime.Now,
                    ReDateOut = DateTime.Now,
                };
                
                return PartialView(requestsModel);
            }
        }


    }
}