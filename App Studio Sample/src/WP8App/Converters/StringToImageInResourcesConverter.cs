using System;
using System.IO;
using System.Windows.Data;

namespace DoWapp.Converters
{
    public class StringToImageInResourcesConverter : IValueConverter
    {
        private const string resourcesFolder = @"..\Resources\";
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var file = value.ToString();
            return Path.Combine(resourcesFolder, file);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
