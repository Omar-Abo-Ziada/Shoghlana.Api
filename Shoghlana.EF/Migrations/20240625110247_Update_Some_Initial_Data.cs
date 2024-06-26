using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shoghlana.EF.Migrations
{
    /// <inheritdoc />
    public partial class Update_Some_Initial_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "219ed24d-3efd-4215-8ee8-2bee6daf553a");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "a3cb5526-023a-42d7-bcdb-3a9ec3b8b9e4");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "a6d5fea6-da45-4571-b6ed-c154e9404cf8");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationTime",
                value: new DateTime(2023, 12, 25, 14, 2, 45, 589, DateTimeKind.Local).AddTicks(6176));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterationTime",
                value: new DateTime(2023, 6, 25, 14, 2, 45, 589, DateTimeKind.Local).AddTicks(6280));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 25, 14, 2, 45, 589, DateTimeKind.Local).AddTicks(6285));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegisterationTime",
                value: new DateTime(2023, 9, 25, 14, 2, 45, 589, DateTimeKind.Local).AddTicks(6290));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 25, 14, 2, 45, 589, DateTimeKind.Local).AddTicks(6293));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 25, 14, 2, 45, 589, DateTimeKind.Local).AddTicks(6297));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7,
                column: "RegisterationTime",
                value: new DateTime(2023, 7, 25, 14, 2, 45, 589, DateTimeKind.Local).AddTicks(6301));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 25, 14, 2, 45, 589, DateTimeKind.Local).AddTicks(6305));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 9,
                column: "RegisterationTime",
                value: new DateTime(2024, 1, 25, 14, 2, 45, 589, DateTimeKind.Local).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 10,
                column: "RegisterationTime",
                value: new DateTime(2023, 8, 25, 14, 2, 45, 589, DateTimeKind.Local).AddTicks(6312));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 11,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 25, 14, 2, 45, 589, DateTimeKind.Local).AddTicks(6315));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 12,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 25, 14, 2, 45, 589, DateTimeKind.Local).AddTicks(6319));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 13,
                column: "RegisterationTime",
                value: new DateTime(2024, 4, 25, 14, 2, 45, 589, DateTimeKind.Local).AddTicks(6323));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 14,
                column: "RegisterationTime",
                value: new DateTime(2023, 9, 25, 14, 2, 45, 589, DateTimeKind.Local).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 15,
                column: "RegisterationTime",
                value: new DateTime(2024, 1, 25, 14, 2, 45, 589, DateTimeKind.Local).AddTicks(6330));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 16,
                column: "RegisterationTime",
                value: new DateTime(2023, 7, 25, 14, 2, 45, 589, DateTimeKind.Local).AddTicks(6334));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 17,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 25, 14, 2, 45, 589, DateTimeKind.Local).AddTicks(6338));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 18,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 25, 14, 2, 45, 589, DateTimeKind.Local).AddTicks(6341));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8645));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8660));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8673));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8679));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 5,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8686));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 6,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8693));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 7,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8699));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 8,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8705));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 9,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8712));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 10,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8718));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 11,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8724));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 12,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8732));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 13,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8738));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 14,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8743));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 15,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8749));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 16,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8756));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 17,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8762));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 18,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8767));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 19,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8773));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 20,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8779));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 21,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8785));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 22,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8793));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 23,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8799));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 24,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8805));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 25,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8811));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 26,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8817));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 27,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8823));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 28,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8829));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 29,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8835));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 30,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8841));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 31,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8848));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 32,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8946));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 33,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8953));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 34,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8960));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 35,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 592, DateTimeKind.Local).AddTicks(8966));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimePublished",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 593, DateTimeKind.Local).AddTicks(3719));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimePublished",
                value: new DateTime(2024, 6, 25, 14, 2, 45, 593, DateTimeKind.Local).AddTicks(3783));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "219ed24d-3efd-4215-8ee8-2bee6daf553a", "900750ef-c738-4cd7-a855-54b8217eca54", "Admin", "ADMIN" },
                    { "a3cb5526-023a-42d7-bcdb-3a9ec3b8b9e4", "24b3f33d-537c-4983-a4e6-2353d7eda940", "Client", "CLIENT" },
                    { "a6d5fea6-da45-4571-b6ed-c154e9404cf8", "de0adefb-479e-4228-b8b5-4f686ad99603", "Freelancer", "FREELANCER" }
                });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationTime",
                value: new DateTime(2023, 12, 25, 13, 54, 35, 73, DateTimeKind.Local).AddTicks(6783));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterationTime",
                value: new DateTime(2023, 6, 25, 13, 54, 35, 73, DateTimeKind.Local).AddTicks(6881));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 25, 13, 54, 35, 73, DateTimeKind.Local).AddTicks(6886));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegisterationTime",
                value: new DateTime(2023, 9, 25, 13, 54, 35, 73, DateTimeKind.Local).AddTicks(6890));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 25, 13, 54, 35, 73, DateTimeKind.Local).AddTicks(6894));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 25, 13, 54, 35, 73, DateTimeKind.Local).AddTicks(6898));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7,
                column: "RegisterationTime",
                value: new DateTime(2023, 7, 25, 13, 54, 35, 73, DateTimeKind.Local).AddTicks(6902));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 25, 13, 54, 35, 73, DateTimeKind.Local).AddTicks(6906));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 9,
                column: "RegisterationTime",
                value: new DateTime(2024, 1, 25, 13, 54, 35, 73, DateTimeKind.Local).AddTicks(6910));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 10,
                column: "RegisterationTime",
                value: new DateTime(2023, 8, 25, 13, 54, 35, 73, DateTimeKind.Local).AddTicks(6914));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 11,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 25, 13, 54, 35, 73, DateTimeKind.Local).AddTicks(7053));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 12,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 25, 13, 54, 35, 73, DateTimeKind.Local).AddTicks(7057));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 13,
                column: "RegisterationTime",
                value: new DateTime(2024, 4, 25, 13, 54, 35, 73, DateTimeKind.Local).AddTicks(7061));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 14,
                column: "RegisterationTime",
                value: new DateTime(2023, 9, 25, 13, 54, 35, 73, DateTimeKind.Local).AddTicks(7064));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 15,
                column: "RegisterationTime",
                value: new DateTime(2024, 1, 25, 13, 54, 35, 73, DateTimeKind.Local).AddTicks(7068));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 16,
                column: "RegisterationTime",
                value: new DateTime(2023, 7, 25, 13, 54, 35, 73, DateTimeKind.Local).AddTicks(7072));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 17,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 25, 13, 54, 35, 73, DateTimeKind.Local).AddTicks(7075));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 18,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 25, 13, 54, 35, 73, DateTimeKind.Local).AddTicks(7079));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3461));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3474));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3481));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3488));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 5,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3494));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 6,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3501));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 7,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3509));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 8,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3516));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 9,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3522));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 10,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3528));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 11,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3535));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 12,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3541));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 13,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3547));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 14,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3553));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 15,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3559));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 16,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3566));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 17,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3572));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 18,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3578));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 19,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3584));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 20,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3590));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 21,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3596));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 22,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3601));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 23,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3607));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 24,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3613));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 25,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3621));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 26,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3626));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 27,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3632));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 28,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3638));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 29,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3644));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 30,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3650));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 31,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3655));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 32,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3661));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 33,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3667));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 34,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3672));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 35,
                column: "PostTime",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(3718));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimePublished",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(7601));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimePublished",
                value: new DateTime(2024, 6, 25, 13, 54, 35, 76, DateTimeKind.Local).AddTicks(7669));
        }
    }
}
