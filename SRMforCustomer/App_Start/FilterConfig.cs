using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRMforCustomer.Models;

namespace SRMforCustomer {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new StaffAuthentication());
        }
    }

    public class StaffAuthentication : IActionFilter {
        public void OnActionExecuted(ActionExecutedContext filterContext) {
        }

        public void OnActionExecuting(ActionExecutingContext filterContext) {
            var httpContext = filterContext.RequestContext.HttpContext;
            if (httpContext.Request.IsAuthenticated && httpContext.Session["staffModel"] == null) {
                using (IdentityManagementEntities1 imcEntities = new IdentityManagementEntities1()) {
                    var info = imcEntities.vwUserInfo.SingleOrDefault(s => s.Username == httpContext.User.Identity.Name);
                    if(info != null) {
                        filterContext.HttpContext.Session["staffModel"] = new StaffModel {
                            UserName = info.Username,
                            UserGUID = info.UserGUID,
                            UserFullName = info.Fullname,
                            UserRankNo = info.RankTypeNo,
                            UserDepartmentCode = info.DepartmentCode,
                            UserDivisionCode = info.DivisionCode
                        };
                    }
                }
            }
        }
    }
}
