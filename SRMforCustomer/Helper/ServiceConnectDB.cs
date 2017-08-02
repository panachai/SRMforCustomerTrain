using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using SRMforCustomer.Models;


namespace SRMforCustomer.Helper {
    public class ServiceConnectDB {

        public void InsertRequests(Requests model) {
            using (SRMForCustomerEntities db = new SRMForCustomerEntities()) {
                db.Requests.Add(model);
                db.SaveChanges();
            }
        }

        public Requests RequestsModelALL(int ticket) {
            //var req = db.Requests.SingleOrDefault(s => s.TicketId == ticket);
            using (SRMForCustomerEntities db = new SRMForCustomerEntities()) {
                var req = db.Requests.Include(i => i.Statuses).Include(i => i.RequestType).SingleOrDefault(s => s.TicketId == ticket);

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

        public Boolean InsertAttachments(Attachments attachmentsModel) {

            using (SRMForCustomerEntities db = new SRMForCustomerEntities()) {
                //var attachments = new Attachments();
                //attachments = attachmentsModel;
                db.Attachments.Add(attachmentsModel);
                //ดัก try ioexception ได้
                db.SaveChanges();

                return true;
            }
            return false;
        }

        public List<Attachments> GetAttachments(int ticket) {
            using (SRMForCustomerEntities db = new SRMForCustomerEntities()) {
                var attach = db.Attachments.Where(s => s.TicketId == ticket).ToList();
                return attach;
            }
        }

        public void UpdateCurrentStaff(Requests model) {
            using (SRMForCustomerEntities db = new SRMForCustomerEntities()) {
                //db.Users.Attach(updatedUser);
                //var entry = db.Entry(updatedUser);
                //entry.Property(e => e.Email).IsModified = true;
                //// other changed properties
                //db.SaveChanges();

                db.Requests.Attach(model);
                var entry = db.Entry(model);
                entry.Property(e => e.CurrentStaffId).IsModified = true;
                db.SaveChanges();

            }
        } //ทำต่อด้วย



        public string GetEmailStaff(Guid? staffGuid) {
            using (IdentityManagementEntities1 db = new IdentityManagementEntities1()) {
                var req = db.vwUserInfo.SingleOrDefault(s => s.UserGUID == staffGuid);

                if (req != null) {
                    return req.Email;

                } else {
                    return null;
                }

            }

        }
    }
}