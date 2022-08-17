using GameCheckerWpf.LoginAutenticationWindows;
using GameCheckerWpf.LoginValidation;
using GameCheckerWpf.Models;
using GameCheckerWpf.Services;
using GameCheckerWpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameCheckerWpf.Commands
{
    public class LoginUserCommand : MethodCommandBase
    {
        private UserModel userModel;
        private readonly HttpClient httpClient = new HttpClient();
        private UserService userService;
        public LoginUserCommand(UserModel userModel)
        {
            this.userModel = userModel;
            userService = new UserService(httpClient);
        }

        public override async void Execute(object? parameter)
        {
            isValid();
        }

        private async void isValid()
        {
            UserModel helpModel = new UserModel();
            helpModel.UserName = userModel.UserName;
            helpModel.Password = userModel.Password;
            UserModel comparableObj = new UserModel();
            try
            {
                comparableObj = (await userService.loginUser(userModel.UserName, userModel.Password));
            }

            catch
            {
                //LoginDeniedWindow loginDeniedWindow = new LoginDeniedWindow(new Exceptions.UserNotFoundException("Autentication failed. Do you have an account already?"));
                //loginDeniedWindow.ShowDialog();
            }

            if (helpModel.UserName == comparableObj.UserName && helpModel.Password == comparableObj.Password)
            {
                UserSession.isValid = true;
                UserSession.loggedUser = comparableObj;
            }
            else
                UserSession.isValid = false;
        }
    }
}
