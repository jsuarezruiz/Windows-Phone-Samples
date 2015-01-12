using Microsoft.Phone.Controls;
using RateMyApp.Helpers;

namespace Ejemplo_RateMyApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
#if DEBUG
            DataContext = FeedbackHelper.Default;
#endif
        }
    }
}