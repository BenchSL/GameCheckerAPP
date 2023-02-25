using GameCheckerWpf.LoginAutenticationWindows;
using GameCheckerWpf.LoginValidation;
using GameCheckerWpf.Models;
using GameCheckerWpf.Services;
using GameCheckerWpf.ViewModels;
using GameCheckerWpf.Exceptions;
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
        //private UserModel userModel;
        private readonly HttpClient httpClient = new HttpClient();
        private readonly UserService userService;
        MainWindowViewModel viewModel;
        public LoginUserCommand(MainWindowViewModel viewModel)//UserModel userModel, MainWindowViewModel mainWindow
        {
            //this.userModel = userModel;
            this.viewModel = viewModel;
            userService = new UserService(httpClient);
        }

        public override async void Execute(object? parameter)
        {
            isValid();
        }

        private async void isValid()
        {
            UserModel helpModel = new UserModel();
            helpModel.UserName = viewModel.UserName;
            helpModel.Password = viewModel.Password;
            UserModel comparableObj = new UserModel();
            
            try
            { 
                comparableObj = (await userService.loginUser(viewModel.UserName, viewModel.Password));
                LoginSuccessfulWindow loginSuccessfulWindow = new LoginSuccessfulWindow(new UserFoundMessage($"Welcome back {viewModel.UserName}, click next to proceed to our application!"));
                loginSuccessfulWindow.ShowDialog();
            }

            catch
            {
                viewModel.SelectedViewModel = new HardwareMonitorViewModel();
                LoginDeniedWindow loginDeniedWindow = new LoginDeniedWindow(new UserNotFoundException("Autentication failed. Do you have an account already?"));
                loginDeniedWindow.ShowDialog();
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
