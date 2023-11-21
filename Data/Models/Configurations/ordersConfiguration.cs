﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Data.Models.Configurations
{
    public partial class ordersConfiguration : IEntityTypeConfiguration<orders>
    {
        public void Configure(EntityTypeBuilder<orders> entity)
        {
            entity.HasKey(e => e.order_id)
                .HasName("PK__orders__465962294F73E9E4");

            entity.Property(e => e.order_date)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.total_amount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.client)
                .WithMany(p => p.orders)
                .HasForeignKey(d => d.client_id)
                .HasConstraintName("FK__orders__client_i__44FF419A");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<orders> entity);
    }
}