using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<MaintenanceActivity> MaintenanceActivities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MaintenanceActivity>()
                .HasOne(m => m.Vehicle)
                .WithMany(m => m.MaintenanceActivities)
                .HasForeignKey(m => m.VehicleId);

            // Seed data
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { VehicleId = 1, Name = "Toyota Camry" },
                new Vehicle { VehicleId = 2, Name = "Toyota Fortuner" }
            );

            modelBuilder.Entity<MaintenanceActivity>().HasData(
                new MaintenanceActivity
                {
                    MaintenanceActivityId = 1,
                    VehicleId = 1,
                    MaintenanceType = "Oil Change",
                    Date = DateTime.Now,
                    Description = "Changed oil",
                    Notes = "Used synthetic oil.",
                    Vehicle = null // Optional, but this should be set by EF Core using VehicleId
                },
                new MaintenanceActivity
                {
                    MaintenanceActivityId = 2,
                    VehicleId = 1,
                    MaintenanceType = "Tyre Change",
                    Date = DateTime.Now.AddMonths(-1),
                    Description = "Changed tyres",
                    Notes = "No issues.",
                    Vehicle = null
                },
                new MaintenanceActivity
                {
                    MaintenanceActivityId = 3,
                    VehicleId = 2,
                    MaintenanceType = "Brake Inspection",
                    Date = DateTime.Now.AddMonths(-2),
                    Description = "Checked brakes",
                    Notes = "Brakes in good condition.",
                    Vehicle = null
                }
            );
        }

    }

}
