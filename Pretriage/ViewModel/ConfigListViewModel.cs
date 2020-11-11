using System.Collections.Generic;

namespace Pretriage.ViewModel
{
    public class ConfigListViewModel
    {
        public IReadOnlyCollection<ConfigItemViewModel> ConfigLists { get; set; }
        public IReadOnlyCollection<UnitListItem> UnitsList { get; set; }
    }
}
