using Microsoft.Speech.Recognition;
using Obsługa_Taxi.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : SpeechPage
    {
        public LoginView()
        {
            InitializeComponent();

        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            PopupLogin.IsOpen = true;
            PopupRegister.IsOpen = false;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            PopupRegister.IsOpen = true;
            PopupLogin.IsOpen = false;
        }

        private void ZamknijPopupClick(object sender, RoutedEventArgs e)
        {
            PopupLogin.IsOpen = false;
            PopupRegister.IsOpen = false;
            NumberTextBox.Text = "";
            NumberTextBoxReg.Text = "";
        }

        private void TylkoLiczbyHandler(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void TextBoxPastingHandler(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                Regex regex = new Regex("[^0-9]+");
                if (regex.IsMatch(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private void NumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LogowaniePopup.IsEnabled = NumberTextBox.Text.Length == NumberTextBox.MaxLength ? true : false;
        }

        private void NumberTextBoxReg_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegisterPopup.IsEnabled = NumberTextBoxReg.Text.Length == NumberTextBoxReg.MaxLength ? true : false;
        }

        private void LogowaniePopup_Click(object sender, RoutedEventArgs e)
        {
            PopupLogin.IsOpen = false;
            PopupRegister.IsOpen = false;
            NumberTextBox.Text = "";
            NumberTextBoxReg.Text = "";
        }

        private void RegisterPopup_Click(object sender, RoutedEventArgs e)
        {
            PopupLogin.IsOpen = false;
            PopupRegister.IsOpen = false;
            NumberTextBox.Text = "";
            NumberTextBoxReg.Text = "";
        }

        public override void InitializeSpeech(object sender, DoWorkEventArgs e)
        {
            base.InitializeSpeech(sender, e);
            SpeakHello();
        }

        private void SpeakHello()
        {
            Speak("Witam w Fake Taxi!");
        }

        private void SpeakRepeat()
        {
            Speak("Powtórz proszę.");
        }

        private void SpeakHelp()
        {
            Speak("Aby zalogować się powiedz LOGOWANIE, po czym po komendzie powiedz numer telefonu i ponownie powiedz LOGOWANIE");
            Speak("Aby zalogować się powiedz REJESTRACJA, po czym po komendzie powiedz numer telefonu i ponownie powiedz REJESTRACJA");
        }

       /* protected override void SpeechRecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
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
                            Speak("Podaj numer telefonu!");
                            PopupLogin.IsOpen = true;
                            PopupRegister.IsOpen = false;
                            break;
                        case "help":
                            SpeakHelp();
                            break;
                        case "register":
                            Speak("Podaj numer telefonu!");
                            PopupLogin.IsOpen = false;
                            PopupRegister.IsOpen = true;
                            break;
                        case "number":
                            switch (command.Skip(1).First())
                            {
                                case "zero":
                                    NumberTextBox.Text = NumberTextBox.Text + "0";
                                    break;
                                case "jeden":
                                    NumberTextBox.Text = NumberTextBox.Text + "1";
                                    break;
                                case "dwa":
                                    NumberTextBox.Text = NumberTextBox.Text + "2";
                                    break;
                                case "trzy":
                                    NumberTextBox.Text = NumberTextBox.Text + "3";
                                    break;
                                case "cztery":
                                    NumberTextBox.Text = NumberTextBox.Text + "4";
                                    break;
                                case "pięć":
                                    NumberTextBox.Text = NumberTextBox.Text + "5";
                                    break;
                                case "sześć":
                                    NumberTextBox.Text = NumberTextBox.Text + "6";
                                    break;
                                case "siedem":
                                    NumberTextBox.Text = NumberTextBox.Text + "7";
                                    break;
                                case "osiem":
                                    NumberTextBox.Text = NumberTextBox.Text + "8";
                                    break;
                                case "dziewięć":
                                    NumberTextBox.Text = NumberTextBox.Text + "9";
                                    break;
                            }
                            break;
                        case "quit":
                            PopupLogin.IsOpen = false;
                            PopupRegister.IsOpen = false;
                            NumberTextBox.Text = "";
                            NumberTextBoxReg.Text = "";
                            break;
                    }
                });
            }
        }*/
    }
}
