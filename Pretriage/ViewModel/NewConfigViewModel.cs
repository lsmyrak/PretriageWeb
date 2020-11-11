using System.ComponentModel.DataAnnotations;

namespace Pretriage.ViewModel
{
    public class NewConfigViewModel
    {
        public string Opis { get; set; }
        [Required(ErrorMessage = "Mazwa Produktu Jest Wymagana")]
        public string Kod_Produktu { get; set; }
        [Required(ErrorMessage = "kod Produktu jest wymagany")]
        public string Nazwa_Produktu { get; set; }
        [Required(ErrorMessage = "Liczba Jewdnostek  jest wymagana")]
        public int Liczba_Jednostek_Roz { get; set; }
        [Required(ErrorMessage = "Wartość Jednostki jest wymagana")]
        public double Wartosc_Jednostki { get; set; }
    }

}
