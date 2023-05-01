using System.ComponentModel.DataAnnotations;

namespace GameCheckerAPI.Models
{
    public class Hardware2User
    {
        [Key]
        public int id { get; set; }
        public UserModel user { get; set; }
        public ComputerHardware computerHardware { get; set; }

        public Hardware2User()
        {

        }

        public Hardware2User(UserModel user, ComputerHardware computerHardware)
        {
            this.user = user;
            this.computerHardware = computerHardware;
        }
    }
}
