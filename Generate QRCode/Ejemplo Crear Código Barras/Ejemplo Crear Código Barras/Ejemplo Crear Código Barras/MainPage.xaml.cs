using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Controls;
using ZXing;

namespace Ejemplo_Crear_Código_Barras
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnGenerate_Click(object sender, RoutedEventArgs e)
        {
            ImgQrCode.Source = GenerateQrCode("@jsuarezruiz");
        }

        private static WriteableBitmap GenerateQrCode(string content)
        {
            var writer = new BarcodeWriter
            {
                Renderer = new ZXing.Rendering.WriteableBitmapRenderer
                {
                    Foreground = System.Windows.Media.Color.FromArgb(255, 0, 0, 0),
                },
                Format = BarcodeFormat.QR_CODE,
                Options = { Height = 400, Width = 400 }
            };

            var barcodeImage = writer.Write(content);

            return barcodeImage;
        }
    }
}