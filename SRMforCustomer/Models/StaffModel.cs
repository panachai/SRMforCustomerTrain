using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SRMforCustomer.Models {
    public class StaffModel {
      
        public string UserName { get; set; }
        public Guid UserGUID { get; set; }
        public string UserFullName { get; set; }
        public int UserRankNo { get; set; }
        public string UserDepartmentCode { get; set; }
        public string UserDivisionCode { get; set; }
    }
}