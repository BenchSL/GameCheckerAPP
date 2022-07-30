using Microsoft.AspNetCore.Mvc;
using GameCheckerAPI.Repos;
using GameCheckerAPI.Models;
using GameCheckerAPI.Database;
using System.Threading.Tasks;

namespace GameCheckerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository gameRepository;

        public GameController(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetGames()
        {
            return Ok(await gameRepository.GetGameModels());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameModel>> GetGame(int id)
        {
            var result = await gameRepository.GetGameModel(id);

            if(result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<GameModel>> AddGame(GameModel gm)
        {
            if(gm == null)
            {
                return BadRequest();
            }

            var result = await gameRepository.AddGameModel(gm);
            return CreatedAtAction(nameof(GetGame), new { Id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult<GameModel>> UpdateGame(GameModel gm)
        {
            if(gm == null)
            {
                return BadRequest();
            }

            return await gameRepository.UpdateGameModel(gm);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GameModel>> DeleteGame(int id)
        {
            var result = gameRepository.GetGameModel(id);

            if(result == null)
            {
                return NotFound($"Game with the given id of: {id}, has not been found!");
            }

            return await gameRepository.DeleteGameModel(id);
        }
    }
}
