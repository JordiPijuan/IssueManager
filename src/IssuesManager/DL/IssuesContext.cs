using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using IssuesManager.Models;

namespace IssuesManager.DL
{
    public class IssuesContext : DbContext
    {
        public IssuesContext(DbContextOptions<IssuesContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureUserEntity(modelBuilder);
        }

        private void ConfigureUserEntity (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(b => b.UserId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                .Property(b => b.DecPassword)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<User>()
                .Property(b => b.Password)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(150);

            modelBuilder.Entity<User>()
                .Property(b => b.Surname)
                .HasMaxLength(150);

            modelBuilder.Entity<User>()
                .Property(b => b.UserName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
