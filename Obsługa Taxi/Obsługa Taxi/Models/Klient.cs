using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Taxi
{
    public class Klient
    {
        private int _Id_klient;
        private String _Nr_telefonu;
        private Boolean _IsLogged;

        


        Klient(int _Id_klient, string _Nr_telefonu)
        {
            Id_klient = _Id_klient;
            Nr_telefonu = _Nr_telefonu;
            IsLogged = true;
        }

        public int Id_klient { get => _Id_klient; set => _Id_klient = value; }
        public String Nr_telefonu { get => _Nr_telefonu; set => _Nr_telefonu = value; }
        public Boolean IsLogged { get => _IsLogged; set => _IsLogged = value; }


        public void LogOut()
        {
            IsLogged = false;
        }

        public void LogIn()
        {
            IsLogged = true;
        }
    }
}
