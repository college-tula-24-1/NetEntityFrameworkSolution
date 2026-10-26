using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFHierarchyApp.Models
{
    public class UnitDbContext : DbContext
    {
        public DbSet<Unit> Units { get; set; } = null!;
        public DbSet<InfantryUnit> Infantries { get; set; } = null!;
        public DbSet<ArcherUnit> Archers { get; set; } = null!;
        public DbSet<CavalryUnit> Cavalries { get; set; } = null!;

        public UnitDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                                                   .SetBasePath(Directory.GetCurrentDirectory())
                                                   .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Table Per Hierarchy
            //modelBuilder.Entity<Unit>().UseTphMappingStrategy();

            // Table Per Type
            //modelBuilder.Entity<Unit>().UseTptMappingStrategy();

            // Table Per Class
            modelBuilder.Entity<Unit>().UseTpcMappingStrategy();
        }
    }
}
