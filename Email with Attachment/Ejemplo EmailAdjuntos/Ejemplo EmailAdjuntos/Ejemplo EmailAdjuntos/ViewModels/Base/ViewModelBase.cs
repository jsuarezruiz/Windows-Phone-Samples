﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Ejemplo_EmailAdjuntos.ViewModels.Base
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        private Frame _appFrame;
        private bool _isBusy;

        public ViewModelBase()
        {
        }

        public Frame AppFrame
        {
            get { return _appFrame; }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public abstract Task OnNavigatedFrom(NavigationEventArgs args);

        public abstract Task OnNavigatedTo(NavigationEventArgs args);

        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            var Handler = PropertyChanged;
            if (Handler != null)
                Handler(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void SetAppFrame(Frame viewFrame)
        {
            _appFrame = viewFrame;
        }
    }
}
