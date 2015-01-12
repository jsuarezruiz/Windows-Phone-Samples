namespace BackgroundAudio.Converters
{
    using System;
    using Windows.UI.Xaml.Data;
    using ViewModels;

    public class StateToIconConverter : IValueConverter
    {
        private const string Play = "ms-appx:///Assets/Play.png";
        private const string Stop = "ms-appx:///Assets/Stop.png";

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var state = value as PlayerViewModel.PlayerState?;

            if (state == null)
                return string.Empty;

            return state == PlayerViewModel.PlayerState.Play ? Play : Stop;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
