using HeroAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace HeroAPI.Repositories
{

    public interface ISuperHeroRepository
    {
        Task<ActionResult<List<SuperHero>>> GetHeroes();
    }

    public class SuperHeroRepository : ISuperHeroRepository
    {
        private readonly DataContext _dataContext;
        public SuperHeroRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ActionResult<List<SuperHero>>> GetHeroes()
        {
            List<SuperHero> heroes = await _dataContext.SuperHeroes.ToListAsync();

            return heroes;
        }
    }
}
