using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Obsługa_Taxi.Helpers;
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
        private int klientID;
        private int zamowienieID;

        private string _adresdo;
        public string adresdo
        {
            get { return _adresdo; }
            set { Set(ref _adresdo, value); }
        }

        private RelayCommand _loadedCommand;
        public RelayCommand LoadedCommand
        {
            get
            {
                return _loadedCommand
                    ?? (_loadedCommand = new RelayCommand(
                    () =>
                    {
                        klientID = (int)_navigationService.Parameter;
                        UtworzZamowienie();
                        zamowienieID = ZamowienieID(klientID);
                    }));
            }
        }

        private RelayCommand _TaxiCommand;
        public RelayCommand TaxiCommand
        {
            get
            {
                return _TaxiCommand
                    ?? (_TaxiCommand = new RelayCommand(
                    () =>
                    {
                        if (AdresDoZamowienia()) _navigationService.NavigateTo("TaxiView", zamowienieID);
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
                        Wyloguj(KlientID());
                        UsunZamowienie();
                        _navigationService.NavigateTo("LoginView");
                    }));
            }
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

        private int KlientID()
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

        private int ZamowienieID(int klientID)
        {
            try
            {
                con = new SqlConnection(Settings.Default.BazaDanychConnectionString);
                con.Open();
                cmd = new SqlCommand("Select ZamowienieID from ZAMOWIENIE where KlientID =" + klientID, con);
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return (int)dr["ZamowienieID"];
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

        private void UtworzZamowienie()
        {
            try
            {
                con = new SqlConnection(Settings.Default.BazaDanychConnectionString);
                con.Open();
                cmd = new SqlCommand("INSERT INTO ZAMOWIENIE " + "(KlientID) " +
                "VALUES(" + klientID + ")", con);
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

        private bool AdresDoZamowienia()
        {
            try
            {
                con = new SqlConnection(Settings.Default.BazaDanychConnectionString);
                con.Open();
                cmd = new SqlCommand("UPDATE ZAMOWIENIE SET AdresDo=@AdresDo WHERE ZamowienieID =" + zamowienieID, con);
                cmd.Parameters.AddWithValue("@AdresDo", adresdo);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
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

        public AdresViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
