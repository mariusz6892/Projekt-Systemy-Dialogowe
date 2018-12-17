using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Taxi
{
    class Taxi
    {

        private int _Id_taxi;
        private int _Nr_taxi;
        private String _Aktualny_adres;
        private Boolean _IsBusy;




        Taxi(int _Id_taxi, int _Nr_taxi, String _Aktualny_adres)
        {
            Id_taxi = _Id_taxi;
            Aktualny_adres = _Aktualny_adres;
            IsBusy = false;
        }

        public int Id_taxi { get => _Id_taxi; set => _Id_taxi = value; }
        public String Aktualny_adres { get => _Aktualny_adres; set => _Aktualny_adres = value; }
        public Boolean IsBusy { get => _IsBusy; set => _IsBusy = value; }
        public int Nr_taxi { get => _Nr_taxi; set => _Nr_taxi = value; }

        public void Drive(String _Adres_do)
        {
            IsBusy = true;
            Aktualny_adres = _Adres_do;
        }

        public void EndTrip()
        {
            IsBusy = false;
        }
    }
}
