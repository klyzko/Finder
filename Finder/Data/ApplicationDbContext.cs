using Microsoft.EntityFrameworkCore;
using Finder.Models;

namespace Finder.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.ReceivedMatches)
                .WithOne(m => m.UserReciever)
                .HasForeignKey(m => m.UserRecieverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.SentMatches)
                .WithOne(m => m.UserSender)
                .HasForeignKey(m => m.UserSenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.UserSender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.UserSenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.UserReciever)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.UserReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}