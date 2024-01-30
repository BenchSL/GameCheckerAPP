using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameCheckerAPI.Models
{
    public enum RunStatus
    {
        Not,
        Barely,
        Perfect
    }

    public class CanRunAudit
    {
        [Key]
        public int Id { get; set; }
        public RunStatus CanRun { get; set; }

        [ForeignKey("GameModel")]
        public int GameModelId { get; set; }
        public GameModel GameModel { get; set; }


        public CanRunAudit(RunStatus canRun)
        {
            this.CanRun = canRun;
        }
    }
}
