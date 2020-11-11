using Pretriage.AccessData.Repositories;
using Pretriage.Entitis.Model;
using Pretriage.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretriage.Services
{
    public class PretriageService : IPretriageService
    {
        private readonly IPretriageRepository _pretriageRepository;
        private readonly IConfigRepository _configRepository;
        private readonly IUnitRepository _unitRepository;

        public PretriageService(IPretriageRepository pretriageRepository, IConfigRepository configRepository, IUnitRepository unitRepository)
        {
            _pretriageRepository = pretriageRepository ?? throw new ArgumentNullException(nameof(pretriageRepository));
            _configRepository = configRepository ?? throw new ArgumentNullException(nameof(configRepository));
            _unitRepository = unitRepository ?? throw new ArgumentNullException(nameof(unitRepository));
        }

        public async Task AddNewPretriage(NewPretiageViewModel NewPretiageViewModel)
        {
            var config = await _configRepository.GetAsync();
            await _pretriageRepository.AddAsync(MapNewPretriageViewModelToPretriageEntity(NewPretiageViewModel, config));
        }



        public void DeletePretriage(int Id) =>
              _pretriageRepository.DeletePretriage(Id);

        public async Task<PretriageEntity> GetPretriage(int Id) =>
            await _pretriageRepository.Get(Id);

        public async Task<EditPretiageViewModel> GetPretiageViewModel(int id)
        {
            var config = await _configRepository.GetAsync();
            var pretriageEditity = await _pretriageRepository.Get(id);
            return await MapPretriageEntityToEditPretriageViewModel(pretriageEditity); 

        }

        public async Task<NewPretiageViewModel> GetNewPretiageViewModel()
        {
            var units = await _unitRepository.GetUnits();
            return new NewPretiageViewModel
            {
                DataDo = DateTime.Now,
                DataOd = DateTime.Now,
                UnitsList = units.Select(MapUnitToUnitListItem).ToList()
            };
        }


        public async Task UpdatePretriage(EditPretiageViewModel editPretiageViewModel)
        {
            var config = await _configRepository.GetAsync();
            var editPretiage = MapEditPretriageViewModelToPretriageEntity(editPretiageViewModel, config);
            editPretiage.SetStatus(false);
            await _pretriageRepository.UpdateAsync(editPretiage);

            var newPretriage = new PretriageEntity();      
            newPretriage.SetAnotherDocument(editPretiageViewModel.InnyDokument);
            newPretriage.SetDateFrom(editPretiageViewModel.Data_Od);
            newPretriage.SetDateTo(editPretiageViewModel.Data_Do);
            newPretriage.SetEntryDate(DateTime.Now);
            newPretriage.SetExport(false);
            newPretriage.SetNumberOfUnits(config.NumberOfUnits);
            newPretriage.SetPesel(editPretiageViewModel.Pesel);
            newPretriage.SetPlace(editPretiageViewModel.Miejsce);
            newPretriage.SetProductCode(config.ProductCode);
            newPretriage.SetProductName(config.ProductName);
            newPretriage.SetSeriesNumber(editPretiageViewModel.NumerSeria);
            newPretriage.SetStatus(true);
            newPretriage.SetUnitValue(config.UnitValue);
            newPretriage.SetValue(config.UnitValue * config.NumberOfUnits);

            await _pretriageRepository.AddAsync(newPretriage);           
        }

        public async Task<IReadOnlyCollection<PretriageEntity>> GetAll() =>
            await _pretriageRepository.Gets();

        public async Task<PretriageListViewModel> GetPretriageListViewModel() 
        {
            var petriageEntity = await _pretriageRepository.Gets();
            var pretriageLists = petriageEntity.Select(MapPretriageEntityToPretriageListItemViewModel);

            return new PretriageListViewModel
            {
                PretriageLists = pretriageLists
            };
        }

        public async Task<PretriageListViewModel> GetPretriageListViewModelFilter(DateTime StartDate, DateTime StopDate)
        {
            var petriageEntity = await _pretriageRepository.GetFilter(StartDate, StopDate);
            var pretriageLists = petriageEntity.Select(MapPretriageEntityToPretriageListItemViewModel);

            return new PretriageListViewModel
            {
                PretriageLists = pretriageLists
            };
        }
        
        public async Task<PretriageListViewModel> GetPretriageListViewModelFilter(DateTime StartDate, DateTime StopDate, string NumberSerialPesel)
        {
            var petriageEntity = await _pretriageRepository.GetFilter(StartDate, StopDate, NumberSerialPesel);
            var pretriageLists = petriageEntity.Select(MapPretriageEntityToPretriageListItemViewModel);

            return new PretriageListViewModel
            {
                PretriageLists = pretriageLists
            };
        }
        
        public async Task<PretriageListViewModel> GetPretriageListViewModelFilter(string NumberSerialPesel)
        {
            var petriageEntity = await _pretriageRepository.GetFilter(NumberSerialPesel);
            var pretriageLists = petriageEntity.Select(MapPretriageEntityToPretriageListItemViewModel);

            return new PretriageListViewModel
            {
                PretriageLists = pretriageLists
            };
        }
        
        public async Task<IReadOnlyCollection<PretriageEntity>> GetFilter(DateTime StartDate, DateTime StopDate) =>
            await _pretriageRepository.GetFilter(StartDate, StopDate);

        public async Task<IReadOnlyCollection<PretriageEntity>> GetFilter(DateTime StartDate, DateTime StopDate, string NumberSerialPesel) =>
            await _pretriageRepository.GetFilter(StartDate, StopDate, NumberSerialPesel);

        public async Task<IReadOnlyCollection<PretriageEntity>> GetFilter(string NumberSerialPesel) =>
            await _pretriageRepository.GetFilter(NumberSerialPesel);

        private PretriageEntity MapNewPretriageViewModelToPretriageEntity(NewPretiageViewModel newPretiageViewModel, Config config)
        {
            var pretriage = new PretriageEntity();
            pretriage.SetAnotherDocument(newPretiageViewModel.InnyDokument);
            pretriage.SetDateFrom(newPretiageViewModel.DataOd);
            pretriage.SetDateTo(newPretiageViewModel.DataDo);
            pretriage.SetEntryDate(DateTime.Now);
            pretriage.SetExport(false);
            pretriage.SetNumberOfUnits(config.NumberOfUnits);
            pretriage.SetPesel(newPretiageViewModel.Pesel);
            pretriage.SetPlace(newPretiageViewModel.Miejsce);
            pretriage.SetProductCode(config.ProductCode);
            pretriage.SetProductName(config.ProductName);
            pretriage.SetSeriesNumber(newPretiageViewModel.NumerSeria);
            pretriage.SetStatus(true);
            pretriage.SetUnitValue(config.UnitValue);
            pretriage.SetValue(config.UnitValue * config.NumberOfUnits);
            return pretriage;
        }

        private PretriageEntity MapEditPretriageViewModelToPretriageEntity(EditPretiageViewModel editPretiageViewModel, Config config)
        {
            var pretriage = new PretriageEntity();
            pretriage.Id = editPretiageViewModel.Id;
            pretriage.SetAnotherDocument(editPretiageViewModel.InnyDokument);
            pretriage.SetDateFrom(editPretiageViewModel.Data_Od);
            pretriage.SetDateTo(editPretiageViewModel.Data_Do);
            pretriage.SetEntryDate(DateTime.Now);
            pretriage.SetExport(false);
            pretriage.SetNumberOfUnits(config.NumberOfUnits);
            pretriage.SetPesel(editPretiageViewModel.Pesel);
            pretriage.SetPlace(editPretiageViewModel.Miejsce);
            pretriage.SetProductCode(config.ProductCode);
            pretriage.SetProductName(config.ProductName);
            pretriage.SetSeriesNumber(editPretiageViewModel.NumerSeria);
            pretriage.SetStatus(true);
            pretriage.SetUnitValue(config.UnitValue);
            pretriage.SetValue(config.UnitValue * config.NumberOfUnits);
            return pretriage;
        }

        private async Task<EditPretiageViewModel> MapPretriageEntityToEditPretriageViewModel(PretriageEntity pretriageEntity)
        {
            var units = await  _unitRepository.GetUnits();

            var EditPretriageviewModel = new EditPretiageViewModel();
            EditPretriageviewModel.InnyDokument = pretriageEntity.InnyDokument;
            EditPretriageviewModel.Data_Od = pretriageEntity.Data_Od;
            EditPretriageviewModel.Data_Do = pretriageEntity.Data_Do;
            EditPretriageviewModel.Liczba_Jednostek_Roz = pretriageEntity.Liczba_Jednostek_Roz;
            EditPretriageviewModel.Pesel = pretriageEntity.Pesel;
            EditPretriageviewModel.Miejsce = pretriageEntity.Miejsce;
            EditPretriageviewModel.Kod_Produktu = pretriageEntity.Kod_Produktu;
            EditPretriageviewModel.Nazwa_Produktu = pretriageEntity.Nazwa_Produktu;
            EditPretriageviewModel.NumerSeria = pretriageEntity.NumerSeria;
            EditPretriageviewModel.Status = pretriageEntity.Status;
            EditPretriageviewModel.Wartosc_Jednostki = pretriageEntity.Wartosc_Jednostki;
            EditPretriageviewModel.Wartosc = pretriageEntity.Wartosc;
            EditPretriageviewModel.UnitsList = units.Select(MapUnitToUnitListItem);
            return EditPretriageviewModel;
        }

       
        private PretriageListItemViewModel MapPretriageEntityToPretriageListItemViewModel(PretriageEntity pretriageEntity) =>
            new PretriageListItemViewModel
            {
                Id = pretriageEntity.Id,
                InnyDokument = pretriageEntity.InnyDokument,
                Data_Od = pretriageEntity.Data_Od,
                Data_Do = pretriageEntity.Data_Do,
                Liczba_Jednostek_Roz = pretriageEntity.Liczba_Jednostek_Roz,
                Pesel = pretriageEntity.Pesel,
                Miejsce = pretriageEntity.Miejsce,
                Kod_Produktu = pretriageEntity.Kod_Produktu,
                Nazwa_Produktu = pretriageEntity.Nazwa_Produktu,
                NumerSeria = pretriageEntity.NumerSeria,
                Status = pretriageEntity.Status,
                Wartosc_Jednostki = pretriageEntity.Wartosc_Jednostki,
                Wartosc = pretriageEntity.Wartosc
            };


        private UnitListItem MapUnitToUnitListItem(Unit unit) =>
            new UnitListItem
            {
                Id = unit.Id,
                Name = unit.Name,
                Status = unit.Status
            };
    }
}
