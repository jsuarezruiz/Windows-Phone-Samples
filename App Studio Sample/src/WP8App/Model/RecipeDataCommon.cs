using DoWapp.ViewModel.Base;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DoWapp.Model
{
    [DataContract]
    public abstract class RecipeDataCommon : INotifyPropertyChanged
    {
        #region Privates

        internal static Uri _baseUri = new Uri("ms-appx:///");

        #endregion

        #region Constructor

        public RecipeDataCommon(String uniqueId, String title, String shortTitle, String imagePath)
        {
            this._uniqueId = uniqueId;
            this._title = title;
            this._shortTitle = shortTitle;
            this._imagePath = imagePath;
        }

        #endregion

        #region Properties

        private string _uniqueId = string.Empty;
        [DataMember(Name = "key")]
        public string UniqueId
        {
            get { return this._uniqueId; }
            set
            {
                this._uniqueId = value;
                RaisePropertyChanged("UniqueId");
            }
        }

        private string _title = string.Empty;
        [DataMember
            (Name = "title")]
        public string Title
        {
            get { return this._title; }
            set
            {
                this._title = value;
                RaisePropertyChanged("Title");
            }
        }

        private string _shortTitle = string.Empty;
        [DataMember(Name = "shortTitle")]
        public string ShortTitle
        {
            get { return this._shortTitle; }
            set
            {
                this._shortTitle = value;
                RaisePropertyChanged("ShortTitle");
            }
        }

        private ImageSource _image = null;
        private string _imagePath = null;

        public Uri ImagePath
        {
            get
            {
                return new Uri(RecipeDataCommon._baseUri, this._imagePath);
            }
        }

        [DataMember(Name = "backgroundImage")]
        public string BackgroundImage
        {
            get
            {
                return _imagePath;
            }
            set
            {
                _imagePath = value;
            }
        }

        [IgnoreDataMember]
        public ImageSource Image
        {
            get
            {
                if (this._image == null && this._imagePath != null)
                {
                    this._image = new BitmapImage(new Uri(RecipeDataCommon._baseUri, this._imagePath));
                }
                return this._image;
            }

            set
            {
                this._imagePath = null;
                this._image = value;

                RaisePropertyChanged("Image");
            }
        }

        #endregion

        #region Methods

        public void SetImage(String path)
        {
            this._image = null;
            this._imagePath = path;
            this.RaisePropertyChanged("Image");
        }

        public string GetImageUri()
        {
            return _imagePath;
        }

        #endregion

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
