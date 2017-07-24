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

        [Required]
        public int TicketId { get; set; }
        [Required(ErrorMessage = "กรุณาเลือกประเภทการร้องขอ")]
        public int RequestTypeId { get; set; }

        public Nullable<int> StaffId { get; set; }
        [Required]
        public int StatusId { get; set; }
        //[Required]
        //[StringLength(250, MinimumLength = 3, ErrorMessage = "ป้อนไม่ถูกต้อง")]
        public string TopicName { get; set; }
        [Required(ErrorMessage = "กรุณากรอกชื่อของท่าน")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "ป้อนชื่อตั้งแต่ 5 ถึง 100ตัวอักษร")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "กรุณากรอกเบอร์โทรศัพท์")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "กรอกอย่างน้อย 10ตัวอักษร")]
        //[Phone(ErrorMessage = "กรุณากรอกเบอร์โทรศัพท์")]
        //[DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(^[0][0-9]{8,9})" , ErrorMessage =  "โปรดกรอกให้ถูกต้อง")]
        public string TelephoneNumber { get; set; }
        [Required(ErrorMessage = "กรุณากรอก Email")]
        [EmailAddress(ErrorMessage = "Email ของท่านไม่ถูกต้อง")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "กรอก Email ตั้งแต่ 5 ถึง 50ตัวอักษร")]
        public string Email { get; set; }
        [Required(ErrorMessage = "กรุณากรอกรายละเอียด")]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "กรอกอย่างน้อย 10 ตัวอักษร แต่ไม่เกิน 2000ตัวอักษร")]
        public string Remark { get; set; }
        
        public int CurrentStaffId { get; set; }
        [Required]
        public System.DateTime DateCreate { get; set; }


    

}

    [MetadataType(typeof(RequestMetadata))]
    public partial class Requests {
        //สามารถ เพิ่ม method และ เพิ่ม properties ได้
        //.jpg", ".jpeg", ".bmp", ".gif", ".png", ".pdf"

        //[FileExtensions(Extensions = "jpg,jpeg,bmp,gif,png", ErrorMessage = "Please upload picture format (Support jpg bmp gif png")]
        public HttpPostedFileBase AttachmentFile { get; set; }
    }
}