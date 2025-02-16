﻿// <auto-generated />
using System;
using CodeAlpha_Restaurant_Management_SystemAPI.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodeAlpha_Restaurant_Management_SystemAPI.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240914121817_Create-Table")]
    partial class CreateTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CodeAlpha_Restaurant_Management_SystemAPI.Models.Inventory", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InventoryId"));

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InventoryId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("CodeAlpha_Restaurant_Management_SystemAPI.Models.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuItemId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InventoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("MenuItemId");

                    b.HasIndex("InventoryId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("CodeAlpha_Restaurant_Management_SystemAPI.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TableId")
                        .HasColumnType("int");

                    b.Property<int>("TableNumber")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("TableId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CodeAlpha_Restaurant_Management_SystemAPI.Models.OrderMenuItem", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "MenuItemId");

                    b.HasIndex("MenuItemId");

                    b.ToTable("OrderMenuItem");
                });

            modelBuilder.Entity("CodeAlpha_Restaurant_Management_SystemAPI.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.Property<int>("TableNumber")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("TableId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("CodeAlpha_Restaurant_Management_SystemAPI.Models.Table", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TableId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("TableNumber")
                        .HasColumnType("int");

                    b.HasKey("TableId");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("CodeAlpha_Restaurant_Management_SystemAPI.Models.MenuItem", b =>
                {
                    b.HasOne("CodeAlpha_Restaurant_Management_SystemAPI.Models.Inventory", null)
                        .WithMany("MenuItems")
                        .HasForeignKey("InventoryId");
                });

            modelBuilder.Entity("CodeAlpha_Restaurant_Management_SystemAPI.Models.Order", b =>
                {
                    b.HasOne("CodeAlpha_Restaurant_Management_SystemAPI.Models.Table", null)
                        .WithMany("Orders")
                        .HasForeignKey("TableId");
                });

            modelBuilder.Entity("CodeAlpha_Restaurant_Management_SystemAPI.Models.OrderMenuItem", b =>
                {
                    b.HasOne("CodeAlpha_Restaurant_Management_SystemAPI.Models.MenuItem", "MenuItem")
                        .WithMany("OrderMenuItems")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeAlpha_Restaurant_Management_SystemAPI.Models.Order", "Order")
                        .WithMany("OrderMenuItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("CodeAlpha_Restaurant_Management_SystemAPI.Models.Reservation", b =>
                {
                    b.HasOne("CodeAlpha_Restaurant_Management_SystemAPI.Models.Table", "Table")
                        .WithMany("Reservations")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Table");
                });

            modelBuilder.Entity("CodeAlpha_Restaurant_Management_SystemAPI.Models.Inventory", b =>
                {
                    b.Navigation("MenuItems");
                });

            modelBuilder.Entity("CodeAlpha_Restaurant_Management_SystemAPI.Models.MenuItem", b =>
                {
                    b.Navigation("OrderMenuItems");
                });

            modelBuilder.Entity("CodeAlpha_Restaurant_Management_SystemAPI.Models.Order", b =>
                {
                    b.Navigation("OrderMenuItems");
                });

            modelBuilder.Entity("CodeAlpha_Restaurant_Management_SystemAPI.Models.Table", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
