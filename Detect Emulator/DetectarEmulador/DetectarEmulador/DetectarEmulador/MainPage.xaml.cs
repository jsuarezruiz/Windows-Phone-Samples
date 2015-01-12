using Microsoft.Phone.Controls;
using System.Windows;

namespace DetectarEmulador
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            if (Microsoft.Devices.Environment.DeviceType ==
               Microsoft.Devices.DeviceType.Emulator)
                MessageBox.Show("Emulador");
            else
                MessageBox.Show("Dispositivo");
        }
    }
}