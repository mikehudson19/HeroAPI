using HeroAPI.Models;
using HeroAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        //private readonly DataContext _context;
        private readonly ISuperHeroRepository _repository;

        public SuperHeroController(ISuperHeroRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuperHero>>> Get()
        {
            var heroes = await _repository.GetAll();
            
            if (heroes == null)
            {
                return NotFound("There are no more heroes");
            }
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = await _repository.Get(id);
            if (hero == null)
            {
                return BadRequest("There was no hero.");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> CreateHero(SuperHero newHero)
        {
            if (newHero == null)
            {
                return BadRequest("There is no superhero to add.");
            }

            await _repository.Create(newHero);

            return Ok(newHero);
        }

        [HttpPut]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero oldHero)
        {
            if (oldHero == null)
            {
                return BadRequest("You didn't provide a hero");
            }

            await _repository.Update(oldHero);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHero(int id)
        {
            var deletedHero = await _repository.Delete(id);

            if (deletedHero == null)
            {
                return NotFound("Cannot find that hero");
            }

            return Ok(deletedHero);
        }
    }
}
