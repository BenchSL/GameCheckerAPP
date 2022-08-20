using System.ComponentModel.DataAnnotations;

namespace GameCheckerAPI.Models
{
    /* Specifications and game are connected through this table -> FkGame -> FkSpecification
     * */
    public class Specifications2Game
    {
        [Key]
        public int id { get; set; }
        public GameModel game { get; set; }
        public Specification specification { get; set; }

        public Specifications2Game()
        {

        }

        public Specifications2Game(GameModel game, Specification specification)
        {
            this.game = game;
            this.specification = specification;
        }
    }
}
