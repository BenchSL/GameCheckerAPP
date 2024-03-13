using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GameCheckerWpf.Converters
{
    public class ImagePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string imageName)
            {
                var basePath = "C:/Users/timzu/Source/Repos/GameCheckerAPP/GameCheckerWpf/GameCheckerWpf";
                var imagePath = Path.Combine(basePath, "Images", imageName + ".jpg");
                return imagePath;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
