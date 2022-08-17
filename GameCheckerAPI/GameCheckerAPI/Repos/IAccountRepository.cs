using GameCheckerAPI.Models;
using System.Threading.Tasks;

namespace GameCheckerAPI.Repos
{
    public interface IAccountRepository
    {
        Task<bool> DoesUsernameExist(string userName);
        Task<bool> DoesEmailExist(string email);
        Task<Account> GetByUserName(string userName);
    }
}
