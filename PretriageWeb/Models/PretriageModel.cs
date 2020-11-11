using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PretriageWeb.Models
{
    [Table("Pretriage")]
    public class PretriageModel
    {
        public int Id { get; set; }
        public string Pesel { get; set; }
        public string? InnyDokument { get; set; }
        public string? NumerSeria { get; set; }
        public string Kod_Produktu { get; set; }
        public string Nazwa_Produktu { get; set; }
        public DateTime Data_Od { get; set; }
        public DateTime Data_Do { get; set; }
        public int Liczba_Jednostek_Roz { get; set; }
        public double Wartosc_Jednostki { get; set; }
        public double Wartosc { get; set; }

        public string Miejsce { get; set; }
        public DateTime DataWpisu { get; set; }
        public bool Status { get; set; }
        public bool Export { get; set; } = false;
    }
}
