using System;
using System.Collections.Generic;

namespace Pretriage.ViewModel
{
    public class ExcelListViewModel
    {
        public IEnumerable<PretriageListItemViewModel> PretriageLists { get; set; }
        public DateTime DataOd { get; set; }
        public DateTime DataDo { get; set; }
    }
}
