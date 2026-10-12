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
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasAlternateKey(c => c.Title);

            builder.Property(c => c.Title)
                   .HasMaxLength(50);

            builder.HasOne(c => c.City)
                   .WithMany(c => c.Companies)
                   .HasForeignKey(c => c.CityId);
        }
    }
}
