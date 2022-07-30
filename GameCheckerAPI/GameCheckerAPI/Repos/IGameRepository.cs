using System.Collections.Generic;
using System.Threading.Tasks;
using GameCheckerAPI.Models;

namespace GameCheckerAPI.Repos
{
    public interface IGameRepository
    {
        Task<IEnumerable<GameModel>> GetGameModels();
        Task<GameModel> GetGameModel(int id);
        Task<GameModel> AddGameModel(GameModel gModel);
        Task<GameModel> UpdateGameModel(GameModel gModel);
        Task<GameModel> DeleteGameModel(int id);
    }
}
