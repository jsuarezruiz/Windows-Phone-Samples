using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace Ejemplo_ActionCenter.Services.Notification
{
    public class LocalNotificationService : ILocalNotificationService
    {
        /// <summary>
        /// Verifica si podemos enviar notificaciones o no.
        /// Verifica si estan habilitadas las notificaciones toast en la App.
        /// </summary>
        /// <returns></returns>
        public bool CanSendToasts()
        {
            bool canSend = true;
            var notifier = ToastNotificationManager.CreateToastNotifier();

            if (notifier.Setting != NotificationSetting.Enabled)
                canSend = false;

            return canSend;
        }

        /// <summary>
        /// Utiliza la plantilla ToastText02. Plantilla sencilla, se puede ver el catálogo en: http://msdn.microsoft.com/en-us/library/windows/apps/hh761494.aspx
        /// </summary>
        /// <param name="toastHeading"></param>
        /// <param name="toastBody"></param>
        /// <param name="tag"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public ToastNotification CreateToast(string toastHeading, string toastBody, string tag, string group)
        {
            // Usamos la plantilla ToastText02.
            ToastTemplateType toastTemplate = ToastTemplateType.ToastText02;

            // Obtenemos el xml que configura el toast para poder acceder a sus propiedades.
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            //Buscamos el text dentro del contenido.
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");

            // Establecemos el texto.
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(toastHeading));
            toastTextElements[1].AppendChild(toastXml.CreateTextNode(toastBody));

            // Duración.
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "long");

            // Creamos la notificación.
            ToastNotification toast = new ToastNotification(toastXml);

            // Si nos llega tag se lo asignamos.
            if (!string.IsNullOrEmpty(tag))
                toast.Tag = tag;

            // Si nos llega grupo se lo asignamos.
            if (!string.IsNullOrEmpty(group))
                toast.Group = group;

            return toast;
        }

        /// <summary>
        /// Además de crear la notificación, la lanza y muestra.
        /// </summary>
        /// <param name="toastHeading"></param>
        /// <param name="toastBody"></param>
        /// <param name="suppressPopup"></param>        
        /// <param name="tag"></param>
        /// <param name="group"></param>
        public void ShowToast(string toastHeading, string toastBody, string tag, string group, bool suppressPopup)
        {
            ToastNotification toast = CreateToast(toastHeading, toastBody, tag, group);

            // SuppressPopup = true no aparece el popup, se envia directamente el action center.
            toast.SuppressPopup = suppressPopup;

            // Envia la notificación toast.
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        /// <summary>
        /// Elimina notificaciones toast por tag o por grupo.
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="group"></param>
        public void RemoveToast(string tag, string group)
        {
            if (!string.IsNullOrEmpty(group) && string.IsNullOrEmpty(tag))
                ToastNotificationManager.History.RemoveGroup(group);
            else if (string.IsNullOrEmpty(group) && !string.IsNullOrEmpty(tag))
                ToastNotificationManager.History.Remove(tag);
            else
                ToastNotificationManager.History.Remove(tag, group);
        }

        /// <summary>
        /// Elimina todas las notificaciones toast.
        /// </summary>
        public void RemoveAllToasts()
        {
            ToastNotificationManager.History.Clear();
        }
    }
}
