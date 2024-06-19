using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shoghlana.EF.Migrations
{
    /// <inheritdoc />
    public partial class Jobs_ClientID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Clients_ClientId",
                table: "Jobs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1734c1e3-5aa2-4e82-abe1-f6ffb73e5de0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bec88b87-a5e2-46a1-bd94-4533e847aaea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc0f20d8-c273-42f6-becd-dbcbbc0ac3e9");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17732e3f-5b88-467d-826f-b88430b5f0b2", "e7f055d1-97b3-49a9-be21-5b2f586522f2", "Admin", "ADMIN" },
                    { "aa088447-8a04-49df-8897-dd86f754369a", "16687aaa-e22f-48a0-b581-b78746fb4095", "Client", "CLIENT" },
                    { "b1507d85-b4da-4a29-bc21-bfd0dd795842", "55aa8cb3-5c6a-440c-8048-9c51135b3303", "Freelancer", "FREELANCER" }
                });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationTime",
                value: new DateTime(2023, 12, 19, 2, 53, 14, 545, DateTimeKind.Local).AddTicks(9850));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterationTime",
                value: new DateTime(2023, 6, 19, 2, 53, 14, 545, DateTimeKind.Local).AddTicks(9927));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 19, 2, 53, 14, 545, DateTimeKind.Local).AddTicks(9932));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegisterationTime",
                value: new DateTime(2023, 9, 19, 2, 53, 14, 545, DateTimeKind.Local).AddTicks(9936));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 19, 2, 53, 14, 545, DateTimeKind.Local).AddTicks(9941));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 19, 2, 53, 14, 545, DateTimeKind.Local).AddTicks(9944));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7,
                column: "RegisterationTime",
                value: new DateTime(2023, 7, 19, 2, 53, 14, 545, DateTimeKind.Local).AddTicks(9949));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 19, 2, 53, 14, 545, DateTimeKind.Local).AddTicks(9953));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 9,
                column: "RegisterationTime",
                value: new DateTime(2024, 1, 19, 2, 53, 14, 545, DateTimeKind.Local).AddTicks(9956));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 10,
                column: "RegisterationTime",
                value: new DateTime(2023, 8, 19, 2, 53, 14, 545, DateTimeKind.Local).AddTicks(9960));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 11,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 19, 2, 53, 14, 545, DateTimeKind.Local).AddTicks(9964));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 12,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 19, 2, 53, 14, 545, DateTimeKind.Local).AddTicks(9968));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 13,
                column: "RegisterationTime",
                value: new DateTime(2024, 4, 19, 2, 53, 14, 545, DateTimeKind.Local).AddTicks(9974));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 14,
                column: "RegisterationTime",
                value: new DateTime(2023, 9, 19, 2, 53, 14, 545, DateTimeKind.Local).AddTicks(9978));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 15,
                column: "RegisterationTime",
                value: new DateTime(2024, 1, 19, 2, 53, 14, 545, DateTimeKind.Local).AddTicks(9982));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 16,
                column: "RegisterationTime",
                value: new DateTime(2023, 7, 19, 2, 53, 14, 545, DateTimeKind.Local).AddTicks(9986));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 17,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 19, 2, 53, 14, 545, DateTimeKind.Local).AddTicks(9990));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 18,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 19, 2, 53, 14, 545, DateTimeKind.Local).AddTicks(9994));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClientId", "PostTime" },
                values: new object[] { 1, new DateTime(2024, 6, 19, 2, 53, 14, 548, DateTimeKind.Local).AddTicks(8766) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClientId", "PostTime" },
                values: new object[] { 2, new DateTime(2024, 6, 19, 2, 53, 14, 548, DateTimeKind.Local).AddTicks(8825) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClientId", "PostTime" },
                values: new object[] { 3, new DateTime(2024, 6, 19, 2, 53, 14, 548, DateTimeKind.Local).AddTicks(8832) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ClientId", "PostTime" },
                values: new object[] { 4, new DateTime(2024, 6, 19, 2, 53, 14, 548, DateTimeKind.Local).AddTicks(8882) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ClientId", "PostTime" },
                values: new object[] { 5, new DateTime(2024, 6, 19, 2, 53, 14, 548, DateTimeKind.Local).AddTicks(8889) });

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Clients_ClientId",
                table: "Jobs",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Clients_ClientId",
                table: "Jobs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17732e3f-5b88-467d-826f-b88430b5f0b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa088447-8a04-49df-8897-dd86f754369a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1507d85-b4da-4a29-bc21-bfd0dd795842");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Jobs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1734c1e3-5aa2-4e82-abe1-f6ffb73e5de0", "12d41127-948c-45b0-9ede-da81f663da7a", "Freelancer", "FREELANCER" },
                    { "bec88b87-a5e2-46a1-bd94-4533e847aaea", "7536f748-cc18-4b00-9049-b3a0512fbc4c", "Client", "CLIENT" },
                    { "dc0f20d8-c273-42f6-becd-dbcbbc0ac3e9", "15225215-34f6-48b7-a4f2-49de1555179c", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationTime",
                value: new DateTime(2023, 12, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6436));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterationTime",
                value: new DateTime(2023, 6, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6516));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6521));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegisterationTime",
                value: new DateTime(2023, 9, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6526));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6530));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6534));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7,
                column: "RegisterationTime",
                value: new DateTime(2023, 7, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6539));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6542));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 9,
                column: "RegisterationTime",
                value: new DateTime(2024, 1, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6546));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 10,
                column: "RegisterationTime",
                value: new DateTime(2023, 8, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 11,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6554));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 12,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6558));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 13,
                column: "RegisterationTime",
                value: new DateTime(2024, 4, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6562));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 14,
                column: "RegisterationTime",
                value: new DateTime(2023, 9, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6566));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 15,
                column: "RegisterationTime",
                value: new DateTime(2024, 1, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6570));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 16,
                column: "RegisterationTime",
                value: new DateTime(2023, 7, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6574));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 17,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6578));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 18,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6583));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClientId", "PostTime" },
                values: new object[] { null, new DateTime(2024, 6, 19, 2, 51, 26, 793, DateTimeKind.Local).AddTicks(297) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClientId", "PostTime" },
                values: new object[] { null, new DateTime(2024, 6, 19, 2, 51, 26, 793, DateTimeKind.Local).AddTicks(386) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClientId", "PostTime" },
                values: new object[] { null, new DateTime(2024, 6, 19, 2, 51, 26, 793, DateTimeKind.Local).AddTicks(393) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ClientId", "PostTime" },
                values: new object[] { null, new DateTime(2024, 6, 19, 2, 51, 26, 793, DateTimeKind.Local).AddTicks(399) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ClientId", "PostTime" },
                values: new object[] { null, new DateTime(2024, 6, 19, 2, 51, 26, 793, DateTimeKind.Local).AddTicks(405) });

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Clients_ClientId",
                table: "Jobs",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }
    }
}
