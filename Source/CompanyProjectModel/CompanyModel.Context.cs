﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CompanyProjectModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class startprojectEntities : DbContext
    {
        public startprojectEntities()
            : base("name=startprojectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<T_ABOUT> T_ABOUT { get; set; }
        public virtual DbSet<T_PORTFOLIO> T_PORTFOLIO { get; set; }
        public virtual DbSet<T_SERVICE> T_SERVICE { get; set; }
        public virtual DbSet<T_TEAM> T_TEAM { get; set; }
        public virtual DbSet<T_CLIENT> T_CLIENT { get; set; }
        public virtual DbSet<T_SOSMED> T_SOSMED { get; set; }
        public virtual DbSet<T_TEAM_SOSMED> T_TEAM_SOSMED { get; set; }
    }
}