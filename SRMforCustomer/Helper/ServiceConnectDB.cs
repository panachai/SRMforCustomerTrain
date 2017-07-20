using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SRMforCustomer.Models;


namespace SRMforCustomer.Helper {
    public class ServiceConnectDB {
        private static SRMForCustomerEntities1 db = new SRMForCustomerEntities1();

        public static Requests RequestsModelALL(int ticket) {

            //int ticketSearch =  Int32.Parse(ticket);

            var req = db.Requests.SingleOrDefault(s => s.TicketId == ticket);

            return req;
        }

    }
}