using System.Windows;
using Ejemplo_Multilingual.Resources;
using Microsoft.Phone.Controls;

namespace Ejemplo_Multilingual
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(AppResources.HelloMessage);
        }
    }
}