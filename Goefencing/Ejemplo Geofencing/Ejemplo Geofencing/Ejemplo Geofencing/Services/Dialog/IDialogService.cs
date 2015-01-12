using System.Threading.Tasks;

namespace Ejemplo_Geofencing.Services.Dialog
{
    public interface IDialogService
    {
        Task Show(string message);
    }
}
