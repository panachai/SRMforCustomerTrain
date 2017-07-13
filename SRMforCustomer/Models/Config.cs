using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SRMforCustomer.Models {
    public class Config {
        private static string _SMTPHost;
        private static string _DeveloperEmail;
        public static string SMTPHost {
            get {
                if (_SMTPHost == null) {
                    _SMTPHost = System.Configuration.ConfigurationManager.AppSettings["SMTPHost"];
                }
                return _SMTPHost;
            }
        }
        public static string DeveloperEmail {
            get {
                if (_DeveloperEmail == null) {
                    _DeveloperEmail = System.Configuration.ConfigurationManager.AppSettings["DeveloperEmail"];
                }
                return _DeveloperEmail;
            }
        }
    }
}
