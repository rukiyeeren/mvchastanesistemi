﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCHASTANE.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MVCHASTANEEntities : DbContext
    {
        public MVCHASTANEEntities()
            : base("name=MVCHASTANEEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tbl_bolum> tbl_bolum { get; set; }
        public virtual DbSet<tbl_doktor> tbl_doktor { get; set; }
        public virtual DbSet<tbl_giris> tbl_giris { get; set; }
        public virtual DbSet<tbl_hasta> tbl_hasta { get; set; }
        public virtual DbSet<tbl_randevu> tbl_randevu { get; set; }
        public virtual DbSet<tbl_iletisim> tbl_iletisim { get; set; }
    }
}
