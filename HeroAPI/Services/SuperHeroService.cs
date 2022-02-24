using HeroAPI.Models;
using HeroAPI.Repositories;

namespace HeroAPI.Services
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAll();
        Task<SuperHero> Get(int id);
        Task<SuperHero> Create(SuperHero newSuperHero);
        Task<SuperHero> Update(SuperHero newSuperHero);
        Task<SuperHero> Delete(int id);
    }

    public class SuperHeroService : ISuperHeroService
    {
        private readonly ISuperHeroRepository _repository;
        public SuperHeroService(ISuperHeroRepository superHeroRepository)
        {
            _repository = superHeroRepository;
        }

        public async Task<List<SuperHero>> GetAll()
        {
            List<SuperHero> heroes = await _repository.GetAll();
            return heroes;
        }

        public async Task<SuperHero> Get(int id)
        {
            SuperHero hero = await _repository.Get(id);
            return hero;
        }

        public async Task<SuperHero> Create(SuperHero newSuperHero)
        {
            return await _repository.Create(newSuperHero);
        }

        public async Task<SuperHero> Update(SuperHero newSuperHero)
        {
           return await _repository.Update(newSuperHero);
        }

        public async Task<SuperHero> Delete(int id)
        {
            return await _repository.Delete(id);
        }
    }
}
