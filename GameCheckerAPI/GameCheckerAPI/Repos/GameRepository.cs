using GameCheckerAPI.Models;
using GameCheckerAPI.Database;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GameCheckerAPI.Repos
{
    public class GameRepository : IGameRepository
    {
        private readonly GameContext gameDbContext;

        public GameRepository(GameContext gameDbContext)
        {
            this.gameDbContext = gameDbContext;
        }

        public async Task<GameModel> AddGameModel(GameModel gModel)
        {
            var result = await gameDbContext.gameModel.AddAsync(gModel);
            await gameDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<GameModel> DeleteGameModel(int id)
        {
            var result = await gameDbContext.gameModel.FirstOrDefaultAsync(x => x.Id == id);
            gameDbContext.gameModel.Remove(result);
            await gameDbContext.SaveChangesAsync();
            return result;
        }

        public async Task<GameModel> GetGameModel(int id)
        {
            var result = await gameDbContext.gameModel.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<IEnumerable<GameModel>> GetGameModels()
        {
            return await gameDbContext.gameModel.ToListAsync();
        }

        public async Task<GameModel> UpdateGameModel(GameModel gModel)
        {
            var result = await gameDbContext.gameModel.FirstOrDefaultAsync(x => x.Id == gModel.Id);
            gameDbContext.gameModel.Remove(result);
            GameModel gm = new GameModel()
            {
                Id = result.Id,
                Appid = result.Appid,
                Has_community_visible_stats = result.Has_community_visible_stats,
                Playtime_forever = result.Playtime_forever,
                Name = result.Name,
                Img_icon_url = result.Img_icon_url
            };

            await gameDbContext.gameModel.AddAsync(gm);
            await gameDbContext.SaveChangesAsync();

            return gm;
        }
    }
}
