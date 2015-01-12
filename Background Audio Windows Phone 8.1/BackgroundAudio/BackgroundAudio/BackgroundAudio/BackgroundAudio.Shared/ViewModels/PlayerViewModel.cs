namespace BackgroundAudio.ViewModels
{
    using System.Threading.Tasks;
    using Windows.UI.Xaml.Navigation;
    using Base;
    using Models;
    using System.Windows.Input;
    using Windows.Foundation.Collections;
    using Windows.Media.Playback;

    public class PlayerViewModel : ViewModelBase
    {
        // Variables
        public enum PlayerState
        {
            Play,
            Pause
        };

        private Event _event;
        private PlayerState _state;
        private MediaPlayer _mediaPlayer;

        //Commands
        private ICommand _playerCommand;

        public Event Event
        {
            get { return _event; }
            set
            {
                _event = value;
                RaisePropertyChanged();
            }
        }

        public PlayerState State
        {
            get { return _state; }
            set
            {
                _state = value;
                RaisePropertyChanged();
            }
        }

        public ICommand PlayerCommand
        {
            get { return _playerCommand = _playerCommand ?? new DelegateCommand(PlayerCommandExecute); }
        }

        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs args)
        {
            // Cargamos los datos del evento
            Event = LoadEvent();

            _mediaPlayer = BackgroundMediaPlayer.Current;

            return null;
        }

        private Event LoadEvent()
        {
            return new Event
            {
                Name = "What’s New for Windows and Windows Phone Developers",
                Image = "ms-appx:///Assets/Build.jpg",
                Duration = "27 minutes, 43 seconds",
                Url = "http://video.ch9.ms/ch9/b544/1a759a52-7309-40c6-aa63-0ef77b38b544/C9Live9001.mp3"
            };
        }

        private void PlayerCommandExecute()
        {
            if(State == PlayerState.Play)
                Play();
            else
                Pause();
        }

        private void Play()
        {
            State = PlayerState.Pause;
            BackgroundMediaPlayer.SendMessageToBackground(new ValueSet
                          {
                              {
                                  "Play",
                                  _event.Url
                              },
                              {
                                  "Title",
                                  _event.Name
                              }
                          });
        }

        private void Pause()
        {
            State = PlayerState.Play;
            BackgroundMediaPlayer.SendMessageToBackground(new ValueSet
                          {
                              {
                                  "Pause",
                                  string.Empty
                              }
                          });
        }
    }
}
