using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameCheckerAPI.Models
{
    public class Hardware2User
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("UserModel")]
        public int UserId { get; set; }
        public UserModel User { get; set; }

        [ForeignKey("ComputerHardware")]
        public int ComputerHardwareId { get; set; }
        public ComputerHardware ComputerHardware { get; set; }

        public Hardware2User()
        {

        }

        public Hardware2User(UserModel user, ComputerHardware computerHardware)
        {
            this.User = user;
            this.ComputerHardware = computerHardware;
        }
    }
}
