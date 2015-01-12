using Microsoft.Phone.Controls;
using System.Linq;
using System.Windows;
using Windows.Foundation;
using Windows.Phone.Speech.Synthesis;

namespace Ejemplo_Parar_Voz
{
    public partial class MainPage : PhoneApplicationPage
    {
        private IAsyncAction _task;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void Leer_Click(object sender, RoutedEventArgs e)
        {
            var synth = new SpeechSynthesizer();

            var voices = InstalledVoices.All.Where(v => v.Language == "es-ES").OrderByDescending(v => v.Gender);

            synth.SetVoice(voices.FirstOrDefault(v => v.Gender == VoiceGender.Male));

            _task = synth.SpeakTextAsync("Esto es una prueba. Realmente dura mucho más de lo necesario. Si quieres puedes parar pulsando el botón Parar Voz");
        }

        private void Parar_Click(object sender, RoutedEventArgs e)
        {
            _task.Cancel();
        }
    }
}