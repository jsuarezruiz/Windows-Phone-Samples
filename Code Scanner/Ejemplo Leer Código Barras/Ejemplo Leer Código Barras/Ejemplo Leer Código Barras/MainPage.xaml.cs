using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Microsoft.Devices;
using Microsoft.Phone.Controls;
using ZXing;

namespace Ejemplo_Leer_Código_Barras
{
    public partial class MainPage : PhoneApplicationPage
    {
        private IBarcodeReader _barcodeReader;
        private PhotoCamera _phoneCamera;
        private WriteableBitmap _previewBuffer;
        private DispatcherTimer _scanTimer;
        private string _barCode;

        public MainPage()
        {
            InitializeComponent();

            _phoneCamera = new PhotoCamera();
            _phoneCamera.Initialized += cam_Initialized;

            VideoBrushBackground.SetSource(_phoneCamera);

            _scanTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(100) };
            _scanTimer.Tick += (o, arg) => ScanForBarcode();
        }

        private void cam_Initialized(object sender, CameraOperationCompletedEventArgs e)
        {
            if (e.Succeeded)
            {
                Dispatcher.BeginInvoke(delegate
                {
                    _phoneCamera.FlashMode = FlashMode.Off;
                    _previewBuffer = new WriteableBitmap((int)_phoneCamera.PreviewResolution.Width,
                        (int)_phoneCamera.PreviewResolution.Height);

                    _barcodeReader = new BarcodeReader { Options = { TryHarder = true } };

                    _barcodeReader.ResultFound += _bcReader_ResultFound;
                    _scanTimer.Start();
                });
            }
            else
                Dispatcher.BeginInvoke(() => MessageBox.Show("No se ha podido inicializar la cámara!"));

        }

        private void _bcReader_ResultFound(Result obj)
        {
            if (obj.Text.Equals(_barCode)) return;
            VibrateController.Default.Start(TimeSpan.FromMilliseconds(100));
            MessageBox.Show(string.Format("Código capturado!. Formato: {0}, Contenido: {1}", obj.BarcodeFormat, obj.Text));
            _barCode = obj.Text;
        }

        private void ScanForBarcode()
        {
            _phoneCamera.GetPreviewBufferArgb32(_previewBuffer.Pixels);
            _previewBuffer.Invalidate();
            _barcodeReader.Decode(_previewBuffer);
        }
    }
}