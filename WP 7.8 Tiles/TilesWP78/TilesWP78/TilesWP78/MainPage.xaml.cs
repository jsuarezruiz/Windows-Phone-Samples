using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Linq;

namespace TilesWP78
{
    public partial class MainPage : PhoneApplicationPage
    {

        private static Version wp7Version = new Version(7, 10, 8858);

        public static bool isWp8Version { get { return Environment.OSVersion.Version >= wp7Version; } }

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            if (isWp8Version)
            {
                Type flipTileData = Type.GetType("Microsoft.Phone.Shell.FlipTileData, Microsoft.Phone");

                Type shellTile = Type.GetType("Microsoft.Phone.Shell.ShellTile, Microsoft.Phone");

                var tileToUpdate = ShellTile.ActiveTiles.First();

                var UpdateTileData = flipTileData.GetConstructor(new Type[] { }).Invoke(null);
 
                SetProperty(UpdateTileData, "Title", "Título");
                SetProperty(UpdateTileData, "Count", 19);
                SetProperty(UpdateTileData, "BackTitle", "Título Atrás");
                SetProperty(UpdateTileData, "BackContent", "Contenido.");
                SetProperty(UpdateTileData, "WideBackContent", "Contenido para el tile en tamaño ancho.");

                shellTile.GetMethod("Update").Invoke(tileToUpdate, new Object[] { UpdateTileData });
            }
            else
            {
                ShellTile tile = ShellTile.ActiveTiles.First();

                if (tile != null)
                {
                    StandardTileData tileData = new StandardTileData
                    {
                        Title = "Titulo",
                        Count = 19,
                        BackTitle = "Título trasero",
                        BackContent = "Contenido"
                    };

                    tile.Update(tileData);
                }
            }
        }

        private static void SetProperty(object instance, string property, object value)
        {
            var method = instance.GetType().GetProperty(property).GetSetMethod();
            method.Invoke(instance, new object[] { value });
        }
    }
}