using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Obsługa_Taxi.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Obsługa_Taxi.ViewModels
{
    public class AdresViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        SqlConnection con;
        SqlCommand cmd;
        private string nrtelefonu;

        private RelayCommand _TaxiCommand;
        public RelayCommand TaxiCommand
        {
            get
            {
                return _TaxiCommand
                    ?? (_TaxiCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("TaxiView");
                    }));
            }
        }

        private RelayCommand _GoBackCommand;
        public RelayCommand GoBackCommand
        {
            get
            {
                return _GoBackCommand
                    ?? (_GoBackCommand = new RelayCommand(
                    () =>
                    {
                        Wyloguj();
                        _navigationService.NavigateTo("LoginView");
                    }));
            }
        }

        private void Wyloguj()
        {
            try
            {
                con = new SqlConnection(Settings.Default.BazaDanychConnectionString);
                con.Open();
                this.nrtelefonu = (string)_navigationService.Parameter;
                cmd = new SqlCommand("UPDATE Klienci SET CzyZalogowany=@CzyZalogowany WHERE Telefon =" + nrtelefonu, con);
                cmd.Parameters.AddWithValue("@CzyZalogowany", false);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public AdresViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
