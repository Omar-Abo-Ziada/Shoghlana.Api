using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shoghlana.EF.Migrations
{
    /// <inheritdoc />
    public partial class sdklgjs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "096b7312-df4d-4fa3-ab50-7ca5fe704fbb", "164a9f77-f0ab-4de3-a38b-40b290d4bb38", "Client", "CLIENT" },
                    { "a04c5901-93d5-486e-ba93-e4e9f2144a6f", "c04fa7f9-89b4-45f8-b202-7e84706703f1", "Admin", "ADMIN" },
                    { "dffa1dba-d80f-428e-8cfc-a4e228dba6e9", "23556f2e-760e-4cd3-972e-dbfe7e5f7134", "Freelancer", "FREELANCER" }
                });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationTime",
                value: new DateTime(2023, 12, 30, 22, 37, 57, 368, DateTimeKind.Local).AddTicks(7876));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterationTime",
                value: new DateTime(2023, 6, 30, 22, 37, 57, 368, DateTimeKind.Local).AddTicks(7925));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 30, 22, 37, 57, 368, DateTimeKind.Local).AddTicks(7930));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegisterationTime",
                value: new DateTime(2023, 9, 30, 22, 37, 57, 368, DateTimeKind.Local).AddTicks(7933));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 30, 22, 37, 57, 368, DateTimeKind.Local).AddTicks(7937));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 29, 22, 37, 57, 368, DateTimeKind.Local).AddTicks(7940));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7,
                column: "RegisterationTime",
                value: new DateTime(2023, 7, 30, 22, 37, 57, 368, DateTimeKind.Local).AddTicks(7943));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 30, 22, 37, 57, 368, DateTimeKind.Local).AddTicks(7946));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 9,
                column: "RegisterationTime",
                value: new DateTime(2024, 1, 30, 22, 37, 57, 368, DateTimeKind.Local).AddTicks(7951));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 10,
                column: "RegisterationTime",
                value: new DateTime(2023, 8, 30, 22, 37, 57, 368, DateTimeKind.Local).AddTicks(7954));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 11,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 30, 22, 37, 57, 368, DateTimeKind.Local).AddTicks(7957));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 12,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 30, 22, 37, 57, 368, DateTimeKind.Local).AddTicks(7961));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 13,
                column: "RegisterationTime",
                value: new DateTime(2024, 4, 30, 22, 37, 57, 368, DateTimeKind.Local).AddTicks(7964));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 14,
                column: "RegisterationTime",
                value: new DateTime(2023, 9, 30, 22, 37, 57, 368, DateTimeKind.Local).AddTicks(7967));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 15,
                column: "RegisterationTime",
                value: new DateTime(2024, 1, 30, 22, 37, 57, 368, DateTimeKind.Local).AddTicks(7970));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 16,
                column: "RegisterationTime",
                value: new DateTime(2023, 7, 30, 22, 37, 57, 368, DateTimeKind.Local).AddTicks(7973));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 17,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 30, 22, 37, 57, 368, DateTimeKind.Local).AddTicks(7975));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 18,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 29, 22, 37, 57, 368, DateTimeKind.Local).AddTicks(7978));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(469));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(480));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(486));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(491));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 5,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(497));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 6,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(502));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 7,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(507));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 8,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(512));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 9,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(518));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 10,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(524));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 11,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(530));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 12,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(535));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 13,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(540));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 14,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(545));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 15,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(550));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 16,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 17,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(559));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 18,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(565));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 19,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(569));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 20,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(576));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 21,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(581));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 22,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(586));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 23,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(591));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 24,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(596));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 25,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(601));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 26,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(606));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 27,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(611));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 28,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(663));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 29,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(669));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 30,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(675));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 31,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(679));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 32,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(684));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 33,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(689));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 34,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(694));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 35,
                column: "PostTime",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(700));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimePublished",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(4166));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimePublished",
                value: new DateTime(2024, 6, 30, 22, 37, 57, 371, DateTimeKind.Local).AddTicks(4203));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "096b7312-df4d-4fa3-ab50-7ca5fe704fbb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a04c5901-93d5-486e-ba93-e4e9f2144a6f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dffa1dba-d80f-428e-8cfc-a4e228dba6e9");

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
    }
}
