using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shoghlana.EF.Migrations
{
    /// <inheritdoc />
    public partial class Edited_JobSkills_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60f84e9d-3305-46fa-838e-d119f68ac222");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b047ef8-fac8-42aa-b72e-c75f01124b4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fecebe08-eea1-4b8a-8b91-e8f957bd57a5");

            migrationBuilder.AddColumn<int>(
                name: "SkillId1",
                table: "JobSkills",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2cac5260-afaf-4b33-b0e3-4d6e40de6665", "6f5565ef-76a2-4b16-b9ba-c1ea0817a305", "Freelancer", "FREELANCER" },
                    { "91b1f6e1-d1ac-45a0-b275-051c0b4c08fe", "896590f4-efe8-4f84-96fe-a31f1c3dda0b", "Admin", "ADMIN" },
                    { "e13a3b8c-ffa0-4786-9353-843411ee8995", "8fcb1724-b26b-444a-9c68-7f8aea709d0e", "Client", "CLIENT" }
                });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationTime",
                value: new DateTime(2023, 12, 22, 20, 14, 0, 422, DateTimeKind.Local).AddTicks(6237));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterationTime",
                value: new DateTime(2023, 6, 22, 20, 14, 0, 422, DateTimeKind.Local).AddTicks(6324));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 22, 20, 14, 0, 422, DateTimeKind.Local).AddTicks(6329));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegisterationTime",
                value: new DateTime(2023, 9, 22, 20, 14, 0, 422, DateTimeKind.Local).AddTicks(6333));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 22, 20, 14, 0, 422, DateTimeKind.Local).AddTicks(6337));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 22, 20, 14, 0, 422, DateTimeKind.Local).AddTicks(6340));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7,
                column: "RegisterationTime",
                value: new DateTime(2023, 7, 22, 20, 14, 0, 422, DateTimeKind.Local).AddTicks(6344));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 22, 20, 14, 0, 422, DateTimeKind.Local).AddTicks(6347));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 9,
                column: "RegisterationTime",
                value: new DateTime(2024, 1, 22, 20, 14, 0, 422, DateTimeKind.Local).AddTicks(6351));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 10,
                column: "RegisterationTime",
                value: new DateTime(2023, 8, 22, 20, 14, 0, 422, DateTimeKind.Local).AddTicks(6355));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 11,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 22, 20, 14, 0, 422, DateTimeKind.Local).AddTicks(6358));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 12,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 22, 20, 14, 0, 422, DateTimeKind.Local).AddTicks(6362));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 13,
                column: "RegisterationTime",
                value: new DateTime(2024, 4, 22, 20, 14, 0, 422, DateTimeKind.Local).AddTicks(6366));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 14,
                column: "RegisterationTime",
                value: new DateTime(2023, 9, 22, 20, 14, 0, 422, DateTimeKind.Local).AddTicks(6369));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 15,
                column: "RegisterationTime",
                value: new DateTime(2024, 1, 22, 20, 14, 0, 422, DateTimeKind.Local).AddTicks(6372));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 16,
                column: "RegisterationTime",
                value: new DateTime(2023, 7, 22, 20, 14, 0, 422, DateTimeKind.Local).AddTicks(6377));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 17,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 22, 20, 14, 0, 422, DateTimeKind.Local).AddTicks(6380));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 18,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 22, 20, 14, 0, 422, DateTimeKind.Local).AddTicks(6384));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5148));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5162));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5170));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5178));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 5,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5185));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 6,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5192));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 7,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5200));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 8,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5207));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 9,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5214));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 10,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5222));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 11,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5229));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 12,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5236));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 13,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5243));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 14,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5250));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 15,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5258));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 16,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5265));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 17,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5272));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 18,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5279));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 19,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5373));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 20,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5381));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 21,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5388));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 22,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5395));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 23,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5402));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 24,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 25,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5416));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 26,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5424));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 27,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5431));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 28,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5439));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 29,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5446));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 30,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5453));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 31,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5460));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 32,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5467));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 33,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5474));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 34,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5481));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 35,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 425, DateTimeKind.Local).AddTicks(5488));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimePublished",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 426, DateTimeKind.Local).AddTicks(128));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimePublished",
                value: new DateTime(2024, 6, 22, 20, 14, 0, 426, DateTimeKind.Local).AddTicks(199));

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_SkillId1",
                table: "JobSkills",
                column: "SkillId1");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkills_Skills_SkillId1",
                table: "JobSkills",
                column: "SkillId1",
                principalTable: "Skills",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSkills_Skills_SkillId1",
                table: "JobSkills");

            migrationBuilder.DropIndex(
                name: "IX_JobSkills_SkillId1",
                table: "JobSkills");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cac5260-afaf-4b33-b0e3-4d6e40de6665");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91b1f6e1-d1ac-45a0-b275-051c0b4c08fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e13a3b8c-ffa0-4786-9353-843411ee8995");

            migrationBuilder.DropColumn(
                name: "SkillId1",
                table: "JobSkills");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "60f84e9d-3305-46fa-838e-d119f68ac222", "268773d7-9f69-42c2-a973-c4141d77bed0", "Admin", "ADMIN" },
                    { "9b047ef8-fac8-42aa-b72e-c75f01124b4f", "c8640980-7ebf-4297-8654-b8f6fde0e0c9", "Client", "CLIENT" },
                    { "fecebe08-eea1-4b8a-8b91-e8f957bd57a5", "c90b6d05-5fcf-46f1-8e7a-3280c994a443", "Freelancer", "FREELANCER" }
                });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationTime",
                value: new DateTime(2023, 12, 22, 19, 35, 37, 537, DateTimeKind.Local).AddTicks(7552));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterationTime",
                value: new DateTime(2023, 6, 22, 19, 35, 37, 537, DateTimeKind.Local).AddTicks(7665));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 22, 19, 35, 37, 537, DateTimeKind.Local).AddTicks(7673));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegisterationTime",
                value: new DateTime(2023, 9, 22, 19, 35, 37, 537, DateTimeKind.Local).AddTicks(7681));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 22, 19, 35, 37, 537, DateTimeKind.Local).AddTicks(7688));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 22, 19, 35, 37, 537, DateTimeKind.Local).AddTicks(7694));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7,
                column: "RegisterationTime",
                value: new DateTime(2023, 7, 22, 19, 35, 37, 537, DateTimeKind.Local).AddTicks(7781));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 22, 19, 35, 37, 537, DateTimeKind.Local).AddTicks(7790));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 9,
                column: "RegisterationTime",
                value: new DateTime(2024, 1, 22, 19, 35, 37, 537, DateTimeKind.Local).AddTicks(7798));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 10,
                column: "RegisterationTime",
                value: new DateTime(2023, 8, 22, 19, 35, 37, 537, DateTimeKind.Local).AddTicks(7805));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 11,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 22, 19, 35, 37, 537, DateTimeKind.Local).AddTicks(7811));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 12,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 22, 19, 35, 37, 537, DateTimeKind.Local).AddTicks(7819));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 13,
                column: "RegisterationTime",
                value: new DateTime(2024, 4, 22, 19, 35, 37, 537, DateTimeKind.Local).AddTicks(7825));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 14,
                column: "RegisterationTime",
                value: new DateTime(2023, 9, 22, 19, 35, 37, 537, DateTimeKind.Local).AddTicks(7832));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 15,
                column: "RegisterationTime",
                value: new DateTime(2024, 1, 22, 19, 35, 37, 537, DateTimeKind.Local).AddTicks(7838));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 16,
                column: "RegisterationTime",
                value: new DateTime(2023, 7, 22, 19, 35, 37, 537, DateTimeKind.Local).AddTicks(7844));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 17,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 22, 19, 35, 37, 537, DateTimeKind.Local).AddTicks(7851));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 18,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 22, 19, 35, 37, 537, DateTimeKind.Local).AddTicks(7857));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(1694));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(1734));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(1756));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(1776));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 5,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(1796));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 6,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(1816));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 7,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(1837));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 8,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(1857));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 9,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(1877));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 10,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(1898));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 11,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(1917));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 12,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(1936));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 13,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(1951));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 14,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(1964));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 15,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(2068));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 16,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(2085));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 17,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(2099));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 18,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(2117));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 19,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(2134));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 20,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(2150));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 21,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(2169));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 22,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 23,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(2205));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 24,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(2222));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 25,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 26,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(2254));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 27,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(2271));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 28,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(2289));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 29,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(2305));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 30,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(2390));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 31,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(2409));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 32,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(2425));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 33,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(2443));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 34,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(2462));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 35,
                column: "PostTime",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 543, DateTimeKind.Local).AddTicks(2480));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimePublished",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 544, DateTimeKind.Local).AddTicks(4961));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimePublished",
                value: new DateTime(2024, 6, 22, 19, 35, 37, 544, DateTimeKind.Local).AddTicks(5074));
        }
    }
}
