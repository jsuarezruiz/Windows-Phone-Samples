using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Ejemplo_HubTile
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            //HubTileService.FreezeGroup("hubs1");
        }

        private void HubTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show(((HubTile)sender).Title);
        }

        private void pastasTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pastas.xaml", UriKind.Relative));
        }
    }
}