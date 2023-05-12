using GameCheckerAPI.Database;

namespace GameCheckerAPI.Helper
{
    public class DbInject
    {
        private readonly GameContext gameContext; 
        public DbInject(GameContext gameContext)
        {
            this.gameContext = gameContext;
        }

        public GameContext getGameContext
        {
            get
            {
                return gameContext;
            }
        }
    }
}
