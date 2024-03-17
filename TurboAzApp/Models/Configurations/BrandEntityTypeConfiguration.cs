using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboAzApp.Models.Configurations;
using TurboAzApp.Models.Entity;

namespace TurboAzApp.Models.Configuration
{
    public class BrandEntityTypeConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1,1);
            builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.ConfigureAuditable();

            builder.HasQueryFilter(x => x.DeletedAt == null);
            builder.HasKey(m => m.Id);
            builder.ToTable("Brands");
        }
    }
}
