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
    
    public partial class Comments
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comments()
        {
            this.Attachments = new HashSet<Attachments>();
        }
    
        public int CommentsId { get; set; }
        public int TicketId { get; set; }
        public Nullable<System.Guid> StaffId { get; set; }
        public string Name { get; set; }
        public System.DateTime DateCreate { get; set; }
        public string CreatedBy { get; set; }
        public string TextComment { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attachments> Attachments { get; set; }
        public virtual Requests Requests { get; set; }
    }
}
