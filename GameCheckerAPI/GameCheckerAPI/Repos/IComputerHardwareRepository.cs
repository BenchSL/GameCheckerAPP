using GameCheckerAPI.Models;
using System.Threading.Tasks;

namespace GameCheckerAPI.Repos
{
    public interface IComputerHardwareRepository
    {
        public Task<ComputerHardware> addHardware(ComputerHardware computerHardware);
        public Task<ComputerHardware> getHardware(int id);
    }
}
