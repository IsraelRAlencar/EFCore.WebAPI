using EFCore.Domain;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;

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
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpPost]
        public ActionResult Post(Hero value) {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }
    }
}
