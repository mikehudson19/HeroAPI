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
        private readonly DataContext _context;
        private readonly ISuperHeroRepository _repository;

        public SuperHeroController(DataContext context, ISuperHeroRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        { // TRYING TO GET THIS WORKING - CAN'T CONVERT TASK FROM THE REPO TO A LIST HERE
            /*List<SuperHero>*/ var heroes = _repository.GetHeroes();
            //List<SuperHero> heroes = await _context.SuperHeroes.ToListAsync();
            if (heroes == null)
            {
                return NotFound("There are no more heroes");
            }
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                return BadRequest("There was no hero.");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero newHero)
        {
            if (newHero == null)
            {
                return BadRequest("There is no superhero to add.");
            }

            _context.SuperHeroes.Add(newHero);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero heroRequest)
        {
            _context.SuperHeroes.Update(heroRequest);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHero(int id)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(id);
            if (dbHero == null)
            {
                return NotFound("Cannot find that hero");
            }

            _context.SuperHeroes.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
