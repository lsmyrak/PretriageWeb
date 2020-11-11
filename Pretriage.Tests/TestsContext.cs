using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Pretriage.Context;

namespace Pretriage.Tests
{
    public class TestsContext : PretriageContext
    {
        private static int _databaseInstanceNumber;

        private readonly string _databaseName;

        public TestsContext()
        {
            _databaseName = $"Pretiage:{Interlocked.Increment(ref _databaseInstanceNumber)}";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(_databaseName);
            optionsBuilder.ConfigureWarnings(warningsConfigurer => warningsConfigurer.Ignore(InMemoryEventId.TransactionIgnoredWarning));
        }
    }
}