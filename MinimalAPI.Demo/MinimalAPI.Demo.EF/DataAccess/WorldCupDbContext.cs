using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MinimalAPI.Demo.EF.DataAccess.Models;

namespace MinimalAPI.Demo.EF.DataAccess
{
    public class WorldCupDbContext : DbContext
    {
        public WorldCupDbContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<Team> Teams => Set<Team>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasData(
                    new Team { Id = 1, Name = "Qatar", Group = 'A' },
                    new Team { Id = 2, Name = "Ecuador", Group = 'A' },
                    new Team { Id = 3, Name = "Netherlands", Group = 'A' },
                    new Team { Id = 4, Name = "Senegal", Group = 'A' },

                    new Team { Id = 5, Name = "England", Group = 'B' },
                    new Team { Id = 6, Name = "USA", Group = 'B' },
                    new Team { Id = 7, Name = "Wales", Group = 'B' },
                    new Team { Id = 8, Name = "Iran", Group = 'B' }
                );
        }
    }
}
