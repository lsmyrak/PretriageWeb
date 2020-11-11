using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pretriage.Entitis.Model;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Pretriage.Context
{
    public class PretriageContext : DbContext
    {
        public PretriageContext(DbContextOptions<PretriageContext> options) : base(options)
        {
        }
        public PretriageContext()
        {
        }

        public DbSet<PretriageEntity> Pretriage { get; set; }

        public DbSet<Config> Config { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Unit> Unit { get; set; }

        //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        //        optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=PreContext; User ID=sa;Password=Immolation@138");
        //}
    }
}
