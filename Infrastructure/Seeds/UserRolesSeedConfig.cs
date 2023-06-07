using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Seeds
{
    public class UserRolesSeedConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "9a92589c-7415-4f0a-b98r-ad4d0d6iu174",
                    RoleId = "94522b4b-23eb-344a-2278-cg215d880e3c"
                }
            );
        }
    }
}

