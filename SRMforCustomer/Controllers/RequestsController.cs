using SRMforCustomer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace SRMforCustomer.Controllers {
    public class RequestsController : Controller {
        // GET: Requests
        public ActionResult Index() {
            return View();
        }


        public JsonResult RequestProcess(Requests modelRequests) {
            ModelState.Remove("ReTicketId"); //remove ออกจากเงื่อนไขการเช็ค IsValid
            ModelState.Remove("StaffId");
            ModelState.Remove("StatusId");
            ModelState.Remove("ReTopicName");
            ModelState.Remove("ReDateIn");
            ModelState.Remove("ReDateOut");

            if (ModelState.IsValid) {

                modelRequests.TicketId = GenRandomNumber();
                modelRequests.StatusId = 0;
                modelRequests.DateCreate = DateTime.Now;
                modelRequests.TopicName = "-";

                InsertRequests(modelRequests);
                using (SRMForCustomerEntities1 db = new SRMForCustomerEntities1()) {
                    var reqType = db.RequestType.SingleOrDefault(s => s.RequestTypeId == modelRequests.RequestTypeId);
                    modelRequests.RequestType = reqType;

                    //modelRequests = db.Requests.Single(s => s.TicketId == modelRequests.TicketId);
                }

                ReceiveMessage(modelRequests);

                return Json(new { success = true, ticketid = modelRequests.TicketId.ToString() }, JsonRequestBehavior.AllowGet);

            }

            return Json(new { success = false, messageAlert = "โปรดป้อนข้อมูลที่ถูกต้อง", errors = ModelState.Where(w => w.Value.Errors.Any()).Select(s => new { s.Key, s.Value.Errors }).ToList() }, JsonRequestBehavior.AllowGet);
        }

        public void InsertRequests(Requests model) {
            using (SRMForCustomerEntities1 db = new SRMForCustomerEntities1()) {
                db.Requests.Add(model);
                db.SaveChanges();
            }
        }
        
        private void ReceiveMessage(Requests modelRequests) {
            string BodyHTML =
                    System.IO.File.ReadAllText(Request.PhysicalApplicationPath +
                                               "Templates\\TemplateLetterFeedback.html");
            BodyHTML = BodyHTML.Replace("@reticketId", modelRequests.TicketId.ToString());
           BodyHTML = BodyHTML.Replace("@typeRequestsId", modelRequests.RequestType.ToString()); //เดี๋ยวเขียนเพิ่มใน DB แล้วเขียน viewmodel ดึงค่ามา
            BodyHTML = BodyHTML.Replace("@reCustomerName", modelRequests.CustomerName);
            BodyHTML = BodyHTML.Replace("@reCustomerTel", modelRequests.TelephoneNumber);
            BodyHTML = BodyHTML.Replace("@reEmail", modelRequests.Email);
            BodyHTML = BodyHTML.Replace("@reDetail", modelRequests.Remark);

            MailMessage NotifyMail = new MailMessage();
            NotifyMail.From = new MailAddress(ConfigurationManager.AppSettings["MailFrom"]);
            NotifyMail.To.Add(modelRequests.Email);//thanaphan.w@prism.co.th
            NotifyMail.Subject = "SRMforCustomer : " + modelRequests.RequestType + " จากคุณ " + modelRequests.CustomerName; //+ modelRequests.TopicName +
            NotifyMail.IsBodyHtml = true;
            NotifyMail.Body = BodyHTML;
            SmtpClient SMTPClient = new SmtpClient();
            SMTPClient.Host = Config.SMTPHost;
            SMTPClient.Send(NotifyMail);
        }


        public int GenRandomNumber() {
            //if (string.IsNullOrEmpty(keyword)) {
            //    return PartialView();
            //}
            //else {
            Random generator = new Random();
            int random;
            do {
                random = generator.Next(0, 1000000);
            } while (random < 100000);

            //checksum
            int checksumDigit = Helper.Util.CalculateCheckDigi(random.ToString());
            int randomValue = Int32.Parse(random + "" + checksumDigit);

            //var requestsModel = new RequestsModel() {
            //    ReTicketID = Int32.Parse(randomString),
            //    TypeRequestsID = 1,
            //    StaffID = 0,
            //    StatusID = 0,
            //    ReTopicName = "testSRMtopic : key : " + keyword + " : endKey ",
            //    ReCustomerName = "CustomerName Test",
            //    ReCustomerTel = "0900000000",
            //    ReEmail = "panachai.ny@gmail.com",
            //    ReDetail = "adasdasd Detail it here",
            //    ReDateIn = DateTime.Now,
            //    ReDateOut = DateTime.Now,
            //};

            return randomValue;
            //}
        }
    }
}