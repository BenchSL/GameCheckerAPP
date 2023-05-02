using GameCheckerAPI.Models;
using System.Threading.Tasks;

namespace GameCheckerAPI.Repos
{
    public interface IComputerHardwareRepository
    {
        public Task<ComputerHardware> addHardware(bool isUserLoggedIn, ComputerHardware computerHardware);
    }
}
