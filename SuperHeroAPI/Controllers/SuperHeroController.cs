using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private static List<SuperHero> heores = new List<SuperHero>
            {
                new SuperHero
                {
                    Id=1,
                    Name="Spider",
                    FirstName="Peter",
                    LastName="Park",
                    Place="Sao Paulo"
                },
                new SuperHero
                {
                    Id=2,
                    Name="Spider2",
                    FirstName="Peter2",
                    LastName="Park2",
                    Place="Sao Paulo2"
                }
};

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {


            return Ok(heores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = heores.Find(x => x.Id == id);

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heores.Add(hero);

            return Ok(heores);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {

            var hero = heores.Find(x => x.Id == request.Id);

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            return Ok(heores);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHero>> Delete(int id)
        {
            var hero = heores.Find(x => x.Id == id);

            heores.Remove(hero);

            return Ok(heores);
        }
    }
}
