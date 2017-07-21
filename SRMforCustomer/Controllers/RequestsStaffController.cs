using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SRMforCustomer.Controllers {
    public class RequestsStaffController : Controller {
        // GET: RequestsStaff
        public ActionResult Index() {
            if (Session["staffId"] == null) {
                //return RedirectToAction("LoginStaffPage", "RequestsStaff");
                return View();

            } else {
                return View();
            }
        }

        public ActionResult LoginStaffPage() {


            if (Session["staffId"] != null) {
                //return RedirectToAction("Index", "RequestsStaff", new { username = Session["username"].ToString() });
                return View();

            } else {
                return View();
            }

        }


        private void LoginStaff() {


            //ยิงเซอวิส where user pass ใน db เพื่อเอา record มา
            List<int> recordStaff = new List<int> { };
            if (recordStaff.Count > 0) {
                Session["staffId"] = "asdasd";

            }

        }
    }
}