using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SRMforCustomer.Controllers {
    public class RequestsStaffController : Controller {
        // GET: RequestsStaff
        public ActionResult Index() {
            if (string.IsNullOrEmpty(Session["userStaff"].ToString())) {

            }

            return View();
        }

        public ActionResult LoginStaff() {

            //ยิงเซอวิส where user pass ใน db เพื่อเอา record มา
            List<int> recordStaff = new List<int> { };
            if (recordStaff.Count > 0) {
                Session["userStaff"] = "asdasd";

            }


            return View();
        }
    }
}