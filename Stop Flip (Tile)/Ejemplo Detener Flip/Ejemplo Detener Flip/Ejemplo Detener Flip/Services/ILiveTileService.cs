using Ejemplo_Detener_Flip.Model;

namespace Ejemplo_Detener_Flip.Services
{
    public interface ILiveTileService
    {
        void UpdateTile(TileInfo tileInfo);
        void StopFlipTile(TileInfo tileInfo);
    }
}
