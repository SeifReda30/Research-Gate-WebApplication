﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication13.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ResearchGateEntities : DbContext
    {
        public ResearchGateEntities()
            : base("name=ResearchGateEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Paper> Papers { get; set; }
        public virtual DbSet<Reaction> Reactions { get; set; }
    }
}