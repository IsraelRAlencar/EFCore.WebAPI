using EFCore.Domain;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleController : Controller
    {
        private readonly IEFCoreRepository _repo;

        public BattleController(IEFCoreRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var battles = await _repo.GetAllBattles(true);
                return Ok(battles);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var battle = await _repo.GetBattleById(id, true);

                if (battle != null)
                {
                    return Ok(battle);
                }
                return Ok("Battle Not Found");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Battle model)
        {
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

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Put(int id, Battle model)
        {
            try
            {
                var battle = await _repo.GetBattleById(id);

                if (battle != null) {
                    _repo.Update(model);

                    if (await _repo.SaveChangeAsync()) {
                        return Ok("Bazinga");
                    }
                }

                return Ok("Battle Not Found");
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
                var battle = await _repo.GetBattleById(id);
                if (battle != null)
                {
                    _repo.Delete(battle);

                    if (await _repo.SaveChangeAsync()) {
                        return Ok("Battle Deleted");
                    }
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
