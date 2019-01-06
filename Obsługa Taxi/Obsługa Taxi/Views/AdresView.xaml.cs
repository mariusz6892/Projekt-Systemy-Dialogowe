using Microsoft.Speech.Recognition;
using Obsługa_Taxi.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Obsługa_Taxi.Views
{
    /// <summary>
    /// Interaction logic for AdresView.xaml
    /// </summary>
    public partial class AdresView : SpeechPage
    {
        public AdresView()
        {
            InitializeComponent();
        }

        public override void InitializeSpeech(object sender, DoWorkEventArgs e)
        {
            base.InitializeSpeech(sender, e);
            SpeakHello();
        }

        private void SpeakHello()
        {
            Speak("Podaj adres podróży!");
        }

        private void SpeakRepeat()
        {
            Speak("Powtórz proszę.");
        }

        private void SpeakHelp()
        {
            Speak("Aby przejść dalej podaj adres i powiedz DALEJ");
            Speak("Aby wylogować się powiedz WYLOGUJ");
        }

        protected override void SpeechRecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            base.SpeechRecognitionEngine_SpeechRecognized(sender, e);
            RecognitionResult result = e.Result;

            if (result.Confidence < 0.6)
            {
                SpeakRepeat();
            }
            else
            {
                string[] command = result.Semantics.Value.ToString().ToLower().Split('.');
                DispatchAsync(() =>
                {
                    switch (command.First())
                    {
                        case "login":
                            if (AdresText.Text.Length > 0)
                            {
                                LogIn.Command?.Execute(null);
                                LogIn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                            }
                            else Speak("Podaj najpierw adres");
                            break;
                        case "help":
                            SpeakHelp();
                            break;
                        case "quit":
                            Register.Command?.Execute(null);
                            Register.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                            break;
                    }
                });
            }
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            StopSpeechRecognition();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            StopSpeechRecognition();
        }
    }
}
