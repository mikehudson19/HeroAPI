using HeroAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroAPI.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<SuperHero>().HasData(
                new SuperHero() { Id = 1, Name = "Batman", FirstName = "Bruce", LastName = "Wayne", Place = "Gotham City" },
                new SuperHero() { Id = 2, Name = "Spider-Man", FirstName = "Peter", LastName = "Parker", Place = "New York City" },
                new SuperHero() { Id = 3, Name = "Iron-Man", FirstName = "Tony", LastName = "Stark", Place = "Los Angeles" }
            );
        }
    }
}
