﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
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

        public List<Comments> CommentsModelformTicket(int ticket) {
            using (SRMForCustomerEntities db = new SRMForCustomerEntities()) {
                var req = db.Comments.Where(s => s.TicketId == ticket).ToList();
                return req;
            }
        }

        public Boolean InsertComment(Comments model) {

            using (SRMForCustomerEntities db = new SRMForCustomerEntities()) {
                var comment = new Comments();
                comment = model;
                db.Comments.Add(comment);
                db.SaveChanges();

                return true;
            }

            //true false รอเงื่อนไขว่า check database ยังไงถ้าทำงานไม่ผิดพลาด

            return false;
        }

    }
}