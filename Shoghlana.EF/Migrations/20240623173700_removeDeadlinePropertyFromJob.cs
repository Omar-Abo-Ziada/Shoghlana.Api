using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shoghlana.EF.Migrations
{
    /// <inheritdoc />
    public partial class removeDeadlinePropertyFromJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94748370-ade1-4132-90e1-7a72cb29f93e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc7bd49d-c523-4267-8cfb-b942ae61e7b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e666f990-9a7d-4c1d-aa3e-ff9e92b3378a");

            migrationBuilder.DropColumn(
                name: "DeadLine",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ProposalsCount",
                table: "Jobs");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b1c8c6ef-60c7-442c-95eb-7478e1c90141", "4916455f-079f-4aec-8d9d-227f17ab3b26", "Client", "CLIENT" },
                    { "c150c3b6-3203-4647-8ca8-8daddf072265", "a1955ef8-0b20-403a-b2c0-30eb7842920b", "Admin", "ADMIN" },
                    { "c487a92e-b777-45c7-aecb-73ca0aa4fcd3", "6aa055be-cf78-42f8-a754-dbe0bbde06f9", "Freelancer", "FREELANCER" }
                });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationTime",
                value: new DateTime(2023, 12, 23, 20, 36, 54, 993, DateTimeKind.Local).AddTicks(1946));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterationTime",
                value: new DateTime(2023, 6, 23, 20, 36, 54, 993, DateTimeKind.Local).AddTicks(2006));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 23, 20, 36, 54, 993, DateTimeKind.Local).AddTicks(2012));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegisterationTime",
                value: new DateTime(2023, 9, 23, 20, 36, 54, 993, DateTimeKind.Local).AddTicks(2016));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 23, 20, 36, 54, 993, DateTimeKind.Local).AddTicks(2020));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 23, 20, 36, 54, 993, DateTimeKind.Local).AddTicks(2024));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7,
                column: "RegisterationTime",
                value: new DateTime(2023, 7, 23, 20, 36, 54, 993, DateTimeKind.Local).AddTicks(2028));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 23, 20, 36, 54, 993, DateTimeKind.Local).AddTicks(2031));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 9,
                column: "RegisterationTime",
                value: new DateTime(2024, 1, 23, 20, 36, 54, 993, DateTimeKind.Local).AddTicks(2035));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 10,
                column: "RegisterationTime",
                value: new DateTime(2023, 8, 23, 20, 36, 54, 993, DateTimeKind.Local).AddTicks(2039));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 11,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 23, 20, 36, 54, 993, DateTimeKind.Local).AddTicks(2043));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 12,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 23, 20, 36, 54, 993, DateTimeKind.Local).AddTicks(2047));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 13,
                column: "RegisterationTime",
                value: new DateTime(2024, 4, 23, 20, 36, 54, 993, DateTimeKind.Local).AddTicks(2050));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 14,
                column: "RegisterationTime",
                value: new DateTime(2023, 9, 23, 20, 36, 54, 993, DateTimeKind.Local).AddTicks(2054));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 15,
                column: "RegisterationTime",
                value: new DateTime(2024, 1, 23, 20, 36, 54, 993, DateTimeKind.Local).AddTicks(2057));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 16,
                column: "RegisterationTime",
                value: new DateTime(2023, 7, 23, 20, 36, 54, 993, DateTimeKind.Local).AddTicks(2061));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 17,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 23, 20, 36, 54, 993, DateTimeKind.Local).AddTicks(2065));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 18,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 23, 20, 36, 54, 993, DateTimeKind.Local).AddTicks(2068));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2445));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2455));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2462));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2469));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 5,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2478));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 6,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2485));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 7,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2491));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 8,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2497));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 9,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2503));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 10,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2509));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 11,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2516));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 12,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2522));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 13,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2528));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 14,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2534));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 15,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2540));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 16,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2546));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 17,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2552));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 18,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2558));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 19,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2564));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 20,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2569));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 21,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2575));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 22,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2581));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 23,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2588));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 24,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2594));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 25,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2599));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 26,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2606));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 27,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2611));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 28,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2617));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 29,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2623));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 30,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2629));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 31,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2635));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 32,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2700));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 33,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2706));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 34,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2712));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 35,
                column: "PostTime",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(2718));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimePublished",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(9034));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimePublished",
                value: new DateTime(2024, 6, 23, 20, 36, 54, 996, DateTimeKind.Local).AddTicks(9107));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1c8c6ef-60c7-442c-95eb-7478e1c90141");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c150c3b6-3203-4647-8ca8-8daddf072265");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c487a92e-b777-45c7-aecb-73ca0aa4fcd3");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeadLine",
                table: "Jobs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProposalsCount",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "94748370-ade1-4132-90e1-7a72cb29f93e", "04a7f301-d737-4f8e-916e-93ff40f4299a", "Admin", "ADMIN" },
                    { "cc7bd49d-c523-4267-8cfb-b942ae61e7b0", "a1c2baf2-c2f4-48b9-81ae-0a6e1eec8d7a", "Freelancer", "FREELANCER" },
                    { "e666f990-9a7d-4c1d-aa3e-ff9e92b3378a", "4bdba120-1580-4eb8-a19b-864225cdf52e", "Client", "CLIENT" }
                });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationTime",
                value: new DateTime(2023, 12, 23, 6, 14, 34, 261, DateTimeKind.Local).AddTicks(7509));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterationTime",
                value: new DateTime(2023, 6, 23, 6, 14, 34, 261, DateTimeKind.Local).AddTicks(7581));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 23, 6, 14, 34, 261, DateTimeKind.Local).AddTicks(7585));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegisterationTime",
                value: new DateTime(2023, 9, 23, 6, 14, 34, 261, DateTimeKind.Local).AddTicks(7589));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 23, 6, 14, 34, 261, DateTimeKind.Local).AddTicks(7593));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 23, 6, 14, 34, 261, DateTimeKind.Local).AddTicks(7596));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7,
                column: "RegisterationTime",
                value: new DateTime(2023, 7, 23, 6, 14, 34, 261, DateTimeKind.Local).AddTicks(7601));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 23, 6, 14, 34, 261, DateTimeKind.Local).AddTicks(7604));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 9,
                column: "RegisterationTime",
                value: new DateTime(2024, 1, 23, 6, 14, 34, 261, DateTimeKind.Local).AddTicks(7608));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 10,
                column: "RegisterationTime",
                value: new DateTime(2023, 8, 23, 6, 14, 34, 261, DateTimeKind.Local).AddTicks(7611));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 11,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 23, 6, 14, 34, 261, DateTimeKind.Local).AddTicks(7615));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 12,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 23, 6, 14, 34, 261, DateTimeKind.Local).AddTicks(7618));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 13,
                column: "RegisterationTime",
                value: new DateTime(2024, 4, 23, 6, 14, 34, 261, DateTimeKind.Local).AddTicks(7622));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 14,
                column: "RegisterationTime",
                value: new DateTime(2023, 9, 23, 6, 14, 34, 261, DateTimeKind.Local).AddTicks(7625));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 15,
                column: "RegisterationTime",
                value: new DateTime(2024, 1, 23, 6, 14, 34, 261, DateTimeKind.Local).AddTicks(7629));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 16,
                column: "RegisterationTime",
                value: new DateTime(2023, 7, 23, 6, 14, 34, 261, DateTimeKind.Local).AddTicks(7633));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 17,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 23, 6, 14, 34, 261, DateTimeKind.Local).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 18,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 23, 6, 14, 34, 261, DateTimeKind.Local).AddTicks(7639));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1123), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1134), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1141), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1148), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1156), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1162), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1169), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1175), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1182), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1188), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1194), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1202), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1209), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1215), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1220), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1226), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1232), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1239), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1245), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1251), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1257), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1263), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1269), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1275), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1282), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1288), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1294), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1359), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1367), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1373), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1379), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1386), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1392), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1399), 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "DeadLine", "PostTime", "ProposalsCount" },
                values: new object[] { null, new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(1404), 0 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimePublished",
                value: new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimePublished",
                value: new DateTime(2024, 6, 23, 6, 14, 34, 265, DateTimeKind.Local).AddTicks(8487));
        }
    }
}
