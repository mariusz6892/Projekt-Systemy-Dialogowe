
using Microsoft.Speech.Recognition;
using Obsługa_Taxi.Helpers;
using Obsługa_Taxi.ViewModels;
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
    /// Interaction logic for TaxiView.xaml
    /// </summary>
    public partial class TaxiView : SpeechPage
    {
        public TaxiViewModel ViewModel;

        public TaxiView()
        {
            InitializeComponent();
            ViewModel = (TaxiViewModel)this.DataContext;
        }
        public override void InitializeSpeech(object sender, DoWorkEventArgs e)
        {
            base.InitializeSpeech(sender, e);
            SpeakHello();
        }

        private void SpeakHello()
        {
            Speak("Wybierz taksówkarza!");
        }

        private void SpeakRepeat()
        {
            Speak("Powtórz proszę.");
        }

        private void SpeakHelp()
        {
            Speak("Aby złożyć zamówienie wybierz taksówkarza i powiedz ZAMÓW");
            Speak("Aby wrócić do wyboru adresu powiedz WRÓĆ");
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
                            Zamow.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                            Zamow.Command?.Execute(null);
                            break;
                        case "help":
                            SpeakHelp();
                            break;
                        case "quit":
                            Wstecz.Command?.Execute(null);
                            Wstecz.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                            break;
                    }
                });
            }
        }

        private void Zamow_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano kierowcy", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                Speak("Nie wybrano kierowcy");
            }
            else
            {
                Zamow.Command = ViewModel.PodsumowanieCommand;
                StopSpeechRecognition();
            }
        }

        private void Wstecz_Click(object sender, RoutedEventArgs e)
        {
            StopSpeechRecognition();
        }
    }
}
