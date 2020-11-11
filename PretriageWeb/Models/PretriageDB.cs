using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace PretriageWeb.Models
{
    public class PretriageDB : DbContext
    {
        public PretriageDB([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        public DbSet<PretriageModel> PretriageModels { get; set; }

        public DbSet<ConfigModel> ConfigModels { get; set; }

        public DbSet<UserModel> User { get; set; }

        public DbSet<UnitModel> Unit { get; set; }

    }
}
