﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FoodOrderApp_Test.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OrderAppEntities2 : DbContext
    {
        public OrderAppEntities2()
            : base("name=OrderAppEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<PRODUCT> PRODUCTs { get; set; }
        public virtual DbSet<RECEIPT> RECEIPTs { get; set; }
        public virtual DbSet<RECEIPT_DETAIL> RECEIPT_DETAIL { get; set; }
        public virtual DbSet<USER> USERS { get; set; }
    }
}