using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoghlana.Core.Models;
using System.Collections.Generic;

namespace Shoghlana.EF.Configurations
{
    internal class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasData(
                new List<Skill>()
                {
                    new Skill { Id = 1, Title = "تصميم الجرافيك" },
                    new Skill { Id = 2, Title = "الرسم الصناعي" },
                    new Skill { Id = 3, Title = "تصميم الويب" },
                    new Skill { Id = 4, Title = "تصميم الهوية التجارية" },
                    new Skill { Id = 5, Title = "تصميم المنتجات" },
                    new Skill { Id = 6, Title = "تصميم الشعارات" },
                    new Skill { Id = 7, Title = "تطوير تطبيقات الجوال" },
                    new Skill { Id = 8, Title = "تطوير الويب" },
                    new Skill { Id = 9, Title = "تطوير الألعاب" },
                    new Skill { Id = 10, Title = "برمجة الحاسوب" },
                    new Skill { Id = 11, Title = "كتابة المحتوى" },
                    new Skill { Id = 12, Title = "كتابة المقالات" },
                    new Skill { Id = 13, Title = "الترجمة" },
                    new Skill { Id = 14, Title = "التدقيق اللغوي" },
                    new Skill { Id = 15, Title = "الكتابة الفنية" },
                    new Skill { Id = 16, Title = "التسويق الرقمي" },
                    new Skill { Id = 17, Title = "تحسين محركات البحث (SEO)" },
                    new Skill { Id = 18, Title = "الإعلانات عبر وسائل التواصل الاجتماعي" },
                    new Skill { Id = 19, Title = "التسويق بالبريد الإلكتروني" },
                    new Skill { Id = 20, Title = "التسويق بالمحتوى" },
                    new Skill { Id = 21, Title = "الدعم الفني" },
                    new Skill { Id = 22, Title = "إدارة الشبكات" },
                    new Skill { Id = 23, Title = "صيانة الأنظمة" },
                    new Skill { Id = 24, Title = "دعم سطح المكتب" },
                    new Skill { Id = 25, Title = "خدمات الحوسبة السحابية" },
                    new Skill { Id = 26, Title = "تطوير البرامج التعليمية" },
                    new Skill { Id = 27, Title = "تصميم المناهج الدراسية" },
                    new Skill { Id = 28, Title = "تطوير التعليم الإلكتروني" },
                    new Skill { Id = 29, Title = "تصميم الدروس التعليمية" },
                    new Skill { Id = 30, Title = "تعليم عبر الإنترنت" },
                    new Skill { Id = 31, Title = "تصميم الإعلانات" },
                    new Skill { Id = 32, Title = "تصميم واجهات المستخدم (UI)" },
                    new Skill { Id = 33, Title = "تجربة المستخدم (UX)" },
                    new Skill { Id = 34, Title = "نمذجة ثلاثية الأبعاد (3D)" },
                    new Skill { Id = 35, Title = "تصميم الشخصيات" },
                    new Skill { Id = 36, Title = "تطوير التطبيقات بواسطة React.js" },
                    new Skill { Id = 37, Title = "تطوير التطبيقات بواسطة Node.js" },
                    new Skill { Id = 38, Title = "تطوير التطبيقات بواسطة Ruby on Rails" },
                    new Skill { Id = 39, Title = "تطوير التطبيقات بواسطة SQL" },
                    new Skill { Id = 40, Title = "تطوير التطبيقات بواسطة Django" },
                    new Skill { Id = 41, Title = "كتابة المقالات القانونية" },
                    new Skill { Id = 42, Title = "الكتابة الإبداعية" },
                    new Skill { Id = 43, Title = "التحقق القانوني" },
                    new Skill { Id = 44, Title = "التعريب" },
                    new Skill { Id = 45, Title = "تحليل السوق" },
                    new Skill { Id = 46, Title = "التحليلات الإحصائية" },
                    new Skill { Id = 47, Title = "التسويق بالأداء" },
                    new Skill { Id = 48, Title = "التسويق بالشراكة" },
                    new Skill { Id = 49, Title = "التسويق الإلكتروني" },
                    new Skill { Id = 50, Title = "إدارة الحملات الإعلانية" }
                }
                );
        }
    }
}
