using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PretriageWeb.Models
{
    [Table("Config")]
    public class ConfigModel
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
