using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Obsługa_Taxi.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obsługa_Taxi.Helpers;
using System.Windows;

namespace Obsługa_Taxi.ViewModels
{
    public class ResignViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        SqlConnection con;
        SqlCommand cmd;
        private int zamowienieID;


        private RelayCommand _loadedCommand;
        public RelayCommand LoadedCommand
        {
            get
            {
                return _loadedCommand
                    ?? (_loadedCommand = new RelayCommand(
                    () =>
                    {
                        zamowienieID = (int)_navigationService.Parameter;
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
                        Wyloguj(KlientID(zamowienieID));
                        UsunZamowienie();
                        _navigationService.NavigateTo("LoginView");
                    }));
            }
        }

        

        public ResignViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private void Wyloguj(int KlientID)
        {
            try
            {
                con = new SqlConnection(Settings.Default.BazaDanychConnectionString);
                con.Open();
                cmd = new SqlCommand("UPDATE Klienci SET CzyZalogowany=@CzyZalogowany WHERE KlientID =" + KlientID, con);
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

        private int KlientID(int zamowienieID)
        {
            try
            {
                con = new SqlConnection(Settings.Default.BazaDanychConnectionString);
                con.Open();
                cmd = new SqlCommand("Select KlientID from ZAMOWIENIE where ZamowienieID =" + zamowienieID, con);
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return (int)dr["KlientID"];
                }
                else return 0;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            finally
            {
                con.Close();
            }
        }

        private void UsunZamowienie()
        {
            try
            {
                con = new SqlConnection(Settings.Default.BazaDanychConnectionString);
                con.Open();
                cmd = new SqlCommand("DELETE FROM ZAMOWIENIE WHERE ZamowienieID =" + zamowienieID, con);
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

    }
}
