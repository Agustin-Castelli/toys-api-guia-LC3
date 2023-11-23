﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Data.Models.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
#nullable disable

namespace Data.Models
{
    public partial class toystoreContext : DbContext
    {
        public toystoreContext()
        {
        }

        public toystoreContext(DbContextOptions<toystoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<categories> categories { get; set; }
        public virtual DbSet<order_line> order_line { get; set; }
        public virtual DbSet<orders> orders { get; set; }
        public virtual DbSet<roles> roles { get; set; }
        public virtual DbSet<toys> toys { get; set; }
        public virtual DbSet<users> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.categoriesConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.order_lineConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ordersConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.rolesConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.toysConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.usersConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
