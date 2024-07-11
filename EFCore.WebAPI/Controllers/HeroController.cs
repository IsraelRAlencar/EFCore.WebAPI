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
                return BadRequest($"Error: {ex}");
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
                return BadRequest($"Error: {ex}");
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

                return Ok("Hero Not Found");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var hero = _context.Heroes.FirstOrDefault(h => h.Id == id);

                if (hero != null)
                {
                    _context.Remove(hero);
                    _context.SaveChanges();
                    return Ok("Hero Deleted");
                }

                return Ok("Hero Not Found");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }
    }
}
