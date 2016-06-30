using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using CERPAlsaceTandem.Models;

namespace CERPAlsaceTandem.Helpers
{
    public class TandemTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tandemType = (TandemType) value;
            switch (tandemType)
            {
                case TandemType.Photo:
                    return "Photos";
                case TandemType.Video:
                    return "Vidéos";
                case TandemType.VideoPhoto:
                    return "Photos et vidéos";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
