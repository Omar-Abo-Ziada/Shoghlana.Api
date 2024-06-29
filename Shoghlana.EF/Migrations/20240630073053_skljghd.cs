using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shoghlana.EF.Migrations
{
    /// <inheritdoc />
    public partial class skljghd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6810a251-3d15-4966-8d02-941990117772");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f5b91c2-4564-4a11-ba83-b2cb508049f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a86ba3b8-3a8c-4a9b-b170-fd316e12c7c3");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Freelancers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aeaa213b-c836-4716-a3f0-4a73249353fc", "fa9e2429-6263-48a4-9dc8-253364ad15a9", "Admin", "ADMIN" },
                    { "b3e075c4-d7e7-4aaf-9629-5eaebd9ef1be", "6080f1a5-8323-41d8-b5a8-2c4d16ed4c33", "Client", "CLIENT" },
                    { "b52dda2d-f65b-4235-88b9-6d902cc63495", "0c6b5fff-7599-4f1f-8098-1cc073a1ebd7", "Freelancer", "FREELANCER" }
                });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationTime",
                value: new DateTime(2023, 12, 30, 10, 30, 50, 581, DateTimeKind.Local).AddTicks(236));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterationTime",
                value: new DateTime(2023, 6, 30, 10, 30, 50, 581, DateTimeKind.Local).AddTicks(293));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 30, 10, 30, 50, 581, DateTimeKind.Local).AddTicks(297));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegisterationTime",
                value: new DateTime(2023, 9, 30, 10, 30, 50, 581, DateTimeKind.Local).AddTicks(300));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 30, 10, 30, 50, 581, DateTimeKind.Local).AddTicks(303));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 29, 10, 30, 50, 581, DateTimeKind.Local).AddTicks(305));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7,
                column: "RegisterationTime",
                value: new DateTime(2023, 7, 30, 10, 30, 50, 581, DateTimeKind.Local).AddTicks(308));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 30, 10, 30, 50, 581, DateTimeKind.Local).AddTicks(311));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 9,
                column: "RegisterationTime",
                value: new DateTime(2024, 1, 30, 10, 30, 50, 581, DateTimeKind.Local).AddTicks(314));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 10,
                column: "RegisterationTime",
                value: new DateTime(2023, 8, 30, 10, 30, 50, 581, DateTimeKind.Local).AddTicks(317));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 11,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 30, 10, 30, 50, 581, DateTimeKind.Local).AddTicks(319));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 12,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 30, 10, 30, 50, 581, DateTimeKind.Local).AddTicks(321));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 13,
                column: "RegisterationTime",
                value: new DateTime(2024, 4, 30, 10, 30, 50, 581, DateTimeKind.Local).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 14,
                column: "RegisterationTime",
                value: new DateTime(2023, 9, 30, 10, 30, 50, 581, DateTimeKind.Local).AddTicks(327));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 15,
                column: "RegisterationTime",
                value: new DateTime(2024, 1, 30, 10, 30, 50, 581, DateTimeKind.Local).AddTicks(329));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 16,
                column: "RegisterationTime",
                value: new DateTime(2023, 7, 30, 10, 30, 50, 581, DateTimeKind.Local).AddTicks(331));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 17,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 30, 10, 30, 50, 581, DateTimeKind.Local).AddTicks(334));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 18,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 29, 10, 30, 50, 581, DateTimeKind.Local).AddTicks(337));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1263));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1276));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1282));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1287));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 5,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1292));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 6,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1296));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 7,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1301));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 8,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1305));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 9,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1361));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 10,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 11,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1371));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 12,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1375));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 13,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1379));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 14,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1384));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 15,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1388));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 16,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1392));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 17,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1396));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 18,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1401));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 19,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1406));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 20,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1410));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 21,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1414));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 22,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1419));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 23,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1423));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 24,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1427));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 25,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1432));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 26,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1436));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 27,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 28,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1445));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 29,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1450));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 30,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1455));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 31,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1461));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 32,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1465));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 33,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1469));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 34,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1474));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 35,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(1478));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimePublished",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(4687));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimePublished",
                value: new DateTime(2024, 6, 30, 10, 30, 50, 583, DateTimeKind.Local).AddTicks(4723));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aeaa213b-c836-4716-a3f0-4a73249353fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3e075c4-d7e7-4aaf-9629-5eaebd9ef1be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b52dda2d-f65b-4235-88b9-6d902cc63495");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Freelancers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6810a251-3d15-4966-8d02-941990117772", "5d4655f7-d823-4827-9bcd-20beba2f9432", "Client", "CLIENT" },
                    { "6f5b91c2-4564-4a11-ba83-b2cb508049f8", "1eee4e72-964b-4817-a53e-bbe494968d34", "Admin", "ADMIN" },
                    { "a86ba3b8-3a8c-4a9b-b170-fd316e12c7c3", "f4cea427-bfe8-42b0-8483-d8611250b9df", "Freelancer", "FREELANCER" }
                });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationTime",
                value: new DateTime(2023, 12, 27, 16, 14, 36, 176, DateTimeKind.Local).AddTicks(4928));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterationTime",
                value: new DateTime(2023, 6, 27, 16, 14, 36, 176, DateTimeKind.Local).AddTicks(5091));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 27, 16, 14, 36, 176, DateTimeKind.Local).AddTicks(5096));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegisterationTime",
                value: new DateTime(2023, 9, 27, 16, 14, 36, 176, DateTimeKind.Local).AddTicks(5100));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 27, 16, 14, 36, 176, DateTimeKind.Local).AddTicks(5103));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 27, 16, 14, 36, 176, DateTimeKind.Local).AddTicks(5107));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7,
                column: "RegisterationTime",
                value: new DateTime(2023, 7, 27, 16, 14, 36, 176, DateTimeKind.Local).AddTicks(5110));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 27, 16, 14, 36, 176, DateTimeKind.Local).AddTicks(5114));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 9,
                column: "RegisterationTime",
                value: new DateTime(2024, 1, 27, 16, 14, 36, 176, DateTimeKind.Local).AddTicks(5118));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 10,
                column: "RegisterationTime",
                value: new DateTime(2023, 8, 27, 16, 14, 36, 176, DateTimeKind.Local).AddTicks(5121));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 11,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 27, 16, 14, 36, 176, DateTimeKind.Local).AddTicks(5125));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 12,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 27, 16, 14, 36, 176, DateTimeKind.Local).AddTicks(5129));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 13,
                column: "RegisterationTime",
                value: new DateTime(2024, 4, 27, 16, 14, 36, 176, DateTimeKind.Local).AddTicks(5132));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 14,
                column: "RegisterationTime",
                value: new DateTime(2023, 9, 27, 16, 14, 36, 176, DateTimeKind.Local).AddTicks(5136));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 15,
                column: "RegisterationTime",
                value: new DateTime(2024, 1, 27, 16, 14, 36, 176, DateTimeKind.Local).AddTicks(5140));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 16,
                column: "RegisterationTime",
                value: new DateTime(2023, 7, 27, 16, 14, 36, 176, DateTimeKind.Local).AddTicks(5143));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 17,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 27, 16, 14, 36, 176, DateTimeKind.Local).AddTicks(5147));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 18,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 27, 16, 14, 36, 176, DateTimeKind.Local).AddTicks(5151));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(7992));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8018));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8024));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 5,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8031));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 6,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8038));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 7,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8044));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 8,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8051));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 9,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8057));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 10,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8064));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 11,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8071));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 12,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8079));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 13,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8087));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 14,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8093));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 15,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8099));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 16,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8105));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 17,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8111));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 18,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8117));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 19,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8123));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 20,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8162));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 21,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8170));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 22,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8176));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 23,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8182));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 24,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8188));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 25,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8194));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 26,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8200));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 27,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8206));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 28,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8211));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 29,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8219));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 30,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8224));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 31,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8230));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 32,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8236));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 33,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8242));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 34,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8248));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 35,
                column: "PostTime",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 179, DateTimeKind.Local).AddTicks(8254));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimePublished",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 180, DateTimeKind.Local).AddTicks(2972));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimePublished",
                value: new DateTime(2024, 6, 27, 16, 14, 36, 180, DateTimeKind.Local).AddTicks(3041));
        }
    }
}
