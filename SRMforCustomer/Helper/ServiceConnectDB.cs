using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SRMforCustomer.Models;


namespace SRMforCustomer.Helper {
    public class ServiceConnectDB {

        public Requests RequestsModelALL(int ticket) {
            //var req = db.Requests.SingleOrDefault(s => s.TicketId == ticket);
            using (SRMForCustomerEntities db = new SRMForCustomerEntities()) {
                var req = db.Requests.Include(i => i.Statuses).Include(i => i.RequestType).Single(s => s.TicketId == ticket);
                return req;
            }

        }

        public List<Comments> CommentsMdoelformTicket(int ticket) {
            using (SRMForCustomerEntities db = new SRMForCustomerEntities()) {
               var req = db.Comments.Where(s => s.CommentsId == ticket).ToList();
                return req;
            }
        }






    }
}