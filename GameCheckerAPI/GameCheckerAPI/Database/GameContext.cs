using Microsoft.EntityFrameworkCore;
using GameCheckerAPI.Models;

namespace GameCheckerAPI.Database
{
    public class GameContext : DbContext
    {
        public DbSet<GameModel> gameModel { get; set; }
        public DbSet<UserModel> userModel { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Specification> Specification { get; set; }
        public DbSet<Specifications2Game> Specifications2Games { get; set; }
        public DbSet<ComputerHardware> computerHardware { get; set; }
        public DbSet<Hardware2User> hardware2Users { get; set; }
        public GameContext(DbContextOptions<GameContext> options)
        : base(options)
        {

        }
    }
}
