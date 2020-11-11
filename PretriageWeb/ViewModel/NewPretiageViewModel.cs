using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PretriageWeb.ViewModel
{
    public class NewPretiageViewModel
    {
       
        [StringLength(11, MinimumLength =11)]
        [RegularExpression(@"^\d{11}$")]
        public string Pesel { get; set; }

        public string? InnyDokument { get; set; }

        public string? NumerSeria { get; set; }

        [Required(ErrorMessage = "Data od jest wymagana")]
        [DataType(DataType.Date)]
        public DateTime DataOd { get; set; }
        
        [Required(ErrorMessage = "Data do jest wymagana")]
        [DataType(DataType.Date)]
        public DateTime DataDo { get; set; }
    
        public string Miejsce { get; set; }

        public IEnumerable<UnitListItem> UnitsList { get; set; }
    }
}
