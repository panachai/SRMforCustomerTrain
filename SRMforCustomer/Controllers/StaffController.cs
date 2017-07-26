using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRMforCustomer.Helper;
using SRMforCustomer.Models;

using System.Configuration;
using System.IO;
using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SRMforCustomer.ViewModels;

namespace SRMforCustomer.Controllers {
    //[Authorize]
    [RoutePrefix("Staff")] //[RoutePrefix("Staff")]
    public class StaffController : Controller {
        ServiceConnectDB service;

        public StaffController() {
            this.service = new ServiceConnectDB();
        }

        //[Route("")]
        //public ActionResult LoginStaffPage() {

        //    if (Session["staffModel"] != null) {
        //        return RedirectToAction("Index", "Requests");
        //    } else {
        //        return View();
        //    }
        //}

        //public ActionResult LoginStaff() {

        //    Session["staffModel"] = service.GetStaffModel(1); //testStaff

        //    ////ยิงเซอวิส where user pass ใน db เพื่อเอา record มา
        //    //List<int> recordStaff = new List<int> { };
        //    //if (recordStaff.Count > 0) {
        //    //    Session["staffModel"] = "asdasd";

        //    //}
        //    return RedirectToAction("Index", "Requests");
        //}

        //public ActionResult LogOutStaff() {
        //    Session.Clear();
        //    return RedirectToAction("LoginStaffPage", "Staff");
        //}

        //------------------------------------- NEW --------------------------------------

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl) {
            ViewData["LoginError"] = TempData["LoginError"] ?? "";
            ViewBag.ReturnUrl = returnUrl;
            string key = Membership.GeneratePassword(16, 0);
            key = Regex.Replace(key, @"[\W_-[#]]+", "A");
            Session["key1"] = key;
            ViewData["key1"] = Session["key1"];
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl) {
            string username = model.UserName;
            string password = model.Password;
            if (Session["key1"] == null) {
                return View();
            }

            FormsAuthentication.SetAuthCookie(username, true);

            LogInApplication(username);
            IdentityManagementEntities1 imcEntities = new IdentityManagementEntities1();
            //var tmpUserDetail = imcEntities.vwUserInfo.Select(s => s.Username == username);
            var tmpUserDetail = (from q in imcEntities.vwUserInfo
                                 where q.Username == username
                                 select q);
            if (tmpUserDetail.Count() > 0) {
                vwUserInfo userDetail = tmpUserDetail.FirstOrDefault();
                UserAuthen.UserName = userDetail.Username;
                UserAuthen.UserGUID = userDetail.UserGUID;
                UserAuthen.UserFullName = userDetail.Fullname;
                UserAuthen.UserRankNo = userDetail.RankTypeNo;
                UserAuthen.UserDepartmentCode = userDetail.DepartmentCode;
                UserAuthen.UserDivisionCode = userDetail.DivisionCode;
                ViewBag.UserGUID = userDetail.UserGUID;

                //Session["staffModel"] = 

                return RedirectToLocal(returnUrl);
            } else {
                TempData["LoginError"] = "ไม่สามารถเข้าระบบได้ กรุณาตรวจสอบ ใหม่อีกครั้ง";
                return RedirectToAction("Login", "Staff");
            }

            ViewData["key1"] = Session["key1"];
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff() {
            FormsAuthentication.SignOut();
            Session.Abandon();
            HttpCookie myCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            myCookie.Expires = DateTime.Now.AddYears(-1);
            myCookie.Value = null;
            Response.Cookies.Add(myCookie);
            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);
            UserAuthen.UserName = "";
            UserAuthen.UserGUID = new Guid();
            UserAuthen.UserFullName = "";
            UserAuthen.UserRankNo = 0;
            UserAuthen.UserDepartmentCode = "";
            UserAuthen.UserDivisionCode = "";
            return RedirectToAction("Login", "Staff");
        }

        public static bool LogInApplication(string userName) {
            using (IdentityManagementEntities1 imc = new IdentityManagementEntities1()) {
                string IP = System.Web.HttpContext.Current.Request.UserHostAddress;
                imc.UpdateAccessLogs(userName, ConfigurationManager.AppSettings["ApplicationName"].ToString(), IP);
                return true;
            }
        }

        private ActionResult RedirectToLocal(string returnUrl) {
            if (Url.IsLocalUrl(returnUrl)) {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Search");
        }

    }
}