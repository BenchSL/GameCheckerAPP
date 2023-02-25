using GameCheckerWpf.Commands;
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

        public ICommand UpdateViewCommand { get; set; }
        public ICommand LoginCommand { get; set; }

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
        }

    }
}
