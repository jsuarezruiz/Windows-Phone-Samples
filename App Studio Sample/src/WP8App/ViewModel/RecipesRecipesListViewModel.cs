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
    public partial class RecipesRecipesListViewModel : BindableBase, IRecipesRecipesListViewModel
    {       
        private readonly INavigationService _NavigationService;
		
		
        //LockScreen 
        private ICommand _setLockScreenCommand;
        public ICommand SetLockScreenCommand
        {
            get { return _setLockScreenCommand = _setLockScreenCommand ?? new DelegateCommand(SetLockScreenCommandControl); }
        }

        public void SetLockScreenCommandControl()
        {
			System.Uri image = null;
            //Dynamic image
            //if (_SelectedRecipeDataSource != null)
            //{
            //    image = new System.Uri("ms-appx:///Resources/"+_SelectedRecipeDataSource.Image, System.UriKind.Absolute);
            //}
			
			//Preconfigured image
			string lockKey = "Splashscreen-720-red.png";
			if (!string.IsNullOrEmpty(lockKey))
				image = new System.Uri("ms-appx:///Resources/"+lockKey, System.UriKind.Absolute);
		
            _LiveTileService.SetLockScreen(image);
        }
        //LockScreen end
		private IRecipeDataSource _RecipeDataSource;
		private ILiveTileService _LiveTileService;
		private IDialogService _DialogService;
		private IShareService _ShareService;
		private ISpeechService _SpeechService;

		public void Load()
		{
		
		}
		
        public RecipesRecipesListViewModel(INavigationService _NavigationService, IRecipeDataSource _RecipeDataSource, ILiveTileService _LiveTileService, IDialogService _DialogService, IShareService _ShareService, ISpeechService _SpeechService)
        {
            this._NavigationService = _NavigationService;
			this._RecipeDataSource = _RecipeDataSource;
			this._LiveTileService = _LiveTileService;
			this._DialogService = _DialogService;
			this._ShareService = _ShareService;
			this._SpeechService = _SpeechService;
        }
		
		private ObservableCollection<Recipe> _RecipeDataSourceCollection;
		public ObservableCollection<Recipe> RecipeDataSourceCollection
		{
			get
			{
				if(_RecipeDataSourceCollection == null)
					_RecipeDataSourceCollection = _RecipeDataSource.GetData();
				return _RecipeDataSourceCollection;
			}
			set
			{
				SetProperty(ref _RecipeDataSourceCollection, value);
			}
		}		
	
        private Recipe _SelectedRecipeDataSource;
        public Recipe SelectedRecipeDataSource
        {
            get { return _SelectedRecipeDataSource; }
            set
            {
                _SelectedRecipeDataSource = value;
                if (value != null)
					_NavigationService.NavigateToSelectedRecipeDataSource(_SelectedRecipeDataSource);
			}
        }
    }
}

