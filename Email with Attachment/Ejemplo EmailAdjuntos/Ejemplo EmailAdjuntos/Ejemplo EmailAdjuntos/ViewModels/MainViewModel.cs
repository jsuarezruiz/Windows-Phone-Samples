using Ejemplo_EmailAdjuntos.Services.Email;
using Ejemplo_EmailAdjuntos.ViewModels.Base;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Email;
using Windows.Storage;

namespace Ejemplo_EmailAdjuntos.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private IEmailService _emailService;

        private ICommand _sendEmailCommand;

        public MainViewModel(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public override Task OnNavigatedFrom(Windows.UI.Xaml.Navigation.NavigationEventArgs args)
        {
            return null;
        }

        public override Task OnNavigatedTo(Windows.UI.Xaml.Navigation.NavigationEventArgs args)
        {
            return null;
        }

        private static async Task<StorageFile> CreateFile()
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var file = await localFolder.CreateFileAsync("file.txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, "Ejemplo Email Adjuntos");

            return file;
        }

        public ICommand SendEmailCommand
        {
            get { return _sendEmailCommand = _sendEmailCommand ?? new DelegateCommandAsync(SendEmailCommandDelegate); }
        }

        public async Task SendEmailCommandDelegate()
        {
            var attachment = new EmailAttachment("file", await CreateFile());
            await _emailService.Send("test@correo.es", "Ejemplo envio email con adjuntos", attachment);
        }
    }
}
