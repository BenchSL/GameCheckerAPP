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


namespace GameCheckerWpf.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl, INotifyPropertyChanged
    {
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

        public MainView()
        {
            InitializeComponent();
            index = 1;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void btn_next_Click(object sender, RoutedEventArgs e)
        {
            index++;
            if (index > 4)
            {
                index = 1;
            }
            MyImage = new BitmapImage(new Uri(@"C:/Users/timzu/OneDrive/Desktop/GameChecker/GameCheckerWpf/GameCheckerWpf/Images/" + index + ".jpg", UriKind.RelativeOrAbsolute));
            PicHolder.ImageSource = MyImage;
        }

        private void btn_pervious_Click(object sender, RoutedEventArgs e)
        {
            index--;
            if (index < 1)
            {
                index = 4;
            }
            MyImage = new BitmapImage(new Uri(@"C:/Users/timzu/OneDrive/Desktop/GameChecker/GameCheckerWpf/GameCheckerWpf/Images/" + index + ".jpg", UriKind.RelativeOrAbsolute));
            PicHolder.ImageSource = MyImage;
        }
    }
}
