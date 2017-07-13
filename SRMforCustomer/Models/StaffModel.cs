using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRMforCustomer.Models {
    public class StaffModel {

        //ไม่ได้ใช้ user pass สามารถนำไป where ใน db ได้เลย (ลืม)
        public int StaffID { get; set; }
        public string StaffName { get; set; }
        public string StaffPosition { get; set; }
        public string StaffUser { get; set; }
        public string StaffPass { get; set; }
    }
}