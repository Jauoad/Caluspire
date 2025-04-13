using Microsoft.EntityFrameworkCore;
using Caluspire.Domain.Entities;
using System;
using System.Linq;

namespace Caluspire.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(j => j.Id);

                entity.Property(j => j.Title)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(j => j.Description)
                      .HasMaxLength(1000);

                entity.HasMany(j => j.Candidates)
                      .WithOne()
                      .HasForeignKey(c => c.JobId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.HasKey(c => c.CandidateId);

                entity.Property(c => c.Name)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(c => c.Status)
                      .IsRequired();

                entity.Property(c => c.Skills)
                      .HasConversion(
                          v => string.Join(',', v),
                          v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                      );
            });
        }
    }
}