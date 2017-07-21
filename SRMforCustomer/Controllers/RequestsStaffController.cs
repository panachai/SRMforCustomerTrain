using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRMforCustomer.Helper;
using SRMforCustomer.Models;

using System.Configuration;
using System.Net.Mail;

namespace SRMforCustomer.Controllers {
    public class RequestsStaffController : Controller {
        ServiceConnectDB service;

        public RequestsStaffController() {
            this.service = new ServiceConnectDB();
        }

        public ActionResult Index() {


            if (Session["staffModel"] == null) {
                return RedirectToAction("LoginStaffPage", "RequestsStaff");
                //return View();
            } else {
                ViewBag.staffModelSession = (Staff)Session["staffModel"];

                using (SRMForCustomerEntities db = new SRMForCustomerEntities()) {
                    ViewBag.RequestTypeId = new SelectList(db.RequestType.ToList(), "RequestTypeId", "Name");
                }
                return View();
            }
        }

        public ActionResult LoginStaffPage() {


            if (Session["staffModel"] != null) {
                //return RedirectToAction("Index", "RequestsStaff", new { username = Session["username"].ToString() });
                return RedirectToAction("Index", "RequestsStaff");
                //return View();

            } else {
                return View();
            }
        }

        public ActionResult LoginStaff() {

            Session["staffModel"] = service.GetStaffModel(1); //testStaff

            ////ยิงเซอวิส where user pass ใน db เพื่อเอา record มา
            //List<int> recordStaff = new List<int> { };
            //if (recordStaff.Count > 0) {
            //    Session["staffModel"] = "asdasd";

            //}
            return RedirectToAction("LoginStaffPage", "RequestsStaff");
        }

        public ActionResult LogOutStaff() {
            Session.Clear();
            return RedirectToAction("LoginStaffPage", "RequestsStaff");
        }


        public JsonResult RequestProcess(Requests modelRequests)
        {

            var staffmodel =(Staff)Session["staffModel"];


            ModelState.Remove("ReTicketId"); //remove ออกจากเงื่อนไขการเช็ค IsValid
            ModelState.Remove("StaffId");
            ModelState.Remove("StatusId");
            ModelState.Remove("ReTopicName");
            ModelState.Remove("ReDateIn");
            ModelState.Remove("ReDateOut");
            if (modelRequests.RequestTypeId == 0) ModelState.AddModelError("RequestTypeId", " โปรดเลือก");
            if (ModelState.IsValid) {

                modelRequests.TicketId = GenRandomNumber();
                modelRequests.StatusId = 0;
                modelRequests.DateCreate = DateTime.Now;
                modelRequests.TopicName = "-";
                modelRequests.StaffId = staffmodel.StaffId;

                service.InsertRequests(modelRequests);

                modelRequests = service.RequestsModelALL(modelRequests.TicketId);


                ReceiveMessage(modelRequests);
                return Json(new {
                    success = true, modelRequest = new {
                        modelRequests.TicketId,
                        modelRequests.Email
                    }
                }, JsonRequestBehavior.AllowGet);

            }

            return Json(new { success = false, messageAlert = "โปรดป้อนข้อมูลที่ถูกต้อง", errors = ModelState.Where(w => w.Value.Errors.Any()).Select(s => new { s.Key, s.Value.Errors }).ToList() }, JsonRequestBehavior.AllowGet);
        }



        private void ReceiveMessage(Requests modelRequests) {
            string BodyHTML =
                System.IO.File.ReadAllText(Request.PhysicalApplicationPath +
                                           "Templates\\TemplateLetterFeedback.html");
            BodyHTML = BodyHTML.Replace("@reticketId", modelRequests.TicketId.ToString());
            BodyHTML = BodyHTML.Replace("@typeRequestsId", modelRequests.RequestType.Name);//เดี๋ยวเขียนเพิ่มใน DB แล้วเขียน viewmodel ดึงค่ามา
            BodyHTML = BodyHTML.Replace("@reCustomerName", modelRequests.CustomerName);
            BodyHTML = BodyHTML.Replace("@reCustomerTel", modelRequests.TelephoneNumber);
            BodyHTML = BodyHTML.Replace("@reEmail", modelRequests.Email);
            BodyHTML = BodyHTML.Replace("@reDetail", modelRequests.Remark);
            BodyHTML = BodyHTML.Replace("@timeNow", DateTimeUtils.DateFormat(modelRequests.DateCreate));


            MailMessage NotifyMail = new MailMessage();
            NotifyMail.From = new MailAddress(ConfigurationManager.AppSettings["MailFrom"]);
            NotifyMail.To.Add(modelRequests.Email);//thanaphan.w@prism.co.th
            NotifyMail.Subject = "SRMforCustomer : " + modelRequests.RequestType.Name + " จากคุณ " + modelRequests.CustomerName; //+ modelRequests.TopicName +
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

            return randomValue;
            //}
        }









    }
}