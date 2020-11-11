using Microsoft.EntityFrameworkCore;
using PretriageWeb.Models;
using PretriageWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PretriageWeb.Services
{
    public class PretriageListService
    {
        private PretriageDB _context;

        public PretriageListService(PretriageDB context)
        {
            _context = context;
        }

        public PretriageListViewModel GetAll(DateTime StartDate, DateTime StopDate)
        {
            var RetVal = _context.PretriageModels.Select(x => new PretriageListItemViewModel
            {
                Id = x.Id,
                Data_Do = x.Data_Do,
                Data_Od = x.Data_Od,
                Pesel = x.Pesel,
                Kod_Produktu = x.Kod_Produktu,
                Liczba_Jednostek_Roz = x.Liczba_Jednostek_Roz,
                Nazwa_Produktu = x.Nazwa_Produktu,
                Wartosc = x.Wartosc,
                Wartosc_Jednostki = x.Wartosc_Jednostki,
                InnyDokument = x.InnyDokument,
                NumerSeria = x.NumerSeria,
                Miejsce = x.Miejsce,
                Status = x.Status,

            }).Where(x => x.Data_Od >= StartDate && x.Data_Od <= StopDate && (x.Status == true)).OrderByDescending(x=>x.Id);

            var vm = new PretriageListViewModel
            {
                PretriageLists = RetVal
            };
            return vm;
        }

        public PretriageListViewModel GetFilter(DateTime StartDate, DateTime StopDate, string NumberSerialPesel)
        {
            var RetVal = _context.PretriageModels.Select(x => new PretriageListItemViewModel
            {
                Id = x.Id,
                Data_Do = x.Data_Do,
                Data_Od = x.Data_Od,
                Pesel = x.Pesel,
                Kod_Produktu = x.Kod_Produktu,
                Liczba_Jednostek_Roz = x.Liczba_Jednostek_Roz,
                Nazwa_Produktu = x.Nazwa_Produktu,
                Wartosc = x.Wartosc,
                Wartosc_Jednostki = x.Wartosc_Jednostki,
                InnyDokument = x.InnyDokument,
                NumerSeria = x.NumerSeria,
                Miejsce = x.Miejsce,
                Status = x.Status,

            }).Where(x => x.Data_Od >= StartDate && x.Data_Od <= StopDate &&
            (x.Pesel.Contains(NumberSerialPesel) || x.NumerSeria.Contains(NumberSerialPesel) || x.InnyDokument.Contains(NumberSerialPesel)) && (x.Status == true)).OrderByDescending(x=>x.Id);

            var vm = new PretriageListViewModel
            {
                PretriageLists = RetVal
            };
            return vm;
        }
        public PretriageListViewModel GetFilter(string NumberSerialPesel)
        {
            var RetVal = _context.PretriageModels.Select(x => new PretriageListItemViewModel
            {
                Id = x.Id,
                Data_Do = x.Data_Do,
                Data_Od = x.Data_Od,
                Pesel = x.Pesel,
                Kod_Produktu = x.Kod_Produktu,
                Liczba_Jednostek_Roz = x.Liczba_Jednostek_Roz,
                Nazwa_Produktu = x.Nazwa_Produktu,
                Wartosc = x.Wartosc,
                Wartosc_Jednostki = x.Wartosc_Jednostki,
                InnyDokument = x.InnyDokument,
                NumerSeria = x.NumerSeria,
                Miejsce = x.Miejsce,
                Status = x.Status,

            }).Where(x=>x.Status == true && ( x.Pesel.Contains(NumberSerialPesel) || x.NumerSeria.Contains(NumberSerialPesel) || x.InnyDokument.Contains(NumberSerialPesel))).OrderByDescending(x=>x.Id);

            var vm = new PretriageListViewModel
            {
                PretriageLists = RetVal
            };
            return vm;
        }

        public PretriageListViewModel GetAll()
        {
            var RetVal = _context.PretriageModels.Select(x => new PretriageListItemViewModel
            {
                Id = x.Id,
                Data_Do = x.Data_Do,
                Data_Od = x.Data_Od,
                Pesel = x.Pesel,
                Kod_Produktu = x.Kod_Produktu,
                Liczba_Jednostek_Roz = x.Liczba_Jednostek_Roz,
                Nazwa_Produktu = x.Nazwa_Produktu,
                Wartosc = x.Wartosc,
                Wartosc_Jednostki = x.Wartosc_Jednostki,
                NumerSeria = x.NumerSeria,
                InnyDokument = x.InnyDokument,
                Miejsce = x.Miejsce,
                Status = x.Status,

            }).Where(x=>x.Status == true).OrderByDescending(x=>x.Id);
            var vm = new PretriageListViewModel
            {
                PretriageLists = RetVal
            };
            return vm;
        }

        public void Add(DateTime data_od, DateTime data_do, string pesel, string? InnyDokument, string? NumerSeria,string Miejsce)
        {
            var configModel = _context.ConfigModels.FirstOrDefault(x => x.Status == true);

            var pretriage = new PretriageModel
            {
                Data_Do = data_do,
                Data_Od = data_od,
                Pesel = pesel,
                InnyDokument = InnyDokument,
                NumerSeria = NumerSeria,
                Kod_Produktu = configModel.Kod_Produktu,
                Nazwa_Produktu = configModel.Nazwa_Produktu,
                Wartosc_Jednostki = configModel.Wartosc_Jednostki,
                Liczba_Jednostek_Roz = configModel.Liczba_Jednostek_Roz,
                Wartosc = (configModel.Wartosc_Jednostki * configModel.Liczba_Jednostek_Roz),
                DataWpisu = DateTime.Now,
                Status = true,
                Miejsce = Miejsce,
            };
            _context.Add(pretriage);
            _context.SaveChanges();
        }
        
        //nie skonczone - Edycja dla Admina
        public void Edit(int Id, DateTime Data_Od, DateTime Data_Do, string Pesel, string? InnyDokument, string? NumerSeria,string Miejsce,string Kod_Produktu)
        {
            var tmp = _context.PretriageModels.FirstOrDefault(x => x.Id == Id);
            if (tmp != null)
            {
                tmp.Data_Od = Data_Od;
                tmp.Data_Do = Data_Do;
                tmp.Pesel = Pesel;
                tmp.InnyDokument = InnyDokument;
                tmp.NumerSeria = NumerSeria;
                tmp.Miejsce = Miejsce;
                tmp.Kod_Produktu = Kod_Produktu;
                _context.SaveChanges();
            }
        }

        public void Edit(int Id, DateTime Data_Od, DateTime Data_Do, string Pesel, string? InnyDokument, string? NumerSeria, string Miejsce)
        {
            var tmp = _context.PretriageModels.FirstOrDefault(x => x.Id == Id);
            var configModel = _context.ConfigModels.FirstOrDefault(x => x.Status == true);

            if (tmp != null)
            {                
                tmp.Status = false;
                var newData = new PretriageModel
                {
                    Data_Do = Data_Do,
                    Data_Od = Data_Od,
                    Pesel = Pesel,
                    InnyDokument = InnyDokument,
                    NumerSeria = NumerSeria,
                    Kod_Produktu = configModel.Kod_Produktu,
                    Nazwa_Produktu = configModel.Nazwa_Produktu,
                    Wartosc_Jednostki = configModel.Wartosc_Jednostki,
                    Liczba_Jednostek_Roz = configModel.Liczba_Jednostek_Roz,
                    Wartosc = (configModel.Wartosc_Jednostki * configModel.Liczba_Jednostek_Roz),
                    DataWpisu = DateTime.Now,
                    Miejsce = Miejsce,
                    Status = true,
                };
                _context.PretriageModels.Add(newData);
                _context.SaveChanges();
            }
        }

        public EditPretiageViewModel Get(int id)
        {
            var data = _context.PretriageModels.Select(x => new EditPretiageViewModel
            {
                Id = x.Id,
                Pesel = x.Pesel,
                InnyDokument = x.InnyDokument,
                NumerSeria = x.NumerSeria,
                Data_Do = x.Data_Do,
                Data_Od = x.Data_Od,
                Miejsce = x.Miejsce,
                Status = x.Status,
                Kod_Produktu =x.Kod_Produktu,
                Wartosc_Jednostki = x.Wartosc_Jednostki,
                Liczba_Jednostek_Roz = x.Liczba_Jednostek_Roz,
                Nazwa_Produktu = x.Nazwa_Produktu,
                Wartosc = x.Wartosc
            }).FirstOrDefault(x => x.Id == id && (x.Status == true));
            if (data != null)
            {
                return data;
            }
            else
            {
                return null;
            }
        }

        public void DeletePretriage(int id)
        {
            var model = _context.PretriageModels.FirstOrDefault(x=>x.Id==id);

            model.Status = false;

            _context.PretriageModels.Update(model);

            _context.SaveChanges();
        }
    }

}
