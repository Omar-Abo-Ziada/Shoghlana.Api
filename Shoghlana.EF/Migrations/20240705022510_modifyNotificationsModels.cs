using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shoghlana.EF.Migrations
{
    /// <inheritdoc />
    public partial class modifyNotificationsModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0001fc2-0002-40a1-ba31-485375ea2cbe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a66ac42f-0b68-41a8-8722-ff17adb4e4f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd20ae0d-4ee5-473c-8f07-5e9928723f37");

            migrationBuilder.AddColumn<int>(
                name: "NotificationTriggerId",
                table: "FreelancerNotifications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Reason",
                table: "FreelancerNotifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NotificationTriggerId",
                table: "ClientNotifications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Reason",
                table: "ClientNotifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "ClientNotifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39b20c3e-f1a2-4c10-b6bf-b2c0b6f5cdcd", "332bb172-89ed-44cd-b7fb-5ae4c10a1d01", "Admin", "ADMIN" },
                    { "99fcd522-583e-48c4-8786-e269c0c67cba", "4332dda6-92ec-42bf-97a1-c8e6e93b0ce5", "Client", "CLIENT" },
                    { "e5cffd5e-e79e-488b-a6ec-8f19064b4cc8", "bb43dfa4-0bf4-486a-85f0-69f46935f8e2", "Freelancer", "FREELANCER" }
                });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationTime",
                value: new DateTime(2024, 1, 5, 5, 25, 4, 88, DateTimeKind.Local).AddTicks(3395));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterationTime",
                value: new DateTime(2023, 7, 5, 5, 25, 4, 88, DateTimeKind.Local).AddTicks(3564));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisterationTime",
                value: new DateTime(2024, 4, 5, 5, 25, 4, 88, DateTimeKind.Local).AddTicks(3570));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 5, 5, 25, 4, 88, DateTimeKind.Local).AddTicks(3575));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisterationTime",
                value: new DateTime(2023, 12, 5, 5, 25, 4, 88, DateTimeKind.Local).AddTicks(3579));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 5, 5, 25, 4, 88, DateTimeKind.Local).AddTicks(3592));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7,
                column: "RegisterationTime",
                value: new DateTime(2023, 8, 5, 5, 25, 4, 88, DateTimeKind.Local).AddTicks(3607));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 5, 5, 25, 4, 88, DateTimeKind.Local).AddTicks(3612));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 9,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 5, 5, 25, 4, 88, DateTimeKind.Local).AddTicks(3616));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 10,
                column: "RegisterationTime",
                value: new DateTime(2023, 9, 5, 5, 25, 4, 88, DateTimeKind.Local).AddTicks(3621));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 11,
                column: "RegisterationTime",
                value: new DateTime(2024, 4, 5, 5, 25, 4, 88, DateTimeKind.Local).AddTicks(3628));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 12,
                column: "RegisterationTime",
                value: new DateTime(2023, 12, 5, 5, 25, 4, 88, DateTimeKind.Local).AddTicks(3633));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 13,
                column: "RegisterationTime",
                value: new DateTime(2024, 5, 5, 5, 25, 4, 88, DateTimeKind.Local).AddTicks(3638));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 14,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 5, 5, 25, 4, 88, DateTimeKind.Local).AddTicks(3642));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 15,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 5, 5, 25, 4, 88, DateTimeKind.Local).AddTicks(3647));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 16,
                column: "RegisterationTime",
                value: new DateTime(2023, 8, 5, 5, 25, 4, 88, DateTimeKind.Local).AddTicks(3678));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 17,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 5, 5, 25, 4, 88, DateTimeKind.Local).AddTicks(3683));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 18,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 5, 5, 25, 4, 88, DateTimeKind.Local).AddTicks(3688));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2212));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2229));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2236));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2243));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 5,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2250));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 6,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2269));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 7,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2330));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 8,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2336));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 9,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2344));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 10,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2352));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 11,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2358));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 12,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2365));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 13,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2371));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 14,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2378));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 15,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2384));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 16,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2395));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 17,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2402));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 18,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2409));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 19,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2416));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 20,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2422));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 21,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2428));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 22,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2435));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 23,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2442));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 24,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2606));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 25,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 26,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2624));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 27,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2631));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 28,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2638));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 29,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2645));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 30,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2651));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 31,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2658));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 32,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2664));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 33,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2671));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 34,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2677));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 35,
                column: "PostTime",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 95, DateTimeKind.Local).AddTicks(2684));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimePublished",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 96, DateTimeKind.Local).AddTicks(243));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimePublished",
                value: new DateTime(2024, 7, 5, 5, 25, 4, 96, DateTimeKind.Local).AddTicks(317));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39b20c3e-f1a2-4c10-b6bf-b2c0b6f5cdcd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99fcd522-583e-48c4-8786-e269c0c67cba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5cffd5e-e79e-488b-a6ec-8f19064b4cc8");

            migrationBuilder.DropColumn(
                name: "NotificationTriggerId",
                table: "FreelancerNotifications");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "FreelancerNotifications");

            migrationBuilder.DropColumn(
                name: "NotificationTriggerId",
                table: "ClientNotifications");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "ClientNotifications");

            migrationBuilder.DropColumn(
                name: "URL",
                table: "ClientNotifications");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a0001fc2-0002-40a1-ba31-485375ea2cbe", "26e6abca-bf67-405e-b8a1-3fcf10e84391", "Client", "CLIENT" },
                    { "a66ac42f-0b68-41a8-8722-ff17adb4e4f9", "6d1e4a16-cb47-4b65-8e94-5972aa019afa", "Admin", "ADMIN" },
                    { "fd20ae0d-4ee5-473c-8f07-5e9928723f37", "cd425ddf-26d6-43a2-9f74-94f92e90120a", "Freelancer", "FREELANCER" }
                });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationTime",
                value: new DateTime(2024, 1, 4, 16, 3, 23, 959, DateTimeKind.Local).AddTicks(2412));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterationTime",
                value: new DateTime(2023, 7, 4, 16, 3, 23, 959, DateTimeKind.Local).AddTicks(2508));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisterationTime",
                value: new DateTime(2024, 4, 4, 16, 3, 23, 959, DateTimeKind.Local).AddTicks(2516));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 4, 16, 3, 23, 959, DateTimeKind.Local).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisterationTime",
                value: new DateTime(2023, 12, 4, 16, 3, 23, 959, DateTimeKind.Local).AddTicks(2525));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 4, 16, 3, 23, 959, DateTimeKind.Local).AddTicks(2529));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7,
                column: "RegisterationTime",
                value: new DateTime(2023, 8, 4, 16, 3, 23, 959, DateTimeKind.Local).AddTicks(2569));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 4, 16, 3, 23, 959, DateTimeKind.Local).AddTicks(2573));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 9,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 4, 16, 3, 23, 959, DateTimeKind.Local).AddTicks(2578));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 10,
                column: "RegisterationTime",
                value: new DateTime(2023, 9, 4, 16, 3, 23, 959, DateTimeKind.Local).AddTicks(2582));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 11,
                column: "RegisterationTime",
                value: new DateTime(2024, 4, 4, 16, 3, 23, 959, DateTimeKind.Local).AddTicks(2626));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 12,
                column: "RegisterationTime",
                value: new DateTime(2023, 12, 4, 16, 3, 23, 959, DateTimeKind.Local).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 13,
                column: "RegisterationTime",
                value: new DateTime(2024, 5, 4, 16, 3, 23, 959, DateTimeKind.Local).AddTicks(2634));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 14,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 4, 16, 3, 23, 959, DateTimeKind.Local).AddTicks(2638));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 15,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 4, 16, 3, 23, 959, DateTimeKind.Local).AddTicks(2642));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 16,
                column: "RegisterationTime",
                value: new DateTime(2023, 8, 4, 16, 3, 23, 959, DateTimeKind.Local).AddTicks(2646));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 17,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 4, 16, 3, 23, 959, DateTimeKind.Local).AddTicks(2650));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 18,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 4, 16, 3, 23, 959, DateTimeKind.Local).AddTicks(2654));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(621));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(636));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(646));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(653));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 5,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(660));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 6,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(667));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 7,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(674));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 8,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 9,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(688));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 10,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(695));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 11,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(702));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 12,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(710));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 13,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(717));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 14,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(723));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 15,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(771));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 16,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(778));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 17,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(785));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 18,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(792));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 19,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(799));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 20,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(805));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 21,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(813));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 22,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(820));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 23,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(827));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 24,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(833));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 25,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(840));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 26,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(846));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 27,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(853));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 28,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(859));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 29,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(866));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 30,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(872));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 31,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(920));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 32,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(927));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 33,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(933));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 34,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(977));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 35,
                column: "PostTime",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(984));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimePublished",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(5503));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimePublished",
                value: new DateTime(2024, 7, 4, 16, 3, 23, 962, DateTimeKind.Local).AddTicks(5571));
        }
    }
}
