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

        public async Task<UserModel> registerUser(string userName, string password, string email)
        {
            UserModel registerUser = new UserModel();
            registerUser.Username = userName;
            registerUser.Password = password;
            registerUser.Email = email;
            if (!findExistingUser(registerUser.Username))
            {
                var result = await gameDbContext.userModel.AddAsync(registerUser); //user not found, saving new user in DB
                await gameDbContext.SaveChangesAsync();
                return result.Entity;
            } else
            {
                return null; //user found, returning null
            }
        }

        public async Task<UserModel> loginUser(string Username, string Password)
        {
            var result = await gameDbContext.userModel.FirstOrDefaultAsync(x => Username == x.Username && Password == x.Password);
            if (result != null)
            {
                return result;
            }
            else
                return null;
        }


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

        private bool findExistingUser(string username)
        {
            bool result = false;
            var userFound = gameDbContext.userModel.FirstOrDefault(x => x.Username == username);
            if (userFound != null)
            {
                result = true;
            } else
            {
                result = false;
            }
            return result;
        }
    }
}
