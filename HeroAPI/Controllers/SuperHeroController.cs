using HeroAPI.Models;
using HeroAPI.Repositories;
using HeroAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _service;

        public SuperHeroController(ISuperHeroService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuperHero>>> Get()
        {
            var heroes = await _service.GetAll();
            
            if (heroes == null)
            {
                return NotFound("There are no more heroes");
            }
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = await _service.Get(id);
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

            await _service.Create(newHero);

            return Ok(newHero);
        }

        [HttpPut]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero oldHero)
        {
            if (oldHero == null)
            {
                return BadRequest("You didn't provide a hero");
            }

            await _service.Update(oldHero);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHero(int id)
        {
            var deletedHero = await _service.Delete(id);

            if (deletedHero == null)
            {
                return NotFound("Cannot find that hero");
            }

            return Ok(deletedHero);
        }
    }
}
