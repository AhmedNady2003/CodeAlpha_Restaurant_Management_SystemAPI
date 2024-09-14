using CodeAlpha_Restaurant_Management_SystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CodeAlpha_Restaurant_Management_SystemAPI.DBContext
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship
            modelBuilder.Entity<OrderMenuItem>()
                .HasKey(om => new { om.OrderId, om.MenuItemId });

            modelBuilder.Entity<OrderMenuItem>()
                .HasOne(om => om.Order)
                .WithMany(o => o.OrderMenuItems) // Ensure this is defined in the Order class
                .HasForeignKey(om => om.OrderId);

            modelBuilder.Entity<OrderMenuItem>()
                .HasOne(om => om.MenuItem)
                .WithMany(m => m.OrderMenuItems) // Ensure this is defined in the MenuItem class
                .HasForeignKey(om => om.MenuItemId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
