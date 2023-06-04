using GameCheckerAPI.Models;
using GameCheckerAPI.Repos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GameCheckerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerHardwareController : ControllerBase
    {
        private readonly IComputerHardwareRepository computerHardwareRepository;

        public ComputerHardwareController(IComputerHardwareRepository computerHardwareRepository)
        {
            this.computerHardwareRepository = computerHardwareRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComputerHardware>> getHardware(int id)
        {
            var result = await computerHardwareRepository.getHardware(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<ComputerHardware>> addHardware([FromBody]ComputerHardware computerHardware, [FromBody]bool userLoggedIn)
        {
            if (computerHardware == null)
            {
                return BadRequest();
            }

            var result = await computerHardwareRepository.addHardware(userLoggedIn, computerHardware);
            return CreatedAtAction(nameof(getHardware), new { Id = result.id }, result);
        }
    }
}
