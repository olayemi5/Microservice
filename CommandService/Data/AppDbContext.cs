using CommandService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Platform>()
                .HasMany<Command>()
                .WithOne(p => p.Platform!)
                .HasForeignKey(p => p.PlatformId);

            builder
                .Entity<Command>()
                .HasOne(p => p.Platform)
                .WithMany(p => p.Commands)
                .HasForeignKey(p => p.PlatformId);
        }
    }
}