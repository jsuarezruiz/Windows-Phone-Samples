using Microsoft.Phone.Controls;
using System;
using System.Windows.Navigation;
using Windows.Phone.Speech.VoiceCommands;

namespace Ejemplo_Comandos_Voz
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            IniciarComandos();
        }

        public async void IniciarComandos()
        {
            await VoiceCommandService.InstallCommandSetsFromFileAsync(new Uri("ms-appx:///Comandos.xml", UriKind.RelativeOrAbsolute));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == System.Windows.Navigation.NavigationMode.New)
            {
                if (NavigationContext.QueryString.ContainsKey("voiceCommandName")) 
                {
                    var command = NavigationContext.QueryString["voiceCommandName"];
                    switch (command)
                    {
                        case "Mensaje": 
                            var phrase = NavigationContext.QueryString["number"]; 
                            CommandText.Text = string.Format("Mensaje: {0}", phrase);
                            break;
                        default:
                            CommandText.Text = "Oops, comando no reconocido!";
                            break;
                    }
                }
            }
        }
    }
}