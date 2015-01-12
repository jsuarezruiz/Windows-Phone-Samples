using Microsoft.Phone.Controls;
using System;
using System.Linq;
using System.Windows;
using Windows.Phone.Speech.Synthesis;   //Text to Speech

namespace Ejemplo_Text_to_Speech
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private async void SpeakClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(inputTextBox.Text))
                MessageBox.Show("Introduce algun texto a leer.");
            else
            {
                try
                {
                    SpeechSynthesizer synth = new SpeechSynthesizer();

                    var voices = InstalledVoices.All.Where(v => v.Language == "es-ES").OrderByDescending(v => v.Gender);

                    VoiceGender gender = VoiceGender.Male;

                    if (rbMale.IsChecked == true)
                        gender = VoiceGender.Male;
                    else
                        gender = VoiceGender.Female;

                    synth.SetVoice(voices.Where(v => v.Gender == gender).FirstOrDefault());

                    await synth.SpeakTextAsync(inputTextBox.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}