using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;
using Ejemplo_ActionCenter.ViewModels.Base;
using Ejemplo_ActionCenter.Services.Notification;

namespace Ejemplo_ActionCenter.ViewModels
{
    public class ToastViewModel : ViewModelBase
    {
        private ILocalNotificationService _localNotificationService;
        private ICommand _sendNotificationCommand;

        public ToastViewModel(ILocalNotificationService localNotificationService)
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

        public ICommand SendNotificationCommand
        {
            get { return _sendNotificationCommand = _sendNotificationCommand ?? new DelegateCommand(SendNotificationCommandDelegate); }
        }

        public void SendNotificationCommandDelegate()
        {
            if (_localNotificationService.CanSendToasts())
                _localNotificationService.ShowToast("Toast Simple", "EL popup de la notificación aparecerá", string.Empty, string.Empty, false);
        }
    }
}
