using Pretriage.AccessData.Repositories;
using Pretriage.Entitis.Model;
using Pretriage.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretriage.Services
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigRepository _configRepository;
        private readonly IUnitRepository _unitRepository;

        public ConfigService(IConfigRepository configRepository, IUnitRepository unitRepository)
        {
            _configRepository = configRepository ?? throw new ArgumentNullException(nameof(configRepository));
            _unitRepository = unitRepository ?? throw new ArgumentNullException(nameof(unitRepository));
        }
        public async Task<ConfigListViewModel> GetConfigListViewModel()
        {
            var configList = GetConfigListItemViewModels(await _configRepository.Gets());
            var unitList = GetUnitListItems(await _unitRepository.GetUnits()).ToList();

            return GetConfigListViewModel(configList, unitList);
        }

        public async Task ChangeStatusConfig(int id)
        {
            var configList = await _configRepository.Gets();
            var cc = configList.ToList();

            foreach (var config in cc)
            {
                config.SetStatus(false);
                if (config.Id == id)
                {
                    config.SetStatus(true);
                }
            }
            var test = configList.FirstOrDefault(x => x.Id == id);
            await _configRepository.UpdateRangeAsync(test);

         //  var test = configList.Select(c => { c.SetStatus(false); return c; });
         //   await _configRepository.UpdateRangeAsync(configList);
        }

        public void DeleteConfig(int id)
        {
            _configRepository.Delete(id);
        }


        public async Task AddNewConfig(NewConfigViewModel newConfigViewModel) =>
                  await _configRepository.AddAsync(MapNewConfigViewModelToConfig(newConfigViewModel));

        public async Task UpdateConfig(EditConfigViewModel updateConfigViewModel) =>
            await _configRepository.UpdateAsync(MapEditConfigViewModelToConfig(updateConfigViewModel));

        public async Task<EditConfigViewModel> GetEditConfigViewModel(int id)
        {
            var configEntity = await _configRepository.GetAsync(id);

            return new EditConfigViewModel
            {
                Id = configEntity.Id,
                Kod_Produktu = configEntity.ProductCode,
                Liczba_Jednostek_Roz = configEntity.NumberOfUnits,
                Nazwa_Produktu = configEntity.ProductName,
                Opis = configEntity.Description,
                Wartosc_Jednostki = configEntity.UnitValue
            };

        }

        private ConfigItemViewModel MapConfigToConfigListItemViewModel(Config config) =>
            new ConfigItemViewModel
            {
                Id = config.Id,
                Kod_Produktu = config.ProductCode,
                Liczba_Jednostek_Roz = config.NumberOfUnits,
                Nazwa_Produktu = config.ProductName,
                Opis = config.Description,
                Wartosc_Jednostki = config.UnitValue,
                Status = config.Status,
                IsDeleted = false
            };

        private IReadOnlyCollection<ConfigItemViewModel> GetConfigListItemViewModels(IReadOnlyCollection<Config> configList) =>
            configList.Select(MapConfigToConfigListItemViewModel).ToList();


        private UnitListItem MapUnitToUnitListItem(Unit unit) =>
            new UnitListItem
            {
                Id = unit.Id,
                Name = unit.Name,
                Status = unit.Status
            };

        private IReadOnlyCollection<UnitListItem> GetUnitListItems(IReadOnlyCollection<Unit> unitList) =>
                unitList.Select(MapUnitToUnitListItem).ToList();

        private ConfigListViewModel GetConfigListViewModel(IReadOnlyCollection<ConfigItemViewModel> configListItemViewModel, IReadOnlyCollection<UnitListItem> unitListItem) =>
            new ConfigListViewModel
            {
                ConfigLists = configListItemViewModel,
                UnitsList = unitListItem
            };

        private Config MapNewConfigViewModelToConfig(NewConfigViewModel newConfigViewModel) =>
             new Config(newConfigViewModel.Opis,
                 newConfigViewModel.Kod_Produktu,
                 newConfigViewModel.Nazwa_Produktu,
                 newConfigViewModel.Liczba_Jednostek_Roz,
                 newConfigViewModel.Wartosc_Jednostki,
                 true,
                 false);
        private Config MapEditConfigViewModelToConfig(EditConfigViewModel editConfigViewModel) =>
             new Config(editConfigViewModel.Opis,
                 editConfigViewModel.Kod_Produktu,
                 editConfigViewModel.Nazwa_Produktu,
                 editConfigViewModel.Liczba_Jednostek_Roz,
                 editConfigViewModel.Wartosc_Jednostki,
                 true,
                 false);

        private Unit MapUnitListItemToUnit(UnitListItem unitListItem)
        {
            return new Unit
            {
                Id = unitListItem.Id,
                Name = unitListItem.Name,
                Status = unitListItem.Status
            };
        }


        public async Task<UnitListItem> GetUnit(int id)
        {
            var unitEntity = await _unitRepository.GetAsync(id);
            return new UnitListItem
            {
                Id = unitEntity.Id,
                Name = unitEntity.Name,
                Status = unitEntity.Status
            };
        }



        public void DeleteUnit(int id)
        {
            _unitRepository.Delete(id);
        }

        public async Task AddNewConfigPlace(UnitListItem unitListItem) =>
            await _unitRepository.AddAsync(MapUnitListItemToUnit(unitListItem));
        

        public async Task UpdatePlace(UnitListItem unitListItem)
        {
           await _unitRepository.UpdateAsync(MapUnitListItemToUnit(unitListItem));
        }
    }
}
