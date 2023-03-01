using GameCheckerWpf.Services;
using GameCheckerWpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCheckerWpf.Commands
{
    public class RegisterUserCommand : MethodCommandBase
    {

        private readonly UserService userService;
        MainWindowViewModel viewModel;

        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
