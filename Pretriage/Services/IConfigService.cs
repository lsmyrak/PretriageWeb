using Pretriage.ViewModel;
using System.Threading.Tasks;

namespace Pretriage.Services
{
    public interface IConfigService
    {
        Task<ConfigListViewModel> GetConfigListViewModel();
        Task ChangeStatusConfig(int id);
        void DeleteConfig(int id);
        Task AddNewConfig(NewConfigViewModel newConfigViewModel);
        Task UpdateConfig(EditConfigViewModel updateConfigViewModel);
        Task<EditConfigViewModel> GetEditConfigViewModel(int id);
        Task<UnitListItem> GetUnit(int id);
        void DeleteUnit(int id);
        Task AddNewConfigPlace(UnitListItem unitListItem);
        Task UpdatePlace(UnitListItem unitListItem);
    }
}