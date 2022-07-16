using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;
using Windows.UI;

namespace PixelArt.Converters
{
    class FromHexToWindowsUIColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var hex = value as String;

            hex = hex.Replace("#", string.Empty);
            // from #RRGGBB string
            var r = (byte)System.Convert.ToUInt32(hex.Substring(0, 2), 16);
            var g = (byte)System.Convert.ToUInt32(hex.Substring(2, 2), 16);
            var b = (byte)System.Convert.ToUInt32(hex.Substring(4, 2), 16);
            //get the color
            Color color = Color.FromArgb(255, r, g, b);

            return new SolidColorBrush(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
