using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shoghlana.EF.Migrations
{
    /// <inheritdoc />
    public partial class addroles2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "38dc52ce-f3ad-4120-bfaa-a576e4683850", "7ab71c6c-2c5a-4bc9-b90f-5f49f3eca4d0", "Freelancer", "FREELANCER" },
                    { "888df4f9-eb86-4089-bed2-f94cd10e5a3d", "75ab8697-5cab-4a5e-9187-679e99e9c3c5", "Admin", "ADMIN" },
                    { "93fd7a84-0507-454a-ad65-a89814592ff3", "1f6ee9bb-2609-435c-b961-10e7cbcdc5b2", "Client", "CLIENT" }
                });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostTime",
                value: new DateTime(2024, 6, 1, 22, 32, 59, 412, DateTimeKind.Local).AddTicks(7795));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostTime",
                value: new DateTime(2024, 6, 1, 22, 32, 59, 412, DateTimeKind.Local).AddTicks(7850));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38dc52ce-f3ad-4120-bfaa-a576e4683850");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "888df4f9-eb86-4089-bed2-f94cd10e5a3d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93fd7a84-0507-454a-ad65-a89814592ff3");

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostTime",
                value: new DateTime(2024, 6, 1, 21, 7, 25, 799, DateTimeKind.Local).AddTicks(2014));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostTime",
                value: new DateTime(2024, 6, 1, 21, 7, 25, 799, DateTimeKind.Local).AddTicks(2074));
        }
    }
}
