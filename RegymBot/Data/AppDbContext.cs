﻿using Microsoft.EntityFrameworkCore;
using RegymBot.Data.Entities;
using System.Reflection;

namespace RegymBot.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<FeedbackEntity> Feedbacks { get; set; }
        public DbSet<PriceEntity> Prices { get; set; }
        public DbSet<StaticMessageEntity> StaticMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
