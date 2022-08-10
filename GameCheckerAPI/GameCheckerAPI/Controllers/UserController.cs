﻿using Microsoft.AspNetCore.Mvc;
using GameCheckerAPI.Models;
using GameCheckerAPI.Database;
using GameCheckerAPI.Repos;
using System.Threading.Tasks;

namespace GameCheckerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<bool>> LoginUser([FromBody]UserModel user)
        {
            return await userRepository.loginUser(user);
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            return Ok(await userRepository.GetUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUser(int id)
        {
            var result = await userRepository.GetUser(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> AddUser(UserModel user)
        {
            if(user == null)
            {
                return BadRequest();
            }

            var result = await userRepository.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { Id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> DeleteUser(int id)
        {
            var result = userRepository.GetUser(id);

            if(result == null)
            {
                return NotFound($"User with the given id of: {id}, has not been found!");
            }

            return await userRepository.DeleteUser(id);
        }

        [HttpPut]
        public async Task<ActionResult<UserModel>> UpdateUser(UserModel um)
        {
            if(um == null)
            {
                return BadRequest();
            }

            return await userRepository.UpdateUser(um);
        }
    }
}
