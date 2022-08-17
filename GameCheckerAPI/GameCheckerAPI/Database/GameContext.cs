﻿using Microsoft.EntityFrameworkCore;
using GameCheckerAPI.Models;

namespace GameCheckerAPI.Database
{
    public class GameContext : DbContext
    {
        public DbSet<GameModel> gameModel { get; set; }
        public DbSet<UserModel> userModel { get; set; }
        public DbSet<Account> Account { get; set; }

        public GameContext(DbContextOptions<GameContext> options)
        : base(options)
        {

        }
    }
}
