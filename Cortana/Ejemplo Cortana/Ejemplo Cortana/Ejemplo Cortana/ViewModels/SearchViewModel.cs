using System.Linq;
using Ejemplo_Cortana.Models;
using Ejemplo_Cortana.Services.Standings;
using Ejemplo_Cortana.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using Windows.Media.SpeechRecognition;

namespace Ejemplo_Cortana.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        //Services
        private IStandingService _standingService;

        //Variables
        private ObservableCollection<DriverStanding> _driverStanding;

        //Constructor
        public SearchViewModel(IStandingService standingService)
        {
            _standingService = standingService;

            _driverStanding = new ObservableCollection<DriverStanding>();
        }

        public ObservableCollection<DriverStanding> DriverStanding
        {
            get { return _driverStanding; }
            set { _driverStanding = value; }
        }

        public override System.Threading.Tasks.Task OnNavigatedFrom(Windows.UI.Xaml.Navigation.NavigationEventArgs args)
        {
            return null;
        }

        public override async System.Threading.Tasks.Task OnNavigatedTo(Windows.UI.Xaml.Navigation.NavigationEventArgs args)
        {
            var season = string.Empty;

            if (args.NavigationMode == NavigationMode.New)
            {
                var voiceResult = args.Parameter as SpeechRecognitionResult;

                if (voiceResult != null)
                    season = voiceResult.Text;
                else
                    season = args.Parameter.ToString();
            }

            if (!string.IsNullOrEmpty(season))
                await LoadStandingsData(season);
        }

        /// <summary>
        /// Accede a la API de clasificación de F1 y prepara la información para la interfaz
        /// </summary>
        /// <param name="season"></param>
        /// <returns></returns>
        private async Task LoadStandingsData(string season)
        {
            var driverStandings = await _standingService.GetSeasonDriverStandingsCollectionAsync(season);
            var drivers = driverStandings.StandingsLists.First().DriverStandings;

            foreach (var driver in drivers)
            {
                DriverStanding.Add(driver);
            }
        }
    }
}
