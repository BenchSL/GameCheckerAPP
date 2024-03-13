using GalaSoft.MvvmLight.CommandWpf;
using GameCheckerWpf.Commands;
using GameCheckerWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameCheckerWpf.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private string username;
        private string password;
        private string email;
        private string confirmPassword;
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

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }

        public ICommand UpdateViewCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public ICommand ShowGameDetailCommand { get; set; }

        private BaseViewModel _selectedViewModel = new MainViewModel();
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        public MainWindowViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
            LoginCommand = new LoginUserCommand(this);
            RegisterCommand = new RegisterUserCommand(this);
            ShowGameDetailCommand = new RelayCommand<object>(game => ShowGameDetail(game));
        }

        private void ShowGameDetail(object game)
        {
            SelectedViewModel = new GameDetailViewModel(game as GameModel);
        }

    }
}
