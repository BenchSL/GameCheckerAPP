using GameCheckerWpf.Models;
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
using System.Windows.Shapes;

namespace GameCheckerWpf.Views
{
    /// <summary>
    /// Interaction logic for CanRunWindow.xaml
    /// </summary>
    public partial class CanRunWindow : Window
    {
        public CanRunWindow(bool canRun, GameModel gameModel)
        {
            InitializeComponent();
            ShowResult(canRun);
            this.DataContext = gameModel;
        }

        private void ShowResult(bool canRun)
        {
            if (canRun)
            {
                ResultText.Text = "Congratulations!";
                SubText.Text = "Your system meets the recommended requirements to run this game.";
            }
            else
            {
                ResultText.Text = "Unfortunately...";
                SubText.Text = "Your system does not meet the recommended requirements to run this game.";
            }
        }
    }
}
