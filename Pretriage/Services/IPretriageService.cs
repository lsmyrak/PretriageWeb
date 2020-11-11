using Pretriage.Entitis.Model;
using Pretriage.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pretriage.Services
{
    public interface IPretriageService
    {
        Task AddNewPretriage(NewPretiageViewModel newPretiageViewModel);

        Task UpdatePretriage(EditPretiageViewModel editPretiageViewModel);

        void DeletePretriage(int id);

        Task<PretriageEntity> GetPretriage(int id);

        Task<EditPretiageViewModel> GetPretiageViewModel(int id);

        Task<IReadOnlyCollection<PretriageEntity>> GetAll();

        Task<PretriageListViewModel> GetPretriageListViewModel();

        Task<IReadOnlyCollection<PretriageEntity>> GetFilter(DateTime startDate, DateTime StopDate);

        Task<IReadOnlyCollection<PretriageEntity>> GetFilter(DateTime StartDate, DateTime StopDate, string NumberSerialPesel);

        Task<IReadOnlyCollection<PretriageEntity>> GetFilter(string NumberSerialPesel);

        Task<NewPretiageViewModel> GetNewPretiageViewModel();

        Task<PretriageListViewModel> GetPretriageListViewModelFilter(DateTime StartDate, DateTime StopDate);

        Task<PretriageListViewModel> GetPretriageListViewModelFilter(DateTime StartDate, DateTime StopDate, string NumberSerialPesel);

        Task<PretriageListViewModel> GetPretriageListViewModelFilter(string NumberSerialPesel);
    }
}