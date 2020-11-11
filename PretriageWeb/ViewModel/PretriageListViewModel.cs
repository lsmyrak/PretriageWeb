using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace PretriageWeb.ViewModel
{
    public class PretriageListViewModel
    {
        public IEnumerable<PretriageListItemViewModel> PretriageLists { get; set; }
    }
}
