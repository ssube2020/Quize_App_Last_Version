using System;
using System.Reflection.Emit;
using Core.Entities;
using Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataContext
{

    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new QuoteConfiguration());
            builder.ApplyConfiguration(new UserAchievementConfiguration());
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            builder.Entity<Quote>().ToTable("Quotes");
            builder.Entity<UserAchievement>().ToTable("UserAchievements");
        }

        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<UserAchievement> UserAchievements { get; set; }
    }

}

