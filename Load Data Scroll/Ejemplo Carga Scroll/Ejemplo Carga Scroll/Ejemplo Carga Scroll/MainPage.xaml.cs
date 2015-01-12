using Ejemplo_Carga_Scroll.ViewModel;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Diagnostics;
using System.Windows;
using System.Windows.Data;

namespace Ejemplo_Carga_Scroll
{
    public partial class MainPage : PhoneApplicationPage
    {
        private const int OffsetKnob = 10;
        private int _pageNumber = 1;
        private string _searchTerm = "Windows Phone";
        private readonly YouTubeViewModel _viewModel;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            _viewModel = (YouTubeViewModel)Resources["viewModel"];
            DataContext = _viewModel;

            Loaded += MainPage_Loaded;

            _viewModel.LoadPage(_searchTerm, _pageNumber);

            YouTubeList.ItemRealized += youTubeList_ItemRealized;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            ProgressIndicator progressIndicator = SystemTray.ProgressIndicator;
            if (progressIndicator != null)
            {
                return;
            }

            progressIndicator = new ProgressIndicator();

            SystemTray.SetProgressIndicator(this, progressIndicator);

            var binding = new Binding("IsLoading") { Source = _viewModel };
            BindingOperations.SetBinding(
                progressIndicator, ProgressIndicator.IsVisibleProperty, binding);

            binding = new Binding("IsLoading") { Source = _viewModel };
            BindingOperations.SetBinding(
                progressIndicator, ProgressIndicator.IsIndeterminateProperty, binding);

            progressIndicator.Text = "Loading new videos...";
        }

        private void youTubeList_ItemRealized(object sender, ItemRealizationEventArgs e)
        {
            if (!_viewModel.IsLoading && YouTubeList.ItemsSource != null &&
                YouTubeList.ItemsSource.Count >= OffsetKnob)
            {
                if (e.ItemKind == LongListSelectorItemKind.Item)
                {
                    var twitterSearchResult = e.Container.Content as object;
                    if (
                        twitterSearchResult != null && twitterSearchResult.Equals(
                            YouTubeList.ItemsSource[YouTubeList.ItemsSource.Count - OffsetKnob]))
                    {
                        Debug.WriteLine("Searching for {0}", _pageNumber);
                        _viewModel.LoadPage(_searchTerm, _pageNumber++);
                    }
                }
            }
        }
    }
}