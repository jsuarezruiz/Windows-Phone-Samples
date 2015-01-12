// Template: ViewModel

using DoWapp;
using DoWapp.Services.Interfaces;
using DoWapp.Data;
using DoWapp.ViewModel;
using DoWapp.ViewModel.Base;
using Microsoft.Phone.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DoWapp.ViewModel
{
    public partial class RecipesRecipeDetail1ViewModel : BindableBase, IRecipesRecipeDetail1ViewModel
    {       
        private readonly INavigationService _NavigationService;
		
		
		private ILiveTileService _LiveTileService;
		private IDialogService _DialogService;
		private IShareService _ShareService;
		private ISpeechService _SpeechService;

		public void Load()
		{
		
		}
		
        public RecipesRecipeDetail1ViewModel(INavigationService _NavigationService, ILiveTileService _LiveTileService, IDialogService _DialogService, IShareService _ShareService, ISpeechService _SpeechService)
        {
            this._NavigationService = _NavigationService;
			this._LiveTileService = _LiveTileService;
			this._DialogService = _DialogService;
			this._ShareService = _ShareService;
			this._SpeechService = _SpeechService;
        }
		
        private Recipe _CurrentRecipe;
        public Recipe CurrentRecipe
        {
            get { return _CurrentRecipe; }
            set
            {
                SetProperty(ref _CurrentRecipe, value);
            }
        }

		private ICommand _shareRecipesRecipeDetail1StaticControlCommand;
		public ICommand ShareRecipesRecipeDetail1StaticControlCommand
        {
            get { return _shareRecipesRecipeDetail1StaticControlCommand = _shareRecipesRecipeDetail1StaticControlCommand ?? new DelegateCommand(ShareRecipesRecipeDetail1StaticControl); }
        }
		
		private ICommand _pinToStartRecipesRecipeDetail1StaticControlCommand;
        public ICommand PinToStartRecipesRecipeDetail1StaticControlCommand
        {
            get { return _pinToStartRecipesRecipeDetail1StaticControlCommand = _pinToStartRecipesRecipeDetail1StaticControlCommand ?? new DelegateCommand(PinToStartRecipesRecipeDetail1StaticControl); }
        }

		private ICommand _readRecipesRecipeDetail1StaticControlCommand;
        public ICommand ReadRecipesRecipeDetail1StaticControlCommand
        {
            get { return _readRecipesRecipeDetail1StaticControlCommand = _readRecipesRecipeDetail1StaticControlCommand ?? new DelegateCommand(ReadRecipesRecipeDetail1StaticControl); }
        }
		
		public void ShareRecipesRecipeDetail1StaticControl()
        {
            _ShareService.Share("elaboration", 
								CurrentRecipe.Instructions, 
								string.Empty);
        }

        public void PinToStartRecipesRecipeDetail1StaticControl()
        {
            string uri = _NavigationService.GetNavigationSource();
            if (_LiveTileService.TileExists(uri))
            {
                _LiveTileService.DeleteTile(uri);
                _DialogService.Show("Secondary Tile deleted.");
            }
            else
            {
			    _LiveTileService.CurrentId = CurrentRecipe.Id.ToString();
                _LiveTileService.Title = CurrentRecipe.Name;
                _LiveTileService.Count = 1;
                _LiveTileService.BackgroundImagePath = CurrentRecipe.Image;
                _LiveTileService.BackBackgroundImagePath = CurrentRecipe.Image;
                _LiveTileService.LogoPath = "Logo.png";
                _LiveTileService.CreateTile(uri);
            }
        }

        public void ReadRecipesRecipeDetail1StaticControl()
        {
			_SpeechService.TextToSpeech("elaboration" + CurrentRecipe.Instructions);
        }

		private ICommand _shareRecipesRecipeIngredientsStaticControlCommand;
		public ICommand ShareRecipesRecipeIngredientsStaticControlCommand
        {
            get { return _shareRecipesRecipeIngredientsStaticControlCommand = _shareRecipesRecipeIngredientsStaticControlCommand ?? new DelegateCommand(ShareRecipesRecipeIngredientsStaticControl); }
        }
		
		private ICommand _pinToStartRecipesRecipeIngredientsStaticControlCommand;
        public ICommand PinToStartRecipesRecipeIngredientsStaticControlCommand
        {
            get { return _pinToStartRecipesRecipeIngredientsStaticControlCommand = _pinToStartRecipesRecipeIngredientsStaticControlCommand ?? new DelegateCommand(PinToStartRecipesRecipeIngredientsStaticControl); }
        }

		private ICommand _readRecipesRecipeIngredientsStaticControlCommand;
        public ICommand ReadRecipesRecipeIngredientsStaticControlCommand
        {
            get { return _readRecipesRecipeIngredientsStaticControlCommand = _readRecipesRecipeIngredientsStaticControlCommand ?? new DelegateCommand(ReadRecipesRecipeIngredientsStaticControl); }
        }
		
		public void ShareRecipesRecipeIngredientsStaticControl()
        {
            _ShareService.Share("ingredients", 
								CurrentRecipe.Ingredients, 
								string.Empty);
        }

        public void PinToStartRecipesRecipeIngredientsStaticControl()
        {
            string uri = _NavigationService.GetNavigationSource();
            if (_LiveTileService.TileExists(uri))
            {
                _LiveTileService.DeleteTile(uri);
                _DialogService.Show("Secondary Tile deleted.");
            }
            else
            {
			    _LiveTileService.CurrentId = CurrentRecipe.Id.ToString();
                _LiveTileService.Title = CurrentRecipe.Name;
                _LiveTileService.Count = 1;
                _LiveTileService.BackgroundImagePath = "";
                _LiveTileService.BackBackgroundImagePath = "";
                _LiveTileService.LogoPath = "Logo.png";
                _LiveTileService.CreateTile(uri);
            }
        }

        public void ReadRecipesRecipeIngredientsStaticControl()
        {
			_SpeechService.TextToSpeech("ingredients" + CurrentRecipe.Ingredients);
        }
    }
}

