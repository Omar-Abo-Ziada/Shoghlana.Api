using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shoghlana.EF.Configurations
{
    internal class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
               new IdentityRole()
               {
                   Id = Guid.NewGuid().ToString(),
                   Name = "Admin",
                   NormalizedName = "Admin".ToUpper(),
                   ConcurrencyStamp = Guid.NewGuid().ToString()
               },
                  new IdentityRole()
                  {
                      Id = Guid.NewGuid().ToString(),
                      Name = "Client",
                      NormalizedName = "Client".ToUpper(),
                      ConcurrencyStamp = Guid.NewGuid().ToString()
                  },
                    new IdentityRole()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Freelancer",
                        NormalizedName = "Freelancer".ToUpper(),
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    }
               );
        }
    }
}
