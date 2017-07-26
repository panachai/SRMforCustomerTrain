using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRMforCustomer.Helper {
    public class UserAuthen {
        public static string UserName { get; set; }
        public static Guid UserGUID { get; set; }
        public static string UserFullName { get; set; }
        public static int UserRankNo { get; set; }
        public static string UserDepartmentCode { get; set; }
        public static string UserDivisionCode { get; set; }
    }
}