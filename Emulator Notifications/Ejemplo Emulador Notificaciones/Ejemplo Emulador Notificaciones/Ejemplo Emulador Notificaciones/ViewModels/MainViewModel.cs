using Ejemplo_Emulador_Notificaciones.ViewModels.Base;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Networking.PushNotifications;

namespace Ejemplo_Emulador_Notificaciones.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ICommand _notificationCommand;

        public override Task OnNavigatedFrom(Windows.UI.Xaml.Navigation.NavigationEventArgs args)
        {
            return null;
        }

        public override Task OnNavigatedTo(Windows.UI.Xaml.Navigation.NavigationEventArgs args)
        {
            return null;
        }

        public ICommand NotificationCommand
        {
            get { return _notificationCommand = _notificationCommand ?? new DelegateCommandAsync(NotificationCommandDelegate); }
        }

        public async Task NotificationCommandDelegate()
        {
            var channel = await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();

            channel.PushNotificationReceived += (s, e) => {
                                                              if (e.ToastNotification != null)
                                                                  Debug.WriteLine("{0}:{1}", e.NotificationType, e.ToastNotification.Content.InnerText);
            };
        }
    }
}
