
using Obsługa_Taxi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for TaxiView.xaml
    /// </summary>
    public partial class TaxiView : Page
    {
        public TaxiViewModel ViewModel;

        public TaxiView()
        {
            InitializeComponent();
            ViewModel = (TaxiViewModel)this.DataContext;
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano kierowcy", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                LogIn.Command = ViewModel.PodsumowanieCommand;
            }
        }
    }
}
