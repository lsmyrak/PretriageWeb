using PretriageWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PretriageWeb.ViewModel
{
    public class ConfigListViewModel
    {
        public IEnumerable<ConfigListItemViewModel> ConfigLists { get; set; }
        public IEnumerable<UnitListItem> UnitsList { get; set; }
    }
}
