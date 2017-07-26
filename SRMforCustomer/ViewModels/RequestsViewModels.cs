using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SRMforCustomer.Models;

namespace SRMforCustomer.ViewModels {
    public class RequestsViewModels {
        //ใช้สำหรับหน้าใดหน้านึง เอาไว้แต่ง Models ตอนโยนเข้าออก

        public Requests RequestsModel { get; set; }

        public Attachments AttachmentsModel { get; set; }

    }
}