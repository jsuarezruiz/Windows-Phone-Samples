using Ejemplo_Transiciones.Services.Navigation;
using Ejemplo_Transiciones.ViewModels.Base;
using System.Diagnostics;
using System.Windows.Input;

namespace Ejemplo_Transiciones.ViewModels
{
    public class Pagina4ViewModel : ViewModelBase
    {
        //Services
        private INavigationService _navigationService;

        //Commands
        private ICommand _navigateBackCommand;

        public Pagina4ViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override System.Threading.Tasks.Task OnNavigatedFrom(Windows.UI.Xaml.Navigation.NavigationEventArgs args)
        {
            return null;
        }

        public override System.Threading.Tasks.Task OnNavigatingFrom(Windows.UI.Xaml.Navigation.NavigatingCancelEventArgs args)
        {
            return null;
        }

        public override System.Threading.Tasks.Task OnNavigatedTo(Windows.UI.Xaml.Navigation.NavigationEventArgs args)
        {
            if (args.Parameter != null)
                Debug.WriteLine(args.Parameter);

            return null;
        }

        public ICommand NavigateBackCommand
        {
            get { return _navigateBackCommand = _navigateBackCommand ?? new DelegateCommand(NavigateBackCommandDelegate); }
        }

        public void NavigateBackCommandDelegate()
        {
            _navigationService.NavigateBack();
        }
    }
}
