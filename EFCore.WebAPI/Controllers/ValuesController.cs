using EFCore.Domain;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly HeroContext _context;
        public ValuesController(HeroContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet("filtro/{name}")]
        public ActionResult GetFiltro(string name)
        {
            var listHero = _context.Heroes
                            .Where(h => EF.Functions.Like(h.Name, $"%{name}%"))
                            .OrderBy(h => h.Id)
                            .LastOrDefault();

            return Ok(listHero);
        }

        // GET api/values/5
        [HttpGet("Atualizar/{nameHero}")]
        public ActionResult Get(string nameHero)
        {
            //var hero = new Hero { Name = nameHero };

            var hero = _context.Heroes
                            .Where(h => h.Id == 3)
                            .FirstOrDefault();
            hero.Name = "Homem Aranha";
            //_context.Heroes.Add(hero);                
            _context.SaveChanges();

            return Ok();
        }

        // GET api/values/5
        [HttpGet("AddRange")]
        public ActionResult GetAddRange()
        {
            _context.AddRange(
                new Hero { Name = "Capitão América" },
                new Hero { Name = "Doutor Estranho" },
                new Hero { Name = "Pantera Negra" },
                new Hero { Name = "Viúva Negra" },
                new Hero { Name = "Hulk" },
                new Hero { Name = "Gavião Arqueiro" },
                new Hero { Name = "Capitã Marvel" }
            );
            _context.SaveChanges();

            return Ok();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("Delete/{id}")]
        public void Delete(int id)
        {
            var hero = _context.Heroes
                                .Where(x => x.Id == id)
                                .Single();
            _context.Heroes.Remove(hero);
            _context.SaveChanges();
        }
    }
}