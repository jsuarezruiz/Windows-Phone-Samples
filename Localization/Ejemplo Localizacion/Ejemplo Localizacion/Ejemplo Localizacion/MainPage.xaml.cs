using Microsoft.Phone.Controls;
using Windows.Devices.Geolocation;  //Geolocalización

namespace Ejemplo_Localizacion
{
    public partial class MainPage : PhoneApplicationPage
    {
        private Geolocator _geoLocator;
        private bool _isTracking;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            _geoLocator = null;
            _isTracking = false;
        }

        void geoLocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            Dispatcher.BeginInvoke(() =>
            {
                tbLatitud.Text = args.Position.Coordinate.Latitude.ToString();
                tbLongitud.Text = args.Position.Coordinate.Longitude.ToString();
                tbVelocidad.Text = args.Position.Coordinate.Speed.HasValue ? args.Position.Coordinate.Speed.ToString() : "UNKNOWN";
            });
        }

        void geoLocator_StatusChanged(Geolocator sender, StatusChangedEventArgs args)
        {
            string status = string.Empty;

            switch (args.Status)
            {
                case PositionStatus.Disabled:
                    // la aplicación no tiene la capacidad adecuada o el gps está apagago
                    status = "La localización está deshabilitada.";
                    break;
                case PositionStatus.Initializing:
                    // la geolocalización comenzó la operación de seguimiento
                    status = "Inicializando";
                    break;
                case PositionStatus.NoData:
                    // el servicio de localización no fue capaz de obtener la ubicación
                    status = "Sin Información";
                    break;
                case PositionStatus.Ready:
                    // el servicio de localización está preparado
                    status = "Preparado";
                    break;
                case PositionStatus.NotAvailable:
                    status = "No Disponible";
                    // no hay ningún hardware capaz de adquirir información de ubicación
                    break;
                case PositionStatus.NotInitialized:
                    // el estado inicial de la geolocalización
                    status = "No Inicializado";
                    break;
            }

            Dispatcher.BeginInvoke(() =>
            {
                tbEstado.Text = status;
            });
        }

        private void ButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!_isTracking)
            {
                _isTracking = true;

                _geoLocator = new Geolocator();
                _geoLocator.DesiredAccuracy = Windows.Devices.Geolocation.PositionAccuracy.High;
                _geoLocator.DesiredAccuracyInMeters = 1; // Debe ser lo más precisa posible para andar / correr / bicicleta. Puede utilizar valores de 50-100 para el coche
                _geoLocator.ReportInterval = 1000; // 1 segundo entre cada refresco es normalmente lo que se necesita para las actualizaciones en escenarios tales como caminar / correr / bicicleta.
                _geoLocator.StatusChanged += geoLocator_StatusChanged;
                _geoLocator.PositionChanged += geoLocator_PositionChanged;
            }
            else
            {
                _isTracking = false;

                _geoLocator.StatusChanged -= geoLocator_StatusChanged;
                _geoLocator.PositionChanged -= geoLocator_PositionChanged;
                _geoLocator = null;
            }
        }
    }
}