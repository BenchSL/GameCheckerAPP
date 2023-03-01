using System.Collections.Generic;
using System.Threading.Tasks;
using GameCheckerAPI.Models;

namespace GameCheckerAPI.Repos
{
    public interface IUserRepository
    {
        Task<UserModel> loginUser(string Username, string Password);
        Task<UserModel> registerUser(string username, string password, string email);
        Task<IEnumerable<UserModel>> GetUsers();
        Task<UserModel> GetUser(int id);
        Task<UserModel> AddUser(UserModel user);
        Task<UserModel> DeleteUser(int id);
        Task<UserModel> UpdateUser(UserModel user);
    }
}
