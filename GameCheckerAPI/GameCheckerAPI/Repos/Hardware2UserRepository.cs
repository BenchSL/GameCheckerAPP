using GameCheckerAPI.Database;
using GameCheckerAPI.Helper;
using GameCheckerAPI.Models;
using System.Threading.Tasks;

namespace GameCheckerAPI.Repos
{
    public class Hardware2UserRepository : IHardware2UserRepository
    {
        private readonly GameContext dbContext;

        public Hardware2UserRepository(GameContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Hardware2User> addHardware2User(int computerHardwareId, int userId)
        {
            if (computerHardwareId != 0 && userId != 0)
            {
                if (!MethodHelper.hardwareAndUserGuidExist(computerHardwareId, userId, new DbInject(dbContext)))
                {
                    Hardware2User hardware2User = new Hardware2User();
                    hardware2User.ComputerHardwareId = computerHardwareId;
                    hardware2User.UserId = userId;
                    var result = await dbContext.hardware2Users.AddAsync(hardware2User);
                    dbContext.SaveChanges();
                    return result.Entity;
                }
            }
            return null;
        }
    }
}
