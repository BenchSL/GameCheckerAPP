﻿using GameCheckerWpf.Services;
using GameCheckerWpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using GameCheckerWpf.Models;
using GameCheckerWpf.RegisterAutenticationWindows;
using GameCheckerWpf.Exceptions;
using GameCheckerWpf.Helper;

namespace GameCheckerWpf.Commands
{
    public class RegisterUserCommand : MethodCommandBase
    {

        private readonly UserService userService;
        private readonly HardwareService hardwareService;
        private readonly HttpClient httpClient = new HttpClient();
        MainWindowViewModel viewModel;

        public RegisterUserCommand(MainWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
            userService = new UserService(httpClient);
            hardwareService = new HardwareService(httpClient);
        }

        public override void Execute(object? parameter)
        {
            isValid();
        }

        private async void isValid()
        {
            UserModel userModel = new UserModel();
            userModel.UserName = viewModel.UserName;
            userModel.Password = viewModel.Password;
            userModel.Email = viewModel.Email;
            UserModel registerUserModel = new UserModel();
            GameCheckerAPI.Models.ComputerHardware computerHardware2Add = HardwareHelper.getCurrentHardware();

            if (userModel.Password != viewModel.ConfirmPassword)
            {
                RegisterDeniedWindow registerDeniedWindow = new RegisterDeniedWindow(new PasswordNotMatchMessage($"Passwords do not match!"));
                registerDeniedWindow.ShowDialog();
            } else
            {
                try
                {
                    computerHardware2Add = (await hardwareService.addHardware(computerHardware2Add.CPU, computerHardware2Add.RAM, computerHardware2Add.OS, computerHardware2Add.GraphicsCard, computerHardware2Add.guid));
                    registerUserModel = (await userService.registerUser(viewModel.UserName, viewModel.Password, viewModel.Email));
                    RegisterSuccessfulWindow registerSuccessfulWindow = new RegisterSuccessfulWindow(new RegisterSuccessfulMessage($"You have successfully made an account {registerUserModel.UserName}"));
                    registerSuccessfulWindow.ShowDialog();
                }
                catch
                {
                    RegisterDeniedWindow registerDeniedWindow = new RegisterDeniedWindow(new PasswordNotMatchMessage($"It appears user with the same username already exists in our database {viewModel.UserName}"));
                    registerDeniedWindow.ShowDialog();
                }
            }
        }
    }
}
