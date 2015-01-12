using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;
using Ejemplo_ActionCenter.ViewModels.Base;
using Ejemplo_ActionCenter.Services.Notification;

namespace Ejemplo_ActionCenter.ViewModels
{
    public class GhostViewModel : ViewModelBase
    {
        private ILocalNotificationService _localNotificationService;
        private ICommand _sendGhostNotificationCommand;

        public GhostViewModel(ILocalNotificationService localNotificationService)
        {
            _localNotificationService = localNotificationService;
        }

        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs args)
        {
            return null;
        }
        public ICommand SendGhostNotificationCommand
        {
            get { return _sendGhostNotificationCommand = _sendGhostNotificationCommand ?? new DelegateCommand(SendGhostNotificationCommandDelegate); }
        }

        public void SendGhostNotificationCommandDelegate()
        {
            if (_localNotificationService.CanSendToasts())
                _localNotificationService.ShowToast("Toast Simple", "EL popup de la notificación NO aparecerá", string.Empty, string.Empty, true);
        }
    }
}
