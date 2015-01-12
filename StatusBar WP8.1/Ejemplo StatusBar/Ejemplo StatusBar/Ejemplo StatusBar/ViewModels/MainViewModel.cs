using Ejemplo_StatusBar.ViewModels.Base;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI;
using Windows.UI.ViewManagement;

namespace Ejemplo_StatusBar.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //Variables
        private Random _rand;

        //Commands
        private ICommand _hideStatusBarCommand;
        private ICommand _showStatusBarCommand;
        private ICommand _changeColorCommand;
        private ICommand _showProgressCommand;
        private ICommand _hideProgressCommand;

        public MainViewModel()
        {
            _rand = new Random();
        }

        public ICommand HideStatusBarCommand
        {
            get { return _hideStatusBarCommand = _hideStatusBarCommand ?? new DelegateCommandAsync(HideStatusBarCommandDelegate); }
        }

        public ICommand ShowStatusBarCommand
        {
            get { return _showStatusBarCommand = _showStatusBarCommand ?? new DelegateCommandAsync(ShowStatusBarCommandDelegate); }
        }

        public ICommand ChangeColorCommand
        {
            get { return _changeColorCommand = _changeColorCommand ?? new DelegateCommand(ChangeColorCommandDelegate); }
        }

        public ICommand ShowProgressCommand
        {
            get { return _showProgressCommand = _showProgressCommand ?? new DelegateCommandAsync(ShowProgressCommandDelegate); }
        }

        public ICommand HideProgressCommand
        {
            get { return _hideProgressCommand = _hideProgressCommand ?? new DelegateCommandAsync(HideProgressCommandDelegate); }
        }

        public override Task OnNavigatedFrom(Windows.UI.Xaml.Navigation.NavigationEventArgs args)
        {
            return null;
        }

        public override Task OnNavigatedTo(Windows.UI.Xaml.Navigation.NavigationEventArgs args)
        {
            return null;
        }

        private Color GetRandomColour()
        {
            var color = String.Format("#{0:X6}", _rand.Next(0x1000000));

            return Ejemplo_StatusBar.Helpers.ColorHelper.GetColorFromHexa(color).Color;
        }

        public async Task HideStatusBarCommandDelegate()
        {
            var statusBar = StatusBar.GetForCurrentView();

            await statusBar.HideAsync();
        }

        public async Task ShowStatusBarCommandDelegate()
        {
            var statusBar = StatusBar.GetForCurrentView();

            await statusBar.ShowAsync();
        }

        public void ChangeColorCommandDelegate()
        {
            var statusBar = StatusBar.GetForCurrentView();
            statusBar.BackgroundOpacity = 1;
            statusBar.BackgroundColor = GetRandomColour();
     
        }

        public async Task ShowProgressCommandDelegate()
        {
            var statusBar = StatusBar.GetForCurrentView();

            await statusBar.ShowAsync();

            await statusBar.ProgressIndicator.ShowAsync();
        }

        public async Task HideProgressCommandDelegate()
        {
            var statusBar = StatusBar.GetForCurrentView();

            await statusBar.ProgressIndicator.HideAsync();
        }
    }
}
