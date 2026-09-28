using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using NetEFModelCreatedApp.Models.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFModelCreatedApp.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;

        //public DbSet<Passport> Passports { get; set; }

        public ApplicationContext()
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
            // Fluent API
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CityConfiguration());

            modelBuilder.Entity<Company>()
                        .HasKey(c => c.Id);

            modelBuilder.Entity<Company>()
                        .HasAlternateKey(c => c.Title);
                        
            modelBuilder.Entity<Company>().ToTable("ComaniesList");

            modelBuilder.Entity<Company>()
                        .Property(c => c.Title)
                        .HasMaxLength(50);




            modelBuilder.Entity<Employee>()
                        .Property(e => e.Salary)
                        .HasDefaultValue(100000.0M);

            modelBuilder.Entity<Employee>()
                        .ToTable(t => t.HasCheckConstraint(
                            "SalaryCheck",
                            "Salary > 0 AND Salary < 1000000"));

            modelBuilder.Entity<Employee>()
                        .Property(e => e.Name)
                        .HasMaxLength(50);


            modelBuilder.Entity<Employee>()
                        .Property(e => e.BirthDate)
                        .HasDefaultValueSql("GETDATE()");


            //modelBuilder.Entity<Passport>()
            //            .HasKey(p => new { p.Series, p.Number });
        }
    }

    //public class Passport
    //{
    //    public string Series { get; set; }
    //    public string Number { get; set; }
    //}
}
