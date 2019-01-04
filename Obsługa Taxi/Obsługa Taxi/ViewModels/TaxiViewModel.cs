using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Obsługa_Taxi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obsługa_Taxi.Properties;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace Obsługa_Taxi.ViewModels
{
    public class TaxiViewModel : ViewModelBase
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataSet ds;
        public ObservableCollection<Taxi> Taxis { get; set; }
        private IFrameNavigationService _navigationService;
        private int zamowienieID;


        private Taxi _taksowkarz;
        public Taxi taksowkarz
        {
            get { return _taksowkarz; }
            set { Set(ref _taksowkarz, value); }
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
                        
                    }));
            }
        }

        private RelayCommand _PodsumowanieCommand;
        public RelayCommand PodsumowanieCommand
        {
            get
            {
                return _PodsumowanieCommand
                    ?? (_PodsumowanieCommand = new RelayCommand(
                    () =>
                    {
                        if (TaxiID())
                        {
                            _navigationService.NavigateTo("PodsumowanieView", zamowienieID);
                        }
                       
                        
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
                        _navigationService.NavigateTo("AdresView", KlientID());
                    }));
            }
        }

        public TaxiViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            FillList();
        }
        public int KlientID()
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


        private bool TaxiID()
        {
            if (taksowkarz != null)
            {
                try
                {
                    con = new SqlConnection(Settings.Default.BazaDanychConnectionString);
                    con.Open();
                    cmd = new SqlCommand("UPDATE ZAMOWIENIE SET TaxiID=@TaxiID WHERE ZamowienieID =" + zamowienieID, con);
                    cmd.Parameters.AddWithValue("@TaxiID", taksowkarz.TaxiID);
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
            else
            {
                MessageBox.Show("Wybierz taksówkarza", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        public void FillList()
        {
            try
            {
                con = new SqlConnection(Settings.Default.BazaDanychConnectionString);
                con.Open();
                cmd = new SqlCommand("Select * from TAKSOWKARZE", con);
                adapter = new SqlDataAdapter(cmd);
                ds = new DataSet();
                adapter.Fill(ds, "TAKSOWKARZE");

                if (Taxis == null) Taxis = new ObservableCollection<Taxi>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (!(Convert.ToBoolean(dr[1].ToString())))//czyzajety
                    {
                        Taxis.Add(new Taxi
                        {
                            TaxiID = Convert.ToInt32(dr[0].ToString()),
                            CzyZajety = Convert.ToBoolean(dr[1].ToString()),
                            AktualnyAdres = dr[2].ToString(),
                            Imie = dr[3].ToString(),
                            Nazwisko = dr[4].ToString()
                        });
                    }
                }
            }

            catch (Exception)
            {
            }
            finally
            {
                ds = null;
                adapter.Dispose();
                con.Close();
                con.Dispose();
            }
        }
    }
}
