using Microsoft.Phone.Controls;
using System.Collections.Generic;
using System;
using System.Windows;

using Inneractive.Nokia.Ad;
using InneractiveAdLocation;

namespace Ejemplo_NAX
{
    public partial class MainPage : PhoneApplicationPage
    {
        Dictionary<InneractiveAd.IaOptionalParams, string> optionalParams;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            IaLocationClass iaLocation = new IaLocationClass();
            iaLocation.Done += new System.EventHandler<IaLocationEventArgs>(iaLocation_Done);
            iaLocation.StartWatchLocation();

            optionalParams = new Dictionary<InneractiveAd.IaOptionalParams, string>();
            optionalParams.Add(InneractiveAd.IaOptionalParams.Key_OptionalAdWidth, "320"); //Width 
            optionalParams.Add(InneractiveAd.IaOptionalParams.Key_OptionalAdHeight, "50"); //Height
            optionalParams.Add(InneractiveAd.IaOptionalParams.Key_Age, "25");
            optionalParams.Add(InneractiveAd.IaOptionalParams.Key_Gender, "m");
        }

        void iaLocation_Done(object sender, IaLocationEventArgs e)
        {
            try
            {
                // Add location, if received
                if (e != null && e.location != null)
                    optionalParams.Add(InneractiveAd.IaOptionalParams.Key_Gps_Coordinates, e.location);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + ex.ToString());
            }
        }

        private void textAd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.nax.Children.Clear();
            InneractiveAd.DisplayAd("appId", InneractiveAd.IaAdType.IaAdType_Text, this.nax, 60, optionalParams);
        }

        private void bannerAd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.nax.Children.Clear();
            InneractiveAd iaBanner = new InneractiveAd("appId", InneractiveAd.IaAdType.IaAdType_Banner, 60, optionalParams);
            this.nax.Children.Add(iaBanner);

            iaBanner.AdClicked += new InneractiveAd.IaAdClicked(InneractiveAd_AdClicked);
            iaBanner.AdReceived += new InneractiveAd.IaAdReceived(InneractiveAd_AdReceived);
            iaBanner.AdFailed += new InneractiveAd.IaAdFailed(InneractiveAd_AdFailed);
        }

        void InneractiveAd_AdClicked(object sender)
        {
            System.Diagnostics.Debug.WriteLine("AdClicked");
            MessageBox.Show("NAX Ad Clicked!");
        }

        void InneractiveAd_AdReceived(object sender)
        {
            System.Diagnostics.Debug.WriteLine("AdReceived");
        }

        void InneractiveAd_AdFailed(object sender)
        {
            System.Diagnostics.Debug.WriteLine("AdFailed");
        }

        private void interstitalAd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            InneractiveAd.DisplayAd("appId", InneractiveAd.IaAdType.IaAdType_Interstitial, LayoutRoot, 60);
        }
    }
}