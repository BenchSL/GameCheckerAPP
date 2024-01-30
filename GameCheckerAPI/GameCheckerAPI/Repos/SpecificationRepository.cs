using GameCheckerAPI.Database;
using GameCheckerAPI.Helper;
using GameCheckerAPI.Models;
using System.Threading.Tasks;

namespace GameCheckerAPI.Repos
{
    public class SpecificationRepository : ISpecificationRepository
    {
        private readonly GameContext gameContext;

        public SpecificationRepository(GameContext gameContext)
        {
            this.gameContext = gameContext;
        }

        public async Task<Specification> addSpecification(Specification spec)
        {
            var result = await gameContext.Specification.AddAsync(spec);
            await gameContext.SaveChangesAsync();
            return result.Entity;
        }

        public Task<bool> canRun(Specification spec, ComputerHardware computerHardware, GameModel gameModel)
        {
            //bool result = false;
            //if (MethodHelper.hardwareSpecificationExists(spec, computerHardware, new DbInject(gameContext)))
            //{
            //    result = spec.RankingScale < computerHardware.RankingScale || spec.RankingScale ==
            //}
            throw new System.NotImplementedException();
        }
    }
}
