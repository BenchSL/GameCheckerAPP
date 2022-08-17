using GameCheckerWpf.Services;
using GameCheckerWpf.LoginValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Input;
using GameCheckerWpf.Commands;
using GameCheckerWpf.ViewModels;

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
        public ICommand LoginCommand { get; }

        public UserModel() 
        {
            LoginCommand = new LoginUserCommand(this);
        }

        public override string ToString()
        {
            return $"id: {id} | Username: {UserName} | Password: {Password}";
        }
    }
}
