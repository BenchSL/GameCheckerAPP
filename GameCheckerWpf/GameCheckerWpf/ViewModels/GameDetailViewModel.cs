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
    public class GameDetailViewModel : BaseViewModel
    {
        private readonly ICommand _updateViewCommand;
        private readonly GameModel _gameModel;

        public GameDetailViewModel(ICommand updateViewCommand) //, GameModel gameModel
        {
            _updateViewCommand = updateViewCommand;
            //_gameModel = gameModel;
        }

        public GameDetailViewModel()
        {

        }
    }
}
