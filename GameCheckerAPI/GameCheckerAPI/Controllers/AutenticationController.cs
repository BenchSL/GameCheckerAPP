using GameCheckerAPI.AutenticationServices;
using GameCheckerAPI.Repos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GameCheckerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticationController : ControllerBase
    {
        private readonly IAutenticationService autenticationService;

        public AutenticationController(IAutenticationService autenticationService)
        {
            this.autenticationService = autenticationService;
        }

        [HttpGet("{Username}/{Password}")]
        public async Task<ActionResult<bool>> LoginUser(string Username, string Password)
        {
            return await autenticationService.Login(Username, Password);
        }

        [HttpPost("{userName}/{password}/{email}/{confirmPassword}")]
        public async Task<ActionResult<bool>> RegisterUser(string userName, string password, string email, string confirmPassword)
        {
            return await autenticationService.Register(userName, password, email, confirmPassword);
        }
    }
}
