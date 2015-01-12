using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Diagnostics;
using System.Windows.Input;
using Microsoft.Devices;
using System.Windows.Media;

namespace DoWapp.Controls
{
    public partial class TwitterControl : UserControl
    {
        int _offsetKnob = 7;
        int _pageNumber = 1;

        TwitterViewModel _viewModel;
        public TwitterViewModel ViewModel
        {
            get { return _viewModel; }
            set { _viewModel = value; }
        }

        public TwitterControl()
        {
            InitializeComponent();
            _viewModel = (TwitterViewModel)Resources["viewModel"];
            resultListBox.ItemRealized += resultListBox_ItemRealized;
            this.Loaded += new RoutedEventHandler(OnLoaded);
        }

        public string SearchTerm
        {
            get { return (string)GetValue(SearchTermProperty); }
            set { SetValue(SearchTermProperty, value); }
        }

        public static readonly DependencyProperty SearchTermProperty =
            DependencyProperty.Register("SearchTerm", typeof(string), typeof(TwitterControl), new PropertyMetadata(string.Empty, searchTermChanged));

        private static void searchTermChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as TwitterControl).tbxSearchTerm.Text = e.NewValue as string;
        }

        public void Refresh()
        {
            if (String.IsNullOrEmpty(SearchTerm))
            {
                VibrateController.Default.Start(TimeSpan.FromMilliseconds(200));
                return;
            }
            _pageNumber = 1;
            _viewModel.LoadPage(SearchTerm, _pageNumber++);
        }

        private void OnLoaded(object sender, EventArgs eventArgs)
        {
            var progressIndicator = SystemTray.ProgressIndicator;
            if (progressIndicator != null)
            {
                return;
            }

            progressIndicator = new ProgressIndicator();

            SystemTray.SetProgressIndicator(this, progressIndicator);

            Binding binding = new Binding("IsLoading") { Source = _viewModel };
            BindingOperations.SetBinding(
                progressIndicator, ProgressIndicator.IsVisibleProperty, binding);

            binding = new Binding("IsLoading") { Source = _viewModel };
            BindingOperations.SetBinding(
                progressIndicator, ProgressIndicator.IsIndeterminateProperty, binding);

            progressIndicator.Text = "Loading new tweets...";
            _viewModel.LoadPage(SearchTerm, _pageNumber++);

            var parentPage = App.RootFrame.Content as PhoneApplicationPage;
            if (parentPage != null)
            {
                parentPage.ApplicationBar = Resources["appbarTwitter"] as ApplicationBar;
                parentPage.ApplicationBar.IsVisible = true;
            }
        }

        private void resultListBox_ItemRealized(object sender, ItemRealizationEventArgs e)
        {
            if (!_viewModel.IsLoading && resultListBox.ItemsSource != null && resultListBox.ItemsSource.Count >= _offsetKnob)
            {
                if (e.ItemKind == LongListSelectorItemKind.Item)
                {
                    if ((e.Container.Content as TwitterSearchResult).Equals(resultListBox.ItemsSource[resultListBox.ItemsSource.Count - _offsetKnob]))
                    {
                        Debug.WriteLine("Searching for {0}", _pageNumber);
                        _viewModel.LoadPage(SearchTerm, _pageNumber++);
                    }
                }
            }
        }

        private void twitterResultListBox_Refresh(object sender, EventArgs e)
        {
            Refresh();
        }  
    }

    public class TwitterViewModel : INotifyPropertyChanged
    {
        const string SEARCH_URI = "http://search.twitter.com/search.atom?q={0}&page={1}";

        private bool _isLoading = false;

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                NotifyPropertyChanged("IsLoading");

            }
        }

        public TwitterViewModel()
        {
            this.TwitterCollection = new ObservableCollection<TwitterSearchResult>();
            this.IsLoading = false;

        }

        public ObservableCollection<TwitterSearchResult> TwitterCollection
        {
            get;
            private set;
        }

        public void LoadPage(string searchTerm, int pageNumber)
        {
            if (pageNumber == 1) this.TwitterCollection.Clear();

            IsLoading = true;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(String.Format(SEARCH_URI, searchTerm, pageNumber)));
            request.BeginGetResponse(new AsyncCallback(ReadCallback), request);
        }

        private void ReadCallback(IAsyncResult asynchronousResult)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
                HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    NameTable nt = new NameTable();

                    XmlNamespaceManager nsmgr = new XmlNamespaceManager(nt);
                    nsmgr.AddNamespace("georss", "http://www.w3.org/2001/XMLSchema-instance");
                    XmlParserContext context = new XmlParserContext(null, nsmgr, null, XmlSpace.None);
                    XmlReaderSettings xset = new XmlReaderSettings();
                    xset.ConformanceLevel = ConformanceLevel.Fragment;


                    XmlReader rdr = XmlReader.Create(reader, xset, context);

                    SyndicationFeed feed = SyndicationFeed.Load(rdr);

                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {

                        foreach (var item in feed.Items)
                        {

                            this.TwitterCollection.Add(new TwitterSearchResult()
                            {
                                Author = item.Authors[0].Name,
                                ID = GetTweetId(item.Id),
                                Tweet = item.Title.Text,
                                PublishDate = item.PublishDate.DateTime.ToLocalTime(),
                                AvatarUrl = item.Links[1].Uri.AbsoluteUri
                            });

                        }
                        IsLoading = false;
                    });

                }
            }
            catch (Exception e)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    MessageBox.Show("Network error occured " + e.Message);
                });
            }
        }

        private string GetTweetId(string twitterId)
        {
            string[] parts = twitterId.Split(":".ToCharArray());

            return parts[2].ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
    public class TwitterSearchResult : INotifyPropertyChanged
    {
        private string _author;
        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                if (_author != value)
                {
                    _author = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _tweet;
        public string Tweet
        {
            get
            {
                return _tweet;
            }
            set
            {
                if (_tweet != value)
                {
                    _tweet = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private DateTime _publishDate;
        public DateTime PublishDate
        {
            get
            { return _publishDate; }
            set
            {
                if (_publishDate != value)
                {
                    _publishDate = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _Id;
        public string ID
        {
            get { return _Id; }
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _avatarUrl;
        public string AvatarUrl
        {
            get { return _avatarUrl; }
            set
            {
                if (_avatarUrl != value)
                {
                    _avatarUrl = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
