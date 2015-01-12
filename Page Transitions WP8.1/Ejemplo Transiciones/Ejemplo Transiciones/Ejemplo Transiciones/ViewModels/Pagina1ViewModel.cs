using Ejemplo_Transiciones.Services.Navigation;
using Ejemplo_Transiciones.ViewModels.Base;
using System.Windows.Input;

namespace Ejemplo_Transiciones.ViewModels
{
    public class Pagina1ViewModel : ViewModelBase
    {
        //Services
        private INavigationService _navigationService;

        //Commands
        private ICommand _navigateCommand;

        public Pagina1ViewModel(INavigationService navigationService)
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
            return null;
        }

        public ICommand NavigateCommand
        {
            get { return _navigateCommand = _navigateCommand ?? new DelegateCommand(NavigateCommandDelegate); }
        }

        public void NavigateCommandDelegate()
        {
            _navigationService.NavigateTo<Pagina2View>("Esto es un parámetro");
        }
    }
}
