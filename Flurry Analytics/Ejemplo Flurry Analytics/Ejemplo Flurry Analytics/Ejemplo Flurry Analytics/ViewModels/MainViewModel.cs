using System;
using System.Windows.Input;
using Cimbalino.Phone.Toolkit.Services;
using Ejemplo_Flurry_Analytics.ViewModels.Base;

namespace Ejemplo_Flurry_Analytics.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        private ICommand _navigateCommand;

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ICommand NavigateCommand
        {
            get { return _navigateCommand = _navigateCommand ?? new DelegateCommand(NavigateCommandDelegate); }
        }

        public void NavigateCommandDelegate()
        {
            FlurryWP8SDK.Api.LogEvent("NavigateCommand");
            _navigationService.NavigateTo(new Uri("/Views/SecondaryView.xaml", UriKind.Relative));
        }
    }
}
