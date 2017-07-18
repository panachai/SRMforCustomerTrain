using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.UI.WebControls;

namespace SRMforCustomer.Models {
    public class RequestMetadata {


        public int TicketId { get; set; }
        public int RequestTypeId { get; set; }
        public Nullable<int> StaffId { get; set; }
        public int StatusId { get; set; }
        public string TopicName { get; set; }
        public string CustomerName { get; set; }
        [Phone(ErrorMessage = "ป้อนเบอร์โทรศัพท์ให้ถูกต้อง")]
        public string TelephoneNumber { get; set; }


        [EmailAddress(ErrorMessage = "Email มึงผิดอะ")]
        public string Email { get; set; }

        [StringLength(13, MinimumLength = 10,ErrorMessage = "testRemark error message")]
        public string Remark { get; set; }
        public int CurrentStaffId { get; set; }
        public System.DateTime DateCreate { get; set; }









    }

    [MetadataType(typeof(RequestMetadata))]
    public partial class Requests {
        //สามารถ เพิ่ม method และ เพิ่ม properties ได้
    }
}