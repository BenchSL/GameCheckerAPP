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

        public ICommand UpdateViewCommand { get; set; }

        public MainWindowViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
        }     

        //public ICommand UpdateViewCommand { get; set; }
        //public MainWindowViewModel()
        //{
        //    UpdateViewCommand = new UpdateViewCommand(this);
        //}

    }
}
