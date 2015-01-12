using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;

namespace Ejemplo_CustomMessageBox
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void BasicMessageBox_Click(object sender, RoutedEventArgs e)
        {
            CustomMessageBox messageBox = new CustomMessageBox()
            {
                Caption = "Pregunta?",
                Message = "Mensaje del CustomMessageBox.",
                LeftButtonContent = "Si",
                RightButtonContent = "No",
                IsFullScreen = (bool)FullScreenCheckBox.IsChecked
            };

            messageBox.Dismissed += (s1, e1) =>
            {
                switch (e1.Result)
                {
                    case CustomMessageBoxResult.LeftButton:
                        // Acción.
                        break;
                    case CustomMessageBoxResult.RightButton:
                        // Acción.
                        break;
                    case CustomMessageBoxResult.None:
                        // Acción.
                        break;
                    default:
                        break;
                }
            };

            messageBox.Show();
        }

        private void AdvancedMessageBox_Click(object sender, RoutedEventArgs e)
        {
            HyperlinkButton hyperlinkButton = new HyperlinkButton()
            {
                Content = "Más información.",
                HorizontalAlignment = HorizontalAlignment.Left,
                NavigateUri = new Uri("http://javiersuarezruiz.wordpress.com/", UriKind.Absolute)
            };

            TiltEffect.SetIsTiltEnabled(hyperlinkButton, true);

            ListPicker listPicker = new ListPicker()
            {
                Header = "Recordar en:",
                ItemsSource = new string[] { "5 minutos", "10 minutos", "15 minutos" }
            };

            StackPanel stackPanel = new StackPanel();
            stackPanel.Children.Add(hyperlinkButton);
            stackPanel.Children.Add(listPicker);

            CustomMessageBox messageBox = new CustomMessageBox()
            {
                Title = "Recordatorio",
                Caption = "Programar Windows Phone",
                Message = "Realizar ejemplo del control CustomMessageBox",
                Content = stackPanel,
                LeftButtonContent = "Aceptar",
                RightButtonContent = "Cancelar",
                IsFullScreen = (bool)FullScreenCheckBox.IsChecked
            };

            messageBox.Dismissing += (s1, e1) =>
            {
                if (listPicker.ListPickerMode == ListPickerMode.Expanded)
                {
                    e1.Cancel = true;
                }
            };

            messageBox.Dismissed += (s2, e2) =>
            {
                switch (e2.Result)
                {
                    case CustomMessageBoxResult.LeftButton:
                        // Acción.
                        break;
                    case CustomMessageBoxResult.RightButton:
                    case CustomMessageBoxResult.None:
                        // Acción.
                        break;
                    default:
                        break;
                }
            };

            messageBox.Show();
        }
    }
}