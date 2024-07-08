using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoghlana.Core.Enums;
using Shoghlana.Core.Models;

namespace Shoghlana.EF.Configurations
{
    internal class JobConfiguraion : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(j => j.Id);

            builder.Property(j => j.Title)
                  .HasMaxLength(100);

            builder.Property(j => j.Description)
                  .HasMaxLength(1000);

            builder.Property(j => j.MinBudget)
                   .HasColumnType("decimal(18,2)");

            builder.Property(j => j.MaxBudget)
                   .HasColumnType("decimal(18,2)");

            builder.Property(j => j.Status)
                       .HasDefaultValue(JobStatus.Active);

            builder.HasOne(j => j.Client)
                   .WithMany(c => c.Jobs)
               .HasForeignKey(j => j.ClientId);

            builder.HasOne(j => j.AcceptedFreelancer)
                   .WithMany(f => f.WorkingHistory)
                           .HasForeignKey(j => j.AcceptedFreelancerId);

            builder.HasOne(j => j.Category)
                   .WithMany(c => c.Jobs)
                   .HasForeignKey(j => j.CategoryId);

            builder.HasData(
                new Job
                {
                    Id = 1,
                    Title = "تصميم شعار احترافي ومميز",
                    PostTime = DateTime.Now,
                    Description = "تصميم وأعمال فنية احترافية",
                    MinBudget = 100,
                    MaxBudget = 500,
                    ExperienceLevel = ExperienceLevel.Beginner,
                    Status = JobStatus.Active,
                    ClientId = 1,
                    AcceptedFreelancerId = 1,
                    CategoryId = 1,
                },
                new Job
                {
                    Id = 2,
                    Title = "تصميم بوستر إعلاني لمواقع التواصل",
                    PostTime = DateTime.Now,
                    Description = "تصميم وأعمال فنية إدارية",
                    MinBudget = 200,
                    MaxBudget = 700,
                    ExperienceLevel = ExperienceLevel.Intermediate,
                    Status = JobStatus.Active,
                    ClientId = 2,
                    AcceptedFreelancerId = 2,
                    CategoryId = 1
                },
                new Job
                {
                    Id = 3,
                    Title = "تصميم كارت شخصي احترافي للطباعة",
                    PostTime = DateTime.Now,
                    Description = "تصميم بطاقات أعمال",
                    MinBudget = 150,
                    MaxBudget = 600,
                    ExperienceLevel = ExperienceLevel.Professional,
                    Status = JobStatus.completed,
                    ClientId = 3,
                    AcceptedFreelancerId = 3,
                    CategoryId = 1
                },
                new Job
                {
                    Id = 4,
                    Title = "تركيب لوحة تحكم مجانية مدى الحياة",
                    PostTime = DateTime.Now,
                    Description = "برمجة وتطوير المواقع والتطبيقات",
                    MinBudget = 300,
                    MaxBudget = 800,
                    ExperienceLevel = ExperienceLevel.Intermediate,
                    Status = JobStatus.completed,
                    ClientId = 4,
                    AcceptedFreelancerId = 4,
                    CategoryId = 2
                },
                new Job
                {
                    Id = 5,
                    Title = "تصميم موقع تعريفي للشركات",
                    PostTime = DateTime.Now,
                    Description = "برمجة مواقع الإنترنت",
                    MinBudget = 200,
                    MaxBudget = 700,
                    ExperienceLevel = ExperienceLevel.Beginner,
                    Status = JobStatus.Closed,
                    ClientId = 5,
                    AcceptedFreelancerId = 5,
                    CategoryId = 3
                },
                new Job
                {
                    Id = 6,
                    Title = "تطوير تطبيق موبايل لنظام iOS و Android",
                    PostTime = DateTime.Now,
                    Description = "برمجة وتصميم تطبيقات الهواتف الذكية",
                    MinBudget = 1000,
                    MaxBudget = 3000,
                    ExperienceLevel = ExperienceLevel.Professional,
                    Status = JobStatus.Closed,
                    ClientId = 6,
                    AcceptedFreelancerId = 6,
                    CategoryId = 4
                },
                new Job
                {
                    Id = 7,
                    Title = "تصميم وتطوير موقع تجارة إلكترونية",
                    PostTime = DateTime.Now,
                    Description = "برمجة وتصميم مواقع التسوق عبر الإنترنت",
                    MinBudget = 500,
                    MaxBudget = 1500,
                    ExperienceLevel = ExperienceLevel.Intermediate,
                    Status = JobStatus.completed,
                    ClientId = 7,
                    AcceptedFreelancerId = 7,
                    CategoryId = 3
                },
                new Job
                {
                    Id = 8,
                    Title = "إدارة حملة إعلانية على وسائل التواصل الاجتماعي",
                    PostTime = DateTime.Now,
                    Description = "تسويق وإعلان للشركات والأفراد",
                    MinBudget = 300,
                    MaxBudget = 1000,
                    ExperienceLevel = ExperienceLevel.Beginner,
                    Status = JobStatus.completed,
                    ClientId = 8,
                    AcceptedFreelancerId = 8,
                    CategoryId = 5
                },
                new Job
                {
                    Id = 9,
                    Title = "تصميم مجموعة من الرسوم التوضيحية للكتب الأطفال",
                    PostTime = DateTime.Now,
                    Description = "فنون تصويرية ورسم",
                    MinBudget = 200,
                    MaxBudget = 600,
                    ExperienceLevel = ExperienceLevel.Intermediate,
                    Status = JobStatus.completed,
                    ClientId = 9,
                    AcceptedFreelancerId = 9,
                    CategoryId = 6
                },
                new Job
                {
                    Id = 10,
                    Title = "كتابة محتوى إعلاني لموقع الويب",
                    PostTime = DateTime.Now,
                    Description = "كتابة محتوى تسويقي وإعلاني",
                    MinBudget = 100,
                    MaxBudget = 300,
                    ExperienceLevel = ExperienceLevel.Beginner,
                    Status = JobStatus.completed,
                    ClientId = 10,
                    AcceptedFreelancerId = 10,
                    CategoryId = 1
                },
                new Job
                {
                    Id = 11,
                    Title = "تصميم وبرمجة نظام إدارة للموظفين",
                    PostTime = DateTime.Now.AddDays(-5),
                    Description = "برمجة نظم إدارية متقدمة",
                    MinBudget = 500,
                    MaxBudget = 2000,
                    ExperienceLevel = ExperienceLevel.Professional,
                    Status = JobStatus.Active,
                    ClientId = 11,
                    CategoryId = 2
                },
                new Job
                {
                    Id = 12,
                    Title = "إعداد دراسة جدوى لمشروع تجاري مستقبلي",
                    PostTime = DateTime.Now.AddDays(-5),
                    Description = "تحليل اقتصادي ومالي",
                    MinBudget = 1000,
                    MaxBudget = 5000,
                    ExperienceLevel = ExperienceLevel.Professional,
                    Status = JobStatus.Active,
                    ClientId = 12,
                    //AcceptedFreelancerId = 12,
                    CategoryId = 3
                },
                new Job
                {
                    Id = 13,
                    Title = "تعليم البرمجة للمبتدئين عبر الإنترنت",
                    PostTime = DateTime.Now.AddDays(-5),
                    Description = "دورات تعليمية وتدريب",
                    MinBudget = 50,
                    MaxBudget = 200,
                    ExperienceLevel = ExperienceLevel.Beginner,
                    Status = JobStatus.Closed,
                    ClientId = 13,
                    //AcceptedFreelancerId = 13,
                    CategoryId = 4
                },
                new Job
                {
                    Id = 14,
                    Title = "تصميم مطبوعات دعائية لفعالية ثقافية",
                    PostTime = DateTime.Now.AddDays(-5),
                    Description = "تصميم جرافيك وإعلان",
                    MinBudget = 150,
                    MaxBudget = 500,
                    ExperienceLevel = ExperienceLevel.Intermediate,
                    Status = JobStatus.Active,
                    ClientId = 14,
                    //AcceptedFreelancerId = 14,
                    CategoryId = 5
                },
                new Job
                {
                    Id = 15,
                    Title = "ترجمة مقالات علمية من الإنجليزية إلى العربية",
                    PostTime = DateTime.Now.AddDays(-5),
                    Description = "ترجمة وكتابة",
                    MinBudget = 200,
                    MaxBudget = 800,
                    ExperienceLevel = ExperienceLevel.Professional,
                    Status = JobStatus.Active,
                    ClientId = 15,
                    //AcceptedFreelancerId = 15,
                    CategoryId = 6
                },
                new Job
                {
                    Id = 16,
                    Title = "تصميم وتطوير لعبة فيديو متنقلة",
                    PostTime = DateTime.Now.AddDays(-5),
                    Description = "برمجة ألعاب الفيديو",
                    MinBudget = 1000,
                    MaxBudget = 5000,
                    ExperienceLevel = ExperienceLevel.Professional,
                    Status = JobStatus.Active,
                    ClientId = 16,
                    //AcceptedFreelancerId = 16,
                    CategoryId = 1
                },
                new Job
                {
                    Id = 17,
                    Title = "تصميم منصة تعليمية عبر الإنترنت",
                    PostTime = DateTime.Now.AddDays(-5),
                    Description = "تصميم وبرمجة منصات تعليمية إلكترونية",
                    MinBudget = 500,
                    MaxBudget = 1500,
                    ExperienceLevel = ExperienceLevel.Intermediate,
                    Status = JobStatus.Active,
                    ClientId = 17,
                    //AcceptedFreelancerId = 17,
                    CategoryId = 2
                },
                new Job
                {
                    Id = 18,
                    Title = "إدارة محتوى لمدونة تقنية",
                    PostTime = DateTime.Now.AddDays(-5),
                    Description = "كتابة وتحرير محتوى",
                    MinBudget = 200,
                    MaxBudget = 700,
                    ExperienceLevel = ExperienceLevel.Intermediate,
                    Status = JobStatus.completed,
                    ClientId = 18,
                    //AcceptedFreelancerId = 18,
                    CategoryId = 3
                },
                new Job
                {
                    Id = 19,
                    Title = "تصميم وتطوير نظام إدارة العلاقات مع العملاء (CRM)",
                    PostTime = DateTime.Now.AddDays(-5),
                    Description = "برمجة وتخصيص نظم CRM",
                    MinBudget = 800,
                    MaxBudget = 2500,
                    ExperienceLevel = ExperienceLevel.Professional,
                    Status = JobStatus.completed,
                    ClientId = 1,
                    //AcceptedFreelancerId = 19,
                    CategoryId = 4
                },
                new Job
                {
                    Id = 20,
                    Title = "تحليل بيانات وإعداد تقرير استراتيجي للشركات",
                    PostTime = DateTime.Now.AddDays(-5),
                    Description = "تحليل بيانات وإعداد تقارير",
                    MinBudget = 300,
                    MaxBudget = 1000,
                    ExperienceLevel = ExperienceLevel.Intermediate,
                    Status = JobStatus.Closed,
                    ClientId = 2,
                    //AcceptedFreelancerId = 20,
                    CategoryId = 5
                },
                new Job
                {
                    Id = 21,
                    Title = "كتابة وتحرير كتب إلكترونية في مجال الذكاء الاصطناعي",
                    PostTime = DateTime.Now.AddDays(5),
                    Description = "كتابة محتوى تعليمي وبحثي",
                    MinBudget = 500,
                    MaxBudget = 1500,
                    ExperienceLevel = ExperienceLevel.Professional,
                    Status = JobStatus.Closed,
                    ClientId = 3,
                    //AcceptedFreelancerId = 21,
                    CategoryId = 6
                },
                new Job
                {
                    Id = 22,
                    Title = "تصميم وتطوير موقع تعليمي للطلاب",
                    PostTime = DateTime.Now.AddDays(5),
                    Description = "برمجة وتصميم مواقع تعليمية",
                    MinBudget = 400,
                    MaxBudget = 1200,
                    ExperienceLevel = ExperienceLevel.Intermediate,
                    Status = JobStatus.Active,
                    ClientId = 4,
                    //AcceptedFreelancerId = 22,
                    CategoryId = 1
                },
                new Job
                {
                    Id = 23,
                    Title = "تصميم وبرمجة منصة للحجز الإلكتروني للفعاليات",
                    PostTime = DateTime.Now.AddDays(5),
                    Description = "تصميم وبرمجة تطبيقات الحجز الإلكتروني",
                    MinBudget = 600,
                    MaxBudget = 1800,
                    ExperienceLevel = ExperienceLevel.Intermediate,
                    Status = JobStatus.Active,
                    ClientId = 5,
                    //AcceptedFreelancerId = 23,
                    CategoryId = 2
                },
                new Job
                {
                    Id = 24,
                    Title = "تحسين محركات البحث (SEO) لموقع الويب",
                    PostTime = DateTime.Now.AddDays(5),
                    Description = "تحسين أداء محركات البحث للمواقع",
                    MinBudget = 200,
                    MaxBudget = 800,
                    ExperienceLevel = ExperienceLevel.Beginner,
                    Status = JobStatus.Active,
                    ClientId = 6,
                    //AcceptedFreelancerId = 24,
                    CategoryId = 3
                },
                new Job
                {
                    Id = 25,
                    Title = "تطوير نظام لإدارة المخزون والمبيعات للشركات الصغيرة",
                    PostTime = DateTime.Now.AddDays(5),
                    Description = "برمجة نظم إدارة متكاملة",
                    MinBudget = 700,
                    MaxBudget = 2500,
                    ExperienceLevel = ExperienceLevel.Professional,
                    Status = JobStatus.Active,
                    ClientId = 7,
                    //AcceptedFreelancerId = 25,
                    CategoryId = 4
                },
                new Job
                {
                    Id = 26,
                    Title = "إعداد دراسة جدوى لمشروع سكني جديد",
                    PostTime = DateTime.Now.AddDays(5),
                    Description = "تحليل اقتصادي ومالي للمشاريع العقارية",
                    MinBudget = 1500,
                    MaxBudget = 5000,
                    ExperienceLevel = ExperienceLevel.Professional,
                    Status = JobStatus.Active,
                    ClientId = 8,
                    //AcceptedFreelancerId = 26,
                    CategoryId = 5
                },
                new Job
                {
                    Id = 27,
                    Title = "تصميم وتطوير تطبيق للمساعدة الشخصية عبر الإنترنت",
                    PostTime = DateTime.Now.AddDays(5),
                    Description = "برمجة تطبيقات المساعدة الشخصية",
                    MinBudget = 800,
                    MaxBudget = 3000,
                    ExperienceLevel = ExperienceLevel.Professional,
                    Status = JobStatus.Active,
                    ClientId = 9,
                    //AcceptedFreelancerId = 27,
                    CategoryId = 6
                },
                new Job
                {
                    Id = 28,
                    Title = "إنشاء وإدارة حملة تبرعات عبر الإنترنت",
                    PostTime = DateTime.Now.AddDays(5),
                    Description = "تسويق وجمع التبرعات",
                    MinBudget = 400,
                    MaxBudget = 1500,
                    ExperienceLevel = ExperienceLevel.Intermediate,
                    Status = JobStatus.Closed,
                    ClientId = 10,
                    //AcceptedFreelancerId = 28,
                    CategoryId = 1
                },
                new Job
                {
                    Id = 29,
                    Title = "تطوير منصة تعليمية تفاعلية لتعليم الرياضيات",
                    PostTime = DateTime.Now.AddDays(5),
                    Description = "تصميم وبرمجة منصات تعليمية تفاعلية",
                    MinBudget = 600,
                    MaxBudget = 2000,
                    ExperienceLevel = ExperienceLevel.Intermediate,
                    Status = JobStatus.Closed,
                    ClientId = 11,
                    //AcceptedFreelancerId = 29,
                    CategoryId = 2
                },
                new Job
                {
                    Id = 30,
                    Title = "تصميم وتطوير لعبة فيديو تعليمية للأطفال",
                    PostTime = DateTime.Now.AddDays(5),
                    Description = "برمجة وتصميم ألعاب تعليمية",
                    MinBudget = 300,
                    MaxBudget = 1200,
                    ExperienceLevel = ExperienceLevel.Beginner,
                    Status = JobStatus.Closed,
                    ClientId = 12,
                    //AcceptedFreelancerId = 30,
                    CategoryId = 3
                },
                new Job
                {
                    Id = 31,
                    Title = "إعداد تقرير بحثي عن السياسات العامة",
                    PostTime = DateTime.Now.AddDays(5),
                    Description = "تحليل سياسات وإعداد تقارير",
                    MinBudget = 200,
                    MaxBudget = 700,
                    ExperienceLevel = ExperienceLevel.Beginner,
                    Status = JobStatus.Closed,
                    ClientId = 13,
                    //AcceptedFreelancerId = 31,
                    CategoryId = 4
                },
                new Job
                {
                    Id = 32,
                    Title = "تصميم وبرمجة نظام إدارة المحتوى للمدونات",
                    PostTime = DateTime.Now.AddDays(5),
                    Description = "برمجة وتخصيص نظم إدارة المحتوى",
                    MinBudget = 400,
                    MaxBudget = 1500,
                    ExperienceLevel = ExperienceLevel.Intermediate,
                    Status = JobStatus.Active,
                    ClientId = 14,
                    //AcceptedFreelancerId = 32,
                    CategoryId = 5
                },
                new Job
                {
                    Id = 33,
                    Title = "إعداد وتنفيذ حملة تسويقية لمنتج جديد",
                    PostTime = DateTime.Now.AddDays(5),
                    Description = "تسويق وإعلان عن المنتجات",
                    MinBudget = 300,
                    MaxBudget = 1000,
                    ExperienceLevel = ExperienceLevel.Beginner,
                    Status = JobStatus.Active,
                    ClientId = 15,
                    //AcceptedFreelancerId = 33,
                    CategoryId = 6
                },
                new Job
                {
                    Id = 34,
                    Title = "تصميم وبرمجة نظام لإدارة المشاريع الهندسية",
                    PostTime = DateTime.Now.AddDays(5),
                    Description = "برمجة نظم إدارة المشاريع",
                    MinBudget = 600,
                    MaxBudget = 2500,
                    ExperienceLevel = ExperienceLevel.Professional,
                    Status = JobStatus.Active,
                    ClientId = 16,
                    //AcceptedFreelancerId = 34,
                    CategoryId = 1
                },
                new Job
                {
                    Id = 35,
                    Title = "تصميم وتطوير تطبيق لتعليم لغات البرمجة",
                    PostTime = DateTime.Now.AddDays(5),
                    Description = "برمجة وتصميم تطبيقات تعليمية",
                    MinBudget = 500,
                    MaxBudget = 1800,
                    ExperienceLevel = ExperienceLevel.Intermediate,
                    Status = JobStatus.Active,
                    ClientId = 17,
                    //AcceptedFreelancerId = 35,
                    CategoryId = 2
                }
            );

        }
    }
}