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
    
    public partial class MeetingDetails
    {
        public int MeetingDetailId { get; set; }
        public Nullable<int> MeetingId { get; set; }
        public Nullable<int> MeetingGroupId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> TimeIn { get; set; }
        public Nullable<System.DateTime> TimeOut { get; set; }
        public string StatusParticipate { get; set; }
    
        public virtual MeetingGroups MeetingGroups { get; set; }
        public virtual Meetings Meetings { get; set; }
        public virtual UserInfo UserInfo { get; set; }
    }
}
