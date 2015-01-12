using Windows.Devices.Geolocation;
using Windows.Devices.Geolocation.Geofencing;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Ejemplo_Geofencing.Services.Dialog;
using Ejemplo_Geofencing.ViewModels.Base;
using System;

namespace Ejemplo_Geofencing.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //Services
        private readonly IDialogService _dialogService;

        //Variables
        readonly GeofenceMonitor _monitor = GeofenceMonitor.Current;
        private readonly CoreDispatcher _dispatcher;

        public MainViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            _dispatcher = Window.Current.Dispatcher;

            // Creamos un Geofence.
            NewGeofence("Windows Phone Developer", 37.3823, -5.9702, 150);

            _monitor.GeofenceStateChanged += MonitorOnGeofenceStateChanged;
        }

        /// <summary>
        /// Crea un geofence.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="radius"></param>
        private void NewGeofence(string id, double latitude, double longitude, double radius)
        {
            // Establecemos la posición del Geofence.
            var position = new BasicGeoposition
            {
                Latitude = latitude,
                Longitude = longitude
            };

            // El Geofence es un círculo centrado en el punto dado por la latitud y la longitud con el radio asignado en la propiedad radius.
            var geocircle = new Geocircle(position, radius);

            // Queremos gestionar los eventos al entrar en la zona.
            const MonitoredGeofenceStates mask = MonitoredGeofenceStates.Entered;

            // Tiempo que el usuario debe estar en el área para recibir la notificación.
            var dwellTime = TimeSpan.FromSeconds(5);

            // Añadimos el Geofence al GeofenceMonitor.
            var geofence = new Geofence(id, geocircle, mask, false, dwellTime);

            if (!GeofenceMonitor.Current.Geofences.Contains(geofence))
                GeofenceMonitor.Current.Geofences.Add(geofence);
        }

        /// <summary>
        /// Evento que se lanza cada vez que entra o sale del área.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void MonitorOnGeofenceStateChanged(GeofenceMonitor sender, object args)
        {
            var fences = sender.ReadReports();

            foreach (var report in fences)
            {
                if (report.Geofence.Id != "Windows Phone Developer")
                    continue;

                switch (report.NewState)
                {
                    case GeofenceState.Entered:
                        _dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                        {
                            await _dialogService.Show("Hola!");
                        });
                        break;
                }
            }
        }
    }
}
