using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PretriageWeb.ViewModel
{
    public class EditConfigViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pesel jest wymagany")]
        public string Opis { get; set; }
        [Required(ErrorMessage = "Pesel jest wymagany")]
        public string Kod_Produktu { get; set; }
        [Required(ErrorMessage = "Pesel jest wymagany")]
        public string Nazwa_Produktu { get; set; }
        [Required(ErrorMessage = "Pesel jest wymagany")]
        public int Liczba_Jednostek_Roz { get; set; }
        [Required(ErrorMessage = "Pesel jest wymagany")]
        public double Wartosc_Jednostki { get; set; }
    }
}
