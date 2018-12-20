using System;
using System.Collections.Generic;
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
    public partial class LoginView : Page
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
    }
}
