using System.ComponentModel.DataAnnotations;

namespace GameCheckerAPI.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public UserModel() { }

        public UserModel(string name, string pass, string email)
        {
            this.Username = name;
            this.Password = pass;
            this.Email = email;
        }
    }
}
