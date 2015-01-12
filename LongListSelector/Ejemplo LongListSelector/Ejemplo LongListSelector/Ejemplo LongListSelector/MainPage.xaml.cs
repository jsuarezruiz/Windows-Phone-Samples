using Ejemplo_LongListSelector.ViewModels;
using Microsoft.Phone.Controls;

namespace Ejemplo_LongListSelector
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            DataContext = new MainPageViewModel();
        }
    }
}