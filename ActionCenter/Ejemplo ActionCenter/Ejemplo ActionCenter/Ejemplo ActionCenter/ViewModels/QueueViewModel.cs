using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;
using Ejemplo_ActionCenter.ViewModels.Base;
using Ejemplo_ActionCenter.Services.Notification;

namespace Ejemplo_ActionCenter.ViewModels
{
    public class QueueViewModel : ViewModelBase
    {
        private const int toastsToSend = 25;

        private ILocalNotificationService _localNotificationService;
        private ICommand _sendNotificationsCommand;

        public QueueViewModel(ILocalNotificationService localNotificationService)
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

        public ICommand SendNotificationsCommand
        {
            get { return _sendNotificationsCommand = _sendNotificationsCommand ?? new DelegateCommand(SendNotificationsCommandDelegate); }
        }

        public void SendNotificationsCommandDelegate()
        {
            if (_localNotificationService.CanSendToasts())
            {
                // Enviamos múltiples notificaciones
                for (int i = 0; i < toastsToSend; i++)
                {
                    _localNotificationService.ShowToast(string.Format("Toast {0}", i + 1), "Contenido", string.Empty, string.Empty, true);
                }
            }
        }
    }
}
