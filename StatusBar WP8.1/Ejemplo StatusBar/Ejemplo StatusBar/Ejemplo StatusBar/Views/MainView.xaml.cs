using Ejemplo_StatusBar.Views.Base;
using Windows.UI.Xaml.Navigation;

namespace Ejemplo_StatusBar
{
    /// <summary>
    /// MainView.
    /// </summary>
    public sealed partial class MainView : PageBase
    {
        public MainView()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }
    }
}
