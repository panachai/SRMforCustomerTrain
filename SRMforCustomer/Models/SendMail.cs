using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRMforCustomer.Models {
    public class SendMail {
        public class MessageViewModel {
            public string name { get; set; }
            public string needhelp { get; set; }
            public string phone { get; set; }
            public string email { get; set; }
            public string detail { get; set; }
            public string Success { get; set; }
        }
    }
}