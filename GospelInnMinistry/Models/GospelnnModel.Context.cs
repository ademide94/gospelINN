﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GospelInnMinistry.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GospeLInnEntities : DbContext
    {

        public GospeLInnEntities()
            : base("name=GospeLInnEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<EventRegistration> EventRegistrations { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Medium> Media { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
    }
}
