using Ejemplo_Cortana.ViewModels.Base;
using Ejemplo_Cortana.Views;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Media.SpeechRecognition;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Ejemplo_Cortana.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //Variables
        private ObservableCollection<string> _years;
        private string _selectedYear;

        //Commands
        private ICommand _searchCommand;

        //Constructor
        public MainViewModel()
        {
            _years = new ObservableCollection<string>();
            SelectedYear = DateTime.Now.Year.ToString();
        }

        public ObservableCollection<string> Years
        {
            get { return _years; }
            set { _years = value; }
        }

        public string SelectedYear
        {
            get { return _selectedYear; }
            set
            {
                _selectedYear = value;
                RaisePropertyChanged();
            }
        }

        public ICommand SearchCommand
        {
            get { return _searchCommand = _searchCommand ?? new DelegateCommand(SearchCommandDelegate); }
        }

        public override System.Threading.Tasks.Task OnNavigatedFrom(Windows.UI.Xaml.Navigation.NavigationEventArgs args)
        {
            return null;
        }

        public override async Task OnNavigatedTo(Windows.UI.Xaml.Navigation.NavigationEventArgs args)
        {
            if (args.NavigationMode == NavigationMode.New)
                await InstallVoice();

            LoadYears();
        }

        /// <summary>
        /// 
        /// </summary>
        async Task InstallVoice()
        {
            var storageFile =
                 await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///VoiceCommandDefinitions.xml"));

            await VoiceCommandManager.InstallCommandSetsFromStorageFileAsync(storageFile);
        }

        private void LoadYears()
        {
            for (var i = 1950; i <= DateTime.Now.Year; i++)
            {
                Years.Add(i.ToString());
            }
        }

        public void SearchCommandDelegate()
        {
            AppFrame.Navigate(typeof(SearchView), _selectedYear);
        }
    }
}
