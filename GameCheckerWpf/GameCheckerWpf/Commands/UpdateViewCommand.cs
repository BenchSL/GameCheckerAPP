using GameCheckerAPI.Models;
using GameCheckerWpf.LoginValidation;
using GameCheckerWpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameCheckerWpf.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainWindowViewModel viewModel;

        public UpdateViewCommand(MainWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Performance")
            {
                viewModel.SelectedViewModel = new PerformanceViewModel();
            }

            else if (parameter.ToString() == "Login")
            {
                if (UserSession.isValid)
                {
                    viewModel.SelectedViewModel = new UserLoggedInViewModel();
                }
                else
                {
                    viewModel.SelectedViewModel = new MainWindowViewModel();
                }
            }

            else if (parameter.ToString() == "Home")
            {
                viewModel.SelectedViewModel = new MainViewModel();
            }

            else if (parameter.ToString() == "Hardware")
            {
                viewModel.SelectedViewModel = new HardwareMonitorViewModel();
            }
        }
    }
}
