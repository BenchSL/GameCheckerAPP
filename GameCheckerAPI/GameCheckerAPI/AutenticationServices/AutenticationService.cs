using GameCheckerAPI.Database;
using GameCheckerAPI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GameCheckerAPI.AutenticationServices
{
    public class AutenticationService : IAutenticationService
    {
        private readonly GameContext db;
        public AutenticationService(GameContext db)
        {
            this.db = db;
        }

        public async Task<bool> Login(string userName, string password)
        {
            bool success = false;
            var resultUser = await db.userModel.FirstOrDefaultAsync(x => x.Username == userName && x.Password == password);

            if ( resultUser != null )
            {
                Account loggedAccount = await db.Account.FirstOrDefaultAsync(x => x.AccountHolder == resultUser);
                if (loggedAccount != null)
                {
                    success = true;
                }
            }
            return success;
        }

        public async Task<bool> Register(string userName, string password, string email, string confirmPassword)
        {
            bool success = false;
            if (password == confirmPassword)
            {
                IPasswordHasher hasher = new PasswordHasher();
                string hashedPassword = hasher.HashPassword(password);

                UserModel newUser = new UserModel(userName, password, email);
                Account newAccount = new Account(newUser);

                var resultAcc = await db.Account.AddAsync(newAccount);
                var resultUser = await db.userModel.AddAsync(newUser);
                if(resultAcc.Entity != null && resultUser.Entity != null)
                {
                    success = true;
                }
            }
            return success;
        }
    }
}
