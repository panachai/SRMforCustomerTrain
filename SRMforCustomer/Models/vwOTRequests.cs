//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SRMforCustomer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class vwOTRequests
    {
        public int OTRequestId { get; set; }
        public string Username { get; set; }
        public System.DateTime TimeStart { get; set; }
        public System.DateTime TimeEnd { get; set; }
        public double TotalHours { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string ApprovedByUsername { get; set; }
        public string CurrentApprovalUsername { get; set; }
        public string CreatedByUsername { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string ModifiedByUsername { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string Fullname { get; set; }
        public string ApprovedByFullname { get; set; }
        public string StatusName { get; set; }
        public double Rate { get; set; }
    }
}
