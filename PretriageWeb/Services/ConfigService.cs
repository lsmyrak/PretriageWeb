using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using PretriageWeb.Migrations;
using PretriageWeb.Models;
using PretriageWeb.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PretriageWeb.Services
{
    public class ConfigService
    {
        private PretriageDB _context;
        public ConfigService(PretriageDB context)
        {
            _context = context;
        }

        public void Add(string Opis, string Kod_Produktu, string Nazwa_Produktu, int Liczba_Jednostek_Roz,
            double Wartosc_Jednostki)
        {
            ConfigModel model = new ConfigModel
            {
                Kod_Produktu = Kod_Produktu,
                Liczba_Jednostek_Roz = Liczba_Jednostek_Roz,
                Nazwa_Produktu = Nazwa_Produktu,
                Opis = Opis,
                Wartosc_Jednostki = Wartosc_Jednostki,
                IsDeleted = false
            };
            _context.ConfigModels.Add(model);
            _context.SaveChanges();
        }

        public IEnumerable<ConfigListItemViewModel> GetAll()
        {
            var RetVal = _context.ConfigModels.Select(x => new ConfigListItemViewModel
            {
                Id = x.Id,
                Kod_Produktu = x.Kod_Produktu,
                Liczba_Jednostek_Roz = x.Liczba_Jednostek_Roz,
                Nazwa_Produktu = x.Nazwa_Produktu,
                Opis = x.Opis,
                Wartosc_Jednostki = x.Wartosc_Jednostki,
                Status = x.Status,
                IsDeleted = false
            }).Where(x => x.IsDeleted == false);
            return RetVal;

        }

        public EditConfigViewModel Get(int Id)
        {
            var retVal = _context.ConfigModels.Select(x=> new EditConfigViewModel 
            {
                Id = x.Id,
                Kod_Produktu= x.Kod_Produktu,
                Liczba_Jednostek_Roz = x.Liczba_Jednostek_Roz,
                Nazwa_Produktu = x.Nazwa_Produktu,
                Opis = x.Opis,
                Wartosc_Jednostki = x.Wartosc_Jednostki
            })
                .FirstOrDefault(x => x.Id == Id);
            return retVal;
        }

        public void Edit(int Id, string Kod_Produktu, int Liczba_jednostek, string Nazwa_Produktu, string Opis, double Wartosc_Jednostki)
        {
            var model = _context.ConfigModels.FirstOrDefault(x => x.Id == Id);            
            if (model != null)
            {
                var configmodel = new ConfigModel
                {
                    Kod_Produktu = Kod_Produktu,
                    Liczba_Jednostek_Roz = Liczba_jednostek,
                    Nazwa_Produktu = Nazwa_Produktu,
                    Opis = Opis,
                    Wartosc_Jednostki = Wartosc_Jednostki,
                    Status = true,
                };
                model.Status = false;
                _context.ConfigModels.Add(configmodel);
                _context.SaveChanges();
            }
        }
        public void ChangeStatus(int Id)
        {
            var listAll = _context.ConfigModels;
            foreach (var item in listAll)
            {
                item.Status = false;
            }
            var itemChange = listAll.FirstOrDefault(x => x.Id == Id);
            itemChange.Status = true;
            _context.SaveChanges();
        }
        public void Delete(int Id)
        {
            var model = _context.ConfigModels.FirstOrDefault(x => x.Id == Id);
            model.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
