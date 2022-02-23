using HeroAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeroAPI.Repositories
{

    public interface ISuperHeroRepository
    {
        Task<List<SuperHero>> GetAll();
        Task<SuperHero> Get(int id);
        Task<SuperHero> Create(SuperHero newSuperHero);
        Task<SuperHero> Update(SuperHero newSuperHero);
        Task<SuperHero> Delete(int id);
    }

    public class SuperHeroRepository : ISuperHeroRepository
    {
        private readonly DataContext _dataContext;
        public SuperHeroRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<SuperHero>> GetAll()
        {
            //List<SuperHero> heroes = await _dataContext.SuperHeroes.ToListAsync();
            List<SuperHero> heroes = await _dataContext.Set<SuperHero>().ToListAsync();

            return heroes;
        }

        public async Task<SuperHero> Get(int id)
        {
            //SuperHero hero = await _dataContext.SuperHeroes.FindAsync(id);
            SuperHero hero = await _dataContext.Set<SuperHero>().FindAsync(id);

            return hero;
        }

        public async Task<SuperHero> Create(SuperHero newSuperHero)
        {
            _dataContext.Set<SuperHero>().Add(newSuperHero);
           
            await _dataContext.SaveChangesAsync();
            
            return newSuperHero;
        }

        public async Task<SuperHero> Update(SuperHero oldSuperHero)
        {
            _dataContext.Set<SuperHero>().Update(oldSuperHero);

            await _dataContext.SaveChangesAsync();

            return oldSuperHero;
        }

        public async Task<SuperHero> Delete(int id) 
        {
            var dbHero = await _dataContext.SuperHeroes.FindAsync(id);

            if (dbHero == null) return null;

            _dataContext.Set<SuperHero>().Remove(dbHero);
            await _dataContext.SaveChangesAsync();

            return dbHero;

        }
    }
}