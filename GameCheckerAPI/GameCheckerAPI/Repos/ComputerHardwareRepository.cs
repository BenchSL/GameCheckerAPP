﻿using GameCheckerAPI.Database;
using GameCheckerAPI.Helper;
using GameCheckerAPI.Models;
using System.Threading.Tasks;

namespace GameCheckerAPI.Repos
{
    public class ComputerHardwareRepository : IComputerHardwareRepository
    {
        private readonly GameContext gameDbContext;

        public async Task<ComputerHardware> addHardware(bool userLoggedIn, ComputerHardware computerHardware)
        {
            if (userLoggedIn)
            {
                if (MethodHelper.guidExists(computerHardware, new DbInject(gameDbContext))) 
                {
                    var result = await gameDbContext.computerHardware.AddAsync(computerHardware);
                    await gameDbContext.SaveChangesAsync();
                    return result.Entity;
                }
            }
            return null;
        }
    }
}
