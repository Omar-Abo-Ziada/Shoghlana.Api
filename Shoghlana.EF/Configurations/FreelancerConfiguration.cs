using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoghlana.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.EF.Configurations
{
    internal class FreelancerConfiguration : IEntityTypeConfiguration<Freelancer>
    {
        public void Configure(EntityTypeBuilder<Freelancer> builder)
        {

            // Seed initial data
            builder.HasData(
                new Freelancer
                {
                    Id = 1,
                    Name = "محمد أحمد",
                    Title = "مطور تطبيقات متخصص",
                    Address = "القاهرة، مصر",
                    Overview = "مطور محترف بخبرة في تطوير تطبيقات الويب والهواتف الذكية",

                },
                new Freelancer
                {
                    Id = 2,
                    Name = "فاطمة علي",
                    Title = "مصممة جرافيك محترفة",
                    Address = "الرياض، السعودية",
                    Overview = "مصممة ذات خبرة عالية في تصميم الشعارات والبوسترات",
                },
                new Freelancer
                {
                    Id = 3,
                    Name = "أحمد خالد",
                    Title = "مبرمج متخصص في الذكاء الاصطناعي",
                    Address = "القاهرة، مصر",
                    Overview = "مبرمج ذو خبرة في تطوير التطبيقات المتقدمة باستخدام تقنيات الذكاء الاصطناعي",
                },
                new Freelancer
                {
                    Id = 4,
                    Name = "سارة حسين",
                    Title = "مصممة تجريدية ومبدعة",
                    Address = "دبي، الإمارات",
                    Overview = "مصممة جرافيك بخبرة في التصميم التجريدي والفنون الإبداعية",
                },
                new Freelancer
                {
                    Id = 5,
                    Name = "عبد الرحمن محمود",
                    Title = "مطور مواقع إلكترونية متقدم",
                    Address = "الإسكندرية، مصر",
                    Overview = "مطور محترف بخبرة في بناء وتطوير المواقع الإلكترونية الكبيرة والمعقدة",
                },
                new Freelancer
                {
                    Id = 6,
                    Name = "ريما عبدالله",
                    Title = "مصممة جرافيك احترافية",
                    Address = "جدة، السعودية",
                    Overview = "مصممة جرافيك بخبرة واسعة في تصميم الشعارات والهويات التجارية",
                },
                new Freelancer
                {
                    Id = 7,
                    Name = "محمود علي",
                    Title = "مطور تطبيقات متخصص في الهواتف الذكية",
                    Address = "القاهرة، مصر",
                    Overview = "مطور متخصص بخبرة في تطوير تطبيقات الهواتف الذكية باستخدام أحدث التقنيات",
                },
                new Freelancer
                {
                    Id = 8,
                    Name = "نور عبدالله",
                    Title = "مطورة تطبيقات محترفة",
                    Address = "الرياض، السعودية",
                    Overview = "مطورة بخبرة في تطوير تطبيقات الويب والهواتف الذكية بتقنيات متقدمة",
                },
                new Freelancer
                {
                    Id = 9,
                    Name = "ليلى محمد",
                    Title = "مصممة جرافيك وفنانة مبدعة",
                    Address = "الإسكندرية، مصر",
                    Overview = "مصممة جرافيك وفنانة بخبرة في تصميم الرسومات والفنون التشكيلية",
                },
                new Freelancer
                {
                    Id = 10,
                    Name = "علي الحسيني",
                    Title = "مطور تطبيقات إلكترونية",
                    Address = "المنامة، البحرين",
                    Overview = "مطور بخبرة في تطوير تطبيقات الويب والهواتف الذكية باللغات المتعددة",
                }
                );
        }
    }
}