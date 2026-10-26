using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFModelCreatedApp.Models.ModelConfiguration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasOne(e => e.Passport)
                   .WithOne(p => p.Employee)
                   .HasForeignKey<Passport>(p => p.EmployeeId);

            builder.HasOne(e => e.Company)
                   .WithMany(c => c.Employees)
                   .HasForeignKey(e => e.CompanyId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Position)
                   .WithMany(p => p.Employees)
                   .HasForeignKey(e => e.PositionId)
                   .OnDelete(DeleteBehavior.NoAction);

            //builder.HasMany(e => e.Projects)
            //       .WithMany(p => p.Employees)
            //       .UsingEntity(ep => ep.ToTable("ProjectsEmployees"));

            builder.HasMany(e => e.Projects)
                   .WithMany(p => p.Employees)
                   .UsingEntity<ProjectEmployee>(
                    fk => fk.HasOne(pe => pe.Project)
                          .WithMany(p => p.ProjectsEmployees)
                          .HasForeignKey(pe => pe.ProjectId),
                    fk => fk.HasOne(pe => pe.Employee)
                            .WithMany(e => e.ProjectsEmployees)
                            .HasForeignKey(pe => pe.EmployeeId),
                    pe =>
                    {
                        pe.Property(pn => pn.DateStart)
                          .HasDefaultValueSql("GETDATE()");
                        pe.HasKey(pk => new { pk.ProjectId, pk.EmployeeId });
                        pe.ToTable("ProjectsEmployees");
                    });
        }
    }
}
