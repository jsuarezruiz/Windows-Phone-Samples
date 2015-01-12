using Ejemplo_Carga_Scroll.Model;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows;
using System.Xml.Linq;

namespace Ejemplo_Carga_Scroll.ViewModel
{
    public class YouTubeViewModel : INotifyPropertyChanged
    {
        private const string SearchUri =
            "https://gdata.youtube.com/feeds/api/videos?q={0}&orderby=published&start-index={1}&max-results=10&v=2";

        private bool _isLoading;

        public YouTubeViewModel()
        {
            YouTubeCollection = new ObservableCollection<YouTubeSearchResult>();
            IsLoading = false;
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                NotifyPropertyChanged("IsLoading");
            }
        }

        public ObservableCollection<YouTubeSearchResult> YouTubeCollection { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public void LoadPage(string searchTerm, int pageNumber)
        {
            if (pageNumber == 1) YouTubeCollection.Clear();

            IsLoading = true;
            var request = (HttpWebRequest)WebRequest.Create(new Uri(String.Format(SearchUri, searchTerm, pageNumber)));
            request.BeginGetResponse(ReadCallback, request);
        }

        private void ReadCallback(IAsyncResult asynchronousResult)
        {
            try
            {
                var request = (HttpWebRequest)asynchronousResult.AsyncState;
                var response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    //For demo purposes only!!!
                    Thread.Sleep(500);

                    var feedData = XElement.Load(reader);
                    var atomns = XNamespace.Get("http://www.w3.org/2005/Atom");
                    var medians = XNamespace.Get("http://search.yahoo.com/mrss/");

                    var entries = from entry in feedData.Descendants(atomns.GetName("entry"))
                                  select new YouTubeSearchResult(atomns, entry, medians);

                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        foreach (var entry in entries)
                        {
                            YouTubeCollection.Add(entry);
                        }

                        IsLoading = false;
                    });
                }
            }
            catch (Exception e)
            {
                Deployment.Current.Dispatcher.BeginInvoke(
                    () => MessageBox.Show("Network error occured " + e.Message));
            }
        }

        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
