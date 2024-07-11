using EFCore.Domain;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleController : Controller
    {
        private readonly HeroContext _context;

        public BattleController(HeroContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Battle());
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        [HttpPost]
        public ActionResult Post(Battle model)
        {
            try
            {
                _context.Battles.Add(model);
                _context.SaveChanges();

                return Ok("Bazinga");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        [HttpPut]
        public ActionResult Put(int id, Battle model)
        {
            try
            {
                if (_context.Battles.AsNoTracking().FirstOrDefault(b => b.Id == id) != null) {
                    _context.Battles.Update(model);
                    _context.SaveChanges();
                    return Ok("Bazinga");
                }

                return Ok("Battle Not Found");
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
                var battle = _context.Battles.FirstOrDefault(b => b.Id == id);

                if (battle != null)
                {
                    _context.Battles.Remove(battle);
                    _context.SaveChanges();
                    return Ok("Battle Deleted");
                }

                return Ok("Battle Not Found");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }
    }
}
