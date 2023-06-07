using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{

    public class UserAchievementConfiguration : IEntityTypeConfiguration<UserAchievement>
    {
        public void Configure(EntityTypeBuilder<UserAchievement> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.User).IsRequired().HasMaxLength(50);
            builder.Property(x => x.QuouteId).IsRequired();
            builder.Property(x => x.Quote).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Answer).IsRequired().HasMaxLength(50);
            builder.Property(x => x.QuoteAuthor).IsRequired().HasMaxLength(50);
            
        }
    }
}

