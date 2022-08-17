using Microsoft.EntityFrameworkCore;
using System.Linq;
using GameCheckerAPI.Models;
using GameCheckerAPI.Database;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GameCheckerAPI.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly GameContext gameDbContext;

        public UserRepository(GameContext gameDbContext)
        {
            this.gameDbContext = gameDbContext;
        }

        //public async Task<UserModel> loginUser(string Username, string Password)
        //{
        //    var result = await gameDbContext.userModel.FirstOrDefaultAsync(x => Username == x.Username && Password == x.Password);
        //    if (result != null)
        //    {
        //        return result;
        //    } else
        //        return null;
        //}


        public async Task<UserModel> AddUser(UserModel user)
        {
            var result = await gameDbContext.userModel.AddAsync(user);
            await gameDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<UserModel> DeleteUser(int id)
        {
            var result = await gameDbContext.userModel.FirstOrDefaultAsync(x => x.Id == id);
            gameDbContext.userModel.Remove(result);
            await gameDbContext.SaveChangesAsync();
            return result;
        }

        public async Task<UserModel> GetUser(int id)
        {
            var result = await gameDbContext.userModel.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            return await gameDbContext.userModel.ToListAsync();
        }

        public async Task<UserModel> UpdateUser(UserModel user)
        {
            var result = await gameDbContext.userModel.FirstOrDefaultAsync(x => x.Id == user.Id);
            gameDbContext.userModel.Remove(result);

            UserModel um = new UserModel()
            {
                Username = result.Username,
                Password = result.Password
            };

            await gameDbContext.userModel.AddAsync(um);
            gameDbContext.SaveChanges();

            return um;
        }
    }
}
