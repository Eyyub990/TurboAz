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
    public class CarEntityTypeConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.ModelId).HasColumnType("int").IsRequired();
            builder.Property(m => m.Category).HasColumnType("int").IsRequired();
            builder.Property(m => m.Gear).HasColumnType("int").IsRequired();
            builder.Property(m => m.FuelType).HasColumnType("int").IsRequired();
            builder.Property(m => m.Transmission).HasColumnType("int").IsRequired();
            builder.Property(m => m.March).HasColumnType("decimal").HasPrecision(18, 2).IsRequired();
            builder.Property(m => m.Price).HasColumnType("decimal").HasPrecision(18, 2).IsRequired();
            builder.Property(m => m.Year).HasColumnType("int").IsRequired();
            builder.ConfigureAuditable();

            builder.HasKey(m => m.Id);
            builder.HasQueryFilter(m => m.DeletedAt == null);

            builder.HasOne<Model>()
                .WithMany()
                .HasPrincipalKey(m => m.Id)
                .HasForeignKey(m => m.ModelId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Announcements");
        }
    }
}
