using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Obsługa_Taxi.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Obsługa_Taxi.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        SqlConnection con;
        SqlCommand cmd;

        private string _nrtelefonu;
        public string nrtelefonu
        {
            get { return _nrtelefonu; }
            set { Set(ref _nrtelefonu, value); }
        }

        private RelayCommand _AdresCommand;
        public RelayCommand AdresCommand
        {
            get
            {
                return _AdresCommand
                    ?? (_AdresCommand = new RelayCommand(
                    () =>
                    {
                            if (CzyZarejestrowany())
                            {
                                if (CzyZalogowany())
                                {
                                MessageBox.Show("Użytkownik jest już zalogowany!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                                else
                                {
                                    Zaloguj();
                                    _navigationService.NavigateTo("AdresView",nrtelefonu);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Użytkownik nie zarejestrowany!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                       
                     }));
            }
        }


        private RelayCommand _RegisterCommand;
        public RelayCommand RegisterCommand
        {
            get
            {
                return _RegisterCommand
                    ?? (_RegisterCommand = new RelayCommand(
                        () =>
                    {

                        if (CzyZarejestrowany())
                        {
                            MessageBox.Show("Użytkownik jest już zarejestrowany!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            Zarejestruj();
                            _navigationService.NavigateTo("AdresView",nrtelefonu);
                        }
                        
                        
                    }));
            }
        }

       

        public LoginViewModel(IFrameNavigationService navigationService)
        {
            try
            {
                _navigationService = navigationService;
            }
            catch(Exception)
            {

            }
            
        }



        private void Zaloguj()
        {
            try
            {
                con = new SqlConnection(Settings.Default.BazaDanychConnectionString);
                con.Open();
                cmd = new SqlCommand("UPDATE Klienci SET CzyZalogowany=@CzyZalogowany WHERE Telefon =" + nrtelefonu, con);
                cmd.Parameters.AddWithValue("@CzyZalogowany", true);
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

        public bool CzyZalogowany()
        {
            try
            {
                con = new SqlConnection(Settings.Default.BazaDanychConnectionString);
                con.Open();
                cmd = new SqlCommand("Select CzyZalogowany from Klienci where Telefon =" + nrtelefonu, con);
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return (bool)dr["CzyZalogowany"];
                }
                else return false;
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public void Zarejestruj()
        {
            try
            {
                con = new SqlConnection(Settings.Default.BazaDanychConnectionString);
                con.Open();
                cmd = new SqlCommand("INSERT INTO Klienci " + "(Telefon, CzyZalogowany) " +
                "VALUES(" + "'" + nrtelefonu + "', @CzyZalogowany)", con);
                cmd.Parameters.AddWithValue("@CzyZalogowany", true);
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

        public bool CzyZarejestrowany()
        {
            try
            {
                con = new SqlConnection(Settings.Default.BazaDanychConnectionString);
                con.Open();
                cmd = new SqlCommand("Select * from Klienci where Telefon =" + "'" +  nrtelefonu + "'", con);
                var dr = cmd.ExecuteReader();
                return dr.Read() ? true : false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            finally
            {
                con.Close();
            }
            
            
        }
    }
}
