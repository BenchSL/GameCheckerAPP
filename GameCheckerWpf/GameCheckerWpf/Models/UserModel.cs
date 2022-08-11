using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCheckerWpf.Models
{
    public class UserModel : BaseClass
    {
        private int id;
        private string username;
        private string password;

        public string UserName
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public UserModel(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }
        public UserModel() { }

        public override string ToString()
        {
            return $"id: {id} | Username: {UserName} | Password: {Password}";
        }
    }
}
