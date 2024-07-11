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
        private readonly IEFCoreRepository _repo;

        public HeroController(IEFCoreRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            try
            {
                var heroes = await _repo.GetAllHeroes(true);
                return Ok(heroes);
            }
            catch (Exception ex) {
                return BadRequest($"Error: {ex}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var hero = await _repo.GetHeroById(id, true);
                return Ok(hero);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Hero model) {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangeAsync()) {
                    return Ok("Bazinga");            
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }

            return BadRequest("An error has occured");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Hero model) {
            try
            {
                var hero = await _repo.GetHeroById(id);
                if (hero != null) {
                    _repo.Update(model);
                    if (await _repo.SaveChangeAsync()) 
                    {
                        return Ok("Bazinga");
                    }
                }

                return Ok("Hero Not Found");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var hero = _repo.GetHeroById(id);

                if (hero != null)
                {
                    _repo.Delete(hero);
                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Hero Deleted");
                    }
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
