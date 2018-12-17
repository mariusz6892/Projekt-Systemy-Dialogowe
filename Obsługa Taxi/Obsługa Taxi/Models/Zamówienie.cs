using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Taxi
{
    class Zamówienie
    {

        private int _Id_zamowienia;
        private String _Adres_do;
        private String _Adres_skad;
        private int _Id_klient;
        private int _Id_taxi;
        private Boolean IsProcessed;



        Zamówienie(int _Id_zamowienia, String _Adres_skad, String _Adres_do, int _Id_klient)
        {
            Id_zamowienia = _Id_zamowienia;
            Adres_do = _Adres_do;
            Adres_skad = _Adres_skad;
            Id_klient = _Id_klient;
            IsProcessed = true;
        }

        public int Id_zamowienia { get => _Id_zamowienia; set => _Id_zamowienia = value; }
        public String Adres_do { get => _Adres_do; set => _Adres_do = value; }
        public String Adres_skad { get => _Adres_skad; set => _Adres_skad = value; }
        public int Id_klient { get => _Id_klient; set => _Id_klient = value; }
        public int Id_taxi { get => _Id_taxi; set => _Id_taxi = value; }

        public void Zamow(int _Id_taxi)
        {
            if (IsProcessed)
            {
                Id_taxi = _Id_taxi;
            }
        }

    }
}
