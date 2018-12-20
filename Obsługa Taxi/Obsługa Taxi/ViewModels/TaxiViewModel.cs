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

        private RelayCommand _PodsumowanieCommand;
        public RelayCommand PodsumowanieCommand
        {
            get
            {
                return _PodsumowanieCommand
                    ?? (_PodsumowanieCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("PodsumowanieView");
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
                        _navigationService.GoBack();
                    }));
            }
        }

        public TaxiViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            FillList();
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
                    if (!(Convert.ToBoolean(dr[1].ToString())))
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
