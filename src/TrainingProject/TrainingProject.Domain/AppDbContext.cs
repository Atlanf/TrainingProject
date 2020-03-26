using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingProject.Domain.Models;

namespace TrainingProject.Domain
{
    public class AppDbContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Result>()
                .HasKey(x => new { x.UserId, x.TestId });

            modelBuilder.Entity<Result>()
                .HasOne(r => r.Test)
                .WithMany(u => u.Results)
                .HasForeignKey(r => r.TestId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Result>()
                .HasOne(r => r.User)
                .WithMany(t => t.Results)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.SetNull);*/
            
            DataSeeding.Seed(modelBuilder);
        }
    }
}
