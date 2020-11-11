using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PretriageWeb.ViewModel
{
    public class ExcelListViewModel
    {
        public IEnumerable<PretriageListItemViewModel> PretriageLists { get; set; }
        public DateTime DataOd { get; set; }
        public DateTime DataDo { get; set; }
    }
}
