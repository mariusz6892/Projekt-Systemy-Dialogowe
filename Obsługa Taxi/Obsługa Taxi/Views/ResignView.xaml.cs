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
    /// Interaction logic for ResignView.xaml
    /// </summary>
    public partial class ResignView : SpeechPage
    {
        public ResignView()
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
            Speak("Zrezygnowałeś z zamówienia!");
        }

        private void SpeakRepeat()
        {
            Speak("Powtórz proszę.");
        }

        private void SpeakHelp()
        {
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

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            StopSpeechRecognition();
        }
    }
}
