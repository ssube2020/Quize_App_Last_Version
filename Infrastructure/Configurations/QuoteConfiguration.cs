using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class QuoteConfiguration : IEntityTypeConfiguration<Quote>
    {
        public void Configure(EntityTypeBuilder<Quote> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.QuoteName).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Author).IsRequired().HasMaxLength(50);
        }
    }
}

