using DocumentFormat.OpenXml.Office2010.Word.Drawing;
using PretriageWeb.Models;
using PretriageWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PretriageWeb.Services
{
    public class UnitService
    {
        private PretriageDB _context;


        public UnitService(PretriageDB context)
        {
            _context = context;
        }

        public IEnumerable<UnitListItem> GetAllUnits()
        {
            var RetVal = _context.Unit.Select(x => new UnitListItem
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.Status,
            }).Where(x => x.Status == true);
            return RetVal;
        }

        //public IEnumerable<UnitListItem> GetAllUnitsEdit()
        //{
        //    var RetVal = _context.Unit.Select(x => new UnitListItem
        //    {
        //        Id = x.Id,
        //        Name = x.Name,
        //        Status = x.Status,
        //    }).Where(x => x.Status == true);

        //    return RetVal;
        //}
    }
}
