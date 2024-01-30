using GameCheckerAPI.Models;
using System.Threading.Tasks;

namespace GameCheckerAPI.Repos
{
    public interface ISpecificationRepository
    {
        public Task<Specification> addSpecification(Specification spec);
        public Task<bool> canRun(Specification spec, ComputerHardware computerHardware, GameModel gameModel);
    }
}