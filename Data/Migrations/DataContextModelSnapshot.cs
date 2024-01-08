﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("Data.Models.Category", b =>
                {
                    b.Property<int>("CategoryCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("category_code");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("CategoryCode"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("category_name");

                    b.Property<bool?>("State")
                        .HasColumnType("boolean")
                        .HasColumnName("state");

                    b.HasKey("CategoryCode");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("Data.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("order_id");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("OrderId"));

                    b.Property<int?>("ClientId")
                        .IsRequired()
                        .HasColumnType("integer")
                        .HasColumnName("client_id");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("order_date");

                    b.Property<bool?>("State")
                        .HasColumnType("boolean")
                        .HasColumnName("state");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric")
                        .HasColumnName("total_amount");

                    b.HasKey("OrderId");

                    b.HasIndex("ClientId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("Data.Models.OrderLine", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("integer")
                        .HasColumnName("order_id")
                        .HasColumnOrder(0);

                    b.Property<int>("OrderLineId")
                        .HasColumnType("integer")
                        .HasColumnName("order_line_id")
                        .HasColumnOrder(1);

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("numeric")
                        .HasColumnName("sub_total");

                    b.Property<int?>("ToyCode")
                        .HasColumnType("integer")
                        .HasColumnName("toy_code");

                    b.Property<bool?>("Wrapped")
                        .HasColumnType("boolean")
                        .HasColumnName("wrapped");

                    b.HasKey("OrderId", "OrderLineId");

                    b.HasIndex("ToyCode");

                    b.ToTable("ordersLines");
                });

            modelBuilder.Entity("Data.Models.PriceHistory", b =>
                {
                    b.Property<int>("HistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("history_id");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("HistoryId"));

                    b.Property<DateTime>("ChangeDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("change_date");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<int?>("ToyCode")
                        .HasColumnType("integer")
                        .HasColumnName("toy_code");

                    b.HasKey("HistoryId");

                    b.HasIndex("ToyCode");

                    b.ToTable("priceHistories");
                });

            modelBuilder.Entity("Data.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("role_id");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("role_name");

                    b.HasKey("RoleId");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("Data.Models.Toy", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("code");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Code"));

                    b.Property<int?>("CategoryId")
                        .IsRequired()
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<bool?>("State")
                        .HasColumnType("boolean")
                        .HasColumnName("state");

                    b.Property<int>("Stock")
                        .HasColumnType("integer")
                        .HasColumnName("stock");

                    b.Property<int>("StockThreshold")
                        .HasColumnType("integer")
                        .HasColumnName("stock_threshold");

                    b.Property<byte[]>("ToyImg")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("toy_img");

                    b.HasKey("Code");

                    b.HasIndex("CategoryId");

                    b.ToTable("toys");
                });

            modelBuilder.Entity("Data.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<int?>("RoleId")
                        .IsRequired()
                        .HasColumnType("integer")
                        .HasColumnName("role_id");

                    b.Property<bool?>("State")
                        .HasColumnType("boolean")
                        .HasColumnName("state");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Data.Models.Order", b =>
                {
                    b.HasOne("Data.Models.User", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Data.Models.OrderLine", b =>
                {
                    b.HasOne("Data.Models.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Toy", "ToyCodeNavigation")
                        .WithMany("OrderLines")
                        .HasForeignKey("ToyCode");

                    b.Navigation("Order");

                    b.Navigation("ToyCodeNavigation");
                });

            modelBuilder.Entity("Data.Models.PriceHistory", b =>
                {
                    b.HasOne("Data.Models.Toy", "ToyCodeNavigation")
                        .WithMany("PriceHistory")
                        .HasForeignKey("ToyCode");

                    b.Navigation("ToyCodeNavigation");
                });

            modelBuilder.Entity("Data.Models.Toy", b =>
                {
                    b.HasOne("Data.Models.Category", "Category")
                        .WithMany("Toys")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Data.Models.User", b =>
                {
                    b.HasOne("Data.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Data.Models.Category", b =>
                {
                    b.Navigation("Toys");
                });

            modelBuilder.Entity("Data.Models.Order", b =>
                {
                    b.Navigation("OrderLines");
                });

            modelBuilder.Entity("Data.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Data.Models.Toy", b =>
                {
                    b.Navigation("OrderLines");

                    b.Navigation("PriceHistory");
                });

            modelBuilder.Entity("Data.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
