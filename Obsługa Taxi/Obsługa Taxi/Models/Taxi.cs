using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obsługa_Taxi.Models
{
    public class Taxi
    {
        public int TaxiID { get; set; }
        public bool CzyZajety { get; set; }
        public string AktualnyAdres { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
    }
}
