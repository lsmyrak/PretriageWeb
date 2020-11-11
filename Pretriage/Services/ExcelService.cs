using ClosedXML.Excel;
using Pretriage.Entitis.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Pretriage.Services
{
    public class ExcelService : IExcelService
    {
        IPretriageService _pretriageService;

        private IReadOnlyCollection<PretriageEntity> pretriageEntities;

        public ExcelService(IPretriageService pretriageService)
        {
            _pretriageService = pretriageService;
        }

        public async Task GenerateExcelData(DateTime? DateFrom, DateTime? DateTo)
        {
            if (DateFrom != null && DateTo != null)
            {
                pretriageEntities = await _pretriageService.GetFilter(DateFrom.Value, DateTo.Value);
            }
            else
            {
                pretriageEntities = await _pretriageService.GetAll();
            }
            string fileName = "Wynik.xlsx";
            int CurrentRow = 2;

            var work = new XLWorkbook();
            var worksheet = work.Worksheets.Add("Export");
            worksheet.Cell(1, 1).Value = "Id";
            worksheet.Cell(1, 2).Value = "Pesel";
            worksheet.Cell(1, 3).Value = "Inny Dokument";
            worksheet.Cell(1, 4).Value = "Numer Seria";
            worksheet.Cell(1, 5).Value = "Kod Produktu";
            worksheet.Cell(1, 6).Value = "Nazwa Produktu";
            worksheet.Cell(1, 7).Value = "Data Od";
            worksheet.Cell(1, 8).Value = "Data Do";
            worksheet.Cell(1, 9).Value = "Liczba Jednostek Rozliczeniowych";
            worksheet.Cell(1, 10).Value = "Wartosc Jednostki";
            worksheet.Cell(1, 11).Value = "Wartość";
            worksheet.Cell(1, 12).Value = "Miejsce";


            foreach (var item in pretriageEntities)
            {
                CurrentRow++;
                worksheet.Cell(CurrentRow, 1).Value = item.Id;

                worksheet.Cell(CurrentRow, 2).Value = "'" + item.Pesel;

                worksheet.Cell(CurrentRow, 3).Value = item.InnyDokument;
                worksheet.Cell(CurrentRow, 4).Value = item.NumerSeria;
                worksheet.Cell(CurrentRow, 5).Value = item.Kod_Produktu;
                worksheet.Cell(CurrentRow, 6).Value = item.Nazwa_Produktu;
                worksheet.Cell(CurrentRow, 7).Value = item.Data_Od;
                worksheet.Cell(CurrentRow, 8).Value = item.Data_Do;
                worksheet.Cell(CurrentRow, 9).Value = item.Liczba_Jednostek_Roz;
                worksheet.Cell(CurrentRow, 10).Value = item.Wartosc_Jednostki;
                worksheet.Cell(CurrentRow, 11).Value = item.Wartosc;
                worksheet.Cell(CurrentRow, 12).Value = item.Miejsce;

                using var stream = new MemoryStream();
                work.SaveAs(stream);
                var content = stream.ToArray();
                await File.WriteAllBytesAsync(fileName, content);
            }
        }
    }
}
