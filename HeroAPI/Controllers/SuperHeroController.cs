using HeroAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>
        {
            new SuperHero
                {
                    Id = 1,
                    Name = "Spider Man",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York City"
                },
            new SuperHero {
                Id = 2,
                Name = "Batman",
                FirstName = "Bruce",
                LastName = "Wayne",
                Place = "Gotham City"
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
            {
                return BadRequest("There was no hero.");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero newHero)
        {
            heroes.Add(newHero);
            return Ok(heroes);
        }

        [HttpPut]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero heroRequest)
        {
            var hero = heroes.Find(h => h.Id == heroRequest.Id);

            if (hero == null)
            {
                return NotFound("THe hero was not found");
            }

            hero.Name = heroRequest.Name;
            hero.FirstName = heroRequest.FirstName;
            hero.LastName = heroRequest.LastName;
            hero.Place = heroRequest.Place;

            return Ok(heroes);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHero(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
            {
                return NotFound("Cannot find that hero");
            }

            heroes.Remove(hero);
            return Ok(heroes);
        }
    }
}
