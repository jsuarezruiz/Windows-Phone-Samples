using Ejemplo_Cortana.Views.Base;
using Windows.UI.Xaml.Navigation;

namespace Ejemplo_Cortana
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
