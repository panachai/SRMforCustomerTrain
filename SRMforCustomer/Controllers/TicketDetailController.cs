using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRMforCustomer.Helper;
using SRMforCustomer.Models;

namespace SRMforCustomer.Controllers {
    [RoutePrefix("TicketDetail")]
    public class TicketDetailController : Controller {

        private readonly ServiceConnectDB service;

        public TicketDetailController() {
            this.service = new ServiceConnectDB();
        }

        // GET: TicketDetail
        [Route("{ticket?}")]
        public ActionResult Index(string ticket = null) {


            int ticketSearch;

            if (!string.IsNullOrEmpty(ticket) && ticket.Length == 7) {
                if (int.TryParse(ticket, out ticketSearch) && Helper.Util.IsValidOTP(ticket)) {

                    //ยิงเก็ทค่าจากเบส
                    Requests modelRequests = service.RequestsModelALL(ticketSearch); //check ยิงเซอวิสว่าผ่านไหม mockdata ไว้ (3852671)

                    //ยิงเรียก Comment
                    List<Comments> listComments = service.CommentsModelformTicket(ticketSearch);

                    ViewBag.listComment = listComments;
                    //ทำ comment ต่อด้วย

                    return View(modelRequests);
                }
                ViewBag.Message = "URL ของท่านผิดพลาดกรุณากลับไปค้นหาที่หน้า Search";
                return View();
            }
            ViewBag.Message = "Return to Search Page";


            return View();
        }

        [Route("SendComment/{ticket}")]
        public ActionResult SendComment(string ticket, int? staffId, string textComment) {
            Comments commentModel;

            Requests modelRequest = service.RequestsModelALL(Int32.Parse(ticket));

            if (staffId == null) {//User
                commentModel = new Comments() {
                    //CommentsId = modelRequest.
                    TicketId = modelRequest.TicketId
                    ,Name = "-"
                    ,DateCreate = DateTime.Now
                    ,CreatedBy = modelRequest.CustomerName
                    ,TextComment = textComment
                };
            }
            else { //Staff
                commentModel = new Comments() {
                    //CommentsId = modelRequest.
                    TicketId = modelRequest.TicketId
                    , StaffId = staffId
                    //, Name
                    //,DateCreate
                    //,CreatedBy
                    //,TextComment
                };
            }
            var check = service.InsertComment(commentModel);
            return RedirectToAction("Index", new {ticket = modelRequest.TicketId});
        }

    }
}