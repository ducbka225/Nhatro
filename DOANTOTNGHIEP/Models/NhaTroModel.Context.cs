﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DOANTOTNGHIEP.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NhaTroEntities : DbContext
    {
        public NhaTroEntities()
            : base("name=NhaTroEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Admin> Admin { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<NeedFor> NeedFor { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<Street> Street { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<SaveProduct> SaveProduct { get; set; }
    }
}
