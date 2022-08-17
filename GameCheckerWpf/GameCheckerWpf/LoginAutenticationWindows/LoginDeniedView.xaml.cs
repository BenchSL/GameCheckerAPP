using GameCheckerWpf.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameCheckerWpf.LoginAutenticationWindows
{
    /// <summary>
    /// Interaction logic for LoginDeniedView.xaml
    /// </summary>
    public partial class LoginDeniedView : UserControl
    {
        public LoginDeniedView(UserNotFoundException userNotFoundException)
        {
            InitializeComponent();
            exception_box.Text = userNotFoundException.Message;
        }
    }
}
