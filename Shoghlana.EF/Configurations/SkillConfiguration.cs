using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Shoghlana.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.EF.Configurations
{
    internal class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasData
             (
                 new List<Skill>()
                 {
                        new Skill() { Id = 1, Title = "C#" },
                        new Skill() { Id = 2, Title = "LINQ" },
                        new Skill() { Id = 3, Title = "EF" },
                        new Skill() { Id = 4, Title = "OOP" },
                        new Skill() { Id = 5, Title = "Agile" },
                        new Skill() { Id = 6, Title = "Blazor" },
                 }
             );
        }
    }
}
