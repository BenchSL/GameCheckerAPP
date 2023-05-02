using GameCheckerAPI.Models;
using System.Threading.Tasks;

namespace GameCheckerAPI.Repos
{
    public interface IHardware2UserRepository
    {
        public Task<Hardware2User> addHardware2User(ComputerHardware computerHardware, UserModel user);
    }
}
