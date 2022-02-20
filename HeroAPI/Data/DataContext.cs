using HeroAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).Seed();
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
