using Microsoft.Phone.Controls;
using Nokia.Phone.HereLaunchers;
using System;
using System.Device.Location;
using System.Windows;

namespace Ejemplo_Lanzadores_HERE
{
    public partial class MainPage : PhoneApplicationPage
    {
        private const double LatitudSevilla = 37.2;
        private const double LongitudSevilla = -6;
        private const double LatitudMadrid = 40.4;
        private const double LongitudMadrid = -3.7;
        private const int zoom = 10;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnDirectionsRouteDestinationTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DirectionsRouteDestinationTask routeTask = new DirectionsRouteDestinationTask();
                routeTask.Origin = new GeoCoordinate(LatitudSevilla, LongitudSevilla); 
                routeTask.Destination = new GeoCoordinate(LatitudMadrid, LongitudMadrid);

                routeTask.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message: " + ex.Message);
            }
        }

        private void btnExploremapsExplorePlacesTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ExploremapsExplorePlacesTask searchMap = new ExploremapsExplorePlacesTask();
                searchMap.Location = new GeoCoordinate(LatitudSevilla, LongitudSevilla);
                searchMap.Category.Add(Nokia.Phone.HereLaunchers.PlaceCategoryId.shopping);

                searchMap.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message: " + ex.Message);
            }
        }

        private void btnGuidanceWalkTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GuidanceWalkTask walkTo = new GuidanceWalkTask();
                //GuidanceDriveTask driveTo = new GuidanceDriveTask();

                walkTo.Destination = new GeoCoordinate(LatitudSevilla, LongitudSevilla);
                walkTo.Title = "Sevilla";
                walkTo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message: " + ex.Message);
            }
        }

        private void btnPlacesShowDetailsByIdHrefTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PlacesShowDetailsByIdHrefTask placeTask = new PlacesShowDetailsByIdHrefTask();
                placeTask.Id = "276u33dc-10ee9c030bc042e6a6e8e0ad56985be2";
                placeTask.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message: " + ex.Message);
            }
        }

        private void btnPlacesShowDetailsByLocationTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PlacesShowDetailsByLocationTask showPlace = new PlacesShowDetailsByLocationTask();
                showPlace.Location = new GeoCoordinate(LatitudSevilla, LongitudSevilla);
                showPlace.Title = "Sevilla";
                showPlace.Show();
            }
            catch (Exception erno)
            {
                MessageBox.Show("Error message: " + erno.Message);
            }
        }

        private void btnPublicTransitRouteDestinationTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PublicTransitRouteDestinationTask JourneyTask = new PublicTransitRouteDestinationTask();
                JourneyTask.Origin = new GeoCoordinate(LatitudSevilla, LongitudSevilla);
                JourneyTask.Destination = new GeoCoordinate(LatitudSevilla + 1, LongitudSevilla + 1);
                JourneyTask.ArrivalTime = DateTime.Now.AddHours(2);
                JourneyTask.DepartureTime = DateTime.Now;
                JourneyTask.OriginTitle = "Sevilla";
                JourneyTask.DestinationTitle = "Destino";

                JourneyTask.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message: " + ex.Message);
            }
        }

        private void btnExploremapsSearchPlacesTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ExploremapsSearchPlacesTask searchMap = new ExploremapsSearchPlacesTask();
                searchMap.Location = new GeoCoordinate(LatitudSevilla, LongitudSevilla);
                searchMap.SearchTerm = "Restaurante";

                searchMap.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message: " + ex.Message);
            }
        }

        private void btnExploremapsShowPlaceTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ExploremapsShowPlaceTask showPlace = new ExploremapsShowPlaceTask();

                showPlace.Location = new GeoCoordinate(LatitudSevilla, LongitudSevilla);
                showPlace.Zoom = zoom;
                showPlace.Title = "Sevilla";

                showPlace.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message: " + ex.Message);
            }
        }

        private void btnExploremapsShowMapTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ExploremapsShowMapTask showMap = new ExploremapsShowMapTask();

                showMap.Location = new GeoCoordinate(LatitudSevilla, LongitudSevilla);
                showMap.Zoom = zoom;
                showMap.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message: " + ex.Message);
            }
        }
    }
}