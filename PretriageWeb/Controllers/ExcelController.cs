using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pretriage.Entitis.Model;
using Pretriage.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PretriageWeb.Controllers
{
   
    public class ExcelController : Controller
    {
        private readonly IPretriageService _pretriageService;
        static DateTime? DataOdForExcel, DataDoforExcel;

        public ExcelController(IPretriageService pretriageListService)
        {
            _pretriageService = pretriageListService;
        }

        public async Task<IActionResult> Index(DateTime? DataOd, DateTime? DataDo)
        {
            if (DataOd != null && DataDo != null)
            {
                DataDoforExcel = DataDo;
                DataOdForExcel = DataOd;
                return View(await _pretriageService.GetFilter(DataOd.Value, DataDo.Value));
            }

            return View(await _pretriageService.GetAll());
        }


        //public async Task<IActionResult> SaveFile()
        //{
        //    IReadOnlyCollection<PretriageEntity> vm;
        //    if (DataOdForExcel != null && DataDoforExcel != null)
        //    {
        //        vm = await _pretriageService.GetFilter(DataOdForExcel.Value, DataDoforExcel.Value);
        //    }
        //    else
        //    {
        //        vm = await _pretriageService.GetAll();
        //    }

        //    string mount = "Abc";

        //    string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //    string fileName = "Wynik.xlsx";
        //    int CurrentRow = 2;
        //    try
        //    {
        //        var work = new XLWorkbook();
        //        var worksheet = work.Worksheets.Add(mount);
        //        worksheet.Cell(1, 1).Value = "Id";
        //        worksheet.Cell(1, 2).Value = "Pesel";
        //        worksheet.Cell(1, 3).Value = "Inny Dokument";
        //        worksheet.Cell(1, 4).Value = "Numer Seria";
        //        worksheet.Cell(1, 5).Value = "Kod Produktu";
        //        worksheet.Cell(1, 6).Value = "Nazwa Produktu";
        //        worksheet.Cell(1, 7).Value = "Data Od";
        //        worksheet.Cell(1, 8).Value = "Data Do";
        //        worksheet.Cell(1, 9).Value = "Liczba Jednostek Rozliczeniowych";
        //        worksheet.Cell(1, 10).Value = "Wartosc Jednostki";
        //        worksheet.Cell(1, 11).Value = "Wartość";
        //        worksheet.Cell(1, 12).Value = "Miejsce";


        //        foreach (var item in vm)
        //        {
        //            CurrentRow++;
        //            worksheet.Cell(CurrentRow, 1).Value = item.Id;

        //            worksheet.Cell(CurrentRow, 2).Value = "'" + item.Pesel;

        //            worksheet.Cell(CurrentRow, 3).Value = item.InnyDokument;
        //            worksheet.Cell(CurrentRow, 4).Value = item.NumerSeria;
        //            worksheet.Cell(CurrentRow, 5).Value = item.Kod_Produktu;
        //            worksheet.Cell(CurrentRow, 6).Value = item.Nazwa_Produktu;
        //            worksheet.Cell(CurrentRow, 7).Value = item.Data_Od;
        //            worksheet.Cell(CurrentRow, 8).Value = item.Data_Do;
        //            worksheet.Cell(CurrentRow, 9).Value = item.Liczba_Jednostek_Roz;
        //            worksheet.Cell(CurrentRow, 10).Value = item.Wartosc_Jednostki;
        //            worksheet.Cell(CurrentRow, 11).Value = item.Wartosc;
        //            worksheet.Cell(CurrentRow, 12).Value = item.Miejsce;
        //        }
        //        using var stream = new MemoryStream();
        //        work.SaveAs(stream);
        //        var content = stream.ToArray();
        //        return File(content, contentType, fileName);
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}


