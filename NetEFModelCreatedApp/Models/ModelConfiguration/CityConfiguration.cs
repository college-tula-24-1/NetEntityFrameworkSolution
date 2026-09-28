using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NetEFModelCreatedApp.Models.ModelConfiguration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.Id)
                   .HasName("PK_Cities");

            builder.HasAlternateKey(c => c.Title)
                   .HasName("UQ_Title");

            builder.HasIndex(c => c.Title)
                   .HasFilter("[Title] IS NOT NULL")
                   .HasDatabaseName("IX_Title");

            builder.ToTable("Cities");

            builder.Property(c => c.Title)
                   .IsRequired()
                   .HasColumnName("Title");
        }
    }
}
