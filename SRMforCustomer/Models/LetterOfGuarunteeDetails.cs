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
    
    public partial class LetterOfGuarunteeDetails
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public int TypeId { get; set; }
        public Nullable<System.DateTime> DateWage { get; set; }
        public double Money { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> Reason { get; set; }
        public string Remark { get; set; }
    
        public virtual LetterOfGuaruntees LetterOfGuaruntees { get; set; }
        public virtual MasterTypes MasterTypes { get; set; }
        public virtual MasterTypes MasterTypes1 { get; set; }
    }
}
