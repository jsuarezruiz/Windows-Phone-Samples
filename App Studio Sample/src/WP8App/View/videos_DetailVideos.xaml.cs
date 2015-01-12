// ------------------------------------------------------------------------
// ========================================================================
// THIS CODE AND INFORMATION ARE GENERATED BY AUTOMATIC CODE GENERATOR
// ========================================================================
// Template:   PageCS.tt
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MyToolkit.Paging;
using Newtonsoft.Json;
using WPAppStudio;
using WPAppStudio.Entities;
using WPAppStudio.Helpers;
using WPAppStudio.Ioc;
using WPAppStudio.Localization;
using WPAppStudio.Repositories;
using WPAppStudio.Services.Interfaces;
using WPAppStudio.ViewModel;
using WPAppStudio.ViewModel.Interfaces;

namespace WPAppStudio.View
{
    /// <summary>
    /// Phone application page for videos_DetailVideos.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    [System.CodeDom.Compiler.GeneratedCode("Radarc", "4.0")]
    public partial class videos_DetailVideos : PhoneApplicationPage
    {       
        /// <summary>
        /// Initializes the phone application page for videos_DetailVideos and all its components.
        /// </summary>
        public videos_DetailVideos()
        {
            InitializeComponent();        
			if (Resources.Contains("Panoramavideos_DetailVideos0AppBar"))
				PhonePage.SetApplicationBar(this, Resources["Panoramavideos_DetailVideos0AppBar"] as BindableApplicationBar);                            
		}
		
        private void panoramavideos_DetailVideos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {		
			InitializeAppBarpanoramavideos_DetailVideos(Panoramavideos_DetailVideos.SelectedItem as PanoramaItem);
        }
		
		private void InitializeAppBarpanoramavideos_DetailVideos(PanoramaItem panoramaItem)        
        {
			if (Resources.Contains(panoramaItem.Name + "AppBar"))
			{
				PhonePage.SetApplicationBar(this, Resources[panoramaItem.Name + "AppBar"] as BindableApplicationBar);            
				ApplicationBar.IsVisible = true;
            }
		    else if(ApplicationBar != null)
		        ApplicationBar.IsVisible = false;
        }

		protected override void OnBackKeyPress(CancelEventArgs e)
		{
			if (MyToolkit.Multimedia.YouTube.CancelPlay())
				e.Cancel = true;

			base.OnBackKeyPress(e);
		}
 
        /// <summary>
        /// Called when the page becomes the active page.
        /// </summary>
        /// <param name="e">Contains information about the navigation done.</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string currentId;
			
            if (NavigationContext.QueryString.TryGetValue("currentID", out currentId))
            {
				var dataSource = new Container().Resolve<IvideosDataSource>();
				AddHomeAppBarButton();
				var pinnedItem  = (await dataSource.GetData()).FirstOrDefault(x => IsPinnedItem(x.VideoId.ToString(), currentId));
				if(pinnedItem==null)
					MessageBox.Show(AppResources.PinError);
				((videos_DetailVideosViewModel)DataContext).CurrentYouTubeVideo = pinnedItem;				
			}
			MyToolkit.Multimedia.YouTube.CancelPlay();
		}

        private static bool IsPinnedItem(string itemId, string currentId)
        {
            itemId = itemId.Trim();
            currentId = HttpUtility.UrlDecode(currentId.Trim());
            return itemId.Equals(currentId, StringComparison.InvariantCultureIgnoreCase);
        }
		
        private void AddHomeAppBarButton()
        {
            if (ApplicationBar.Buttons.Count >= 4) return;
						
			var homeIcon = new ApplicationBarIconButton() {IconUri = new Uri("/Images/Icons/Light/Home.png", UriKind.Relative), IsEnabled = true, Text = "Home"};
            homeIcon.Click += delegate { new Container().Resolve<INavigationService>().NavigateTo<ITheTeam_AlbumViewModel>(); };
            ApplicationBar.Buttons.Add(homeIcon);
        }
    }
}