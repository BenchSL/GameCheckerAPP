using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GameDatabaseFiller.ClassesM;

#nullable disable

namespace GameDatabaseFiller.Data
{
    public partial class GameModelDbContext : DbContext
    {
        public GameModelDbContext()
        {
        }

        public GameModelDbContext(DbContextOptions<GameModelDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GameModel> GameModels { get; set; }
        public virtual DbSet<UserModel> UserModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GameCheckerAPI.Database.GameContext;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameModel>(entity =>
            {
                entity.ToTable("gameModel");

                entity.Property(e => e.HasCommunityVisibleStats).HasColumnName("Has_community_visible_stats");

                entity.Property(e => e.ImgIconUrl).HasColumnName("Img_icon_url");

                entity.Property(e => e.PlaytimeForever).HasColumnName("Playtime_forever");
            });

            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.ToTable("userModel");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
