using WPAppStudio.Services.Interfaces;
using System.Windows;
using Microsoft.Phone.Controls;

namespace WPAppStudio.Services
{
    /// <summary>
    /// Implementation of a dialog service.
    /// </summary>
    public class DialogService : IDialogService
    {
        /// <summary>
        /// Shows a message in the dialog.
        /// </summary>
		/// <param name="message">The message to show.</param>
        public void Show(string message)
        {
            CustomMessageBox messageBox = new CustomMessageBox()
            {
                Message = message
            };

            messageBox.Show();
        }

        /// <summary>
        /// Shows a message with a caption in the dialog.
        /// </summary>
        /// <param name="message">The message to show.</param>
        /// <param name="caption">The caption of the dialog.</param>
        public void Show(string message, string caption)
        {
            CustomMessageBox messageBox = new CustomMessageBox()
            {
                Caption = caption,
                Message = message
            };

            messageBox.Show();
        }
    }
}
