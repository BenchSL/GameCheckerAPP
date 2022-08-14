using GameCheckerWpf.LoginValidation;
using GameCheckerWpf.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace GameCheckerWpf
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        string gameTitle = "";
        int index;

        private BitmapImage _image;
        public BitmapImage MyImage
        {
            get { return _image; }
            set 
            {
                _image = value;
                if (BitmapImage.Equals(value, _image))
                    return;
                _image = value;
                OnPropertyChanged("MyImage");             
            }
        }
        private string gameText;
        public string GameText
        {
            get { return gameText; }
            set 
            {
                if (string.Equals(value, gameText))
                    return;
                gameText = value;
                OnPropertyChanged("GameText");
            }
        }
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            index = 1;
            //GameText = getGameName(gameTitle);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
