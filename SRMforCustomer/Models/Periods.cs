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
    
    public partial class Periods
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Periods()
        {
            this.PeriodDetails = new HashSet<PeriodDetails>();
            this.UserInPeriods = new HashSet<UserInPeriods>();
        }
    
        public int PeriodId { get; set; }
        public string PeriodName { get; set; }
        public string PeriodName_EN { get; set; }
        public Nullable<int> HolidayGroupId { get; set; }
        public Nullable<int> SpecialShiftId { get; set; }
        public Nullable<int> SpecialShiftTypeId { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string CreatedByUsername { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public string ModifiedByUsername { get; set; }
        public bool IsActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PeriodDetails> PeriodDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserInPeriods> UserInPeriods { get; set; }
    }
}
