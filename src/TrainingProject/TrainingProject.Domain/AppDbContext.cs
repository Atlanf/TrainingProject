using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainingProject.Domain.Models;

namespace TrainingProject.Domain
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Result> Results { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Choice>()
                .Property(e => e.Choices)
                .HasConversion(
                    v => string.Join('|', v),
                    v => v.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                )
                .Metadata.SetValueComparer(new ValueComparer<string[]>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToArray())
                );

            modelBuilder.Entity<Choice>()
                .Property(e => e.Answers)
                .HasConversion(
                    v => string.Join('|', v),
                    v => v.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(val => int.Parse(val))
                        .ToArray())
                .Metadata.SetValueComparer(new ValueComparer<int[]>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToArray())
                );

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
