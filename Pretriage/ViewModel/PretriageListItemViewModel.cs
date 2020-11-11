using System;
using System.ComponentModel.DataAnnotations;

namespace Pretriage.ViewModel
{
    public class PretriageListItemViewModel
    {
        public int Id { get; set; }
        public string Pesel { get; set; }
        public string InnyDokument { get; set; }
        public string NumerSeria { get; set; }
        public string Kod_Produktu { get; set; }
        public string Nazwa_Produktu { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data_Od { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data_Do { get; set; }
        public int Liczba_Jednostek_Roz { get; set; }
        public double Wartosc_Jednostki { get; set; }
        public double Wartosc { get; set; }
        public string Miejsce { get; set; }
        public bool Status { get; set; }
        public bool Export { get; set; }

    }
}
