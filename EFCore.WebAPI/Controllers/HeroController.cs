using EFCore.Domain;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : Controller
    {
        private readonly HeroContext _context;
        public HeroController(HeroContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get() {
            try
            {
                return Ok(new Hero());
            }
            catch (Exception ex) {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpPost]
        public ActionResult Post(Hero model) {
            try
            {
                _context.Heroes.Add(model);
                _context.SaveChanges();

                return Ok("Bazinga");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Hero model) {
            try
            {
                if (_context.Heroes.AsNoTracking().FirstOrDefault(h => h.Id == id) != null) {
                    _context.Update(model);
                    _context.SaveChanges();
                    return Ok("Bazinga");
                }

                return Ok("Não encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }
    }
}
