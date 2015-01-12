using Windows.UI.Xaml.Navigation;
using BackgroundAudio.Views.Base;

namespace BackgroundAudio.Views
{
    /// <summary>
    ///     PlayerView
    /// </summary>
    public sealed partial class PlayerView : PageBase
    {
        public PlayerView()
        {
            InitializeComponent();

            NavigationCacheMode = NavigationCacheMode.Required;
        }
    }
}