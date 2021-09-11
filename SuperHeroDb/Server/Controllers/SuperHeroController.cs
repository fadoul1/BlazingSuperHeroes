using Microsoft.AspNetCore.Mvc;
using SuperHeroDb.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroDb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        static List<Comic> Comics = new List<Comic>()
        {
            new Comic
            {
                Id = 1,
                Name = "Marvel"
            },
            new Comic
            {
                Id = 2,
                Name = "DC"
            }
        };

        static List<SuperHero> Heroes = new List<SuperHero>()
        {
            new SuperHero
            {
                Id= 1,
                FirstName = "Peter",
                LastName = "Parker",
                HeroName = "Spider Man",
                Comic = Comics[0]
            },
            new SuperHero
            {
                Id = 2,
                FirstName = "Bruce",
                LastName = "Wayne",
                HeroName = "Bat Man",
                Comic = Comics[1]
            }
        };

        [HttpGet("comics")]
        public async Task<IActionResult> GetComics()
        {
            return Ok(Comics);
        }

        [HttpGet]
        public async Task<IActionResult> GetSuperHeroes()
        {
            return Ok(Heroes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleSuperHero(int id)
        {
            var hero = Heroes.FirstOrDefault(h => h.Id == id);

            if (hero == null)
            {
                return NotFound("Super Hero not found");
            }

            return Ok(hero);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSuperHero(SuperHero hero)
        {
            hero.Id = Heroes.Max(h => h.Id + 1);
            Heroes.Add(hero);

            return Ok(Heroes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSuperHero(int id, SuperHero hero)
        {
            var dbHero = Heroes.FirstOrDefault(h => h.Id == id);

            if (dbHero == null)
            {
                return NotFound("Super Hero not found");
            }

            var index = Heroes.IndexOf(dbHero);
            Heroes[index] = hero;

            return Ok(Heroes);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuperHero(int id)
        {
            var dbHero = Heroes.FirstOrDefault(h => h.Id == id);

            if (dbHero == null)
            {
                return NotFound("Super Hero not found");
            }

            Heroes.Remove(dbHero);

            return Ok(Heroes);
        }
    }
}
