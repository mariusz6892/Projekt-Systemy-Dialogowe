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
using Obsługa_Taxi.Helpers;

namespace Obsługa_Taxi.ViewModels
{
    public class PodsumowanieViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        SqlConnection con;
        SqlCommand cmd;
        private int zamowienieID;
        private int klientID;
        private int taxiID;

        private string _nrtelefonu;
        public string nrtelefonu
        {
            get { return _nrtelefonu; }
            set { Set(ref _nrtelefonu, value); }
        }

        private string _imietaxi;
        public string imietaxi
        {
            get { return _imietaxi; }
            set { Set(ref _imietaxi, value); }
        }

        private string _nazwiskotaxi;
        public string nazwiskotaxi
        {
            get { return _nazwiskotaxi; }
            set { Set(ref _nazwiskotaxi, value); }
        }


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
                        zamowienieID = (int)_navigationService.Parameter;
                        FillPodsumowanie();
                    }));
            }
        }


        private RelayCommand _resignCommand;
        public RelayCommand ResignCommand
        {
            get
            {
                return _resignCommand
                    ?? (_resignCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("ResignView",zamowienieID);
                    }));
            }
        }

        private RelayCommand _confirmCommand;
        public RelayCommand ConfirmCommand
        {
            get
            {
                return _confirmCommand
                    ?? (_confirmCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("ThankYouView",zamowienieID);
                    }));
            }
        }

        public PodsumowanieViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;            
        }

        public void NrTelefonu()
        {
            KlientID();
            try
            {
                con = new SqlConnection(Settings.Default.BazaDanychConnectionString);
                con.Open();
                cmd = new SqlCommand("Select Telefon from Klienci where KlientID =" + klientID, con);
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    nrtelefonu = (string)dr["Telefon"];
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public void ImieTaxi()
        {
            TaxiID();
            try
            {
                con = new SqlConnection(Settings.Default.BazaDanychConnectionString);
                con.Open();
                cmd = new SqlCommand("Select Imie from TAKSOWKARZE where TaxiID =" + taxiID, con);
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    imietaxi = (string)dr["Imie"];
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public void NazwiskoTaxi()
        {
            TaxiID();
            try
            {
                con = new SqlConnection(Settings.Default.BazaDanychConnectionString);
                con.Open();
                cmd = new SqlCommand("Select Nazwisko from TAKSOWKARZE where TaxiID =" + taxiID, con);
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    nazwiskotaxi = (string)dr["Nazwisko"];
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public void AdresDo()
        {
            try
            {
                con = new SqlConnection(Settings.Default.BazaDanychConnectionString);
                con.Open();
                cmd = new SqlCommand("Select AdresDo from ZAMOWIENIE where ZamowienieID =" + zamowienieID, con);
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    adresdo = (string)dr["AdresDo"];
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public void KlientID()
        {
            try
            {
                con = new SqlConnection(Settings.Default.BazaDanychConnectionString);
                con.Open();
                cmd = new SqlCommand("Select KlientID from ZAMOWIENIE where ZamowienieID =" + zamowienieID, con);
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    klientID = (int)dr["KlientID"];
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public void TaxiID()
        {
            try
            {
                con = new SqlConnection(Settings.Default.BazaDanychConnectionString);
                con.Open();
                cmd = new SqlCommand("Select TaxiID from ZAMOWIENIE where ZamowienieID =" + zamowienieID, con);
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    taxiID = (int)dr["TaxiID"];
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                con.Close();
            }
        }

        public void FillPodsumowanie()
        {
            NrTelefonu();
            ImieTaxi();
            NazwiskoTaxi();
            AdresDo();
        }
    }
}
