using System.Windows.Input;
using Ejemplo_Cimbalino.ViewModel.Base;
using Ejemplo_Detener_Flip.Model;
using Ejemplo_Detener_Flip.Services;

namespace Ejemplo_Detener_Flip.ViewModel
{
    public class MainViewModel
    {
        private readonly ILiveTileService _liveTileService;

        public MainViewModel(ILiveTileService liveTileService)
        {
            _liveTileService = liveTileService;
        }

        private ICommand _updateTileCommand;

        public ICommand UpdateTileCommand
        {
            get { return _updateTileCommand = _updateTileCommand ?? new DelegateCommand(UpdateTileCommandDelegate); }
        }

        public void UpdateTileCommandDelegate()
        {
            var tileInfo = new TileInfo
            {
                Title = "Test",
                Count = 4,
                BackgroundImagePath = "Assets/Code.png",
                BackTitle = "Test Back",
                BackContent = "Test Back Content",
                BackBackgroundImagePath = "Assets/ApplicationIcon.png"
            };

            _liveTileService.UpdateTile(tileInfo);
        }

        private ICommand _stopFlipTileCommand;

        public ICommand StopFlipTileCommand
        {
            get { return _stopFlipTileCommand = _stopFlipTileCommand ?? new DelegateCommand(StopFlipTileCommandDelegate); }
        }

        public void StopFlipTileCommandDelegate()
        {
            var tileInfo = new TileInfo
            {
                Title = "Test",
                Count = 4,
                BackgroundImagePath = "Assets/Code.png"
            };

            _liveTileService.StopFlipTile(tileInfo);
        }
    }
}
