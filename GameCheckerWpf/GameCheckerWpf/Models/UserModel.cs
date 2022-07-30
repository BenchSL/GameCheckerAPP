using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCheckerWpf.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public UserModel(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
        public UserModel() { }

        public override string ToString()
        {
            return $"id: {id} | Username: {Username} | Password: {Password}";
        }
    }
}
