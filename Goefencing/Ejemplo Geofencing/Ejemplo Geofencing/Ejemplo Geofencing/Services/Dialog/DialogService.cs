using System;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Ejemplo_Geofencing.Services.Dialog
{
    public class DialogService : IDialogService
    {
        public async Task Show(string message)
        {
            await new MessageDialog(message).ShowAsync();
        }
    }
}
