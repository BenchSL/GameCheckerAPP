using GameCheckerAPI.Models;
using GameCheckerAPI.Repos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GameCheckerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<bool>> DoesEmailExist(string email)
        {
            return await accountRepository.DoesEmailExist(email);
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult<bool>> DoesUsernameExist(string userName)
        {
            return await accountRepository.DoesUsernameExist(userName);
        }

        [HttpGet("userName")]
        public async Task<ActionResult<Account>> GetByUserName(string userName)
        {
            var result = await accountRepository.GetByUserName(userName);
            return result;
        }
    }
}
