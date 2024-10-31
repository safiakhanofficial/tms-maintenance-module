using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Name" },
                values: new object[,]
                {
                    { 1, "Toyota Camry" },
                    { 2, "Toyota Fortuner" }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceActivities",
                columns: new[] { "MaintenanceActivityId", "Date", "Description", "MaintenanceType", "Notes", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 30, 16, 57, 29, 321, DateTimeKind.Local).AddTicks(4809), "Changed oil", "Oil Change", "Used synthetic oil.", 1 },
                    { 2, new DateTime(2024, 9, 30, 16, 57, 29, 321, DateTimeKind.Local).AddTicks(4828), "Changed tyres", "Tyre Change", "No issues.", 1 },
                    { 3, new DateTime(2024, 8, 30, 16, 57, 29, 321, DateTimeKind.Local).AddTicks(4838), "Checked brakes", "Brake Inspection", "Brakes in good condition.", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MaintenanceActivities",
                keyColumn: "MaintenanceActivityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MaintenanceActivities",
                keyColumn: "MaintenanceActivityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MaintenanceActivities",
                keyColumn: "MaintenanceActivityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 2);
        }
    }
}
