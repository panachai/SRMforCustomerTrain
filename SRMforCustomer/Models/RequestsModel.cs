using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRMforCustomer.Models {
    public class RequestsModel {
        public int ReTicketID { get; set; }
        public int TypeRequestsID { get; set; }
        public int StaffID { get; set; }
        public string ReTopicName { get; set; }
        public string ReCustomerName { get; set; }
        public string ReCustomerTel { get; set; }
        public string ReEmail { get; set; }
        public string ReDetail { get; set; }
        public DateTime ReDateIn { get; set; }
        public DateTime ReDateOut { get; set; }
    }
}