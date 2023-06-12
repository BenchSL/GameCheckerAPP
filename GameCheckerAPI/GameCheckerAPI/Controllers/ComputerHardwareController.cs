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

        [HttpGet("{cpu}/{ram}/{os}/{graphicsCard}/{guid}")]
        public async Task<ActionResult<ComputerHardware>> addHardware(string cpu, string ram, string os, string graphicsCard, string guid)
        {
            ComputerHardware computerHardware = new ComputerHardware();
            if (cpu != null)
            {
                computerHardware.CPU = cpu;
            }
            if (graphicsCard != null)
            {
                computerHardware.GraphicsCard = graphicsCard;
            } 
            if (guid != null)
            {
                computerHardware.guid = guid;
            }
            if (os != null)
            {
                computerHardware.OS = os;
            }
            if (ram != null)
            {
                computerHardware.RAM = ram;
            }

            var result = await computerHardwareRepository.addHardware(computerHardware);
            return CreatedAtAction(nameof(getHardware), new { Id = result.id }, result);
        }
    }
}
