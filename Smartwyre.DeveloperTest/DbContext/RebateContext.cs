using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest
{
    public class RebateContext : DbContext
    {
        public RebateContext() : base()
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Rebate> Rebate { get; set; }
        public DbSet<RebateCalculation> RebateCalculation { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseMySQL(configuration.GetConnectionString("MyConnection"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rebate>()
                        .HasKey(b => b.Identifier);

            modelBuilder.Entity<Rebate>().ToTable("rebate");
            modelBuilder.Entity<Product>().ToTable("product");
            modelBuilder.Entity<RebateCalculation>().ToTable("rebatecalculation");

            base.OnModelCreating(modelBuilder);
        }
    }
}
