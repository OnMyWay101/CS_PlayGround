using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace CarGuide3
{
        public class AutoMakerToLogoPathConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                string uriStr = $"Resources/Logo/{(string)value}.png";
                return new BitmapImage(new Uri(uriStr, UriKind.Relative));
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
        public class NameToPhotoPathConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                string uriStr = $"/Resources/Image/{(string)value}.png";
                return new BitmapImage(new Uri(uriStr, UriKind.Relative));
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
}
