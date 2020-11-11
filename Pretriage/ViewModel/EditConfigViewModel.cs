using System.ComponentModel.DataAnnotations;

namespace Pretriage.ViewModel
{
    public class EditConfigViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Opis jest wymagany")]
        public string Opis { get; set; }
        [Required(ErrorMessage = "Kod Produktu jest wymagany")]
        public string Kod_Produktu { get; set; }
        [Required(ErrorMessage = "Nazwa produktu jest wymagana")]
        public string Nazwa_Produktu { get; set; }
        [Required(ErrorMessage = "Liczba jednostek jest wymagana")]
        public int Liczba_Jednostek_Roz { get; set; }
        [Required(ErrorMessage = "Wartość jest wymagana")]
        public double Wartosc_Jednostki { get; set; }
    }
}
