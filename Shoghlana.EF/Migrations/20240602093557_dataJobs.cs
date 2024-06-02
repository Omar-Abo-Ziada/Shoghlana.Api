using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shoghlana.EF.Migrations
{
    /// <inheritdoc />
    public partial class dataJobs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CategoryId", "ClientId", "Description", "ExperienceLevel", "FreelancerId", "MaxBudget", "MinBudget", "PostTime", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, "We need a web application developed with ASP.NET Core", 1, 1, 1000m, 500m, new DateTime(2024, 6, 2, 12, 35, 54, 150, DateTimeKind.Local).AddTicks(6253), "Develop a web application" },
                    { 2, 2, 2, "We need a logo designed for our new product", 0, 2, 300m, 100m, new DateTime(2024, 6, 2, 12, 35, 54, 150, DateTimeKind.Local).AddTicks(6301), "Design a logo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
