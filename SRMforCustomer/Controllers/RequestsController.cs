using SRMforCustomer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SRMforCustomer.Controllers
{
    public class RequestsController : Controller
    {
        // GET: Requests
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult receiveMessage(SendMail.MessageViewModel Model) {
            if (ModelState.IsValid) {
                string BodyHTML = System.IO.File.ReadAllText(Request.PhysicalApplicationPath + "Templates\\TemplateLetterFeedback.html");
                BodyHTML = BodyHTML.Replace("@fullname", Model.name);
                BodyHTML = BodyHTML.Replace("@email", Model.email);
                BodyHTML = BodyHTML.Replace("@phone", Model.phone);
                BodyHTML = BodyHTML.Replace("@word1", Model.detail);
                MailMessage NotifyMail = new MailMessage();
                var a = ConfigurationManager.AppSettings["MailFrom"];
                NotifyMail.From = new MailAddress(ConfigurationManager.AppSettings["MailFrom"]);
                NotifyMail.To.Add("thanaphan.w@prism.co.th");
                NotifyMail.Subject = "Venio : Feedback";
                NotifyMail.IsBodyHtml = true;
                NotifyMail.Body = BodyHTML;
                SmtpClient SMTPClient = new SmtpClient();
                SMTPClient.Host = Config.SMTPHost;
                SMTPClient.Send(NotifyMail);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            Model.Success = "false";
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}