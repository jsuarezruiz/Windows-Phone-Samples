using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Ejemplo_Carga_Scroll.Model
{
    public class YouTubeSearchResult : INotifyPropertyChanged
    {
        public YouTubeSearchResult(XNamespace atomns, XElement entry, XNamespace medians)
        {
            var xElement = entry.Element(atomns.GetName("id"));
            var element = entry.Element(atomns.GetName("id"));
            if (element != null)
                Id = xElement != null
                              ? element.Value.Split(':').Last()
                              : string.Empty;
            ImageUrl = (from thumbnail in entry.Descendants(medians.GetName("thumbnail"))
                        let xAttribute = thumbnail.Attribute("url")
                        where xAttribute != null
                        select xAttribute.Value).FirstOrDefault();
            var xElement1 = entry.Element(atomns.GetName("title"));
            if (xElement1 != null)
                Title = xElement1.Value;
        }

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

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (_title != value)
                {
                    _title = value;
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
        public string Id
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
