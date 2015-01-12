using System;
using System.Linq;
using Ejemplo_Detener_Flip.Model;
using Microsoft.Phone.Shell;

namespace Ejemplo_Detener_Flip.Services
{
    public class LiveTileService : ILiveTileService
    {
        public void UpdateTile(TileInfo tileInfo)
        {
            var tileData = GetStandardTileData(tileInfo);

            var activeTile = ShellTile.ActiveTiles.FirstOrDefault();
            if (activeTile != null)
                activeTile.Update(tileData);
        }

        public void StopFlipTile(TileInfo tileInfo)
        {
            string xmlFlipTileData = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
            xmlFlipTileData += "<wp:Notification xmlns:wp=\"WPNotification\" Version=\"2.0\">";
            xmlFlipTileData += "<wp:Tile Id=\"1\" Template=\"FlipTile\">";
            xmlFlipTileData += "<wp:Count>" + tileInfo.Count + "</wp:Count>";
            xmlFlipTileData += "<wp:Title>" + tileInfo.Title + "</wp:Title>";

            if (!string.IsNullOrEmpty(tileInfo.BackgroundImagePath))
                xmlFlipTileData += "<wp:BackgroundImage IsRelative=\"true\">" + tileInfo.BackgroundImagePath + "</wp:BackgroundImage>";


            xmlFlipTileData += "<wp:BackTitle Action=\"Clear\"> </wp:BackTitle>";
            xmlFlipTileData += "<wp:BackContent Action=\"Clear\"></wp:BackContent>";
            xmlFlipTileData += "<wp:WideBackContent Action=\"Clear\"></wp:WideBackContent>";
            xmlFlipTileData += "<wp:BackBackgroundImage IsRelative=\"true\" Action=\"Clear\"></wp:BackBackgroundImage>";
            xmlFlipTileData += "<wp:WideBackBackgroundImage IsRelative=\"true\" Action=\"Clear\"></wp:WideBackBackgroundImage>";
            xmlFlipTileData += "</wp:Tile>";
            xmlFlipTileData += "</wp:Notification>";

            var tileData = new FlipTileData(xmlFlipTileData);
            ShellTile tileToFind = ShellTile.ActiveTiles.FirstOrDefault();

            if (tileToFind != null)
                tileToFind.Update(tileData);
        }

        private static StandardTileData GetStandardTileData(TileInfo tileInfo)
        {
            var tileData = new StandardTileData
            {
                Title = tileInfo.Title ?? string.Empty,
                Count = tileInfo.Count,
                BackTitle = tileInfo.BackTitle ?? string.Empty,
                BackContent = tileInfo.BackContent ?? string.Empty
            };
            if (!string.IsNullOrEmpty(tileInfo.BackgroundImagePath))
                tileData.BackgroundImage = new Uri(tileInfo.BackgroundImagePath, UriKind.RelativeOrAbsolute);
            if (!string.IsNullOrEmpty(tileInfo.BackBackgroundImagePath))
                tileData.BackBackgroundImage = new Uri(tileInfo.BackBackgroundImagePath, UriKind.RelativeOrAbsolute);

            return tileData;
        }
    }
}
