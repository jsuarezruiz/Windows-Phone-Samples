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
    public partial class RssControl : UserControl
    {
        RssViewModel _viewModel;
        public RssViewModel ViewModel
        {
            get { return _viewModel; }
            set { _viewModel = value; }
        }

        public RssControl()
        {
            InitializeComponent();
            _viewModel = (RssViewModel)Resources["viewModel"];
            this.Loaded += new RoutedEventHandler(OnLoaded);
        }

        public string RssUri
        {
            get { return (string)GetValue(RssUriProperty); }
            set { SetValue(RssUriProperty, value); }
        }

        public static readonly DependencyProperty RssUriProperty =
            DependencyProperty.Register("RssUri", typeof(string), typeof(RssControl), new PropertyMetadata(string.Empty));

        public string RssTitle
        {
            get { return (string)GetValue(RssTitleProperty); }
            set { SetValue(RssTitleProperty, value); }
        }

        public static readonly DependencyProperty RssTitleProperty =
            DependencyProperty.Register("RssTitle", typeof(string), typeof(RssControl), new PropertyMetadata(string.Empty, rssTitleChanged));

        private static void rssTitleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as RssControl).tbxRssTitle.Text = e.NewValue as string;
        }

        public void Refresh()
        {
            if (String.IsNullOrEmpty(RssUri))
            {
                VibrateController.Default.Start(TimeSpan.FromMilliseconds(200));
                return;
            }
            _viewModel.LoadPage(RssUri);
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
            _viewModel.LoadPage(RssUri);

            var parentPage = App.RootFrame.Content as PhoneApplicationPage;
            if (parentPage != null)
            {
                parentPage.ApplicationBar = Resources["appbarRss"] as ApplicationBar;
                parentPage.ApplicationBar.IsVisible = true;
            }
        }

        private void rssResultListBox_Refresh(object sender, EventArgs e)
        {
            Refresh();
        }  
    }

    public class RssViewModel : INotifyPropertyChanged
    {
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

        public RssViewModel()
        {
            this.RSSCollection = new ObservableCollection<RSSSearchResult>();
            this.IsLoading = false;

        }

        public ObservableCollection<RSSSearchResult> RSSCollection
        {
            get;
            private set;
        }

        public void LoadPage(string rssUri)
        {
            this.RSSCollection.Clear();

            IsLoading = true;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(String.Format(rssUri)));
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

                            this.RSSCollection.Add(new RSSSearchResult()
                            {
                                Author = item.Authors[0].Name,
                                ID = item.Id,
                                Title = item.Title.Text,
                                Summary = item.Summary.Text.Length > 140 ? item.Summary.Text.Substring(0,140) + "..." : item.Summary.Text,
                                PublishDate = item.PublishDate.DateTime.ToString("dd/MM/yy HH:mm tt"),
                                ImageUrl = GetImage(item)
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

        private string GetImage(SyndicationItem item)
        {
            var feedDataImage = string.Empty;
            foreach (SyndicationLink link in item.Links)
            {
                string linkImagen = link.Uri.AbsoluteUri.ToLower();
                if (linkImagen.Contains(".jpg") || linkImagen.Contains(".jpeg") || linkImagen.Contains(".png") || linkImagen.Contains(".gif"))
                    feedDataImage = link.Uri.AbsoluteUri;
            }

            if (feedDataImage.Equals(string.Empty))
                foreach (var link in item.ElementExtensions)
                {
                    string linkImagen = link.OuterName.ToLower();
                    if (linkImagen.Contains(".jpg") || linkImagen.Contains(".jpeg") || linkImagen.Contains(".png") || linkImagen.Contains(".gif"))
                        feedDataImage = link.OuterName;
                }

            if (feedDataImage.Equals(string.Empty))
            {
                if (item.Summary.Text.Contains("<img "))
                {
                    string aux = item.Summary.Text.Substring(item.Summary.Text.IndexOf("<img "));
                    aux = aux.Substring(0, aux.IndexOf(">"));
                    aux = aux.Substring(aux.IndexOf("src="));
                    aux = aux.Substring(aux.IndexOf("http"));
                    if (aux.Contains(".jpg"))
                        feedDataImage = aux.Substring(0, aux.LastIndexOf(".jpg") + 4);
                    else if (aux.Contains(".png"))
                        feedDataImage = aux.Substring(0, aux.LastIndexOf(".png") + 4);
                    else if (aux.Contains(".gif"))
                        feedDataImage = aux.Substring(0, aux.LastIndexOf(".gif") + 4);
                    else if (aux.Contains(".jpeg"))
                        feedDataImage = aux.Substring(0, aux.LastIndexOf(".") + 5);
                }
            }
            return feedDataImage;
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
    public class RSSSearchResult : INotifyPropertyChanged
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

        private string _publishDate;
        public string PublishDate
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

        private string _Title;
        public string Title
        {
            get { return _Title; }
            set
            {
                if (_Title != value)
                {
                    _Title = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _Summary;
        public string Summary
        {
            get { return _Summary; }
            set
            {
                if (_Summary != value)
                {
                    _Summary = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _imageUrl;
        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                if (_imageUrl != value)
                {
                    _imageUrl = value;
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
