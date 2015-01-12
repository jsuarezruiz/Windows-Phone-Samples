using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;
using Ejemplo_ActionCenter.ViewModels.Base;
using Ejemplo_ActionCenter.Services.Notification;

namespace Ejemplo_ActionCenter.ViewModels
{
    public class EditViewModel : ViewModelBase
    {
        private ILocalNotificationService _localNotificationService;

        private ICommand _sendNotificationsCommand;
        private ICommand _removeTagCommand;
        private ICommand _removeGroupCommand;
        private ICommand _removeAllCommand;

        public EditViewModel(ILocalNotificationService localNotificationService)
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

        public ICommand RemoveTagCommand
        {
            get { return _removeTagCommand = _removeTagCommand ?? new DelegateCommand(RemoveTagCommandDelegate); }
        }

        public ICommand RemoveGroupCommand
        {
            get { return _removeGroupCommand = _removeGroupCommand ?? new DelegateCommand(RemoveGroupCommandDelegate); }
        }

        public ICommand RemoveAllCommand
        {
            get { return _removeAllCommand = _removeAllCommand ?? new DelegateCommand(RemoveAllCommandDelegate); }
        }

        public void SendNotificationsCommandDelegate()
        {
            _localNotificationService.ShowToast("Toast Tag", "Contenido", "Tag", string.Empty, false);

            _localNotificationService.ShowToast("Toast Group", "Contenido", string.Empty, "Group", false);

            _localNotificationService.ShowToast("Toast Tag&Group", "Contenido", "Tag", "Group", false);
        }

        public void RemoveTagCommandDelegate()
        {
            _localNotificationService.RemoveToast("Tag", string.Empty);
        }

        public void RemoveGroupCommandDelegate()
        {
            _localNotificationService.RemoveToast(string.Empty, "Group");
        }

        public void RemoveAllCommandDelegate()
        {
            _localNotificationService.RemoveAllToasts();
        }
    }
}
