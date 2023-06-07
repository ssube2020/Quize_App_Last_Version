using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Constants;

namespace Infrastructure.Seeds
{
    public class RoleSeedConfig : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "94522b4b-23eb-344a-2278-cg215d880e3c",
                    Name = RoleConsts.Admin,
                    NormalizedName = RoleConsts.Admin.ToUpper()
                },
                new IdentityRole
                {
                    Id = "42567b4b-33et-384r-5778-cg215d990e3c",
                    Name = RoleConsts.BasicUser,
                    NormalizedName = RoleConsts.BasicUser.ToUpper()
                }
            );
        }
    }

}

