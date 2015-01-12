using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Ejemplo_Tiles
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

        private void FlipTileButtonClick(object sender, RoutedEventArgs e)
        {
            ShellTile tile = ShellTile.ActiveTiles.FirstOrDefault();

            FlipTileData flipTile = new FlipTileData();
            flipTile.Title = "Título Flip Tile";
            flipTile.Count = 33;

            flipTile.BackTitle = "Título trasero Flip Tile";
            flipTile.BackContent = "Contenido parte trasera";
            flipTile.WideBackContent = "Contenido ancho parte trasera";

            flipTile.SmallBackgroundImage = new Uri("Assets/Tiles/FlipCycleTileSmall.png", UriKind.Relative);
            flipTile.BackgroundImage = new Uri("Assets/Tiles/FlipCycleTileMedium.png", UriKind.Relative);
            flipTile.WideBackgroundImage = new Uri("Assets/Tiles/FlipCycleTileLarge.png", UriKind.Relative);

            ShellTile.Create(new Uri("/MainPage.xaml?id=tile", UriKind.Relative), flipTile, true);
        }

        private void IconicTileButtonClick(object sender, RoutedEventArgs e)
        {
            IconicTileData iconTile = new IconicTileData();
            iconTile.Title = "Iconic Tile";
            iconTile.Count = 21;

            iconTile.IconImage = new Uri("Assets/Tiles/FlipCycleTileMedium.png", UriKind.Relative);
            iconTile.SmallIconImage = new Uri("Assets/Tiles/FlipCycleTileSmall.png", UriKind.Relative);

            iconTile.WideContent1 = "Ejemplo Iconic Tile";
            iconTile.WideContent2 = "Texto Contenido Ancho";
            iconTile.WideContent3 = "Podemos utilizar hasta 3 líneas!";

            ShellTile.Create(new Uri("/MainPage.xaml?id=iconic", UriKind.Relative), iconTile, true);
        }

        private void CycleTileButtonClick(object sender, RoutedEventArgs e)
        {
            CycleTileData cycleTile = new CycleTileData();
            cycleTile.Title = "Cycle Tile";
            cycleTile.Count = 25;

            cycleTile.SmallBackgroundImage = new Uri("Assets/Tiles/FlipCycleTileSmall.png", UriKind.Relative);

            List<Uri> images = new List<Uri>();
            images.Add(new Uri("Assets/Tiles/CycleTile1.png", UriKind.Relative));
            images.Add(new Uri("Assets/Tiles/CycleTile2.png", UriKind.Relative));
            cycleTile.CycleImages = images;

            ShellTile.Create(new Uri("/MainPage.xaml?id=cycle", UriKind.Relative), cycleTile, true);
        }
    }
}