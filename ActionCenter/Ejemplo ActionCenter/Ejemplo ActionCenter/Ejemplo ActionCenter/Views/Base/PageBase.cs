using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Ejemplo_ActionCenter.ViewModels.Base;

namespace Ejemplo_ActionCenter.Views.Base
{
    public class PageBase : Page
    {
        private ViewModelBase _vm;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _vm = (ViewModelBase) DataContext;
            _vm.SetAppFrame(Frame);
            _vm.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            _vm.OnNavigatedFrom(e);
        }
    }
}