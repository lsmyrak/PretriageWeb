using System;
using System.Threading.Tasks;

namespace Pretriage.Services
{
    public interface IExcelService
    {
        Task GenerateExcelData(DateTime? DateFrom, DateTime? DateTo);
    }
}