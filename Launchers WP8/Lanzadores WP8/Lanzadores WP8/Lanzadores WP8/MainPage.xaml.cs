using System;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using System.Device.Location;

namespace Lanzadores_WP8
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Código de ejemplo para traducir ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void btnMapsTask_Click_1(object sender, RoutedEventArgs e)
        {
            MapsTask mapsTask = new MapsTask();
            mapsTask.Center = new GeoCoordinate(37.387908, 6.001959);
            mapsTask.ZoomLevel = 8; // 1- 20
            mapsTask.SearchTerm = "restaurante";
  
            mapsTask.Show();
        }

        private void btnMapsDirectionsTask_Click_1(object sender, RoutedEventArgs e)
        {
            MapsDirectionsTask mapDirectionsTask = new MapsDirectionsTask();
            mapDirectionsTask.Start = new LabeledMapLocation("Sevilla", new GeoCoordinate(37.387908, 6.001959));
            mapDirectionsTask.End = new LabeledMapLocation("Madrid", new GeoCoordinate(40.420299, 3.705770));

            mapDirectionsTask.Show();
        }

        private void btnMapDownloaderTask_Click_1(object sender, RoutedEventArgs e)
        {
            MapDownloaderTask mapDownloaderTask = new MapDownloaderTask();

            mapDownloaderTask.Show();
        }

        private void btnSaveAppointmentTask_Click_1(object sender, RoutedEventArgs e)
        {
            SaveAppointmentTask saveAppointmentTask = new SaveAppointmentTask();
            saveAppointmentTask.StartTime = DateTime.Now.AddHours(1);
            saveAppointmentTask.EndTime = DateTime.Now.AddHours(2);
            saveAppointmentTask.Subject = "Artículo WP8";
            saveAppointmentTask.Details = "Escribir artículo Lanzadores en Windows Phone 8";
            saveAppointmentTask.Reminder = Reminder.FiveMinutes;

            saveAppointmentTask.Show();
        }

        private void btnShareMediaTask_Click_1(object sender, RoutedEventArgs e)
        {
            PhotoChooserTask photoChooserTask = new PhotoChooserTask();
            photoChooserTask.ShowCamera = true;
            photoChooserTask.PixelHeight = 300;
            photoChooserTask.PixelWidth = 300;
            photoChooserTask.Completed += photoChooserTask_Completed;

            photoChooserTask.Show();
        }

        void photoChooserTask_Completed(object sender, PhotoResult e)
        {
            ShareMediaTask shareMediaTask = new ShareMediaTask();
            shareMediaTask.FilePath = e.OriginalFileName;

            shareMediaTask.Show();
        }

        // Código de ejemplo para compilar una ApplicationBar traducida
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Establecer ApplicationBar de la página en una nueva instancia de ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Crear un nuevo botón y establecer el valor de texto en la cadena traducida de AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Crear un nuevo elemento de menú con la cadena traducida de AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}