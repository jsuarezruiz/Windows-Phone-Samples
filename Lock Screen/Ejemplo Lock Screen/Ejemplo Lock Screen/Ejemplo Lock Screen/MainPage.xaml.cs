using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Linq;
using System.Windows;

namespace Ejemplo_Lock_Screen
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Código de ejemplo para traducir ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void btnChangeCounterClick(object sender, RoutedEventArgs e)
        {
            ShellTile.ActiveTiles.First().Update(
            new FlipTileData()
            {
                Count = 59,
                WideBackContent = "Texto Pantalla Bloqueo",
                SmallBackgroundImage = new Uri(@"Assets\Tiles\FlipCycleTileSmall.png", UriKind.Relative),
                BackgroundImage = new Uri(@"Assets\Tiles\FlipCycleTileMedium.png", UriKind.Relative),
                BackBackgroundImage = new Uri(@"Assets\Tiles\FlipCycleTileMedium.png", UriKind.Relative)
            });
        }

        private async void btnChangeImageClick(object sender, RoutedEventArgs e)
        {
            if (!Windows.Phone.System.UserProfile.LockScreenManager.IsProvidedByCurrentApplication)
            {
                //Pedir Permisos.
                var permission = await Windows.Phone.System.UserProfile.LockScreenManager.RequestAccessAsync();

                if (permission == Windows.Phone.System.UserProfile.LockScreenRequestResult.Denied)
                {
                    //Permiso denegado.
                    return;
                }
            }

            Windows.Phone.System.UserProfile.LockScreen.SetImageUri(new Uri("ms-appx:///Assets/LockScreen.png", UriKind.Absolute));
        }
    }
}