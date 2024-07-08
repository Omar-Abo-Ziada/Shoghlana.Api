using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoghlana.Core.Models;

namespace Shoghlana.EF.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Title).IsRequired().HasMaxLength(50);

            builder.Property(c => c.Description).IsRequired(false).HasMaxLength(200);

            builder.HasData(
                new Category { Id = 1, Title = "خدمات التصميم", Description = "تشمل كافة الخدمات المتعلقة بالتصميم الجرافيكي، التصميم الصناعي، وتصميم الويب." },
                new Category { Id = 2, Title = "خدمات برمجية", Description = "تشمل كتابة وتطوير التطبيقات والبرمجيات لمختلف الأنظمة والأجهزة." },
                new Category { Id = 3, Title = "خدمات الكتابة والترجمة", Description = "تشمل كتابة المقالات، الترجمة الفورية، وكتابة المحتوى للمواقع والمدونات." },
                new Category { Id = 4, Title = "خدمات التسويق الرقمي", Description = "تشمل إدارة حملات التسويق الرقمي، الإعلانات على وسائل التواصل الاجتماعي، وتحليلات السوق." },
                new Category { Id = 5, Title = "خدمات الدعم الفني والتقني", Description = "تشمل دعم المستخدمين، إصلاح الأعطال التقنية، وتحسين أداء النظم والشبكات." },
                new Category { Id = 6, Title = "خدمات التعليم والتدريب", Description = "تشمل تقديم دورات تدريبية، تصميم مناهج تعليمية، وتطوير الموارد التعليمية." }
            );
        }
    }
}