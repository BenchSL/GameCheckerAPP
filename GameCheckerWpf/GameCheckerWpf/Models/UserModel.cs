using GameCheckerWpf.Services;
using GameCheckerWpf.LoginValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace GameCheckerWpf.Models
{
    public class UserModel : BaseClass
    {
        private int id;
        private string username;
        private string password;

        private UserService userService;
        private readonly HttpClient httpClient = new HttpClient();
        private bool isValid;
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

        public UserModel() 
        {
            userService = new UserService(httpClient);
            LoginUser();
        }

        public async void LoginUser()
        {
            UserModel userModel = new UserModel();
            userModel.UserName = UserName;
            userModel.Password = Password;

            UserSession.isValid = (await userService.loginUser(userModel));
        }

        public override string ToString()
        {
            return $"id: {id} | Username: {UserName} | Password: {Password}";
        }
    }
}
