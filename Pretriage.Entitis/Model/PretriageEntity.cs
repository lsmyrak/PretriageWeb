using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pretriage.Entitis.Model
{
    [Table("Pretriage")]
    public class PretriageEntity
    {
        public PretriageEntity(string pesel, string innyDokument, string numerSeria, string kod_Produktu, string nazwa_Produktu, DateTime data_Od, DateTime data_Do, int liczba_Jednostek_Roz, double wartosc_Jednostki, double wartosc, string miejsce, DateTime dataWpisu, bool status, bool export)
        {
            Pesel = pesel;
            InnyDokument = innyDokument;
            NumerSeria = numerSeria;
            Kod_Produktu = kod_Produktu;
            Nazwa_Produktu = nazwa_Produktu;
            Data_Od = data_Od;
            Data_Do = data_Do;
            Liczba_Jednostek_Roz = liczba_Jednostek_Roz;
            Wartosc_Jednostki = wartosc_Jednostki;
            Wartosc = wartosc;
            Miejsce = miejsce;
            DataWpisu = dataWpisu;
            Status = status;
            Export = export;
        }

        public PretriageEntity()
        {
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Pesel { get; private set; }
        public string InnyDokument { get; private set; }
        public string NumerSeria { get; private set; }
        public string Kod_Produktu { get; private set; }
        public string Nazwa_Produktu { get; private set; }
        public DateTime Data_Od { get; private set; }
        public DateTime Data_Do { get; private set; }
        public int Liczba_Jednostek_Roz { get; private set; }
        public double Wartosc_Jednostki { get; private set; }
        public double Wartosc { get; private set; }

        public string Miejsce { get; private set; }
        public DateTime DataWpisu { get; private set; }
        public bool Status { get; private set; }
        public bool Export { get; private set; } = false;


        public void SetPesel(string pesel)
        {
            Pesel = pesel;
        }

        public void SetAnotherDocument(string anotherDocument)
        {
            InnyDokument = anotherDocument;
        }

        public void SetSeriesNumber(string seriesNumber)
        {
            NumerSeria = seriesNumber;
        }

        public void SetProductCode(string productCode)
        {
            Kod_Produktu = productCode;
        }


        public void SetProductName(string productName)
        {
            Nazwa_Produktu = productName;
        }

        public void SetDateFrom(DateTime dateFrom)
        {
            Data_Od = dateFrom;
        }

        public void SetDateTo(DateTime dateTo)
        {
            Data_Do = dateTo;
        }

        public void SetNumberOfUnits(int numberOfUnits)
        {
            Liczba_Jednostek_Roz = numberOfUnits;
        }

        public void SetUnitValue(double unitValue)
        {
            Wartosc_Jednostki = unitValue;
        }

        public void SetValue(double value)
        {
            Wartosc = value;
        }

        public void SetPlace(string place)
        {
            Miejsce = place;
        }

        public void SetEntryDate(DateTime entryDate)
        {
            DataWpisu = entryDate;
        }

        public void SetStatus(bool status)
        {
            Status = status;
        }

        public void SetExport(bool export)
        {
            Export = export;
        }

    }
}