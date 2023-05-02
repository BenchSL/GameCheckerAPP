using GameCheckerAPI.Database;
using GameCheckerAPI.Models;
using System.Threading.Tasks;

namespace GameCheckerAPI.Repos
{
    public class ComputerHardwareRepository : IComputerHardwareRepository
    {
        private readonly GameContext gameDbContext;

        public Task<ComputerHardware> addHardware(bool userLoggedIn, ComputerHardware computerHardware)
        {
            if (userLoggedIn)
            {
                if (guidExists(computerHardware)) 
                { 

                }
            }
        }

       private bool guidExists(ComputerHardware computerHardware)
        {
            return true; //dummy return
        }
    }
}
