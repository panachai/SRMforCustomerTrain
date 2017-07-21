using SRMforCustomer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO;
using SRMforCustomer.Helper;
using SRMforCustomer.ViewModels;
using TKSLibrary;

namespace SRMforCustomer.Controllers {
    public class RequestsController : Controller {
        ServiceConnectDB service;

        public RequestsController() {
            this.service = new ServiceConnectDB();
        }


        public ActionResult Index() {

            if (Session["staffModel"] == null) {

                using (SRMForCustomerEntities db = new SRMForCustomerEntities()) {
                    ViewBag.RequestTypeId = new SelectList(db.RequestType.ToList(), "RequestTypeId", "Name");
                }
                return View();

            } else {
                return RedirectToAction("Index", "RequestsStaff");
            }
        }

        public JsonResult RequestProcess(Requests model, HttpPostedFileBase attachment) { //รับตรง Parameter (กรณีใช้ Formdata)

            ModelState.Remove("ReTicketId"); //remove ออกจากเงื่อนไขการเช็ค IsValid
            ModelState.Remove("StaffId");
            ModelState.Remove("StatusId");
            ModelState.Remove("ReTopicName");
            ModelState.Remove("ReDateIn");
            ModelState.Remove("ReDateOut");
            if (model.RequestTypeId == 0) ModelState.AddModelError("RequestTypeId", " โปรดเลือก");
            if (ModelState.IsValid) {

                model.TicketId = GenRandomNumber();
                model.StatusId = 0;
                model.DateCreate = DateTime.Now;
                model.TopicName = "-";

                service.InsertRequests(model);

                //ยิงภาพ
                if (attachment != null) {
                    AddPicture(attachment, model.TicketId);
                }

                //using (SRMForCustomerEntities db = new SRMForCustomerEntities()) {

                //db.Configuration.ProxyCreationEnabled = false;
                //modelRequests = db.Requests.Include(i => i.RequestType).Include(i => i.Statuses).Single(s => s.TicketId == modelRequests.TicketId);
                //}


                model = service.RequestsModelALL(model.TicketId);


                ReceiveMessage(model);
                return Json(new {
                    success = true, modelRequest = new {
                        model.TicketId,
                        model.Email
                    }
                }, JsonRequestBehavior.AllowGet);

            }

            return Json(new { success = false, messageAlert = "โปรดป้อนข้อมูลที่ถูกต้อง", errors = ModelState.Where(w => w.Value.Errors.Any()).Select(s => new { s.Key, s.Value.Errors }).ToList() }, JsonRequestBehavior.AllowGet);
        }

        private void AddPicture(HttpPostedFileBase attachment, int ticket) {
            var fileSize = TKSLibrary.NumberingHelper.ToFileSizeText(attachment.ContentLength);
            var image = TKSLibrary.IOHelper.ReadToEnd(attachment.InputStream);

            string fileName = Path.GetFileNameWithoutExtension(attachment.FileName);
            string extensionName = Path.GetExtension(attachment.FileName);



            Attachments attachments = new Attachments() {
                AttachmentNo = 1,
                TicketId = ticket,
                CommentsId = null,
                AttachmentFile = image,
                AttachmentMimeType = attachment.ContentType,
                AttachmentFileName = fileName,
                AttachmentFileExtension = extensionName,
                AttachmentSize = fileSize
            };

            service.InsertAttachments(attachments);
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