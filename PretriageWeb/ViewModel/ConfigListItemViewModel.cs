using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PretriageWeb.ViewModel
{
    public class ConfigListItemViewModel
    {
        public int Id { get; set; }
        public string Opis { get; set; }
        public string Kod_Produktu { get; set; }
        public string Nazwa_Produktu { get; set; }
        public int Liczba_Jednostek_Roz { get; set; }
        public double Wartosc_Jednostki { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
