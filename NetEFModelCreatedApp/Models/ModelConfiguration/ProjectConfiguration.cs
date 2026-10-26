using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFModelCreatedApp.Models.ModelConfiguration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                   .IsRequired();

            //builder.HasMany(p => p.Employees)
            //       .WithMany(e => e.Projects)
            //       .UsingEntity<ProjectEmployee>(
            //        fk => fk.HasOne(pe => pe.Employee)
            //              .WithMany(p => p.ProjectsEmployees)
            //              .HasForeignKey(pe => pe.EmployeeId),
            //        fk => fk.HasOne(pe => pe.Project)
            //                .WithMany(e => e.ProjectsEmployees)
            //                .HasForeignKey(pe => pe.ProjectId),
            //        pe =>
            //        {
            //            pe.Property(pn => pn.DateStart)
            //              .HasDefaultValueSql("GETDATE()");
            //            pe.HasKey(pk => new { pk.ProjectId, pk.EmployeeId });
            //            pe.ToTable("ProjectsEmployees");
            //        });
        }
    }
}
