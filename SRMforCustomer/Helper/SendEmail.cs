using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRMforCustomer.Models;

using System.Configuration;

using System.Net.Mail;


namespace SRMforCustomer.Helper {
    public class SendEmail : Controller {


        public static void ReceiveMessage(Requests modelRequests, string Request, EmailType.Type type) {



            string BodyHTML =
                    System.IO.File.ReadAllText(Request
                    + "Templates\\TemplateLetterFeedback.html");

            if (type == EmailType.Type.RequestsCustomer) {
                BodyHTML = BodyHTML.Replace("@row1", "ถึง คุณ " + modelRequests.CustomerName);
                BodyHTML = BodyHTML.Replace("@row2", "TicketID : " + modelRequests.TicketId);
                BodyHTML = BodyHTML.Replace("@row3", "ประเภทการร้องขอ : " + modelRequests.RequestType.Name);
                BodyHTML = BodyHTML.Replace("@row4", "เบอร์ : " + modelRequests.TelephoneNumber);
                BodyHTML = BodyHTML.Replace("@row5", "Email : " + modelRequests.Email);

            } else if (type == EmailType.Type.RequestsStaff) {
                BodyHTML = BodyHTML.Replace("@row1", "จาก คุณ " + modelRequests.CustomerName);
                BodyHTML = BodyHTML.Replace("@row2", "TicketID : " + modelRequests.TicketId);
                BodyHTML = BodyHTML.Replace("@row3", "ประเภทการร้องขอ : " + modelRequests.RequestType.Name);
                BodyHTML = BodyHTML.Replace("@row4", "เบอร์ : " + modelRequests.TelephoneNumber);
                BodyHTML = BodyHTML.Replace("@row5", "Email : " + modelRequests.Email);

            }


            BodyHTML = BodyHTML.Replace("@timeNow", DateTimeUtils.DateFormat(modelRequests.DateCreate));

#if DEBUG
            BodyHTML = BodyHTML.Replace("@urlDetail", "http://localhost:50714/TicketDetail/" + modelRequests.TicketId);
#else
            BodyHTML = BodyHTML.Replace("@urlDetail", "http://dev.tks.co.th/SRMForCustomer/TicketDetail/" + modelRequests.TicketId);
#endif

            MailMessage NotifyMail = new MailMessage();
            NotifyMail.From = new MailAddress(ConfigurationManager.AppSettings["MailFrom"]);
            NotifyMail.To.Add(modelRequests.Email);//thanaphan.w@prism.co.th
            NotifyMail.Subject = "SRMC : " + modelRequests.RequestType.Name + " จากคุณ " + modelRequests.CustomerName; //+ modelRequests.TopicName +
            NotifyMail.IsBodyHtml = true;
            NotifyMail.Body = BodyHTML;
            SmtpClient SMTPClient = new SmtpClient();
            SMTPClient.Host = Config.SMTPHost;
            SMTPClient.Send(NotifyMail);
        }


        public static void ReceiveComment(Comments comment, Requests requests, string Request, EmailType.Type type) {



            string BodyHTML =
                System.IO.File.ReadAllText(Request
                + "Templates\\TemplateLetterFeedback.html");

            BodyHTML = BodyHTML.Replace("@row1", "มีความคิดเห็นจาก คุณ " + comment.CreatedBy);
            BodyHTML = BodyHTML.Replace("@row2", "ความคิดเห็น : " + comment.TextComment);

            BodyHTML = BodyHTML.Replace("@timeNow", DateTimeUtils.DateFormat(comment.DateCreate));

#if DEBUG
            BodyHTML = BodyHTML.Replace("@urlDetail", "http://localhost:50714/TicketDetail/" + comment.TicketId);
#else
            BodyHTML = BodyHTML.Replace("@urlDetail", "http://dev.tks.co.th/SRMForCustomer/TicketDetail/" + comment.TicketId);
#endif

            MailMessage NotifyMail = new MailMessage();
            NotifyMail.From = new MailAddress(ConfigurationManager.AppSettings["MailFrom"]);

            if (type == EmailType.Type.CommentCustomer) {
                NotifyMail.To.Add(requests.Email);

            } else if (type == EmailType.Type.CommentStaff) {

                //เดี๋ยวเขียน updatecurrentStaff


                //if (requests.CurrentStaffId != null) {
                    ServiceConnectDB service = new ServiceConnectDB();
                    var staffemail = service.GetEmailStaff(requests.CurrentStaffId);
                //}

                NotifyMail.To.Add(staffemail);



            }


            NotifyMail.Subject = "SRMC : " + "มีความคิดเห็นจาก คุณ " + comment.CreatedBy;

            NotifyMail.IsBodyHtml = true;
            NotifyMail.Body = BodyHTML;
            SmtpClient SMTPClient = new SmtpClient();
            SMTPClient.Host = Config.SMTPHost;
            SMTPClient.Send(NotifyMail);

        }
    }
}