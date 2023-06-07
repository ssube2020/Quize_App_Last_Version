using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Seeds
{
    public class UsersSeedConfig : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            var hasher = new PasswordHasher<IdentityUser>();

            builder.HasData(
                new IdentityUser
                {

                    Id = "9a92589c-7415-4f0a-b98r-ad4d0d6iu174",
                    UserName = "admin",
                    PasswordHash = hasher.HashPassword(null, "asdASD@123"),
                }
               
             );
        }
    }
}

