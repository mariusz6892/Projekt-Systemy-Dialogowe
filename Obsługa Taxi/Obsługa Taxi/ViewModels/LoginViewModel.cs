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
        SqlDataAdapter adapter;
        DataSet ds;

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

                        _navigationService.NavigateTo("AdresView");
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
                        cmd = new SqlCommand("INSERT INTO Klienci " + "(Telefon, CzyZalogowany) " + 
                            "VALUES(" + "'" + nrtelefonu + "', @CzyZalogowany)", con);

                       // cmd.Parameters.AddWithValue("@Telefon", nrtelefonu);
                       cmd.Parameters.AddWithValue("@CzyZalogowany", true);

                        try
                        {
                            con.Open();
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
                        _navigationService.NavigateTo("AdresView");
                    }));
            }
        }

       

        public LoginViewModel(IFrameNavigationService navigationService)
        {
            try
            {
                con = new SqlConnection(Settings.Default.BazaDanychConnectionString);
            }
            catch(Exception)
            {

            }
            _navigationService = navigationService;
        }
         

        public void Zaloguj(string nrtelefonu)
        {
            cmd = new SqlCommand("Select * from TAKSOWKARZE", con);
            adapter = new SqlDataAdapter(cmd);
            ds = new DataSet();
            adapter.Fill(ds, "TAKSOWKARZE");
        }

        

        public bool CzyZalogowany(string nrtelefonu)
        {
            /*cmd = new SqlCommand("Select CzyZalogowany from Klient where Telefon =" + nrtelefonu, con);
            adapter = new SqlDataAdapter(cmd);
            ds = new DataSet();
            adapter.Fill(ds, "Klient");*/
            return true;
        }

        public void Zarejestruj()
        {

        }

        public bool CzyZarejestrowany()
        {
            return true;
        }
    }
}
