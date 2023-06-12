using GameCheckerAPI.Models;
using GameCheckerAPI.Repos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GameCheckerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Hardware2UserController : ControllerBase
    {
        private readonly IHardware2UserRepository hardware2UserRepository;

        public Hardware2UserController(IHardware2UserRepository hardware2UserRepository)
        {
            this.hardware2UserRepository = hardware2UserRepository;
        }

        [HttpGet("{computerHardwareId}/{userId}")]
        public async Task<ActionResult<Hardware2User>> addHardware2User(int computerHardwareId, int userId)
        {
            if (computerHardwareId != 0 && userId != 0)
            {
                var result = await hardware2UserRepository.addHardware2User(computerHardwareId, userId);
                return result;
            }
            return null;
        }
    }
}
