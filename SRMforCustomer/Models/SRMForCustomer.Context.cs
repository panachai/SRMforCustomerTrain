﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SRMForCustomerEntities : DbContext
    {
        public SRMForCustomerEntities()
            : base("name=SRMForCustomerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Pictures> Pictures { get; set; }
        public virtual DbSet<Requests> Requests { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Statuses> Statuses { get; set; }
        public virtual DbSet<TypeRequests> TypeRequests { get; set; }
    }
}
