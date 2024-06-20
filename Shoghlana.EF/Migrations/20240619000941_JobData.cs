using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shoghlana.EF.Migrations
{
    /// <inheritdoc />
    public partial class JobData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "165bc26e-84f4-4dfd-8c8a-ab65cfad5938", "7fdea4c6-6776-4b1d-928b-007907f4ce8b", "Freelancer", "FREELANCER" },
                    { "923a5659-53bc-47de-b20c-367f0deb3611", "8f585296-7dc1-4323-b5f1-dc8d55119ed2", "Client", "CLIENT" },
                    { "965ec63a-f4f9-4ceb-a7bb-6a28e3b8bf28", "836ff1f7-8b35-4482-8155-821ce4b9bace", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisterationTime",
                value: new DateTime(2023, 12, 19, 3, 9, 39, 830, DateTimeKind.Local).AddTicks(5737));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisterationTime",
                value: new DateTime(2023, 6, 19, 3, 9, 39, 830, DateTimeKind.Local).AddTicks(5853));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 19, 3, 9, 39, 830, DateTimeKind.Local).AddTicks(5864));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegisterationTime",
                value: new DateTime(2023, 9, 19, 3, 9, 39, 830, DateTimeKind.Local).AddTicks(5872));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 19, 3, 9, 39, 830, DateTimeKind.Local).AddTicks(5881));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 19, 3, 9, 39, 830, DateTimeKind.Local).AddTicks(5889));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7,
                column: "RegisterationTime",
                value: new DateTime(2023, 7, 19, 3, 9, 39, 830, DateTimeKind.Local).AddTicks(5897));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 19, 3, 9, 39, 830, DateTimeKind.Local).AddTicks(5905));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 9,
                column: "RegisterationTime",
                value: new DateTime(2024, 1, 19, 3, 9, 39, 830, DateTimeKind.Local).AddTicks(5913));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 10,
                column: "RegisterationTime",
                value: new DateTime(2023, 8, 19, 3, 9, 39, 830, DateTimeKind.Local).AddTicks(5922));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 11,
                column: "RegisterationTime",
                value: new DateTime(2024, 3, 19, 3, 9, 39, 830, DateTimeKind.Local).AddTicks(5930));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 12,
                column: "RegisterationTime",
                value: new DateTime(2023, 11, 19, 3, 9, 39, 830, DateTimeKind.Local).AddTicks(5938));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 13,
                column: "RegisterationTime",
                value: new DateTime(2024, 4, 19, 3, 9, 39, 830, DateTimeKind.Local).AddTicks(5947));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 14,
                column: "RegisterationTime",
                value: new DateTime(2023, 9, 19, 3, 9, 39, 830, DateTimeKind.Local).AddTicks(5955));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 15,
                column: "RegisterationTime",
                value: new DateTime(2024, 1, 19, 3, 9, 39, 830, DateTimeKind.Local).AddTicks(5963));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 16,
                column: "RegisterationTime",
                value: new DateTime(2023, 7, 19, 3, 9, 39, 830, DateTimeKind.Local).AddTicks(5972));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 17,
                column: "RegisterationTime",
                value: new DateTime(2023, 10, 19, 3, 9, 39, 830, DateTimeKind.Local).AddTicks(5980));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 18,
                column: "RegisterationTime",
                value: new DateTime(2024, 2, 19, 3, 9, 39, 830, DateTimeKind.Local).AddTicks(5988));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostTime",
                value: new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7386));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostTime",
                value: new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7485));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostTime",
                value: new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4,
                column: "PostTime",
                value: new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7542));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 5,
                column: "PostTime",
                value: new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7550));

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CategoryId", "ClientId", "Description", "ExperienceLevel", "FreelancerId", "MaxBudget", "MinBudget", "PostTime", "Title" },
                values: new object[,]
                {
                    { 6, 4, 6, "برمجة وتصميم تطبيقات الهواتف الذكية", 2, 6, 3000m, 1000m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7561), "تطوير تطبيق موبايل لنظام iOS و Android" },
                    { 7, 3, 7, "برمجة وتصميم مواقع التسوق عبر الإنترنت", 1, 7, 1500m, 500m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7569), "تصميم وتطوير موقع تجارة إلكترونية" },
                    { 8, 5, 8, "تسويق وإعلان للشركات والأفراد", 0, 8, 1000m, 300m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7577), "إدارة حملة إعلانية على وسائل التواصل الاجتماعي" },
                    { 9, 6, 9, "فنون تصويرية ورسم", 1, 9, 600m, 200m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7585), "تصميم مجموعة من الرسوم التوضيحية للكتب الأطفال" },
                    { 10, 1, 10, "كتابة محتوى تسويقي وإعلاني", 0, 10, 300m, 100m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7593), "كتابة محتوى إعلاني لموقع الويب" },
                    { 11, 2, 11, "برمجة نظم إدارية متقدمة", 2, null, 2000m, 500m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7603), "تصميم وبرمجة نظام إدارة للموظفين" },
                    { 12, 3, 12, "تحليل اقتصادي ومالي", 2, null, 5000m, 1000m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7612), "إعداد دراسة جدوى لمشروع تجاري مستقبلي" },
                    { 13, 4, 13, "دورات تعليمية وتدريب", 0, null, 200m, 50m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7619), "تعليم البرمجة للمبتدئين عبر الإنترنت" },
                    { 14, 5, 14, "تصميم جرافيك وإعلان", 1, null, 500m, 150m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7627), "تصميم مطبوعات دعائية لفعالية ثقافية" },
                    { 15, 6, 15, "ترجمة وكتابة", 2, null, 800m, 200m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7634), "ترجمة مقالات علمية من الإنجليزية إلى العربية" },
                    { 16, 1, 16, "برمجة ألعاب الفيديو", 2, null, 5000m, 1000m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7642), "تصميم وتطوير لعبة فيديو متنقلة" },
                    { 17, 2, 17, "تصميم وبرمجة منصات تعليمية إلكترونية", 1, null, 1500m, 500m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7650), "تصميم منصة تعليمية عبر الإنترنت" },
                    { 18, 3, 18, "كتابة وتحرير محتوى", 1, null, 700m, 200m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7657), "إدارة محتوى لمدونة تقنية" },
                    { 19, 4, 1, "برمجة وتخصيص نظم CRM", 2, null, 2500m, 800m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7664), "تصميم وتطوير نظام إدارة العلاقات مع العملاء (CRM)" },
                    { 20, 5, 2, "تحليل بيانات وإعداد تقارير", 1, null, 1000m, 300m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7672), "تحليل بيانات وإعداد تقرير استراتيجي للشركات" },
                    { 21, 6, 3, "كتابة محتوى تعليمي وبحثي", 2, null, 1500m, 500m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7680), "كتابة وتحرير كتب إلكترونية في مجال الذكاء الاصطناعي" },
                    { 22, 1, 4, "برمجة وتصميم مواقع تعليمية", 1, null, 1200m, 400m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7688), "تصميم وتطوير موقع تعليمي للطلاب" },
                    { 23, 2, 5, "تصميم وبرمجة تطبيقات الحجز الإلكتروني", 1, null, 1800m, 600m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7695), "تصميم وبرمجة منصة للحجز الإلكتروني للفعاليات" },
                    { 24, 3, 6, "تحسين أداء محركات البحث للمواقع", 0, null, 800m, 200m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7703), "تحسين محركات البحث (SEO) لموقع الويب" },
                    { 25, 4, 7, "برمجة نظم إدارة متكاملة", 2, null, 2500m, 700m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7710), "تطوير نظام لإدارة المخزون والمبيعات للشركات الصغيرة" },
                    { 26, 5, 8, "تحليل اقتصادي ومالي للمشاريع العقارية", 2, null, 5000m, 1500m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7718), "إعداد دراسة جدوى لمشروع سكني جديد" },
                    { 27, 6, 9, "برمجة تطبيقات المساعدة الشخصية", 2, null, 3000m, 800m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7725), "تصميم وتطوير تطبيق للمساعدة الشخصية عبر الإنترنت" },
                    { 28, 1, 10, "تسويق وجمع التبرعات", 1, null, 1500m, 400m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7733), "إنشاء وإدارة حملة تبرعات عبر الإنترنت" },
                    { 29, 2, 11, "تصميم وبرمجة منصات تعليمية تفاعلية", 1, null, 2000m, 600m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7740), "تطوير منصة تعليمية تفاعلية لتعليم الرياضيات" },
                    { 30, 3, 12, "برمجة وتصميم ألعاب تعليمية", 0, null, 1200m, 300m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7748), "تصميم وتطوير لعبة فيديو تعليمية للأطفال" },
                    { 31, 4, 13, "تحليل سياسات وإعداد تقارير", 0, null, 700m, 200m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7756), "إعداد تقرير بحثي عن السياسات العامة" },
                    { 32, 5, 14, "برمجة وتخصيص نظم إدارة المحتوى", 1, null, 1500m, 400m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7763), "تصميم وبرمجة نظام إدارة المحتوى للمدونات" },
                    { 33, 6, 15, "تسويق وإعلان عن المنتجات", 0, null, 1000m, 300m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7771), "إعداد وتنفيذ حملة تسويقية لمنتج جديد" },
                    { 34, 1, 16, "برمجة نظم إدارة المشاريع", 2, null, 2500m, 600m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7779), "تصميم وبرمجة نظام لإدارة المشاريع الهندسية" },
                    { 35, 2, 17, "برمجة وتصميم تطبيقات تعليمية", 1, null, 1800m, 500m, new DateTime(2024, 6, 19, 3, 9, 39, 835, DateTimeKind.Local).AddTicks(7786), "تصميم وتطوير تطبيق لتعليم لغات البرمجة" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "165bc26e-84f4-4dfd-8c8a-ab65cfad5938");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "923a5659-53bc-47de-b20c-367f0deb3611");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "965ec63a-f4f9-4ceb-a7bb-6a28e3b8bf28");

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 35);

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
                column: "PostTime",
                value: new DateTime(2024, 6, 19, 2, 53, 14, 548, DateTimeKind.Local).AddTicks(8766));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostTime",
                value: new DateTime(2024, 6, 19, 2, 53, 14, 548, DateTimeKind.Local).AddTicks(8825));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostTime",
                value: new DateTime(2024, 6, 19, 2, 53, 14, 548, DateTimeKind.Local).AddTicks(8832));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4,
                column: "PostTime",
                value: new DateTime(2024, 6, 19, 2, 53, 14, 548, DateTimeKind.Local).AddTicks(8882));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 5,
                column: "PostTime",
                value: new DateTime(2024, 6, 19, 2, 53, 14, 548, DateTimeKind.Local).AddTicks(8889));
        }
    }
}
