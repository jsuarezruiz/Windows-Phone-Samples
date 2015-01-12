
namespace Ejemplo_ActionCenter.Services.Notification
{
    public interface ILocalNotificationService
    {
        /// <summary>
        /// Verifica si podemos enviar notificaciones o no.
        /// Verifica si estan habilitadas las notificaciones toast en la App.
        /// </summary>
        /// <returns></returns>
        bool CanSendToasts();

        /// <summary>
        /// Además de crear la notificación, la lanza y muestra.
        /// </summary>
        /// <param name="toastHeading"></param>
        /// <param name="toastBody"></param>
        /// <param name="suppressPopup"></param>        
        /// <param name="tag"></param>
        /// <param name="group"></param>
        void ShowToast(string toastHeading, string toastBody, string tag, string group, bool suppressPopup);

        /// <summary>
        /// Elimina notificaciones toast por tag o por grupo.
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="group"></param>
        void RemoveToast(string tag, string group);

        /// <summary>
        /// Elimina todas las notificaciones toast.
        /// </summary>
        void RemoveAllToasts();
    }
}
