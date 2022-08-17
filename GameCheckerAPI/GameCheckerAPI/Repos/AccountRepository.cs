using GameCheckerAPI.Database;
using GameCheckerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GameCheckerAPI.Repos
{
    public class AccountRepository : IAccountRepository
    {
        private readonly GameContext db;
        public AccountRepository(GameContext db)
        {
            this.db = db;
        }

        public async Task<bool> DoesEmailExist(string email)
        {
            bool exists = false;
            UserModel account = await db.userModel.FirstOrDefaultAsync(x => x.Email == email);
            if (account != null)
            {
                return exists;
            } else
            {
                exists = true;
                return exists;
            }
        }

        public async Task<bool> DoesUsernameExist(string userName)
        {
            bool exists = false;
            UserModel account = await db.userModel.FirstOrDefaultAsync(x => x.Username == userName);
            if (account != null)
            {
                return exists;
            }
            else
            {
                exists = true;
                return exists;
            }
        }

        public async Task<Account> GetByUserName(string userName)
        {
            UserModel userNameUserModel = await db.userModel.FirstOrDefaultAsync(x => x.Username == userName);
            Account accountUser = await db.Account.FirstOrDefaultAsync(x => x.AccountHolder == userNameUserModel);
            if (accountUser != null)
            {
                return accountUser;
            }
            else
                return new Account();
        }
    }
}
